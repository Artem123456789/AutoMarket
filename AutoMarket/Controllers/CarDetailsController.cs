using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoMarket;
using AutoMarket.Models;
using AutoMarket.ViewModels;

namespace AutoMarket.Controllers
{
    public class CarDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public CarDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CarDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarDetails.Include(d => d.Car).ToListAsync());
        }

        // GET: CarDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDetail = await _context.CarDetails.Include(d => d.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carDetail == null)
            {
                return NotFound();
            }

            return View(carDetail);
        }

        // GET: CarDetails/Create
        public IActionResult Create()
        {
            AddCars();
            return View();
        }

        private void AddCars()
        {
            ViewBag.Cars = new SelectList(_context.Cars, "Id", "Name");
        }

        // POST: CarDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Price, CarId")] CarDetail carDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: CarDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Cars = _context.Cars;
            var carDetail = await _context.CarDetails.Include(d => d.Car).Where(d => d.Id == id).FirstAsync();
            if (carDetail == null)
            {
                return NotFound();
            }
            return View(carDetail);
        }

        // POST: CarDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Price, CarId")] CarDetail carDetail)
        {
            if (id != carDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarDetailExists(carDetail.Id))
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
            return View(carDetail);
        }

        // GET: CarDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carDetail = await _context.CarDetails.Include(d => d.Car)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carDetail == null)
            {
                return NotFound();
            }

            return View(carDetail);
        }

        // POST: CarDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carDetail = await _context.CarDetails.FindAsync(id);
            _context.CarDetails.Remove(carDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarDetailExists(int id)
        {
            return _context.CarDetails.Any(e => e.Id == id);
        }
    }
}
