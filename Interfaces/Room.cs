using System.Threading.Tasks;
using Refit;

namespace Refit
{
    public class CreateRoom
    {
        public interface IRoom
        {
            [Post("/games/create/")]
            Task<GameInfo> NewRoom([Body(BodySerializationMethod.UrlEncoded)] Room name);

            [Post("/games/edit/")]
            Task<GameInfo> NewRoomName([Body(BodySerializationMethod.UrlEncoded)]Room name);

            [Delete("/games/delete")]
            Task  DeleteRoom([Body]int gameId);
        }
    }
}