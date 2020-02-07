using Newtonsoft.Json;

namespace Refit
{
        public class VotingBody
    {
        [JsonProperty("gameId")]
          public int GameId {get; set; }

          [JsonProperty("vote")]
          public int Vote {get; set;}

    }
}