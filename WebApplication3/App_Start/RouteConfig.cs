using CultureBase.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CultureBase
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                      "AboutRoute",
                      "About",
                      new { controller = "Home", action = "About" }
               ).RouteHandler = new SingleCultureMvcRouteHandler();

            foreach (Route r in routes)
            {
                if (!(r.RouteHandler is SingleCultureMvcRouteHandler))
                {
                    r.RouteHandler = new MultiCultureMvcRouteHandler();
                    r.Url = "{culture}/" + r.Url;
                    //Adding default culture 
                    if (r.Defaults == null)
                    {
                        r.Defaults = new RouteValueDictionary();
                    }
                    r.Defaults.Add("culture", CultureHelper.RetornaDescriptionCulture(Culture.pt));

                    //Adding constraint for culture param
                    if (r.Constraints == null)
                    {
                        r.Constraints = new RouteValueDictionary();
                    }
                    r.Constraints.Add("culture", new CultureConstraint(
                                        CultureHelper.RetornaDescriptionCulture(Culture.en),
                                        CultureHelper.RetornaDescriptionCulture(Culture.ru),
                                        CultureHelper.RetornaDescriptionCulture(Culture.pt),
                                        CultureHelper.RetornaDescriptionCulture(Culture.ptbr)));
                }
            }
        }
    }
}
