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
    public class ProjectItemsController : Controller
    {
        private readonly MvcToDoApiContext _context;

        public ProjectItemsController(MvcToDoApiContext context)
        {
            _context = context;
        }

        // GET: ProjectItems
        public async Task<IActionResult> Index()
        {
              return _context.ProjectItem != null ? 
                          View(await _context.ProjectItem.ToListAsync()) :
                          Problem("Entity set 'MvcToDoApiContext.ProjectItem'  is null.");
        }

        // GET: ProjectItems/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.ProjectItem == null)
            {
                return NotFound();
            }

            var projectItem = await _context.ProjectItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectItem == null)
            {
                return NotFound();
            }

            return View(projectItem);
        }

        // GET: ProjectItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StartDate,EndDate,StatusOfProject,Priority")] ProjectItem projectItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectItem);
        }

        // GET: ProjectItems/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.ProjectItem == null)
            {
                return NotFound();
            }

            var projectItem = await _context.ProjectItem.FindAsync(id);
            if (projectItem == null)
            {
                return NotFound();
            }
            return View(projectItem);
        }

        // POST: ProjectItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,StartDate,EndDate,StatusOfProject,Priority")] ProjectItem projectItem)
        {
            if (id != projectItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectItemExists(projectItem.Id))
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
            return View(projectItem);
        }

        // GET: ProjectItems/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.ProjectItem == null)
            {
                return NotFound();
            }

            var projectItem = await _context.ProjectItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectItem == null)
            {
                return NotFound();
            }

            return View(projectItem);
        }

        // POST: ProjectItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.ProjectItem == null)
            {
                return Problem("Entity set 'MvcToDoApiContext.ProjectItem'  is null.");
            }
            var projectItem = await _context.ProjectItem.FindAsync(id);
            if (projectItem != null)
            {
                _context.ProjectItem.Remove(projectItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectItemExists(long id)
        {
          return (_context.ProjectItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
