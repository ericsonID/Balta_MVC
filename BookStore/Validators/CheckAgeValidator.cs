using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Validators
{
    public class CheckAgeValidator:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = (DateTime)value;
            if ((date.Year - 18) > 0)
            {
                return new ValidationResult("Somente maiores de idade");
            }
            return ValidationResult.Success;
        }
    }
}