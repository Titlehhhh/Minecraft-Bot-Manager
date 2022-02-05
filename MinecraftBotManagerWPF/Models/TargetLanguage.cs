using System.ComponentModel;
using MinecraftBotManager.Converters;

namespace MinecraftBotManager.Models
{
    [TypeConverter(typeof(DescriptionConverter))]
    public enum TargetLanguage
    { 
        [Description("Visual C#")]
        CSharp,        
        Python,        
        Lua
    }
}
