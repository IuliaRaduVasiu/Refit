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
            Task<StoryInfo> CreateStory([Body(BodySerializationMethod.UrlEncoded)] Story roomId);

            [Post("/stories/update/")]
            Task<StoryList> ChangeStoryName([Body(BodySerializationMethod.UrlEncoded)] UpdateStory newStoryName);

            [Post("/stories/delete/")]
            Task<StoryList> DeleteStory([Body(BodySerializationMethod.UrlEncoded)] DeleteStory storyId);

            
        }
    }
}