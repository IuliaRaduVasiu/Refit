using Newtonsoft.Json;

namespace Refit
{
    public class DeleteStory
    {
        [JsonProperty("gameId")]
        public int GameId { get; set; }
        
        [JsonProperty("storyId")]
        public int StoryId { get; set; }
    }
}