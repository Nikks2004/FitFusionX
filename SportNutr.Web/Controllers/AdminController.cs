using System.Linq;
using System.Web.Mvc;
using SportNutr.Db;
using SportNutr.Web.SecurityItems;

namespace SportNutr.Web.Controllers
{
    [ModeratorAccess]
    public class AdminController : Controller
    {
        private SportsNutritionDbContext db = new SportsNutritionDbContext();

        [HttpGet]
        public ActionResult ViewMembers()
        {
            var members = db.Members.ToList();
            return View(members);
        }

        [HttpPost]
        public ActionResult ApproveMember(int id)
        {
            var member = db.Members.Find(id);
            if (member != null)
            {
                // Если нужно выполнить какие-то действия при одобрении, можно сделать это здесь
                db.SaveChanges();
            }
            return RedirectToAction("ViewMembers");
        }

        [HttpPost]
        public ActionResult DisapproveMember(int id)
        {
            var member = db.Members.Find(id);
            if (member != null)
            {
                db.Members.Remove(member);
                db.SaveChanges();
            }
            return RedirectToAction("ViewMembers");
        }
    }

}