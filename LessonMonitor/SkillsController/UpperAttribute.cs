using System;
using System.ComponentModel.DataAnnotations;

namespace SkillsController
{
    public class UpperAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                var ch = value.ToString()[0];
                if (ch.ToString() == ch.ToString().ToUpper())
                {
                    return true;
                }
            }
            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"Invalid field {name}, the first letter must be capitalized.";
        }
    }
}