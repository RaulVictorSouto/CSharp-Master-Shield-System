using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSLibrary
{
    public class ValidadorClass
    {
        public static IEnumerable<ValidationResult> ValidarObjeto(object obj)
        {
            List<ValidationResult> validationResultList = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(obj, null, null);
            Validator.TryValidateObject(obj, validationContext, validationResultList, true);
            return validationResultList;
        }
    }
}
