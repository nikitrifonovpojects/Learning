using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Logger.Common
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize<T>(T input)
        {
            return JsonConvert.SerializeObject(input);
        }
    }
}
