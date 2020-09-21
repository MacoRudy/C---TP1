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
            PizzaCreateViewModel vm = new PizzaCreateViewModel();
            vm.Pizza = FakeDb.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
            return View(vm);

        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaCreateViewModel pizzaVM = new PizzaCreateViewModel();
            pizzaVM.Ingredients = FakeDb.Instance.ListeIngredients;
            pizzaVM.Pate = FakeDb.Instance.ListePates;
            Random rand = new Random();
            pizzaVM.IdPate = FakeDb.Instance.ListePates[rand.Next(3)].Id;
            return View(pizzaVM);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaCreateViewModel pizzaVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pizzaVM.Pizza.Id = FakeDb.Instance.ListePizzas.Count == 0 ? 1 : FakeDb.Instance.ListePizzas.Max(x => x.Id) + 1;
                    pizzaVM.Pizza.Pate = FakeDb.Instance.ListePates.FirstOrDefault(x => x.Id == pizzaVM.IdPate);
                    foreach (var item in pizzaVM.IdsIngredient)
                    {
                        pizzaVM.Pizza.Ingredients.Add(FakeDb.Instance.ListeIngredients.FirstOrDefault(x => x.Id == item));
                    }
                    FakeDb.Instance.ListePizzas.Add(pizzaVM.Pizza);
                    return RedirectToAction("Index");
                }
                else
                {
                    pizzaVM.Ingredients = FakeDb.Instance.ListeIngredients;
                    pizzaVM.Pate = FakeDb.Instance.ListePates;
                    return View(pizzaVM);
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaCreateViewModel pizzaVM = new PizzaCreateViewModel();
            pizzaVM.Pizza = FakeDb.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
            pizzaVM.Ingredients = FakeDb.Instance.ListeIngredients;
            pizzaVM.Pate = FakeDb.Instance.ListePates;
            pizzaVM.IdPate = pizzaVM.Pizza.Pate.Id;
            pizzaVM.IdsIngredient = new List<int>();
            //pizzaVM.IdsIngredient = pizzaVM.Pizza.Ingredients.Select(x => x.Id).ToList();
            foreach (var item in pizzaVM.Pizza.Ingredients)
            {
                pizzaVM.IdsIngredient.Add(item.Id);
            }

            return View(pizzaVM);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PizzaCreateViewModel pizzaVM)
        {
            try
            {
                // recuperation de la pizza de la liste
                Pizza pizzaEdite = FakeDb.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
                // recuperation de la pate selectionnée
                pizzaEdite.Pate = FakeDb.Instance.ListePates.FirstOrDefault(x => x.Id == pizzaVM.IdPate);
                pizzaEdite.Nom = pizzaVM.Pizza.Nom;
                pizzaEdite.Ingredients.Clear();

                foreach (var item in pizzaVM.IdsIngredient)
                {
                    pizzaEdite.Ingredients.Add(FakeDb.Instance.ListeIngredients.FirstOrDefault(x => x.Id == item));

                }
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
            PizzaCreateViewModel pizzaVM = new PizzaCreateViewModel();
            pizzaVM.Pizza = FakeDb.Instance.ListePizzas.FirstOrDefault(x => x.Id == id);
            return View(pizzaVM);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PizzaCreateViewModel pizzaVM)
        {
            try
            {
                FakeDb.Instance.ListePizzas.Remove(FakeDb.Instance.ListePizzas.FirstOrDefault(x => x.Id == id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
