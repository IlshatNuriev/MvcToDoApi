using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcToDoApi.Data;
using MvcToDoApi.Models;

namespace MvcToDoApi.Controllers
{
    public class TaskItemsController : Controller
    {
        private readonly MvcToDoApiContext _context;

        public TaskItemsController(MvcToDoApiContext context)
        {
            _context = context;
        }

        // GET: TaskItems
        public async Task<IActionResult> Index()
        {
            var mvcToDoApiContext = _context.TaskItem.Include(t => t.ProjectItem);
            return View(await mvcToDoApiContext.ToListAsync());
        }

        // GET: TaskItems/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TaskItem == null)
            {
                return NotFound();
            }

            var taskItem = await _context.TaskItem
                .Include(t => t.ProjectItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // GET: TaskItems/Create
        public IActionResult Create()
        {
            ViewData["ProjectItemId"] = new SelectList(_context.ProjectItem, "Id", "Name");
            return View();
        }

        // POST: TaskItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StatusOfTask,Description,Priority,ProjectItemId")] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectItemId"] = new SelectList(_context.ProjectItem, "Id", "Name", taskItem.ProjectItemId);
            return View(taskItem);
        }

        // GET: TaskItems/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TaskItem == null)
            {
                return NotFound();
            }

            var taskItem = await _context.TaskItem.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            ViewData["ProjectItemId"] = new SelectList(_context.ProjectItem, "Id", "Name", taskItem.ProjectItemId);
            return View(taskItem);
        }

        // POST: TaskItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,StatusOfTask,Description,Priority,ProjectItemId")] TaskItem taskItem)
        {
            if (id != taskItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskItemExists(taskItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectItemId"] = new SelectList(_context.ProjectItem, "Id", "Name", taskItem.ProjectItemId);
            return View(taskItem);
        }

        // GET: TaskItems/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TaskItem == null)
            {
                return NotFound();
            }

            var taskItem = await _context.TaskItem
                .Include(t => t.ProjectItem)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // POST: TaskItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.TaskItem == null)
            {
                return Problem("Entity set 'MvcToDoApiContext.TaskItem'  is null.");
            }
            var taskItem = await _context.TaskItem.FindAsync(id);
            if (taskItem != null)
            {
                _context.TaskItem.Remove(taskItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskItemExists(long id)
        {
          return (_context.TaskItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
