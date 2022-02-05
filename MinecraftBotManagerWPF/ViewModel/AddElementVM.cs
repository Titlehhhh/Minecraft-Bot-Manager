using GalaSoft.MvvmLight;
using MinecraftBotManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignThemes.Wpf;

namespace MinecraftBotManager.ViewModel
{
    public class AddElementVM : ViewModelBase
    {
        public static List<Element> Patterns { get; } = new List<Element>();
        static AddElementVM()
        {
            Patterns.Add(new Element("Класс","", TargetLanguage.CSharp,PackIconKind.LanguageCsharp,ElementType.CS_Class));
            Patterns.Add(new Element("Класс", "", TargetLanguage.CSharp, PackIconKind.LanguageCsharp, ElementType.CS_Class));
            Patterns.Add(new Element("Класс", "", TargetLanguage.CSharp, PackIconKind.LanguageCsharp, ElementType.CS_Class));

        }
    }
}
