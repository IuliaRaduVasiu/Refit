using Newtonsoft.Json;

namespace Refit
{
    public class DeleteStory
    {
        public int GameId { get; set; }
        public int StoryId { get; set; }
    }
}