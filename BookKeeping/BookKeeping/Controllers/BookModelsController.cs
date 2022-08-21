using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookKeeping.Data;
using BookKeeping.Models;

namespace BookKeeping.Controllers
{
    public class BookModelsController : Controller
    {
        private readonly BookKeepingContext _context;

        public BookModelsController(BookKeepingContext context)
        {
            _context = context;
        }

        // GET: BookModels
        public async Task<IActionResult> Index()
        {
              return _context.BookModel != null ? 
                          View(await _context.BookModel.ToListAsync()) :
                          Problem("Entity set 'BookKeepingContext.BookModel'  is null.");
        }

        // GET: BookModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookModel == null)
            {
                return NotFound();
            }

            var bookModel = await _context.BookModel
                .FirstOrDefaultAsync(m => m.isbn == id);
            if (bookModel == null)
            {
                return NotFound();
            }

            return View(bookModel);
        }

        // GET: BookModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("isbn,title,categoryId,Author")] BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookModel);
        }

        // GET: BookModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookModel == null)
            {
                return NotFound();
            }

            var bookModel = await _context.BookModel.FindAsync(id);
            if (bookModel == null)
            {
                return NotFound();
            }
            return View(bookModel);
        }

        // POST: BookModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("isbn,title,categoryId,Author")] BookModel bookModel)
        {
            if (id != bookModel.isbn)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookModelExists(bookModel.isbn))
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
            return View(bookModel);
        }

        // GET: BookModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookModel == null)
            {
                return NotFound();
            }

            var bookModel = await _context.BookModel
                .FirstOrDefaultAsync(m => m.isbn == id);
            if (bookModel == null)
            {
                return NotFound();
            }

            return View(bookModel);
        }

        // POST: BookModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookModel == null)
            {
                return Problem("Entity set 'BookKeepingContext.BookModel'  is null.");
            }
            var bookModel = await _context.BookModel.FindAsync(id);
            if (bookModel != null)
            {
                _context.BookModel.Remove(bookModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookModelExists(int id)
        {
          return (_context.BookModel?.Any(e => e.isbn == id)).GetValueOrDefault();
        }
    }
}
