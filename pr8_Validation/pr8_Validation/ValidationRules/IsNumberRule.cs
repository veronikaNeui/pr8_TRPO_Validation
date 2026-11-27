using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace pr8_Validation.ValidationRules
{
    class IsNumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, "Введите число");
            }

            // Если value уже является строкой (что чаще всего и бывает при вводе)
            string input = value as string;
            if (input == null)
            {
                input = value.ToString();
            }

            // Убираем пробелы
            input = input.Trim();

            // Проверяем на пустоту
            if (string.IsNullOrEmpty(input))
            {
                return new ValidationResult(false, "Введите число");
            }

            // Пытаемся распарсить
            if (!int.TryParse(input, out int intvalue))
            {
                return new ValidationResult(false, "Необходимо ввести число");
            }

            // Проверяем на положительность
            if (intvalue <= 0)
            {
                return new ValidationResult(false, "Число должно быть больше нуля");
            }

            return ValidationResult.ValidResult;
        }
    }
}
