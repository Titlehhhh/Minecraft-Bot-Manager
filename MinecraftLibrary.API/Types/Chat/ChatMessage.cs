﻿using System.Text.Json;

namespace MinecraftLibrary.API.Types.Chat
{
    public class ChatMessage
    {
        public string Text { get; set; }

        public HexColor Color { get; set; }

        public bool Bold { get; set; }

        public bool Italic { get; set; }

        public bool Underlined { get; set; }

        public bool Strikethrough { get; set; }

        public bool Obfuscated { get; set; }

        public string Insertion { get; set; }

        public ClickComponent ClickEvent { get; set; }

        public HoverComponent HoverEvent { get; set; }

        public List<ChatMessage> Extra { get; private set; }


        public IEnumerable<ChatMessage> Extras => GetExtras();

        public IEnumerable<ChatMessage> GetExtras()
        {
            if (Extra == null)
                yield break;

            foreach (var extra in Extra)
            {
                yield return extra;
            }
        }

        public static implicit operator ChatMessage(string text) => Simple(text);

        public static ChatMessage operator +(ChatMessage a, ChatMessage b) => a.AddExtra(b);

        public static ChatMessage operator +(ChatMessage a, ChatColor b) => a.AppendColor(b);

        public static ChatMessage Simple(string text) => new() { Text = text };

        public static ChatMessage SimpleLegacy(string text) => new() { Text = ReformatAmpersandPrefixes(text) };

        public static ChatMessage Simple(string text, ChatColor color) => new()
        {
            Text = $"{color}{text}"
        };

        public static ChatMessage SimpleLegacy(string text, ChatColor color) => new()
        {
            Text = $"{color}{ReformatAmpersandPrefixes(text)}"
        };

        public static ChatMessage Click(ChatMessage message, EClickAction action, string value, string translate = "")
        {
            message.ClickEvent = new ClickComponent(action, value, translate);
            return message;
        }

        public static ChatMessage Hover(ChatMessage message, EHoverAction action, object contents, string translate = "")
        {
            message.HoverEvent = new HoverComponent(action, contents, translate);
            return message;
        }

        public static string ReformatAmpersandPrefixes(string originalText)
        {
            return string.Create(originalText.Length, originalText, (span, text) =>
            {
                for (int i = 0; i < span.Length; i++)
                {
                    char c = text[i];
                    span[i] = c;

                    if (c == '&' && i + 1 < text.Length)
                    {
                        c = text[i + 1];
                        if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'e') || (c >= 'k' && c <= 'o') || c == 'r')
                        {
                            span[i] = '§';
                        }
                    }
                }
            });
        }

        public ChatMessage AddExtra(ChatMessage message)
        {
            Extra ??= new List<ChatMessage>();
            Extra.Add(message);

            return this;
        }

        public ChatMessage AddExtra(List<ChatMessage> messages)
        {
            Extra ??= new List<ChatMessage>(capacity: messages.Count);
            Extra.AddRange(messages);

            return this;
        }

        public ChatMessage AddExtra(IEnumerable<ChatMessage> messages)
        {
            foreach (var message in messages)
            {
                AddExtra(message);
            }

            return this;
        }

        public ChatMessage AppendText(string text)
        {
            if (Text is null)
            {
                Text = text;
            }
            else
            {
                Text += text;
            }
            return this;
        }

        public ChatMessage AppendColor(ChatColor color)
        {
            if (Text is null)
            {
                Text = color.ToString();
            }
            else
            {
                Text += color.ToString();
            }

            return this;
        }

        public ChatMessage AppendText(string text, ChatColor color)
        {
            if (Text is null)
            {
                Text = $"{color}{text}";
            }
            else
            {
                Text += $"{color}{text}";
            }
            return this;
        }

        public ChatMessage()
        {

        }
        public ChatMessage(string json)
        {

        }

        public static ChatMessage Empty => Simple(string.Empty);

        public string ToString(JsonSerializerOptions options) => JsonSerializer.Serialize(this, options);
    }
}
