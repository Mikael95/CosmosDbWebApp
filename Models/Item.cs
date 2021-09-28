using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SimpleAzureCosmosDbWebApp.Models
{
    // Song model
    public class Item
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("band")]
        public string Band { get; set; }
        [JsonPropertyName("singer")]
        public string Singer { get; set; }
        [JsonPropertyName("link")]
        public string Link { get; set; }
    }
}
