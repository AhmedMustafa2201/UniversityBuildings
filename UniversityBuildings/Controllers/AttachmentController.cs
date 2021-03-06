﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityBuildings.Models;

namespace UniversityBuildings.Controllers
{
    [Authorize]
    public class AttachmentController : Controller
    {
        private BuildingsDBEntities db = new BuildingsDBEntities();

        // GET: Attachment
        public ActionResult Index()
        {
            var attachments = db.Attachments.Include(a => a.Faculty_Buildings);
            return View(attachments.ToList());
        }

        // GET: Attachment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Attachments attachments = db.Attachments.Find(id);
            if (attachments == null)
            {
                return RedirectToAction("Index");
            }
            return View(attachments);
        }

        // GET: Attachment/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin"))
            {
                ViewBag.fac_ID = new SelectList(db.Faculty_Buildings, "ID", "Faculty_Name");
            }
            else
            {
                var curr_username = User.Identity.Name;
                AspNetUsers user = new AspNetUsers();
                var result = (from a in db.AspNetUsers
                            where a.Email == curr_username
                            select a.Faculty_Number).FirstOrDefault();

                var text_roles = (from s in db.Faculty_Buildings where s.ID == result select s.Faculty_Name).FirstOrDefault();
                string returned_val = result.ToString();
                ViewBag.fac_ID = new List<SelectListItem>()
                {
                new SelectListItem() {Text=text_roles,Value=returned_val }
                };
            }
            return View();
        }

        // POST: Attachment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Attachments attachments)
        {
            if (ModelState.IsValid)
            {
                db.Attachments.Add(attachments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (User.IsInRole("Admin"))
            {
                ViewBag.fac_ID = new SelectList(db.Faculty_Buildings, "ID", "Faculty_Name", attachments.fac_ID);
            }
            var curr_username = User.Identity.Name;
            AspNetUsers user = new AspNetUsers();
            var result = (from a in db.AspNetUsers
                        where a.Email == curr_username
                        select a.Faculty_Number).FirstOrDefault();

            var text_roles = (from s in db.Faculty_Buildings where s.ID == result select s.Faculty_Name).FirstOrDefault();
            string returned_val = result.ToString();
            ViewBag.fac_ID = new List<SelectListItem>()
            {
                new SelectListItem() {Text=text_roles,Value=returned_val }
            };

            return View(attachments);
        }

        // GET: Attachment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Attachments attachments = db.Attachments.Find(id);
            if (attachments == null)
            {
                return RedirectToAction("Index");
            }
            
            if (User.IsInRole("Admin"))
            {
                ViewBag.fac_ID = new SelectList(db.Faculty_Buildings, "ID", "Faculty_Name");
            }
            var curr_username = User.Identity.Name;
            AspNetUsers user = new AspNetUsers();

            var validate_email = (from a in db.AspNetUsers
                        where a.Email == curr_username
                        select a.Faculty_Number).FirstOrDefault();

            var validate_username = (from a in db.AspNetUsers
                        where a.UserName == curr_username
                       select a.Faculty_Number).FirstOrDefault();

            var validate_fac_id = (from z in db.Attachments
                         where z.fac_ID == validate_username
                         select z.fac_ID).FirstOrDefault();

            if (User.IsInRole("Admin")||validate_fac_id==validate_username)
            {
                var result = (from s in db.Faculty_Buildings where s.ID == validate_email select s.Faculty_Name).FirstOrDefault();
                string result_value = validate_email.ToString();
                ViewBag.fac_ID = new List<SelectListItem>()
                 {
                     new SelectListItem() {Text=result,Value=result_value }
                 };
                return View(attachments);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Attachment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Att_Name,Att_Section_Name,Att_Place_of_it,Att_Vision,Att_Message,Att_Details,Att_Stages_Number,Att_Floors_Number,Att_Is_Inside,Att_NameEN,Att_Section_NameEN,Att_Place_of_itEN,Att_VisionEN,Att_MessageEN,Att_DetailsEN,fac_ID")] Attachments attachments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attachments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (User.IsInRole("Admin"))
            {
                ViewBag.fac_ID = new SelectList(db.Faculty_Buildings, "ID", "Faculty_Name", attachments.fac_ID);
            }
            var curr_username = User.Identity.Name;
            AspNetUsers user = new AspNetUsers();
            var validate_email = (from a in db.AspNetUsers
                        where a.Email == curr_username
                        select a.Faculty_Number).FirstOrDefault();

            var result = (from s in db.Faculty_Buildings where s.ID == validate_email select s.Faculty_Name).FirstOrDefault();
            string result_value = validate_email.ToString();
            ViewBag.fac_ID = new List<SelectListItem>()
            {
                new SelectListItem() {Text=result,Value=result_value }
            };
            return View(attachments);
        }

        // GET: Attachment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Attachments attachments = db.Attachments.Find(id);
            AspNetUsers user = new AspNetUsers();

            var curr_username = User.Identity.Name;
            var validate_username = (from a in db.AspNetUsers
                       where a.UserName == curr_username
                       select a.Faculty_Number).FirstOrDefault();

            var validate_fac_id = (from z in db.Attachments
                         where z.fac_ID == validate_username
                         select z.fac_ID).FirstOrDefault();

            if (User.IsInRole("Admin") || validate_fac_id == validate_username)
            {
                return View(attachments);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Attachment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attachments attachments = db.Attachments.Find(id);
            db.Attachments.Remove(attachments);
            db.SaveChanges();
            return RedirectToAction("Index");
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
