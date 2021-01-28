using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityBuildings.Models;

namespace UniversityBuildings.Controllers
{
    [Authorize]
    public class BuildingsController : Controller
    {
        private BuildingsDBEntities db = new BuildingsDBEntities();

        public ActionResult Index()
        {
            return View(db.Faculty_Buildings.ToList());
        }

        public PartialViewResult HospitalBuildings()
        {

            return PartialView("_Hospital", db.Hospital_Buildings.ToList());
        }

        public PartialViewResult OtherBuildings()
        {
            return PartialView("_Others", db.Other_Buildings.ToList());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult HospitalDetails(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Hospital_Buildings hospital_Buildings = db.Hospital_Buildings.Find(id);
            if (hospital_Buildings == null)
            {
                return View("Error");
            }
            return View(hospital_Buildings);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult OtherBuildingsDetails(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Other_Buildings other_Buildings = db.Other_Buildings.Find(id);
            if (other_Buildings == null)
            {
                return View("Error");
            }
            return View(other_Buildings);
        }
        public ActionResult Details(int? id)
        {
            AspNetUsers user = new AspNetUsers();
            var fefe = (from a in db.AspNetUsers
                        where a.Faculty_Number == id
                        select a.UserName).FirstOrDefault();
            string value = HttpContext.User.Identity.Name;
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Faculty_Buildings faculty_Buildings = db.Faculty_Buildings.Find(id);
            if (faculty_Buildings == null)
            {
                return View("Error");
            }
            if (User.IsInRole("Admin") || value == fefe)
            {
                return View(faculty_Buildings);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateHospital()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Faculty_Buildings/Create
        public ActionResult CreateHospital(Hospital_Buildings hospital_Buildings)
        {

            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin"))
                {
                    db.Hospital_Buildings.Add(hospital_Buildings);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(hospital_Buildings);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateOtherBuildings()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Faculty_Buildings/Create
        public ActionResult CreateOtherBuildings(Other_Buildings other_Buildings)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin"))
                {
                    db.Other_Buildings.Add(other_Buildings);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(other_Buildings);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Faculty_Buildings faculty_Buildings)
        {
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin"))
                {
                    db.Faculty_Buildings.Add(faculty_Buildings);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }

            return View(faculty_Buildings);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditHospital(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Hospital_Buildings hospital_Buildings = db.Hospital_Buildings.Find(id);
            if (hospital_Buildings == null)
            {
                return View("Error");
            }
            return View(hospital_Buildings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHospital(Hospital_Buildings hospital_Buildings)
        {

            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin"))
                {
                    db.Entry(hospital_Buildings).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(hospital_Buildings);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditOtherBuildings(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Other_Buildings other_Buildings = db.Other_Buildings.Find(id);
            if (other_Buildings == null)
            {
                return View("Error");
            }
            return View(other_Buildings);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOtherBuildings(Other_Buildings other_Buildings)
        {

            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin"))
                {
                    db.Entry(other_Buildings).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return View(other_Buildings);
        }


        // GET: Faculty_Buildings/Edit/5
        public ActionResult Edit(int? id)
        {
            AspNetUsers user = new AspNetUsers();
            var Is_Match_User = (from a in db.AspNetUsers
                        where a.Faculty_Number == id
                        select a.UserName).FirstOrDefault();
            string value = HttpContext.User.Identity.Name;

            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Faculty_Buildings faculty_Buildings = db.Faculty_Buildings.Find(id);
            if (faculty_Buildings == null)
            {
                return View("Error");
            }
            if (User.IsInRole("Admin") || value == Is_Match_User)
            {
                return View(faculty_Buildings);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Faculty_Buildings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Faculty_Buildings faculty_Buildings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faculty_Buildings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faculty_Buildings);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}