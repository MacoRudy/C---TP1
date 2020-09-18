using BO;
using BO.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP4Pizza.Models
{
    public class PizzaCreateViewModel
    {
        public Pizza Pizza { get; set; }

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        [IngredientValidator]
        public List<int> IdsIngredient { get; set; } = new List<int>();

        public List<Pate> Pate { get; set; } = new List<Pate>();

        public int IdPate { get; set; }
    }
}