using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jespers_slutprojekt.Data;
using Jespers_slutprojekt.Models;
using Microsoft.AspNetCore.Authorization;

namespace Jespers_slutprojekt.Controllers
{
    [Authorize()]
    public class CoursesAndTreatmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesAndTreatmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CoursesAndTreatments
        public async Task<IActionResult> Index()
        {
            return View(await _context.coursesAndTreatments.ToListAsync());
        }

        // GET: CoursesAndTreatments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesAndTreatments = await _context.coursesAndTreatments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursesAndTreatments == null)
            {
                return NotFound();
            }

            return View(coursesAndTreatments);
        }

        // GET: CoursesAndTreatments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoursesAndTreatments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseStartDate,BirthDate,StreetAddress,ZipCode,CoursePrice,FirstName,LastName,EmailAddress,PhoneNumber,SignedUpDate,TreatmentDate,TreatmentMethod,TreatmentPrice")] CoursesAndTreatments coursesAndTreatments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coursesAndTreatments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coursesAndTreatments);
        }

        // GET: CoursesAndTreatments/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesAndTreatments = await _context.coursesAndTreatments.FindAsync(id);
            if (coursesAndTreatments == null)
            {
                return NotFound();
            }
            return View(coursesAndTreatments);
        }

        // POST: CoursesAndTreatments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseStartDate,BirthDate,StreetAddress,ZipCode,CoursePrice,FirstName,LastName,EmailAddress,PhoneNumber,SignedUpDate,TreatmentDate,TreatmentMethod,TreatmentPrice")] CoursesAndTreatments coursesAndTreatments)
        {
            if (id != coursesAndTreatments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coursesAndTreatments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursesAndTreatmentsExists(coursesAndTreatments.Id))
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
            return View(coursesAndTreatments);
        }

        // GET: CoursesAndTreatments/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesAndTreatments = await _context.coursesAndTreatments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coursesAndTreatments == null)
            {
                return NotFound();
            }

            return View(coursesAndTreatments);
        }

        // POST: CoursesAndTreatments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coursesAndTreatments = await _context.coursesAndTreatments.FindAsync(id);
            _context.coursesAndTreatments.Remove(coursesAndTreatments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursesAndTreatmentsExists(int id)
        {
            return _context.coursesAndTreatments.Any(e => e.Id == id);
        }
    }
}
