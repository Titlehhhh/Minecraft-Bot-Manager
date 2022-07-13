
using MinecraftBotManager.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MinecraftBotManager.Services
{
    public class JsonSerializationService : ISerializationService
    {
        private readonly DataContractJsonSerializerSettings Settings =
            new DataContractJsonSerializerSettings
            { UseSimpleDictionaryFormat = true };
        public TValue Deserialize<TValue>(string path, params object[] constructorArgs)
        {
            try
            {
                using (var stream = File.OpenRead(path))
                {
                    var currentCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

                    try
                    {
                        var serializer = new DataContractJsonSerializer(typeof(TValue), Settings);
                        var item = (TValue)serializer.ReadObject(stream);
                        if (Equals(item, null)) throw new Exception();
                        return item;
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception.ToString());
                        return (TValue)Activator.CreateInstance(typeof(TValue), constructorArgs);
                    }
                    finally
                    {
                        Thread.CurrentThread.CurrentCulture = currentCulture;
                    }
                }
            }
            catch
            {
                return (TValue)Activator.CreateInstance(typeof(TValue), constructorArgs);
            }
        }

        public void Serialize<TValue>(TValue item, string path)
        {
            try
            {
                using (var stream = File.Open(path, FileMode.Create))
                {
                    var currentCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

                    try
                    {
                        using (var writer = JsonReaderWriterFactory.CreateJsonWriter(
                            stream, Encoding.UTF8, true, true, "  "))
                        {
                            var serializer = new DataContractJsonSerializer(typeof(TValue), Settings);
                            serializer.WriteObject(writer, item);
                            writer.Flush();
                        }
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception.ToString());
                    }
                    finally
                    {
                        Thread.CurrentThread.CurrentCulture = currentCulture;
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.ToString());
            }
        }
    }
}
