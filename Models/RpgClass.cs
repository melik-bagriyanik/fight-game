using System.Text.Json.Serialization;

namespace udemy_dotnet.models
{ 
    [JsonConverter(typeof(JsonStringEnumConverter))] // This allows the enum to be serialized as a string
        public enum RpgClass//
    {
        knight,// A brave and strong warrior
        mage,   // A master of elemental magic
        cleric, // A healer and protector
    }
}