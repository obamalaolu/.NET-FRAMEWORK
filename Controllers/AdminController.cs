using System.Web.Mvc;

namespace ProjectTise.Models
{
    public class AdminController : Controller
    {
        private ShoppingEntities3 db = new ShoppingEntities3();

        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }







        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}