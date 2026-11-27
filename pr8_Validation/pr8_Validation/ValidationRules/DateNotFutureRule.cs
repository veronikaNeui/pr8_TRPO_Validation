using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr8_Validation.ValidationRules
{
    class DateNotFutureRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is DateTime date)
            {
                if (date.Date > DateTime.Now.Date)
                {
                    return new ValidationResult(false, "Дата не может быть из будущего");
                }
                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Некорректная дата");
        }

    }
}
