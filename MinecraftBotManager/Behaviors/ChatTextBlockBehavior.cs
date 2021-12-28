using MinecraftLibrary;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace MinecraftBotManager.Behaviors
{
    public class ChatTextBlockBehavior : Behavior<TextBlock>
    {


        public string Json
        {
            get { return (string)GetValue(JsonProperty); }
            set
            {
                SetValue(JsonProperty, value);
                ParseText();
            }
        }

        // Using a DependencyProperty as the backing store for Json.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty JsonProperty =
            DependencyProperty.Register("Json", typeof(string), typeof(ChatTextBlockBehavior), new PropertyMetadata(""));

        protected override void OnAttached()
        {
            ParseText();
            base.OnAttached();
        }

        public static readonly Dictionary<string, string> rules = new Dictionary<string, string>
        {
            ["chat.type.admin"] = "[{0}: {1}]",
            ["chat.type.announcement"] = "[{0}] {1}",
            ["chat.type.emote"] = " * {0} {1}",
            ["chat.type.text"] = "<{0}> {1}",
            ["multiplayer.player.joined"] = "{0} joined the game.",
            ["multiplayer.player.left"] = "{0} left the game.",
            ["commands.message.display.incoming"] = "{0} whispers to you: {1}",
            ["commands.message.display.outgoing"] = "{0} whisper to {1}: {2}"
        };
        private void ParseText()
        {
            AssociatedObject.Inlines.Clear();
            try
            {
                JObject json = JObject.Parse(Json);
                
                Console.WriteLine(json.ToString(Newtonsoft.Json.Formatting.Indented));


                AssociatedObject.Inlines.AddRange(JsonToInlines(json, FontWeights.Normal, FontStyles.Normal, Brushes.White));
            }
            catch (Newtonsoft.Json.JsonReaderException e)
            {
                Console.WriteLine(e.ToString() + " Строка: \n" + Json);
            }
        }
        private static List<Inline> JsonToInlines(JToken json, FontWeight weight, FontStyle style, SolidColorBrush color)
        {
            List<Inline> result = new List<Inline>();





            switch (json.Type)
            {
                case JTokenType.Object:
                    JObject currentObj = (JObject)json;
                    if (currentObj.ContainsKey("color"))
                    {
                        color = CodeToColor(json.Value<string>("color"));
                    }
                    if (currentObj.ContainsKey("italic"))
                    {
                        if (json.Value<bool>("italic"))
                            style = FontStyles.Italic;
                    }
                    if (currentObj.ContainsKey("bold"))
                    {
                        if (json.Value<bool>("bold"))
                            weight = FontWeights.Bold;
                    }
                    if (currentObj.ContainsKey("extra"))
                    {
                        foreach (var item in currentObj.Value<JArray>("extra"))
                        {
                            result.AddRange(JsonToInlines(item, weight, style, color));
                        }
                    }
                    if (currentObj.ContainsKey("text"))
                    {
                        result.AddRange(JsonToInlines(json.Value<string>("text"), weight, style, color));
                    }
                    else if (currentObj.ContainsKey("translate"))
                    {
                        if (currentObj.ContainsKey("using") && !currentObj.ContainsKey("with"))
                            json["with"] = json["using"];
                        if (currentObj.ContainsKey("with"))
                        {
                            foreach(var item in Translate(currentObj.Value<JArray>("with"), currentObj.Value<string>("translate")))
                            {
                                item.Foreground = color;
                                item.FontWeight = weight;
                                item.FontStyle = style;
                                result.Add(item);
                            }
                            
                        }
                    }
                    break;
                case JTokenType.Array:
                    foreach (var item in json.Value<JArray>())
                    {
                        result.AddRange(JsonToInlines(item, weight, style, color));
                    }
                    break;
                case JTokenType.String:
                    List<Run> runs = StrToRuns(json.Value<string>());
                    runs.ForEach(r =>
                    {
                        r.FontWeight = weight;
                        r.FontStyle = style;
                        r.Foreground = color;
                    });
                    result.AddRange(runs);
                    break;
            }



            return result;
        }
    

        public static List<Run> Translate(JArray with, string rule)
        {
            List<Run> result = new List<Run>();
            List<string> datas = new List<string>();
            foreach(var item in with)
            {
                datas.Add(JsonTostr(item));
            }
            Run run = new Run();
            run.Text = string.Format(rules[rule],datas.ToArray());
            result.Add(run);

            return result;
        }
        public static string JsonTostr(JToken token)
        {
            string result = "";
            switch (token.Type)
            {
                case JTokenType.Object:
                    JObject obj = (JObject)token;
                    if (obj.ContainsKey("text"))
                    {
                        result += JsonTostr(obj.Value<string>("text"));
                    }
                    return result;
                    break;
                case JTokenType.String:
                    return token.Value<string>();
                    break;
            }
            return result;
        }

        public static List<Run> StrToRuns(string str)
        {
            List<Run> result = new List<Run>();
            Run run = new Run(str);
            result.Add(run);


            return result;
        }
        public static SolidColorBrush CodeToColor(string code)
        {
            switch (code)
            {
                case "black": return Brushes.Black;
                case "dark_blue": return Brushes.DarkBlue;
                case "dark_green": return Brushes.DarkGreen;
                case "dark_aqua": case "dark_cyan": return Brushes.DarkCyan;
                case "dark_red": return Brushes.DarkRed;
                case "dark_purple": case "dark_magenta": return Brushes.DarkMagenta;
                case "gold": case "dark_yellow": return Brushes.Gold;
                case "gray": return Brushes.Gray;
                case "dark_gray": return Brushes.DarkGray;
                case "blue": return Brushes.Blue;
                case "green": return Brushes.Green;
                case "aqua": case "cyan": return Brushes.Aqua;
                case "red": return Brushes.Red;
                case "light_purple": case "magenta": return Brushes.Magenta;
                case "yellow": return Brushes.Yellow;
                case "white": return Brushes.White;
                default: return Brushes.White;
            }
        }
    }
}
