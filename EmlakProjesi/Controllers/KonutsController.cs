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
    public class KonutsController : Controller
    {
        private readonly EmlakDbContext _context;

        public KonutsController(EmlakDbContext context)
        {
            _context = context;
        }

        // GET: Konuts
        public async Task<IActionResult> Index()
        {
            var emlakDbContext = _context.Konut.Include(k => k.Isyeri).Include(k => k.Musteri);
            return View(await emlakDbContext.ToListAsync());
        }

        // GET: Konuts/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konut = await _context.Konut
                .Include(k => k.Isyeri)
                .Include(k => k.Musteri)
                .FirstOrDefaultAsync(m => m.KonutId == id);
            if (konut == null)
            {
                return NotFound();
            }
            return View(konut);
        }

        // GET: Konuts/Create
        public IActionResult Create()
        {
            ViewData["IsyeriId"] = new SelectList(_context.Isyeri, "IsyeriId", "IsletmeAdi");
            ViewData["MusteriId"] = new SelectList(_context.Musteri, "MusteriId", "Email");
            return View();
        }

        // POST: Konuts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KonutId,IsyeriId,MusteriId,EmlakTuru,Alan,OdaSayisi,KatNo,IsinmaTuru,SatisFiyati")] Konut konut)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konut);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IsyeriId"] = new SelectList(_context.Isyeri, "IsyeriId", "IsletmeAdi", konut.IsyeriId);
            ViewData["MusteriId"] = new SelectList(_context.Musteri, "MusteriId", "Email", konut.MusteriId);
            return View(konut);
        }

        // GET: Konuts/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konut = await _context.Konut.FindAsync(id);
            if (konut == null)
            {
                return NotFound();
            }
            ViewData["IsyeriId"] = new SelectList(_context.Isyeri, "IsyeriId", "IsletmeAdi", konut.IsyeriId);
            ViewData["MusteriId"] = new SelectList(_context.Musteri, "MusteriId", "Email", konut.MusteriId);
            return View(konut);
        }

        // POST: Konuts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("KonutId,IsyeriId,MusteriId,EmlakTuru,Alan,OdaSayisi,KatNo,IsinmaTuru,SatisFiyati")] Konut konut)
        {
            if (id != konut.KonutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konut);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KonutExists(konut.KonutId))
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
            ViewData["IsyeriId"] = new SelectList(_context.Isyeri, "IsyeriId", "IsletmeAdi", konut.IsyeriId);
            ViewData["MusteriId"] = new SelectList(_context.Musteri, "MusteriId", "Email", konut.MusteriId);
            return View(konut);
        }

        private bool KonutExists(long id)
        {
            return _context.Konut.Any(e => e.KonutId == id);
        }


    }
}
