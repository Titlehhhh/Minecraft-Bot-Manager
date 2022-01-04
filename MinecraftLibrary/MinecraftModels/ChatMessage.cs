using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftModels
{
    public class ChatMessage 
    {
        public string Json { get; private set; }
        public bool IsJson { get;private set; }

        public ChatMessage(string json,bool isJson = true)
        {
            Json = json;
            IsJson = isJson;
        }

    }

}
