using Newtonsoft.Json;

namespace Refit
{
    public class StartVotingBody
    {
        [JsonProperty("gameId")]
        public int GameId { get; set; }
    }
}