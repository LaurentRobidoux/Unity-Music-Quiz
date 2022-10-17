using System;
using Newtonsoft.Json;

namespace Music.Entities
{
    [Serializable]
    public partial class Song
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("picture")]
        public string Picture { get; set; }

        [JsonProperty("sample")]
        public string Sample { get; set; }
    }
}