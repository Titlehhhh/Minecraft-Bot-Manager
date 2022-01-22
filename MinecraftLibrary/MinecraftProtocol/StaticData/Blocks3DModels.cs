using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json.Linq;
using System.IO.Compression;
using System.IO;

namespace MinecraftLibrary.MinecraftProtocol.StaticData
{
    public static class Blocks3DModels
    {
        public static async Task LoadData(BackgroundWorker worker = null)
        {
            await Task.Run(() =>
            {

                using (MemoryStream ms = new MemoryStream(Properties.Resources.Assets))
                using (ZipArchive zip = new ZipArchive(ms))
                {
                    var blocks = zip.Entries.Where(item => item.FullName.StartsWith("models/block") && item.FullName.EndsWith(".json"));
                    int count = blocks.Count();
                    for (int i = 0; i < count; i++)
                    {
                        using(StreamReader sr = new StreamReader(blocks.ElementAt(i).Open()))
                        {
                            JObject.Parse(sr.ReadToEnd());
                        }
                        int percente = Convert.ToInt32((i + 1d) / count * 100d);
                        worker?.ReportProgress(percente, new LoadState(LoadState.State.Blocks, blocks.ElementAt(i).Name));

                    }
                    var items = zip.Entries.Where(item => item.FullName.StartsWith("models/item") && item.FullName.EndsWith(".json"));
                     count = items.Count();
                    for (int i = 0; i < count; i++)
                    {
                        using (StreamReader sr = new StreamReader(items.ElementAt(i).Open()))
                        {
                            JObject.Parse(sr.ReadToEnd());
                        }
                        //Console.WriteLine(i);
                        int percente = Convert.ToInt32((i + 1d) / count * 100d);
                        worker?.ReportProgress(percente, new LoadState(LoadState.State.Items, items.ElementAt(i).Name));

                    }
                }                
            });
            
        }
    }
    public struct LoadState
    {
        public enum State { Blocks, Items }
        public State StateLoad { get; private set; }        
        public string Description { get; private set; }

        public LoadState(State stateLoad, string description)
        {
            StateLoad = stateLoad;
           
            Description = description;
        }
    }

}
