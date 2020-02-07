using System.Collections.Generic;
using Newtonsoft.Json;

namespace Refit
{
     public class StoryList
    {
        [JsonProperty("stories")]
        public List<StoryInfo> Stories { get; set; }

        [JsonProperty("storiesCount")]
        public int StoriesCount { get; set; }
    }
}