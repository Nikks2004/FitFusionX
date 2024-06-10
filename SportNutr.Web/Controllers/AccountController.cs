using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SportNutr.BL;
using SportNutr.Db;
using SportNutr.Domain;

namespace SportNutr.Web.Controllers
{
    public class AccountController : Controller
    {
        private static readonly SportsNutritionDbContext _context = new SportsNutritionDbContext();
        private static readonly EfStoreRepository _repository = new EfStoreRepository(_context);
        private readonly CredentialManager _credentialManager = new CredentialManager(_repository);

        // GET: Display the login page
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Process the login form
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var client = _credentialManager.ConfirmCredentials(username, password);
            if (client != null)
            {
                AuthenticateUser(client);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View();
        }

        // GET: Display the registration page
        public ActionResult Register()
        {
            return View();
        }

        // POST: Process the registration form
        [HttpPost]
        public ActionResult Register(string username, string password)
        {
            var client = _credentialManager.EnrollClient(username, password);
            if (client != null)
            {
                AuthenticateUser(client);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
            return View();
        }

        // Log out the current user and clear session
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, "")
            {
                Expires = DateTime.Now.AddYears(-1)
            };
            HttpContext.Response.Cookies.Add(authCookie);

            return RedirectToAction("Login");
        }

        // Helper method to authenticate and sign in the user
        private void AuthenticateUser(Client client)
        {
            var ticket = new FormsAuthenticationTicket(
                1, // Ticket version
                client.Username, 
                DateTime.Now,
                DateTime.Now.AddMinutes(20), // Expiration time
                false, // Assuming "Remember me" is not a default option
                client.Privilege, // Using Privilege instead of Role
                "/");

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Response.Cookies.Add(authCookie);
        }
    }
}
