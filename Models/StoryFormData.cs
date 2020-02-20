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
        public static async Task<StoryInfo> CreateStory(string roomName, string userName, string adress, string storyName)
        {
           var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var roomBody = RoomFormData.RoomBody(roomName);
            var roomActions = RestService.For<CreateRoom.IRoom>(client, new RefitSettings {
        ContentSerializer = new JsonContentSerializer( 
            new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
        }
    )});
            var info = await roomActions.NewRoom(roomBody);
            var storyDetails = new Story
            {
                GameId = info.GameId,
                Name = storyName
            };
             var storyActions = RestService.For<NewStory.IStory>(client, new RefitSettings {
        ContentSerializer = new JsonContentSerializer( 
            new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
        }
    )});
            var storyInfo = await storyActions.CreateStory(storyDetails);

            return storyInfo;
        }

        public static async Task<StoryList> StoryDetails(string roomName, string userName, string adress, string storyName)
        {
           var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var roomBody = RoomFormData.RoomBody(roomName);
            var roomActions = RestService.For<CreateRoom.IRoom>(client, new RefitSettings {
        ContentSerializer = new JsonContentSerializer( 
            new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
        }
    )});
            var info = await roomActions.NewRoom(roomBody);
            var storyDetails = new Story
            {
                GameId = info.GameId,
                Name = storyName
            };
             var storyActions = RestService.For<NewStory.IStory>(client, new RefitSettings {
        ContentSerializer = new JsonContentSerializer( 
            new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
        }
    )});
            var storyInfo = await storyActions.CreateStory(storyDetails);

              var allStoryNameDetails = new StoryDetails
            {
                GameId = info.GameId,
                Page = 1, 
                Skip = 0,
                PerPage = 25,
                Status = 0
            };
            var storyDetailsList = RestService.For<GetDetails.IDetails>(client, new RefitSettings {
        ContentSerializer = new JsonContentSerializer( 
            new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
        }
    )});
            var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

            return allStoryDetails;
        }
    }
}