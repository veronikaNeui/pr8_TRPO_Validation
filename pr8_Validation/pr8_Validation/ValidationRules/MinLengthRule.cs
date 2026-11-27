using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr8_Validation.ValidationRules
{
    class MinLengthRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            if (input.Length < 3)
            {
                return new ValidationResult(false, "Минимум 3 символа");
            }
            return ValidationResult.ValidResult;
        }
    }
}
