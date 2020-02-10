using Newtonsoft.Json;

namespace Refit
{
        public class Story
    {
        [JsonProperty("gameId")]
          public int RoomId {get; set; }
          public string name {get; set;}

    }
}