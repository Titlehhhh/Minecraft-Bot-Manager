using System.Globalization;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace MinecraftBotManager.Validations
{
    public class IPValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex reg = new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
            return new ValidationResult(reg.IsMatch((value as string) ?? ""), "Неверный формат");
        }
    }
}
