using System;
using Newtonsoft.Json;

namespace Music.Entities
{
    public partial class Playlist
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("questions")]
        public Question[] Questions { get; set; }

        [JsonProperty("playlist")]
        public string Name { get; set; }
    }
}