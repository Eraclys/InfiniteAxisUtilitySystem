using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace InfiniteAxisUtilitySystem.Persistence
{
    public static class Serializer
    {
        static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
        };

        public static string Serialize(IntelligenceDatabase database) =>
            JsonConvert.SerializeObject(
                database,
                Formatting.Indented,
                SerializerSettings);

        public static IntelligenceDatabase Deserialize(string value) =>
            JsonConvert.DeserializeObject<IntelligenceDatabase>(
                value,
                SerializerSettings);
    }
}


