using Xunit;
using System.Net.Http;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using System;
using Newtonsoft.Json.Serialization;

namespace Refit
{
    public class StoryFormData
    {
        public  Story StoryBody(string roomName, string userName, string adress, string storyName)
        {
           var storyDetails = new Story
            {
                //GameId = RoomFormData.CreateRoom(roomName, userName, adress).GameId,
                Name = storyName
            };
             return storyDetails;
        }

        public static Room CardTypeBody(string roomName, int cardType)
        {
            var roomBody = new Room
            {
                Name = roomName,
                CardSetType = cardType,
                HaveStories = true,
                ShowVotingToObservers = true,
                ConfirmSkip = true,
                AutoReveal = true,
                ChangeVote = false,
                CountdownTimer = false,
                CountdownTimerValue = 30
            };
            return roomBody;
        }
    }
}