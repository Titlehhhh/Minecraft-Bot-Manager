using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.ComponentModel;

namespace MinecraftBotManager.Markup
{
    public class EnumToCollectionExtension : MarkupExtension
    {
        public Type EnumType { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (EnumType == null) throw new ArgumentNullException(nameof(EnumType));

            return Enum.GetValues(EnumType).Cast<Enum>();
        }
        private string EnumToDesc(Enum value)
        {
            return value.GetType().GetField(value.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .FirstOrDefault()?.Description ?? value.ToString();
        }
    }
}
