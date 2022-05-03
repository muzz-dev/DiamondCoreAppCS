using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DiamondCoreAppCS.Models;
using Newtonsoft.Json;

namespace DiamondCoreAppCS.Controllers
{
    public class DiamondController : Controller
    {
        private readonly CollegeDBContext _context;

        public DiamondController(CollegeDBContext context)
        {
            _context = context;
        }

        // GET: Diamond
        public async Task<IActionResult> Index()
        {
            var result = await _context.Diamond.ToListAsync();
            return View(Tuple.Create(result));
        }

        // GET: Diamond/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diamond = await _context.Diamond
                .FirstOrDefaultAsync(m => m.DiamondId == id);
            Tuple<Diamond> diamondDetail = Tuple.Create(diamond);
            if (diamond == null)
            {
                return NotFound();
            }

            return View(diamondDetail.Item1);
        }

        // GET: Diamond/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diamond/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DiamondId,DiamondCut,DiamondColor,DiamondClarity,DiamondCarat")] Diamond diamond)
        {
            Tuple<Diamond> newDiamond = Tuple.Create(diamond);
            if (ModelState.IsValid)
            {
                _context.Add(newDiamond.Item1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newDiamond.Item1);
        }

        // GET: Diamond/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diamond = await _context.Diamond.FindAsync(id);
            Tuple<Diamond> diamondToEdit = Tuple.Create(diamond);
            if (diamond == null)
            {
                return NotFound();
            }
            return View(diamondToEdit.Item1);
        }

        // POST: Diamond/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiamondId,DiamondCut,DiamondColor,DiamondClarity,DiamondCarat")] Diamond diamond)
        {
            Tuple<Diamond> diamondtoEdit = Tuple.Create(diamond);
            if (id != diamond.DiamondId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diamondtoEdit.Item1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiamondExists(diamondtoEdit.Item1.DiamondId))
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
            return View(diamondtoEdit.Item1);
        }

        // GET: Diamond/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diamond = await _context.Diamond
                .FirstOrDefaultAsync(m => m.DiamondId == id);

            Tuple<Diamond> diamondtoDelete = Tuple.Create(diamond);

            if (diamond == null)
            {
                return NotFound();
            }

            return View(diamondtoDelete.Item1);
        }

        // POST: Diamond/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diamond = await _context.Diamond.FindAsync(id);
            _context.Diamond.Remove(diamond);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiamondExists(int id)
        {
            return _context.Diamond.Any(e => e.DiamondId == id);
        }
    }
}
