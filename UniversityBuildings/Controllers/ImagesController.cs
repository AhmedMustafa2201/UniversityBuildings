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
    public class ImagesController : Controller
    {
        private BuildingsDBEntities db = new BuildingsDBEntities();

        // GET: Images
        public ActionResult Index1()
        {
            if (User.IsInRole("Admin"))
            {
                var images = db.Images.Include(i => i.Faculty_Buildings).Include(i => i.Hospital_Buildings).Include(i => i.Other_Buildings);
                return View(images.ToList());
            }
            else
            {
                var theUser = User.Identity.Name;
                AspNetUsers user = new AspNetUsers();
                var Is_Match_User = (from a in db.AspNetUsers
                            where a.Email == theUser
                            select a.Faculty_Number).FirstOrDefault();
                var target = (from s in db.Images where s.Fac_ID == Is_Match_User select s).ToList();
                return View(target);
            }
        }

        // GET: Images/Create
        public ActionResult Create()
        {
            if (User.IsInRole("Admin"))
            {
                ViewBag.fac_ID = new SelectList(db.Faculty_Buildings, "ID", "Faculty_Name");
            }
            else
            {
                var theUser = User.Identity.Name;
                AspNetUsers user = new AspNetUsers();
                var validate_email = (from a in db.AspNetUsers
                            where a.Email == theUser
                            select a.Faculty_Number).FirstOrDefault();

                var result = (from s in db.Faculty_Buildings where s.ID == validate_email select s.Faculty_Name).FirstOrDefault();
                string result_value = validate_email.ToString();
                ViewBag.fac_ID = new List<SelectListItem>()
                {
                new SelectListItem() {Text=result,Value=result_value }
                };
            }
            return View();

            //ViewBag.Fac_ID = new SelectList(db.Faculty_Buildings, "ID", "Faculty_Name");
            //return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase profimg, Images images)
        {
            if (profimg != null)
            {
                var supportedTypes = new[] { "jpg", "jpeg", "png" };
                var fileExt = Path.GetExtension(profimg.FileName).Substring(1);
                var final = fileExt.ToLower();
                if (supportedTypes.Contains(final))
                {
                    var path = "";
                    var name = new Random();
                    var theFinalName = DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + name.Next() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "." + final;
                    var fileattachName = Path.GetFileName(theFinalName);
                    path = Path.Combine(Server.MapPath("../Images/Image/"), fileattachName);
                    profimg.SaveAs(path);
                    string phnameattach = Path.GetFileName(path);
                    images.Image_Path = Url.Content("../Images/Image/" + phnameattach);
                    db.Images.Add(images);
                    db.SaveChanges();
                    return RedirectToAction("Index1", "Images");
                }
            }
            if (User.IsInRole("Admin"))
            {
                ViewBag.fac_ID = new SelectList(db.Faculty_Buildings, "ID", "Faculty_Name", images.Fac_ID);
            }
            var theUser = User.Identity.Name;
            AspNetUsers user = new AspNetUsers();
            var fefe = (from a in db.AspNetUsers
                        where a.Email == theUser
                        select a.Faculty_Number).FirstOrDefault();

            var erer = (from s in db.Faculty_Buildings where s.ID == fefe select s.Faculty_Name).FirstOrDefault();
            string dqdq = fefe.ToString();
            ViewBag.fac_ID = new List<SelectListItem>()
            {
                new SelectListItem() {Text=erer,Value=dqdq }
            };

            return View(images);
        }

        [Authorize(Roles ="Admin")]
        public ActionResult CreateHospital()
        {

            ViewBag.Hos_ID = new SelectList(db.Hospital_Buildings, "ID", "Hospital_Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHospital(Images images1, HttpPostedFileBase profimg)
        {
            if (profimg != null)
            {
                var supportedTypes = new[] { "jpg", "jpeg", "png" };
                var fileExt = Path.GetExtension(profimg.FileName).Substring(1);
                var final = fileExt.ToLower();
                if (supportedTypes.Contains(final))
                {
                    var path = "";
                    var name = new Random();
                    //var FileName = Path.GetFileNameWithoutExtension(profimg.FileName);
                    var theFinalName = DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Year + DateTime.Now.Second + DateTime.Now.Millisecond + name.Next() + DateTime.Now.Month + DateTime.Now.Day + "." + final;
                    var fileattachName = Path.GetFileName(theFinalName);
                    path = Path.Combine(Server.MapPath("../Images/Image/"), fileattachName);
                    profimg.SaveAs(path);
                    string phnameattach = Path.GetFileName(path);
                    images1.Image_Path = Url.Content("../Images/Image/" + phnameattach);

                    db.Images.Add(images1);
                    db.SaveChanges();
                    return RedirectToAction("Index1", "Images");
                }
            }
            ViewBag.Hos_ID = new SelectList(db.Hospital_Buildings, "ID", "Hospital_Name", images1.Hos_ID);
            return View(images1);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateOthers()
        {

            ViewBag.Other_ID = new SelectList(db.Other_Buildings, "ID", "Building_Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOthers([Bind(Include = "ID,Image_Path,Other_ID")] Images images, HttpPostedFileBase profimg)
        {
            if (profimg != null)
            {
                var supportedTypes = new[] { "jpg", "jpeg", "png" };
                var fileExt = Path.GetExtension(profimg.FileName).Substring(1);
                var final = fileExt.ToLower();
                if (supportedTypes.Contains(final))
                {
                    var path = "";
                    var name = new Random();
                    //var FileName = Path.GetFileNameWithoutExtension(profimg.FileName);
                    var theFinalName = DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + name.Next() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "." + final;
                    var fileattachName = Path.GetFileName(theFinalName);
                    path = Path.Combine(Server.MapPath("../Images/Image/"), fileattachName);
                    profimg.SaveAs(path);
                    string phnameattach = Path.GetFileName(path);
                    images.Image_Path = Url.Content("../Images/Image/" + phnameattach);
                    db.Images.Add(images);
                    db.SaveChanges();
                    return RedirectToAction("Index1", "Images");
                }
            }
            ViewBag.Other_ID = new SelectList(db.Other_Buildings, "ID", "Building_Name", images.Other_ID);
            return View(images);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Images images = db.Images.Find(id);
            if (images == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fac_ID = new SelectList(db.Faculty_Buildings, "ID", "Faculty_Name", images.Fac_ID);
            ViewBag.Hos_ID = new SelectList(db.Hospital_Buildings, "ID", "Hospital_Name", images.Hos_ID);
            ViewBag.Other_ID = new SelectList(db.Other_Buildings, "ID", "Building_Name", images.Other_ID);
            return View(images);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Images images, HttpPostedFileBase profimg)
        {
            if (profimg != null)
            {
                var supportedTypes = new[] { "jpg", "jpeg", "png" };
                var fileExt = Path.GetExtension(profimg.FileName).Substring(1);
                var final = fileExt.ToLower();
                if (supportedTypes.Contains(final))
                {
                    var path = "";
                    var name = new Random();
                    //var FileName = Path.GetFileNameWithoutExtension(profimg.FileName);
                    var theFinalName = DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + name.Next() + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "." + final;
                    var fileattachName = Path.GetFileName(theFinalName);
                    path = Path.Combine(Server.MapPath("../Image/"), fileattachName);
                    profimg.SaveAs(path);
                    string phnameattach = Path.GetFileName(path);
                    var tneen = Url.Content("../Images/Image/" + phnameattach);
                    images.Image_Path = tneen;
                    db.Entry(images).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index1", "Images");
                }
            }
            ViewBag.Fac_ID = new SelectList(db.Faculty_Buildings, "ID", "Faculty_Name", images.Fac_ID);
            ViewBag.Hos_ID = new SelectList(db.Hospital_Buildings, "ID", "Hospital_Name", images.Hos_ID);
            ViewBag.Other_ID = new SelectList(db.Other_Buildings, "ID", "Building_Name", images.Other_ID);
            return View(images);
        }


        // GET: Images/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index1", "Images");
            }
            Images images = db.Images.Find(id);
            if (images == null)
            {
                return RedirectToAction("Index1", "Images");
            }
            return View(images);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Images images = db.Images.Find(id);
            db.Images.Remove(images);
            db.SaveChanges();
            return RedirectToAction("Index1", "Images");
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