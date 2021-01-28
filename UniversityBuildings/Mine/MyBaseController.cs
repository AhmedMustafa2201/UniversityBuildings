using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UniversityBuildings.Mine
{
    public class MyBaseController : Controller
    {
        protected string _currentLanguage = "";
        //protected string currentUrl = "";
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string lang = null;
            HttpCookie langCookie = Request.Cookies["culture"];

            if (langCookie!=null)
            {
                lang = langCookie.Value;
            }
            else
            {
                var userLanguage = Request.UserLanguages;
                var userLang = userLanguage != null ? userLanguage[0] : "";
                if (userLang!="")
                {
                    lang = userLang;
                }
                else
                {
                    lang = SiteLanguages.GetDefaultLanguage();
                }
            }
            new SiteLanguages().SetLanguage(lang);

            _currentLanguage = System.Web.HttpContext.Current.Request.Cookies["culture"].Value;
            ViewBag.currentLanguage = System.Web.HttpContext.Current.Request.Cookies["culture"].Value;
            ViewBag.currentUrl = Request.RawUrl;
            return base.BeginExecuteCore(callback, state);
        }
    }
}