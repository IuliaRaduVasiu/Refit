using System.Threading.Tasks;
using Refit;

namespace Refit
{
    public class StoryDelete
    {
        private string url;
        private string cookie;

        public StoryDelete(string url, string cookie)
        {
            this.url = url;
            this.cookie = cookie;
        }

             public interface IDeleteAStory
        {

            [Post("/stories/delete/")]
            Task<StoryList> DeleteStory([Body(BodySerializationMethod.UrlEncoded)] DeleteStory storyId);

        }
    }
}