using System.Collections.Generic;
using Newtonsoft.Json;

namespace Refit
{
    public class UpdateStory
    {
        public int StoryId { get; set; }

        public string Title { get; set; }
        public int Estimate { get; set; }
    }

}