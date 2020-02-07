using Newtonsoft.Json;

namespace Refit
{
        public class StoryBody
    {
        [JsonProperty("gameId")]
          public int RoomId {get; set; }
          public string name {get; set;}

    }
}