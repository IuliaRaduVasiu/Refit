using System.Threading.Tasks;
using Refit;

namespace Refit
{
    public class RoomDelete
    {
        private string url;
        private string cookie;

        public RoomDelete(string url, string cookie)
        {
            this.url = url;
            this.cookie = cookie;
        }

        public interface IDelete
        {
            [Delete("/games/delete")]
            Task  DeleteRoom([Body]int gameId);
        }
    }
}