using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.Services
{
    public class Resolver
    {
        public void MinecraftServerLookup(ref string domain,ref ushort port)
        {
            try
            {
                
                Heijden.DNS.Response response = new Heijden.DNS.Resolver().Query("_minecraft._tcp." + domain, Heijden.DNS.QType.SRV);
                Heijden.DNS.RecordSRV[] srvRecords = response.RecordsSRV;
                if (srvRecords != null && srvRecords.Any())
                {
                    //Order SRV records by priority and weight, then randomly
                    Heijden.DNS.RecordSRV result = srvRecords
                        .OrderBy(record => record.PRIORITY)
                        .ThenByDescending(record => record.WEIGHT)
                        .ThenBy(record => Guid.NewGuid())
                        .First();
                    string target = result.TARGET.Trim('.');                    
                    domain = target;
                    port = result.PORT;
                    
                }              

            }
            catch
            {
               
            }
            
        }
    }
}
