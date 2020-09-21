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

            bool result = true;
            if (value != null)
            {
                string nomPizza = value as string;

                foreach (var item in FakeDb.Instance.ListePizzas)
                {
                    if (item.Nom.ToLower().Equals(nomPizza.ToLower()))
                    {
                        result = false;
                    }
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
