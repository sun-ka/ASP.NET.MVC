using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PerformingValidationsDemo
{
    public class CityValidator
    {

        public static ValidationResult IsCityValid(string City, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(City))
                return new ValidationResult("City cannot be null or white space");

            if (City.ToLower().Equals("hyderabad") || City.ToLower().Equals("cyberabad"))
                return ValidationResult.Success;

            return new ValidationResult("City can only be either Hyderabad or Cyberabad");
        }

    }
}