using Newtonsoft.Json;

namespace Refit
{
    public class GameInfo
    {
        [JsonProperty("gameId")]
        public int GameId { get; set; }
        
        [JsonProperty("gameCode")]
        public string GameCode { get; set; }
    }
}