using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Validator
{
    public class IngredientValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = false;
            if (value != null)
            {
                List<int> ListeIngredient = value as List<int>;
                if (ListeIngredient.Count() >= 2 && ListeIngredient.Count() <= 5)
                {
                    result = true;
                }
            }
            
            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Il doit y avoir entre 2 et 5 ingredients par pizza !!";
        }
    }
}
