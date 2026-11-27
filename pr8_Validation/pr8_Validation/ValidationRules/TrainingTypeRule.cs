using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr8_Validation.ValidationRules
{
    class TrainingTypeRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (value ?? "").ToString().Trim();
            string[] allowed = { "Силовая", "Кардио", "Функциональная", "Интервальная", "Восстановительная" };

            if (Array.IndexOf(allowed, input) == -1)
            {
                return new ValidationResult(false, "Недопустимый тип тренировки");
            }
            
            return ValidationResult.ValidResult;
        }
    }
}
