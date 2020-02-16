using Xunit;
using System.Net.Http;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using System;

namespace Refit
{
    public class RoomFormData
    {
        public static Room RoomBody(string roomName)
        {
            var roomBody = new Room
            {
                Name = roomName,
                CardSetType = 1,
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