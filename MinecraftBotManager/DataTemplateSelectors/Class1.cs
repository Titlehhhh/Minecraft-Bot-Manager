using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MinecraftBotManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MinecraftBotManager.DataTemplateSelectors
{
    public class HostBoxDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate StandartTempalte { get; set; }
        public DataTemplate LoadindTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            Trace.WriteLine("gg");
            SearchItem model = (SearchItem)item;
            if (model.IsLoaded)
            {
                return LoadindTemplate;
            }
            return StandartTempalte;
        }
        protected override bool IsOverridableInterface(Guid iid)
        {
            Trace.WriteLine("gg2");
            return base.IsOverridableInterface(iid);
        }
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            Trace.WriteLine("gg3");
            return base.SelectTemplateCore(item, container);
        }
    }
}
