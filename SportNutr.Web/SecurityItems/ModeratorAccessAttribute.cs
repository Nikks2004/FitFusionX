using System.Web;
using System.Web.Mvc;

namespace SportNutr.Web.SecurityItems
{
    // Custom authorization attribute to ensure users have the 'Moderator' role
    public class ModeratorAccessAttribute : AuthorizeAttribute
    {
        // Define the specific role that has access permission
        private readonly string _accessRole = "Moderator";

        // Determine if the user is authorized based on their role
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Reject access if the user is not authenticated
            if (!httpContext.User.Identity.IsAuthenticated)
            {
                return false;
            }

            // Grant access if the user is in the required role
            return httpContext.User.IsInRole(_accessRole);
        }

        // Redirect the user to an error page if they are unauthorized
        protected override void HandleUnauthorizedRequest(AuthorizationContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                // User is logged in but does not have the right role, redirect to custom error page
                context.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary
                    {
                        { "area", "" },
                        { "controller", "AccessDenied" },
                        { "action", "Index" }
                    });
            }
            else
            {
                // If the user is not authenticated at all, use the default unauthorized handling
                base.HandleUnauthorizedRequest(context);
            }
        }
    }
}