using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly LibraryDbContext data;

        public BookController(LibraryDbContext _data)
        {
            data = _data;
        }

        public async Task<IActionResult> All()
        {
            var books = await data.Books
                .AsNoTracking()
                .Select(b => new BookInfoViewModel(
                    b.Id,
                    b.Title,
                    b.Author,
                    b.ImageUrl,
                    b.Rating,
                    b.Category.Name
                    ))
                .ToListAsync();

            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int id)
        {
            var b = await data.Books
                .Where(b => b.Id == id)
                .Include(b => b.UsersBooks)
                .FirstOrDefaultAsync();

            if (b == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!b.UsersBooks.Any(p => p.CollectorId == userId))
            {
                b.UsersBooks.Add(new IdentityUserBook()
                {
                    BookId= b.Id,
                    CollectorId = userId
                });

                await data.SaveChangesAsync();
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var b = await data.Books
                .Where(b => b.Id == id)
                .Include(b => b.UsersBooks)
                .FirstOrDefaultAsync();

            if (b == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var ub = b.UsersBooks.FirstOrDefault(ub => ub.CollectorId == userId);

            if (ub == null)
            {
                return BadRequest();
            }

            b.UsersBooks.Remove(ub);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            string userId = GetUserId();

            var model = await data.IdentityUserBooks
                .Where(ub => ub.CollectorId == userId)
                .AsNoTracking()
                .Select(ub => new BookDetailsViewModel(
                    ub.BookId,
                    ub.Book.Title,
                    ub.Book.Author,
                    ub.Book.ImageUrl,
                    ub.Book.Description,
                    ub.Book.Category.Name
                    ))
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new BookFormViewModel();
            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BookFormViewModel model)
        {
            decimal rating;

            if (!decimal.TryParse(model.Rating, out rating) || rating < 0 || rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating), "Rating must be a number between 0 and 10.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            var entity = new Book()
            {
                Author = model.Author,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.Url,
                Title = model.Title,
                Rating = rating,
            };

            await data.Books.AddAsync(entity);
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
