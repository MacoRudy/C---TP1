using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Validator
{
    public class UniqueIngredientValidator : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            bool result = true;

            if (value != null)
            {
                List<int> ListeIdsIngredients = value as List<int>;
                List<Pizza> listePizza = FakeDb.Instance.ListePizzas.Where(x => x.Ingredients.Count == ListeIdsIngredients.Count).ToList();
                if (listePizza.Count > 0)
                {

                    List<int> idsIngredientPizza = new List<int>();
                    foreach (var pizza in listePizza)
                    {
                        idsIngredientPizza = pizza.Ingredients.Select(x => x.Id).ToList();
                        if (ListeIdsIngredients.SequenceEqual(idsIngredientPizza))
                        {
                            result = false;
                        }

                    }
                }
            }
            return result;
        }
        public override string FormatErrorMessage(string name)
        {
            return "Ce combo de d'ingredients existe déjà";
        }



    }
}
