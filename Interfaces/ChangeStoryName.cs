using System.Threading.Tasks;
using Refit;

namespace Refit
{
    public class NewStoryName
    {
        private string url;
        private string cookie;

        public NewStoryName(string url, string cookie)
        {
            this.url = url;
            this.cookie = cookie;
        }

             public interface INewName
        {
            [Post("/stories/update/")]
            Task<StoryList> ChangeStoryName([Body(BodySerializationMethod.UrlEncoded)] UpdateStory newStoryName);
        }
    }
}