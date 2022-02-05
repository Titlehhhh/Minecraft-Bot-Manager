using MinecraftLibrary.MinecraftModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace MinecraftBotManager.ViewModel
{
    public class ChatMessageVM
    {
        public ChatMessage Model { get; set; }
        public List<Run> ColoredText { get; set; } = new List<Run>();
        public ChatMessageVM(ChatMessage chatMessage)
        {
            Model = chatMessage;
            string json = chatMessage.Json;
            if (chatMessage.IsJson)
            {

                try
                {
                    JObject obj = JObject.Parse(json);
                    ColoredText = JsonToInlines(obj, FontWeights.Normal, FontStyles.Normal, Brushes.White);
                }
                catch
                {
                    ColoredText = StrToRuns(json);
                }
            }
            else
            {
                ColoredText = new List<Run> { new Run(json) };
            }
        }
        public ChatMessageVM()
        {
                
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
        private static List<Run> JsonToInlines(JToken json, FontWeight weight, FontStyle style, SolidColorBrush color)
        {
            List<Run> result = new List<Run>();





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
                            foreach (var item in Translate(currentObj.Value<JArray>("with"), currentObj.Value<string>("translate")))
                            {

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
                        if (r.FontWeight == FontWeights.Normal)
                            r.FontWeight = weight;
                        if (r.FontStyle == FontStyles.Normal)
                            r.FontStyle = style;
                        if (r.Foreground == Brushes.White)
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
            foreach (var item in with)
            {
                datas.Add(JsonTostr(item));
            }

            result.AddRange(StrToRuns(string.Format(rules[rule], datas.ToArray())));

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
                    if (obj.ContainsKey("extra"))
                    {
                        result += JsonTostr(obj.Value<JArray>("extra"));
                    }
                    return result;
                    break;
                case JTokenType.Array:
                    foreach (var item in token.Value<JArray>())
                    {
                        result += JsonTostr(item);
                    }
                    break;
                case JTokenType.String:
                    return token.Value<string>();
                    break;
            }
            return result;
        }
        static char[] colors = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
        static char[] styles = { 'k', 'l', 'm', 'n', 'o' };
        public static List<Run> StrToRuns(string str)
        {
            List<Run> result = new List<Run>();


            char colorCode = 'f';
            HashSet<string> styles_ = new HashSet<string>();
            string currentStr = "";
            bool flag = false;
            for (int i = 0; i < str.Length; i++)
            {
                char debugChar = str[i];

                if (str[i] == '§' && i + 1 < str.Length)
                {
                    if (colors.Contains(str[i + 1]))
                    {

                        if (currentStr != string.Empty)
                        {
                            Run run = new Run(currentStr);
                            currentStr = "";
                            run.Foreground = CodeToBrush(colorCode.ToString());
                            foreach (var item in styles_)
                            {
                                StylingRun(run, item);
                            }
                            result.Add(run);

                        }
                        styles_.Clear();
                        colorCode = str[i + 1];
                        i += 1;
                        continue;
                    }
                    else if (styles.Contains(str[i + 1]))
                    {

                        if (currentStr != string.Empty)
                        {
                            Run run = new Run(currentStr);
                            currentStr = "";
                            run.Foreground = CodeToBrush(colorCode.ToString());
                            foreach (var item in styles_)
                            {
                                StylingRun(run, item);
                            }
                            result.Add(run);

                        }
                        styles_.Add(str[i + 1].ToString());
                        i += 1;
                        continue;
                    }
                    else if (str[i + 1] == 'r')
                    {
                        Run run = new Run(currentStr);
                        run.Foreground = CodeToBrush(colorCode.ToString());
                        foreach (var item in styles_)
                        {
                            StylingRun(run, item);
                        }
                        currentStr = "";
                        styles_.Clear();
                        colorCode = 'f';
                        i += 1;
                        continue;

                    }
                    else
                    {
                        currentStr += str[i].ToString() + str[i + 1].ToString();
                        i += 1;
                        continue;
                    }




                }
                else
                {
                    currentStr += str[i];
                }

                if (i == str.Length - 1 && currentStr != string.Empty)
                {
                    Run run = new Run(currentStr);
                    run.Foreground = CodeToBrush(colorCode.ToString());
                    styles_.Add(str[i].ToString());
                    foreach (var item in styles_)
                    {
                        StylingRun(run, item);
                    }
                    result.Add(run);
                }
            }


            return result;
        }
        public static void StylingRun(Run run, string code)
        {
            switch (code)
            {
                case "l":
                    run.FontWeight = FontWeights.Bold;
                    break;
                case "m":
                    run.TextDecorations.Add(TextDecorations.Strikethrough);
                    break;
                case "n":
                    run.TextDecorations.Add(TextDecorations.Underline);
                    break;
                case "o":
                    run.FontStyle = FontStyles.Italic;
                    break;

            }
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
        public static SolidColorBrush CodeToBrush(string code)
        {
            switch (code)
            {
                case "0": return Brushes.Black;
                case "1": return Brushes.DarkBlue;
                case "2": return Brushes.DarkGreen;
                case "3": return Brushes.DarkCyan;
                case "4": return Brushes.DarkRed;
                case "5": return Brushes.DarkMagenta;
                case "6": return Brushes.Gold;
                case "7": return Brushes.Gray;
                case "8": return Brushes.DarkGray;
                case "9": return Brushes.Blue;
                case "a": return Brushes.Green;
                case "b": return Brushes.Aqua;
                case "c": return Brushes.Red;
                case "d": return Brushes.Magenta;
                case "e": return Brushes.Yellow;
                case "f": return Brushes.White;
                default: return Brushes.White;
            }
        }
    }
}
