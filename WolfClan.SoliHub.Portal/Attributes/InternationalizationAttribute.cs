using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace WolfClan.SoliHub.Portal.Attributes
{
    public class InternationalizationAttribute : ActionFilterAttribute
    {
        private readonly List<string> _supportedLocales;
        private readonly string _defaultLang;

        public InternationalizationAttribute()
        {
            _supportedLocales = new List<string>() { "en", "ar" };
            _defaultLang = "en";
        }

        private void SetLang(string lang)
        {
            if (lang.Trim().ToLower().StartsWith("en")) lang = "en";
            if (lang.Trim().ToLower().StartsWith("ar")) lang = "ar";
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(lang);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            setLang:
            string lang = (string)filterContext.RouteData.Values["lang"] ?? _defaultLang;
            if (string.IsNullOrEmpty(lang))
                lang = _defaultLang;
            if (lang.Trim().ToLower().StartsWith("en") || lang.Trim().ToLower().StartsWith("ar"))
            {
                SetLang(lang);
            }
            else
            {
                filterContext.RouteData.Values["lang"] = "en";
                goto setLang;
                throw new Exception("Can't found and language with this name: " + lang);
            }
        }
    }
}