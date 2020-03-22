using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using University_Core_MVC.Data;
using University_Core_MVC.Models;

namespace University_Core_MVC.Controllers
{
    public class AllocationsController : Controller
    {
        private readonly University_Core_DbContext _context;

        public AllocationsController(University_Core_DbContext context)
        {
            _context = context;
        }

        // GET: Allocations
        public async Task<IActionResult> Index()
        {
            var university_Core_DbContext = _context.Allocation.Include(a => a.Department).Include(a => a.Lecturer).Include(a => a.Module);
            return View(await university_Core_DbContext.ToListAsync());
        }

        // GET: Allocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _context.Allocation
                .Include(a => a.Department)
                .Include(a => a.Lecturer)
                .Include(a => a.Module)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allocation == null)
            {
                return NotFound();
            }

            return View(allocation);
        }
        [Authorize]
        // GET: Allocations/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "Id", "Id");
            ViewData["LecturerId"] = new SelectList(_context.Set<Lecturer>(), "Id", "Id");
            ViewData["ModuleId"] = new SelectList(_context.Set<Module>(), "Id", "Id");
            return View();
        }

        // POST: Allocations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DepartmentId,LecturerId,ModuleId")] Allocation allocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(allocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "Id", "Id", allocation.DepartmentId);
            ViewData["LecturerId"] = new SelectList(_context.Set<Lecturer>(), "Id", "Id", allocation.LecturerId);
            ViewData["ModuleId"] = new SelectList(_context.Set<Module>(), "Id", "Id", allocation.ModuleId);
            return View(allocation);
        }
        [Authorize]
        // GET: Allocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _context.Allocation.FindAsync(id);
            if (allocation == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "Id", "Id", allocation.DepartmentId);
            ViewData["LecturerId"] = new SelectList(_context.Set<Lecturer>(), "Id", "Id", allocation.LecturerId);
            ViewData["ModuleId"] = new SelectList(_context.Set<Module>(), "Id", "Id", allocation.ModuleId);
            return View(allocation);
        }

        // POST: Allocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DepartmentId,LecturerId,ModuleId")] Allocation allocation)
        {
            if (id != allocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(allocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllocationExists(allocation.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Set<Department>(), "Id", "Id", allocation.DepartmentId);
            ViewData["LecturerId"] = new SelectList(_context.Set<Lecturer>(), "Id", "Id", allocation.LecturerId);
            ViewData["ModuleId"] = new SelectList(_context.Set<Module>(), "Id", "Id", allocation.ModuleId);
            return View(allocation);
        }
        [Authorize]
        // GET: Allocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allocation = await _context.Allocation
                .Include(a => a.Department)
                .Include(a => a.Lecturer)
                .Include(a => a.Module)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (allocation == null)
            {
                return NotFound();
            }

            return View(allocation);
        }

        // POST: Allocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allocation = await _context.Allocation.FindAsync(id);
            _context.Allocation.Remove(allocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AllocationExists(int id)
        {
            return _context.Allocation.Any(e => e.Id == id);
        }
    }
}
