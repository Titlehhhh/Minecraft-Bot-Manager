using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Reflection;
using System.ComponentModel;

namespace MinecraftBotManager.Converters
{
    public class NameAttributeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Type t = value.GetType();
            DisplayNameAttribute result = t.GetCustomAttribute<DisplayNameAttribute>();
            return result == null ? t.Name : result.DisplayName; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
