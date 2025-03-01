using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ECommerce.MVC.Areas.Admin.Views.Shared.Validations
{
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            var currentValue = (DateTime)value;

            var comparisonProperty = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (comparisonProperty == null)
            {
                return new ValidationResult($"'{_comparisonProperty}' adlı özellik bulunamadı.");
            }

            var comparisonValue = comparisonProperty.GetValue(validationContext.ObjectInstance);

            if (comparisonValue == null)
            {
                return new ValidationResult($"'{_comparisonProperty}' alanı zorunludur.");
            }

            var comparisonDateTime = (DateTime)comparisonValue;

            if (currentValue <= comparisonDateTime)
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} değeri, {_comparisonProperty} değerinden büyük olmalıdır.");
            }

            return ValidationResult.Success;
        }
    }
}