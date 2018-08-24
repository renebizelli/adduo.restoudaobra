using Newtonsoft.Json;

namespace adduo.helper.serialization
{
    public class SerializerHelper
    {
        public static T Deserializer<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
