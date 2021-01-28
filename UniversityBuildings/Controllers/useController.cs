using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UniversityBuildings.Mine;
using UniversityBuildings.Models;
using UniversityBuildings.ViewModel;

namespace UniversityBuildings.Controllers
{
    [HandleError(View = "theError")]
    public class useController : MyBaseController
    {
        private BuildingsDBEntities db = new BuildingsDBEntities();

        // GET: use
        [OutputCache(Duration = 700)]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult search()
        {
            var topElements = from q
                              in db.Faculty_Buildings
                              where q.ID <= 3
                              select q;
            return View(topElements.ToList());
        }

        [HttpPost]
        public PartialViewResult search(string pname)
        {
            if (_currentLanguage == "en")
            {
                if (!string.IsNullOrWhiteSpace(pname) && !pname.Contains("0123456789`~!@#$%^&*()_-=+';:\\/?.,<>][{}"))
                {
                    var theSearch = db.Faculty_Buildings
                                   .Where(a => a.Faculty_NameEN.Contains(pname));
                    return PartialView("_mainSearch", theSearch.OrderBy(e => e.Faculty_NameEN).ToList());
                }
                var theSerch = db.Faculty_Buildings.Where(w => w.ID <= 3);
                return PartialView("_mainSearch", theSerch.OrderBy(e => e.Faculty_NameEN).ToList());
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(pname) && !pname.Contains("0123456789`~!@#$%^&*()_-=+';:\\/?.,<>][{}"))
                {
                    var theSearch = db.Faculty_Buildings
                                   .Where(a => a.Faculty_Name.Contains(pname));
                    return PartialView("_mainSearch", theSearch.OrderBy(e => e.Faculty_Name).ToList());
                }
                var theSerch = db.Faculty_Buildings.Where(w => w.ID <= 3);
                return PartialView("_mainSearch", theSerch.OrderBy(e => e.Faculty_Name).ToList());
            }
        }

