using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;

namespace MinecraftBotManager.Models
{
    public struct Element 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TargetLanguage Language { get; set; }
        public PackIconKind Icon { get; set; }

        public ElementType Identifier { get; set; }

        public Element(string name, string description, TargetLanguage language, PackIconKind icon, ElementType identifier)
        {
            Name = name;
            Description = description;
            Language = language;
            Icon = icon;
            Identifier = identifier;
        }
    }
}
