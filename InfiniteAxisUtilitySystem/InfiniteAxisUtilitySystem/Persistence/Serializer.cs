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

        public static string Serialize(IntelligenceDefinition intelligenceDefinition) =>
            JsonConvert.SerializeObject(
                intelligenceDefinition,
                Formatting.Indented,
                SerializerSettings);

        public static IntelligenceDefinition Deserialize(string value) =>
            JsonConvert.DeserializeObject<IntelligenceDefinition>(
                value,
                SerializerSettings);
    }
}