        public ActionResult quickSearch(string term)
        {
            if (_currentLanguage == "en")
            {
                if (!string.IsNullOrWhiteSpace(term) && !term.Contains("0123456789`~!@#$%^&*()_-=+';:\\/?.,<>][{}"))
                {
                    return Json(db.Faculty_Buildings.Where(a => a.Faculty_NameEN.Contains(term))
                          .Take(10)
                          .OrderBy(a => a.Faculty_NameEN)
                          .Select(w => w.Faculty_NameEN), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new string[0], JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(term) && !term.Contains("0123456789`~!@#$%^&*()_-=+';:\\/?.,<>][{}"))
                {
                    return Json(db.Faculty_Buildings.Where(a => a.Faculty_Name.Contains(term))
                           .Take(10)
                           .OrderBy(a => a.Faculty_Name)
                           .Select(w => w.Faculty_Name), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new string[0], JsonRequestBehavior.AllowGet);
                }
            }
        }

        [OutputCache(Duration = 700, VaryByParam = "id")]
        public ActionResult learnMore(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var viewModel = new FacImagesViewModel();
            viewModel.faculty_buildings = (from q
                                          in db.Faculty_Buildings
                                           where q.ID == id
                                           select q).FirstOrDefault();

            var theName = id.ToString();
            ViewBag.mainImage = "~/MainImages/faculty/" + theName + ".jpg";

            viewModel.images = db.Images.Where(w => w.Fac_ID == id).ToList();
            if (viewModel.images==null)
            {
                ViewBag.none = "<h1>None</h1>";
            }
            if (viewModel == null)
            {
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [OutputCache(Duration = 700, VaryByParam = "id")]
        public ActionResult attachmentsForFac(int? id)
        {
            if (id==null)
            {
                return RedirectToAction("Index");
            }
            var item = (from s in db.Attachments
                        where s.fac_ID == id
                        select s).ToList();
            if (item == null)
            {
                return RedirectToAction("search");
            }
            return View(item);
        }

        [OutputCache(Duration = 700, VaryByParam = "id")]
        public ActionResult LearnmoreForAtt(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var item = (from s in db.Attachments
                        where s.ID == id
                        select s).FirstOrDefault();
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        /*****************************************************************************/
        public ActionResult hospitalSearch()
        {
            var topElements = from q
                              in db.Hospital_Buildings
                              where q.ID <= 3
                              select q;
            return View(topElements.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult hospitalSearch(string pname)
        {
            if (_currentLanguage == "en")
            {
                if (!string.IsNullOrWhiteSpace(pname))
                {
                    var theSearch = db.Hospital_Buildings
                                   .Where(a => a.Hospital_NameEN.Contains(pname));
                    return PartialView("_mainHospitalSearch", theSearch.OrderBy(e => e.Hospital_NameEN).ToList());
                }
                var theSerch = db.Hospital_Buildings.Where(w => w.ID <= 3);
                return PartialView("_mainHospitalSearch", theSerch.OrderBy(e => e.Hospital_NameEN).ToList());
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(pname))
                {
                    var theSearch = db.Hospital_Buildings
                                   .Where(a => a.Hospital_Name.Contains(pname));
                    return PartialView("_mainHospitalSearch", theSearch.OrderBy(e => e.Hospital_Name).ToList());
                }
                var theSerch = db.Hospital_Buildings.Where(w => w.ID <= 3);
                return PartialView("_mainHospitalSearch", theSerch.OrderBy(e => e.Hospital_Name).ToList());
            }
        }

        public ActionResult quickHospitalSearch(string term)
        {

            if (_currentLanguage == "en")
            {
                if (string.IsNullOrWhiteSpace(term))
                {
                    return Json(new string[0], JsonRequestBehavior.AllowGet);
                }
                return Json(db.Hospital_Buildings.Where(a => a.Hospital_NameEN.Contains(term))
                    .Take(10)
                    .OrderBy(a => a.Hospital_NameEN)
                    .Select(w => w.Hospital_NameEN), JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(term))
                {
                    return Json(new string[0], JsonRequestBehavior.AllowGet);
                }
                return Json(db.Hospital_Buildings.Where(a => a.Hospital_Name.Contains(term))
                    .Take(10)
                    .OrderBy(a => a.Hospital_Name)
                    .Select(w => w.Hospital_Name), JsonRequestBehavior.AllowGet);

            }
        }

        [OutputCache(Duration = 700, VaryByParam = "id")]
        public ActionResult HospitalLearnMore(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var viewModel = new HosImagesViewModel();
            viewModel.hospital_buildings = (from q
                                          in db.Hospital_Buildings
                                            where q.ID == id
                                            select q).FirstOrDefault();
            var theName = id.ToString();
            ViewBag.mainImage = "~/MainImages/hospital/" + theName + ".jpg";

            viewModel.images = db.Images.Where(w => w.Hos_ID == id).ToList();
            if (viewModel == null)
            {
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        //*******************************************************************************

        public ActionResult OtherBuildingSearch()
        {

            var topElements = from q
                              in db.Other_Buildings
                              where q.ID <= 3
                              select q;
            return View(topElements.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult OtherBuildingSearch(string pname)
        {

            if (_currentLanguage == "en")
            {
                if (!string.IsNullOrWhiteSpace(pname))
                {
                    var theSearch = db.Other_Buildings
                                   .Where(a => a.Building_NameEN.Contains(pname));
                    return PartialView("_mainOthersSearch", theSearch.OrderBy(e => e.Building_NameEN).ToList());
                }
                var theSerch = db.Other_Buildings.Where(w => w.ID <= 3);
                return PartialView("_mainOthersSearch", theSerch.OrderBy(e => e.Building_NameEN).ToList());
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(pname))
                {
                    var theSearch = db.Other_Buildings
                                   .Where(a => a.Building_Name.Contains(pname));
                    return PartialView("_mainOthersSearch", theSearch.OrderBy(e => e.Building_Name).ToList());
                }
                var theSerch = db.Other_Buildings.Where(w => w.ID <= 3);
                return PartialView("_mainOthersSearch", theSerch.OrderBy(e => e.Building_Name).ToList());

            }
        }

        public ActionResult quickOthersSearch(string term)
        {

            if (_currentLanguage == "en")
            {
                if (string.IsNullOrWhiteSpace(term))
                {
                    return Json(new string[0], JsonRequestBehavior.AllowGet);
                }
                return Json(db.Other_Buildings.Where(a => a.Building_NameEN.Contains(term))
                    .Take(10)
                    .OrderBy(a => a.Building_NameEN)
                    .Select(w => w.Building_NameEN), JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(term))
                {
                    return Json(new string[0], JsonRequestBehavior.AllowGet);
                }
                return Json(db.Other_Buildings.Where(a => a.Building_Name.Contains(term))
                    .Take(10)
                    .OrderBy(a => a.Building_Name)
                    .Select(w => w.Building_Name), JsonRequestBehavior.AllowGet);

            }
        }

        [OutputCache(Duration = 700, VaryByParam = "id")]
        public ActionResult OtherBuildingLearnMore(int? id)
        {

            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var viewModel = new OtherImagesViewModel();
            viewModel.other_buildings = (from q
                                          in db.Other_Buildings
                                         where q.ID == id
                                         select q).FirstOrDefault();
            var theName = id.ToString();
            ViewBag.mainImage = "~/MainImages/otherBuildings/" + theName + ".jpg";

            viewModel.images = db.Images.Where(w => w.Other_ID == id).ToList();
            if (viewModel == null)
            {
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }
        public ActionResult ChangeLanguage(string lang,string url)
        {
            new SiteLanguages().SetLanguage(lang);
            return Redirect(url);
        }

        /*****************************************************************************/
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