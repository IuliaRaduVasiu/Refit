using System.Threading.Tasks;
using Refit;

namespace Refit
{
    public class NewName
    {
        private string url;
        private string cookie;

        public NewName(string url, string cookie)
        {
            this.url = url;
            this.cookie = cookie;
        }

        public interface IChangeRoomName
        {
             [Post("/games/edit/")]
            Task<GameInfo> NewRoomName([Body(BodySerializationMethod.UrlEncoded)]Room name);
        }
    }
}