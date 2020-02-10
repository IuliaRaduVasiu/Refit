using System.Threading.Tasks;
using Refit;

namespace Refit
{
    public class EndVoting
    {
        private string url;
        private string cookie;

        public EndVoting(string url, string cookie)
        {
            this.url = url;
            this.cookie = cookie;
        }

            public interface IFinishVoting
            {
                [Post("/stories/finish/")]
                Task Finish([Body(BodySerializationMethod.UrlEncoded)] FinishVoting gameId);
            }
            
    }
}