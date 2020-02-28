using Xunit;
using System.Net.Http;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using System;
using Newtonsoft.Json.Serialization;

namespace Refit
{
    public class StoryFormData
    {
        public static Story CreateStoryInfo(string storyName, GameInfo info)
        {
            return new Story
            {
                GameId = info.GameId,
                Name = storyName
            };
        }

        public static QueryInfo StoryDetails(GameInfo info)
        {
            return new QueryInfo
            {
                GameId = info.GameId,
                Page = 1,
                Skip = 0,
                PerPage = 25,
                Status = 0
            };
        }
    }
}