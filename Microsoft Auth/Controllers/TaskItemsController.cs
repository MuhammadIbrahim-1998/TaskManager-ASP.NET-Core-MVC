using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft_Auth.Models;
using Microsoft_Auth.Repositories;

namespace Microsoft_Auth.Controllers
{
    [Authorize]
    public class TaskItemsController : Controller
    {
        private readonly IGenericRepository<TaskItem> _repo;
        private readonly UserManager<ApplicationUser> _userManager;

        public TaskItemsController(
            IGenericRepository<TaskItem> repo,
            UserManager<ApplicationUser> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var query = _repo.AsQueryable();

            if (User.IsInRole("DataEntry"))
            {
                var userId = _userManager.GetUserId(User);
                query = query.Where(t => t.CreatedBy == userId);
            }

            var tasks = await query
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            return View(tasks);
        }

        [Authorize(Roles = "SuperAdmin,DataEntry")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin,DataEntry")]
        public async Task<IActionResult> Create(TaskItem taskItem)
        {
            if (!ModelState.IsValid)
                return View(taskItem);

            taskItem.CreatedBy = _userManager.GetUserId(User);
            taskItem.CreatedAt = DateTime.UtcNow;

            await _repo.AddAsync(taskItem);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Edit(int id, TaskItem formModel) 
        {
            if (!ModelState.IsValid)
                return View(formModel);

            var taskInDb = await _repo.AsQueryable().FirstOrDefaultAsync(t => t.Id == id); 
            if (taskInDb == null)
                return NotFound();

            formModel.Id = id;

            taskInDb.Title = formModel.Title;                 
            taskInDb.Description = formModel.Description;     
            taskInDb.Status = formModel.Status;               

            await _repo.UpdateAsync(taskInDb); 
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null)
                return NotFound();

            await _repo.DeleteAsync(task);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null)
                return NotFound();

            if (User.IsInRole("DataEntry"))
            {
                var userId = _userManager.GetUserId(User);
                if (task.CreatedBy != userId)
                    return Forbid();
            }

            return View(task);
        }
    }
}
