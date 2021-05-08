using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReflectionAttributes.Attributes
{
    public class MyDateGreaterThanAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = DateTime.Parse(value.ToString());

            if (value != null && date > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
