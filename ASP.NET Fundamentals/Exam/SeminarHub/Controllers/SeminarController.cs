using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models;
using System.Globalization;
using System.Security.Claims;

namespace SeminarHub.Controllers
{

    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext data;

        public SeminarController(SeminarHubDbContext _data)
        {
            data = _data;
        }

        public async Task<IActionResult> All()
        {
            var seminars = await data.Seminars
                .AsNoTracking()
                .Select(s => new SeminarInfoViewModel(
                    s.Id,
                    s.Topic,
                    s.Lecturer,
                    s.Category.Name,
                    s.DateAndTime,
                    s.Organizer.UserName
                    ))
                .ToListAsync();

            return View(seminars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarFormViewModel();
            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormViewModel model)
        {
            DateTime dateAndTime = DateTime.Now;
            int duration;

            if (!DateTime.TryParseExact(model.DateAndTime, DataConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateAndTime))
            {
                ModelState.AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be {DataConstants.DateFormat}");
            }
             
            if (!int.TryParse(model.Duration, out duration) || duration < DataConstants.DuratioMin || duration > DataConstants.DuratioMax)
            {
                ModelState.AddModelError(nameof(model.Duration), "Duration must be a number between 30 and 180.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            var entity = new Seminar()
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                OrganizerId = GetUserId(),
                DateAndTime = dateAndTime,
                CategoryId = model.CategoryId,
                Duration = duration,
            };

            await data.Seminars.AddAsync(entity);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();

            var model = await data.SeminarsParticipants
                .Where(sp => sp.ParticipantId == userId)
                .AsNoTracking()
                .Select(sp => new SeminarInfoViewModel(
                    sp.SeminarId,
                    sp.Seminar.Topic,
                    sp.Seminar.Lecturer,
                    sp.Seminar.Category.Name,
                    sp.Seminar.DateAndTime,
                    sp.Seminar.Organizer.UserName
                    ))
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var s = await data.Seminars
                .Where(e => e.Id == id)
                .Include(e => e.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (s == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!s.SeminarsParticipants.Any(p => p.ParticipantId == userId))
            {
                s.SeminarsParticipants.Add(new SeminarParticipant()
                {
                    SeminarId = s.Id,
                    ParticipantId = userId
                });

                await data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Leave(int id)
        {
            var s = await data.Seminars
                .Where(e => e.Id == id)
                .Include(e => e.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (s == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var sp = s.SeminarsParticipants.FirstOrDefault(ep => ep.ParticipantId == userId);

            if (sp == null)
            {
                return BadRequest();
            }

            s.SeminarsParticipants.Remove(sp);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var s = await data.Seminars
                .Where(e => e.Id == id)
                .Include(e => e.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (s == null)
            {
                return BadRequest();
            }

            if (s.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new SeminarFormViewModel()
            {
                Topic = s.Topic,
                Lecturer = s.Lecturer,
                Details = s.Details,
                DateAndTime = s.DateAndTime.ToString(DataConstants.DateFormat, CultureInfo.InvariantCulture),
                Duration = s.Duration.ToString(),
                CategoryId = s.CategoryId
            };

            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SeminarFormViewModel model, int id)
        {
            var s = await data.Seminars
                .Where(e => e.Id == id)
                .Include(e => e.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (s == null)
            {
                return BadRequest();
            }

            if (s.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime dateAndTime = DateTime.Now;
            int duration;

            if (!DateTime.TryParseExact(model.DateAndTime, DataConstants.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateAndTime))
            {
                ModelState.AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be {DataConstants.DateFormat}");
            }

            if (!int.TryParse(model.Duration, out duration) || duration < DataConstants.DuratioMin || duration > DataConstants.DuratioMax)
            {
                ModelState.AddModelError(nameof(model.Duration), "Duration must be a number between 30 and 180.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            s.Topic = model.Topic;
            s.Lecturer = model.Lecturer;
            s.Details = model.Details;
            s.DateAndTime = dateAndTime;
            s.Duration = duration;
            s.CategoryId = model.CategoryId;

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await data.Seminars
                .Where(s => s.Id == id)
                .AsNoTracking()
                .Select(s => new SeminarDetailsViewModel(
                    s.Id,
                    s.Topic,
                    s.Lecturer,
                    s.Category.Name,                   
                    s.DateAndTime,
                    s.Organizer.UserName,
                    s.Details,
                    s.Duration
                    ))
                .FirstOrDefaultAsync();


            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var s = await data.Seminars
                .Where(e => e.Id == id)
                .Include(e => e.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (s == null)
            {
                return BadRequest();
            }

            if (s.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new SeminarDeleteViewModel()
            {
                Id = id,
                DateAndTime = s.DateAndTime.ToString(DataConstants.DateFormat, CultureInfo.InvariantCulture),
                Topic = s.Topic,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var s = await data.Seminars
                .Where(e => e.Id == id)
                .Include(e => e.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (s == null)
            {
                return BadRequest();
            }

            if (s.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            data.Seminars.Remove(s);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }


        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return await data.Categories
                .AsNoTracking()
                .Select(t => new CategoryViewModel()
                { Id = t.Id, Name = t.Name, }
                ).ToListAsync();
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
