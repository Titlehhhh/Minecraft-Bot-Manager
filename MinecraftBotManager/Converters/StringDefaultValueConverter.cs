﻿using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Converters
{
    public class StringDefaultValueConverter : IValueConverter
    {
        public string DefaultValue { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string str = (string)value;
            if (string.IsNullOrEmpty(str))
                return DefaultValue;

            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
