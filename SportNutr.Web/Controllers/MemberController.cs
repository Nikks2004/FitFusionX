using System.Web.Mvc;
using SportNutr.Db;
using SportNutr.Domain;

namespace SportNutr.Web.Controllers
{
    public class MemberController : Controller
    {
        private SportsNutritionDbContext db = new SportsNutritionDbContext();

        [HttpGet]
        public ActionResult BecomeMember()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BecomeMember(Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(member);
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }

}