using Newtonsoft.Json;

namespace Refit
{
        public class Story
    {
        [AliasAs("gameId")]
          public int GameId {get; set; }
          [AliasAs("name")]
          public string Name {get; set;}

    }
}