using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP4Pizza.Models;

namespace TP4Pizza.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
                        
            return View(FakeDb.Instance.ListePizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaCreateViewModel pizzaVM = new PizzaCreateViewModel();
            pizzaVM.Ingredients = FakeDb.Instance.ListeIngredients;
            pizzaVM.Pate = FakeDb.Instance.ListePates;
            return View(pizzaVM);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaCreateViewModel pizzaVM)
        {
            try
            {
                pizzaVM.Pizza.Pate = FakeDb.Instance.ListePates.FirstOrDefault(x => x.Id == pizzaVM.IdPate);
                foreach (var item in pizzaVM.IdsIngredient)
                {
                    pizzaVM.Pizza.Ingredients.Add(FakeDb.Instance.ListeIngredients.FirstOrDefault(x => x.Id == item));

                }
                FakeDb.Instance.ListePizzas.Add(pizzaVM.Pizza);


           

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
