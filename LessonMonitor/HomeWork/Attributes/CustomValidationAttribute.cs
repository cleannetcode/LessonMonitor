using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork.Attributes
{
    public class CustomValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string text = value.ToString();

                if (string.IsNullOrWhiteSpace(text))
                    return false;


                return true;
            }

            return false;
        }
    }
}
