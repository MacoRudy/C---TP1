using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Validator
{
    public class NomPizzaValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            bool result = false;
            if (value != null)
            {
                Pizza pizza = value as Pizza;
                if (!FakeDb.Instance.ListePizzas.Contains(pizza))
                {
                    result = true;
                }
                            }
            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Ce nom de pizza existe deja !";
        }
    }
}
