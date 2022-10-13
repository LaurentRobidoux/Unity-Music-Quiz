using System;
using Newtonsoft.Json;

namespace Music.Entities
{
    public partial class Choice
    {
        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}