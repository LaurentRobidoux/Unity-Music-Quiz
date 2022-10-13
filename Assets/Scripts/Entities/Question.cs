using System;
using Newtonsoft.Json;

namespace Music.Entities
{
    public partial class Question
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("answerIndex")]
        public long AnswerIndex { get; set; }

        [JsonProperty("choices")]
        public Choice[] Choices { get; set; }

        [JsonProperty("song")]
        public Song Song { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }
}