using Newtonsoft.Json;

namespace HandsOnApi.Models
{
    public abstract class Document
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
    }
}
