
using MinecraftBotManager.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Services
{
    public class StorageService : IStorageService
    {
        public Task<object> LoadObjectAsync(string filename)
        {
            return Task<object>.Run(() =>
            {
                try
                {
                    using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        return bin.Deserialize(fs);
                    }
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.ToString());
                    return null;
                }
            });
        }
        private readonly object locker = new object();
        public Task SaveObjectAsync(object data, string filename)
        {
            return Task.Run(() =>
            {
                lock (locker)
                {
                    using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(fs, data);
                    }
                }
            });
        }
       
    }
}
