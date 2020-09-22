using BOSamourai;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using TP5Samourai.Data;
using TP5Samourai.Models;

namespace TP5Samourai.Controllers
{
    public class SamouraisController : Controller
    {
        private TP5SamouraiContext db = new TP5SamouraiContext();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            SamouraiVM vm = new SamouraiVM();
            vm.ListeArmes = db.Armes.ToList();

            return View(vm);
        }

        // POST: Samourais/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiVM samouraiVM)
        {
            if (ModelState.IsValid)
            {

                samouraiVM.Samourai.Arme = db.Armes.FirstOrDefault(x => x.Id == samouraiVM.IdArme);

                db.Samourais.Add(samouraiVM.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(samouraiVM.Samourai);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            SamouraiVM vm = new SamouraiVM();
            if (samourai == null)
            {
                return HttpNotFound();
            }
            else
            {
                vm.Samourai = samourai;
                vm.ListeArmes = db.Armes.ToList();
                if (samourai.Arme != null)
                {
                    vm.IdArme = samourai.Arme.Id;
                }

            }


            return View(vm);
        }

        // POST: Samourais/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiVM vm)
        {
            if (ModelState.IsValid)
            {
                Samourai samourai = db.Samourais.FirstOrDefault(x => x.Id == vm.Samourai.Id);
                var arme = samourai.Arme;
                samourai.Arme = db.Armes.FirstOrDefault(x => x.Id == vm.IdArme);
                samourai.Force = vm.Samourai.Force;
                samourai.Nom = vm.Samourai.Nom;
                db.Entry(samourai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
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
