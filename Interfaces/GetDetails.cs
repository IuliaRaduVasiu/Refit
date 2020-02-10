using System.Threading.Tasks;
using Refit;

namespace Refit
{
    public class GetDetails
    {
        private string url;
        private string cookie;

        public GetDetails(string url, string cookie)
        {
            this.url = url;
            this.cookie = cookie;
        }

             public interface IDetails
        {

            [Post("/stories/get/")]
            Task<StoryList> GetStoryDetails([Body(BodySerializationMethod.UrlEncoded)] StoryDetails roomDetails); //Intoarce o lista cu toare story-urile dintr-un room);
        }
    }
}