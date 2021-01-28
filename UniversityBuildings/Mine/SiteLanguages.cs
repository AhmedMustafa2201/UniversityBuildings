using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;

namespace UniversityBuildings.Mine
{
    public class SiteLanguages
    {
        public static List<languages> AvailableLanguages = new List<languages>
        {
            new languages {langFullName="العربية", langCultureName="ar" },
            new languages {langFullName="English", langCultureName="en" }
        };

        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguages.Where(w => w.langCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return AvailableLanguages[0].langCultureName;
        }

        public void SetLanguage(string lang)
        {
            try
            {
                if (!IsLanguageAvailable(lang))
                    lang = GetDefaultLanguage();
                var cultureInfo = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                HttpCookie langCookie = new HttpCookie("culture", lang);
                langCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(langCookie);
            }
            catch (Exception)
            {
            }
        }

    }

    public class languages
    {
        public string langFullName { get; set; }
        public string langCultureName { get; set; }

    }
}