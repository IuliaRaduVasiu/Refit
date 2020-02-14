using System.Collections.Generic;
using Newtonsoft.Json;

namespace Refit
{
     public class StoryList
{
        public List<StoryInfo> Stories { get; set; }
        public int StoriesCount { get; set; }
    }
}