using System.Threading.Tasks;
using Refit;

namespace Refit
{
    public interface IStory
    {
        [Post("/stories/create/")]
        Task CreateStory([Body(BodySerializationMethod.UrlEncoded)] Story roomId);

        [Post("/stories/update/")]
        Task ChangeStoryName([Body(BodySerializationMethod.UrlEncoded)] UpdateStory newStoryName);

        [Post("/stories/delete/")]
        Task DeleteStory([Body(BodySerializationMethod.UrlEncoded)] DeleteStory storyId);

        [Post("/stories/get/")]
        Task<StoryList> GetStoryDetails([Body(BodySerializationMethod.UrlEncoded)] QueryInfo roomDetails);

        [Post("/stories/next/")]
        Task<StartVotingDetails> Start([Body(BodySerializationMethod.UrlEncoded)] StartVoting gameId);

        [Post("/stories/finish/")]
        Task Finish([Body(BodySerializationMethod.UrlEncoded)] VoteEnd gameId);
    }
}