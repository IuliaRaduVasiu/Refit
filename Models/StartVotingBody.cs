using Newtonsoft.Json;

namespace Refit
{
    public class StartVoting
    {
        [JsonProperty("gameId")]
        public int GameId { get; set; }
    }
}