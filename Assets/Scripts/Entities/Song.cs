using System;
using Newtonsoft.Json;
namespace Music.Entities
{

    public partial class Song
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("picture")]
        public Uri Picture { get; set; }

        [JsonProperty("sample")]
        public Uri Sample { get; set; }
    }
}
