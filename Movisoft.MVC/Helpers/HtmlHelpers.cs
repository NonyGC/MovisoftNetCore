using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movisoft.MVC.Helpers
{
    public static class HtmlHelpers
    {

        public static string IsSelected(this IHtmlHelper html, string area = null, string controller = null, string action = null, string cssClass = null)
        {
            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];
            string currentArea = (string)html.ViewContext.RouteData.Values["area"];

            if (controller == null)
                controller = currentController;

            if (action == null)
                action = currentAction;

            if (area == null)
                area = currentArea;

            var result = controller == currentController && action == currentAction && area == currentArea ? cssClass : string.Empty;

            return result;
        }

        public static string PageClass(this IHtmlHelper htmlHelper)
        {
            string currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

    }
}
