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
    public class RoomFormData
    {
        public static async Task<GameInfo> CreateRoom(string roomName, string userName, string adress)
        {
            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var roomBody = RoomFormData.RoomBody(roomName);
            var roomActions = RestService.For<IRoom>(client, new RefitSettings {
        ContentSerializer = new JsonContentSerializer( 
            new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
        }
    )});
            var info = await roomActions.NewRoom(roomBody);

            return info;
        }
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