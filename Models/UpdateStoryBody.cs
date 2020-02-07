using System.Collections.Generic;
using Newtonsoft.Json;

namespace Refit
{
    public class UpdateStoryBody
    {
        [JsonProperty("storyId")]
        public int StoryId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("estimate")]
        public int Estimate { get; set; }
    }

}