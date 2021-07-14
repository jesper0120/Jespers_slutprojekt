using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jespers_slutprojekt.Data;
using Jespers_slutprojekt.Models;

/*
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using DHTMLX.Common;
using System.Web.Mvc;
using FormCollection = Microsoft.AspNetCore.Http.FormCollection;
*/

namespace Jespers_slutprojekt.Controllers
{
    [Authorize()]
    public class CoursesAndTreatmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
       // private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        // public CoursesAndTreatmentsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        public CoursesAndTreatmentsController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
           // _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: CoursesAndTreatments
        public async Task<IActionResult> Index()
        {
            //Run once to get User in Role. Logout and Login again to get it to work.
            //await AddToAdminRole();
            //await RemoveFromAdminRole();

            string absoluteurl = HttpContext.Request.Path;
            Debug.WriteLine(absoluteurl);

            // ADDED BEGIN 2021-07-11 
            /*
            DHXScheduler scheduler = new DHXScheduler();
            scheduler.Skin = DHXScheduler.Skins.Flat;

            scheduler.Config.first_hour = 6;
            scheduler.Config.last_hour = 20;

            scheduler.EnableDynamicLoading(SchedulerDataLoader.DynamicalLoadingMode.Month);

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;

            return View(scheduler); 
            how to change this line with scheduler to the below line with await etc? 
            */
            // ADDED END 2021-07-11 

            return View(await _context.coursesAndTreatments.ToListAsync());
        }
/*
        public ContentResult Data(DateTime from, DateTime to)
        {
            var apps = _context.
                coursesAndTreatments.Where(e => e.StartDate < to && e.EndDate >= from).ToList();
            return new SchedulerAjaxData(apps);
        }

        public Microsoft.AspNetCore.Mvc.ContentResult Data()
        {
            
            var apps = db.Appointments.ToList();
            return new SchedulerAjaxData(apps);
            

            List<CoursesAndTreatments> apps = _context.coursesAndTreatments.ToList();
            SchedulerAjaxData schedulerAjaxData = new SchedulerAjaxData(apps);
            return schedulerAjaxData;
        }

        public Microsoft.AspNetCore.Mvc.ActionResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);

            try
            {
                var changedEvent = DHXEventsHelper.Bind<CalendarAppointments>(actionValues);
                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        _context.coursesAndTreatments.Add(changedEvent);
                        break;
                    case DataActionTypes.Delete:
                        _context.Entry(changedEvent).State = EntityState.Deleted;
                        break;
                    default:  "update"  
                        _context.Entry(changedEvent).State = EntityState.Modified;
                        break;
                }
                _context.SaveChanges();
                action.TargetId = changedEvent.Id;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }

            return (new AjaxSaveResponse(action));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
*/
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

        // GET: CoursesAndTreatments/CreateCourse
        /*   NEED TO EDIT CONTROLLER AND / OR CLASS FIRST
        public IActionResult CreateCourse()
        {
            return View();
        }
        */

        // POST: CoursesAndTreatments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseStartDate,BirthDate,StreetAddress,ZipCode,CoursePrice,FirstName,LastName,EmailAddress,PhoneNumber,SignedUpDate,TreatmentDate,TreatmentMethod, TreatmentTime, TreatmentPrice")] CoursesAndTreatments coursesAndTreatments)
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
        /*
        private async Task<bool> AddToAdminRole()
        {
            if (!User.IsInRole("Administrator"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ApplicationUser user = _userManager.Users.Where(s => s.Id == userId).FirstOrDefault();
                if (!await _roleManager.RoleExistsAsync("Administrator"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("Administrator"));
                }
                await _userManager.AddToRoleAsync(user, "Administrator");
                return true;
            }
            return false;
        }

        private async Task<bool> RemoveFromAdminRole()
        {
            if (User.IsInRole("Administrator"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ApplicationUser user = _userManager.Users.Where(s => s.Id == userId).FirstOrDefault();
                await _userManager.RemoveFromRoleAsync(user, "Administrator");
                return true;
            }
            return false;
        }
        */
    }
}
