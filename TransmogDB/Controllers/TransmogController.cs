using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TransmogDB.Models;

namespace TransmogDB.Controllers
{
    public class TransmogController : Controller
    {
        private TransmogDataContext db = new TransmogDataContext();


        // GET: Transmogs
        public ActionResult Index()
        {
            // Get the top 10 transmog items
            string query = "SELECT TOP 10 Count(ItemID) as ItemCount, Name, ItemID FROM TransmogItems WHERE Transmogrified = 1 GROUP BY Name, ItemID ORDER BY ItemCount Desc, Name ASC";
            List<TransmogPopularItem> TransmogTopItems = (db.Database.SqlQuery<TransmogPopularItem>(query)).ToList();
            
            //ViewBag.ItemCount = TransmogTopItems.Count();
            

            // Select 4 random transmogs to display
            List<Transmog> RandomTransmogs = db.Transmogs.OrderBy(x => Guid.NewGuid()).Take(4).ToList();

            // Get total number of transmogs in the database
            ViewBag.totalAppearances = db.Transmogs.Count();


            // Generate the model
            HomeViewModel model = new HomeViewModel();
            model.Appearance = RandomTransmogs;
            model.PopularItems = TransmogTopItems;
            //ViewBag.TopItems = TransmogTopItems.ToList();
            //ViewBag.RandomTransmogs = RandomTransmogs.ToList();

            //return View(RandomTransmogs);
            return View(model);
        }

        // GET: Transmogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Transmog transmog = db.Transmogs.Find(id);
 

            if (transmog == null)
            {
                return HttpNotFound();
            }
            return View(transmog);
        }

        // GET: Transmogs/Appearance
        public ActionResult Appearance(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            

            Transmog transmog = db.Transmogs.Find(id);
            // List<TransmogItem> items = new List<TransmogItem>();
            List<TransmogItem> items = db.Items.Where(i => i.TransmogID == id).ToList();

            //foreach (TransmogItem item in db.Items.Where(i => i.TransmogID == id))
            //{
            //    items.Add(item);
            //}


            //Transmog transmog = db.Transmogs
            //        .Where(t => t.ID == id)
            //       .Include(t => t.Items)
            //      .FirstOrDefault();

           // List<TransmogItem> items = transmog.Items.ToList();

            DetailViewModel model = new DetailViewModel(transmog, items);


            if (transmog == null)
            {
                return HttpNotFound();
            }

            return View(model);
            //return View();

        }

        // GET: Transmogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transmogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Realm,Race,Gender,Class,Image")] Transmog transmog)
        {
            if (ModelState.IsValid)
            {
                db.Transmogs.Add(transmog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transmog);
        }


        // GET: Transmogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmog transmog = db.Transmogs.Find(id);
            if (transmog == null)
            {
                return HttpNotFound();
            }
            return View(transmog);
        }

        // POST: Transmogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CharacterName,Realm,Race,Gender,Class,Image")] Transmog transmog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transmog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transmog);
        }

        // GET: Transmogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transmog transmog = db.Transmogs.Find(id);
            if (transmog == null)
            {
                return HttpNotFound();
            }
            return View(transmog);
        }

        // POST: Transmogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transmog transmog = db.Transmogs.Find(id);
            db.Transmogs.Remove(transmog);
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
