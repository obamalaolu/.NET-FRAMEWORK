using ProjectTise.Models;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ProjectTise.Controllers
{
    public class ProductInfoesController : Controller
    {
        private ShoppingEntities3 db = new ShoppingEntities3();

        // GET: ProductInfoes
        public ActionResult Index()
        {
            return View(db.ProductInfoes.ToList());
        }

        // GET: ProductInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo productInfo = db.ProductInfoes.Find(id);
            if (productInfo == null)
            {
                return HttpNotFound();
            }
            return View(productInfo);
        }

        // GET: ProductInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productId,Product_Name,Product_Number,Product_Description,Product_Price,Image,ImageFile")] ProductInfo productInfo)

        {

            if (ModelState.IsValid)
            {

                string imagename = Path.GetFileNameWithoutExtension(productInfo.ImageFile.FileName);

                string extension = Path.GetExtension(productInfo.ImageFile.FileName);

                imagename = imagename + extension;


                productInfo.Image = imagename;
                imagename = Path.Combine(Server.MapPath("~/Content/img/"), imagename);
                productInfo.ImageFile.SaveAs(imagename);


                db.ProductInfoes.Add(productInfo);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(productInfo);

        }

        // GET: ProductInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo productInfo = db.ProductInfoes.Find(id);
            if (productInfo == null)
            {
                return HttpNotFound();
            }
            return View(productInfo);
        }

        // POST: ProductInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productId,Product_Name,Product_Number,Product_Description,Product_Price,Image")] ProductInfo productInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productInfo);
        }

        // GET: ProductInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductInfo productInfo = db.ProductInfoes.Find(id);
            if (productInfo == null)
            {
                return HttpNotFound();
            }
            return View(productInfo);
        }

        // POST: ProductInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductInfo productInfo = db.ProductInfoes.Find(id);
            db.ProductInfoes.Remove(productInfo);
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


