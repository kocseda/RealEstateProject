using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmlakProjesi.Models;

namespace EmlakProjesi.Controllers
{
    public class IsyerisController : Controller
    {
        private readonly EmlakDbContext _context;

        public IsyerisController(EmlakDbContext context)
        {
            _context = context;
        }

        // GET: Isyeris
        public async Task<IActionResult> Index()
        {
            return View(await _context.Isyeri.ToListAsync());
        }

        // GET: Isyeris/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isyeri = await _context.Isyeri
                .FirstOrDefaultAsync(m => m.IsyeriId == id);
            if (isyeri == null)
            {
                return NotFound();
            }

            return View(isyeri);
        }

        // GET: Isyeris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Isyeris/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IsyeriId,IsletmeAdi,Adres,PhoneNumber,YetkiliAdi")] Isyeri isyeri)
        {

            if (ModelState.IsValid)
            {
                _context.Add(isyeri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(isyeri);
        }

        // GET: Isyeris/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var isyeri = await _context.Isyeri.FindAsync(id);
            if (isyeri == null)
            {
                return NotFound();
            }
            return View(isyeri);
        }

        // POST: Isyeris/Edit/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IsyeriId,IsletmeAdi,Adres,PhoneNumber,YetkiliAdi")] Isyeri isyeri)
        {
            if (id != isyeri.IsyeriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isyeri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsyeriExists(isyeri.IsyeriId))
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
            return View(isyeri);
        }


        private bool IsyeriExists(long id)
        {
            return _context.Isyeri.Any(e => e.IsyeriId == id);
        }
    }
}
