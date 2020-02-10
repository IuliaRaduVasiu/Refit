using Newtonsoft.Json;
namespace Refit
{
        public class FinishVoting
    {
        [JsonProperty("gameId")]
          public int GameId {get; set; }

          [JsonProperty("estimate")]
          public int Estimate {get; set;}

    }
}