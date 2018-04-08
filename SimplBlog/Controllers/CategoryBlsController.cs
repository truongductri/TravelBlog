using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimplBlog.Models;

namespace SimplBlog.Controllers
{
    public class CategoryBlsController : Controller
    {
        private readonly BloggingContext _context;

        public CategoryBlsController(BloggingContext context)
        {
            _context = context;
        }

        // GET: CategoryBls
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoryBls.ToListAsync());
        }
        public async Task<IActionResult> _NaviCate(int n = 5)
        {
            return PartialView(await _context.CategoryBls.Take(n).ToListAsync());
        }

        // GET: CategoryBls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryBl = await _context.CategoryBls
                .SingleOrDefaultAsync(m => m.CateBlId == id);
            if (categoryBl == null)
            {
                return NotFound();
            }

            return View(categoryBl);
        }

        // GET: CategoryBls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryBls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CateBlId,Url,Name")] CategoryBl categoryBl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryBl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryBl);
        }

        // GET: CategoryBls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryBl = await _context.CategoryBls.SingleOrDefaultAsync(m => m.CateBlId == id);
            if (categoryBl == null)
            {
                return NotFound();
            }
            return View(categoryBl);
        }

        // POST: CategoryBls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CateBlId,Url,Name")] CategoryBl categoryBl)
        {
            if (id != categoryBl.CateBlId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryBl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryBlExists(categoryBl.CateBlId))
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
            return View(categoryBl);
        }

        // GET: CategoryBls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryBl = await _context.CategoryBls
                .SingleOrDefaultAsync(m => m.CateBlId == id);
            if (categoryBl == null)
            {
                return NotFound();
            }

            return View(categoryBl);
        }

        // POST: CategoryBls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryBl = await _context.CategoryBls.SingleOrDefaultAsync(m => m.CateBlId == id);
            _context.CategoryBls.Remove(categoryBl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryBlExists(int id)
        {
            return _context.CategoryBls.Any(e => e.CateBlId == id);
        }
    }
}
