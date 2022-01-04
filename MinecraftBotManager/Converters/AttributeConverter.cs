using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.ComponentModel;
using System.Reflection;

namespace MinecraftBotManager.Converters
{
    public class AttributeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                Type t = (value as Type) ?? value.GetType();
                string code = parameter.ToString();
                switch (code)
                {
                    case "name": return t.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? t.Name;
                    case "desc": return t.GetCustomAttribute<DescriptionAttribute>()?.Description ?? "";
                    default: return "";
                }
            }
            return "Error";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
