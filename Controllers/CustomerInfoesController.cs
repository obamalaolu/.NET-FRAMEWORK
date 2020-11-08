using ProjectTise.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProjectTise.Controllers
{
    public class CustomerInfoesController : Controller
    {
        private ShoppingEntities3 db = new ShoppingEntities3();

        // GET: CustomerInfoes
        public ActionResult Index()
        {
            return View(db.CustomerInfoes.ToList());
        }

        // GET: CustomerInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfo customerInfo = db.CustomerInfoes.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            return View(customerInfo);
        }

        // GET: CustomerInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,Customer_First_Name,Customer_Last_Name,Customer_D_O_B,Customer_Email,Address_Name_No,Address_Line_2,Town_City,Postcode_Zip_Code")] CustomerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                db.CustomerInfoes.Add(customerInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerInfo);
        }

        // GET: CustomerInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfo customerInfo = db.CustomerInfoes.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            return View(customerInfo);
        }

        // POST: CustomerInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,Customer_First_Name,Customer_Last_Name,Customer_D_O_B,Customer_Email,Address_Name_No,Address_Line_2,Town_City,Postcode_Zip_Code")] CustomerInfo customerInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerInfo);
        }

        // GET: CustomerInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerInfo customerInfo = db.CustomerInfoes.Find(id);
            if (customerInfo == null)
            {
                return HttpNotFound();
            }
            return View(customerInfo);
        }

        // POST: CustomerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerInfo customerInfo = db.CustomerInfoes.Find(id);
            db.CustomerInfoes.Remove(customerInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
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
