using Newtonsoft.Json;

namespace Refit
{
        public class Voting
    {
        [JsonProperty("gameId")]
          public int GameId {get; set; }

          [JsonProperty("vote")]
          public int Vote {get; set;}

    }
}