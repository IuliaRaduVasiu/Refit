using System.Threading.Tasks;
using Refit;

namespace Refit
{
    public class NewStory
    {
        private string url;
        private string cookie;

        public NewStory(string url, string cookie)
        {
            this.url = url;
            this.cookie = cookie;
        }

             public interface IStory
        {
            [Post("/stories/create/")]
            Task<StoryInfo> CreateStory([Body(BodySerializationMethod.UrlEncoded)] Story roomId, Story name);
        }
    }
}