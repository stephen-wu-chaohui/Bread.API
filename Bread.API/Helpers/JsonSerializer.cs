using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Bread.API.Helpers
{
    internal sealed class JsonSerializer
    {
        private static readonly JsonSerializerSettings Settings = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public static string SerializeObject(object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.Indented, Settings);
        }
    }
}
