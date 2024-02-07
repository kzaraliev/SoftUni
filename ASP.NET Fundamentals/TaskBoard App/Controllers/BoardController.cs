using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoard_App.Data;
using TaskBoard_App.Models;

namespace TaskBoard_App.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private readonly TaskBoardAppDbContext data;

        public BoardController(TaskBoardAppDbContext _data)
        {
            data = _data;
        }

        public async Task<IActionResult> Index()
        {
            var boards = await data.Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks
                        .Select(t => new TaskViewModel()
                        {
                            Id = t.Id,
                            Description = t.Description,
                            Owner = t.Owner.UserName,
                            Title = t.Title
                        })
                })
                .ToListAsync();

            return View(boards);
        }
    }
}
