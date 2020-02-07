using Newtonsoft.Json;
namespace Refit
{
        public class FinishVotingBody
    {
        [JsonProperty("gameId")]
          public int GameId {get; set; }

          [JsonProperty("estimate")]
          public int Estimate {get; set;}

    }
}