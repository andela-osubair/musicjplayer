using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace MvcHtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString MenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            if (actionName == currentAction && controllerName == currentController)
            {
                return htmlHelper.ActionLink(
                    linkText,
                    actionName,
                    controllerName,
                    null,
                    new
                    {
                        @class = "active"
                    });
            }
            return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }

        public static MvcHtmlString DDMenuLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            if (actionName == currentAction && controllerName == currentController)
            {
                return htmlHelper.ActionLink(
                    linkText,
                    actionName,
                    controllerName,
                    null,
                    new
                    {
                        @role = "menuitem",
                        @tabindex = "-1"
                    });
            }
            return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }
    }
}