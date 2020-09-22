using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOSamourai;
using TP5Samourai.Data;

namespace TP5Samourai.Controllers
{
    public class ArmesController : Controller
    {
        private TP5SamouraiContext db = new TP5SamouraiContext();

        // GET: Armes
        public ActionResult Index()
        {
            return View(db.Armes.ToList());
        }

        // GET: Armes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arme arme = db.Armes.Find(id);
            if (arme == null)
            {
                return HttpNotFound();
            }
            return View(arme);
        }

        // GET: Armes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Armes/Create
       [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Degats")] Arme arme)
        {
            if (ModelState.IsValid)
            {
                db.Armes.Add(arme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arme);
        }

        // GET: Armes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arme arme = db.Armes.Find(id);
            if (arme == null)
            {
                return HttpNotFound();
            }
            return View(arme);
        }

        // POST: Armes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Degats")] Arme arme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arme);
        }

        // GET: Armes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arme arme = db.Armes.Find(id);
            if (arme == null)
            {
                return HttpNotFound();
            }
            return View(arme);
        }

        // POST: Armes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arme arme = db.Armes.Find(id);
            foreach (var samourai in db.Samourais)
            {
                if (samourai.Arme != null && samourai.Arme.Id == id)
                {
                    samourai.Arme = null;
                    db.Entry(samourai).State = EntityState.Modified;
                  
                }
            }
            db.Armes.Remove(arme);
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
