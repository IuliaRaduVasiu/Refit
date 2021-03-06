﻿// using Xunit;
// using System.Net.Http;
// using System.IO;
// using System.Text;
// using Newtonsoft.Json;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Refit;
// using System;
// using Newtonsoft.Json.Serialization;

// namespace Refit
// {
//     public class VotingFeature
//     {
//         private const string adress = "https://www.planitpoker.com/api";
//         private const string userName = "Iulia";
//         private const string roomName = "Teste Room";
//         private const string newName = "Test Room2";
//         private const string storyName = "Test Story";
//         private const string newStoryName = "Gigel";
//         private const int cardType = 4;
//         private const int selectedCard = 6;
//         private GameInfo info = new GameInfo().GameId;


//         [Fact]
//         public async void Authentification()
//         {
//             //Scenario: Authentification page
//             // Given the user is in the authentification page
//             // When he inputs the username

//             var dictionary = new Dictionary<string, string> { { "name", userName } };
//             var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
//             var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
//             var response = await client.SendAsync(request);
//             response.EnsureSuccessStatusCode();

//             // A temporary user is created

//             Assert.NotNull(response);
//         }



//         [Fact]
//         public async void CreateRoom()
//         {
//             //Scenario: Creating a room
//             //Given the user has created a username
//             var dictionary = new Dictionary<string, string> { { "name", userName } };
//             var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
//             var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
//             var response = await client.SendAsync(request);
//             response.EnsureSuccessStatusCode();

//             //When the user creates a room

//             var roomBody = RoomFormData.RoomBody(roomName);
//             var roomActions = RestService.For<IRoom>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var info = await roomActions.NewRoom(roomBody);

//             //Then the room is created

//             Assert.NotNull(info);
//         }
//         [Fact]
//         public async void NewRommName()
//         {
//             //Scenario: Changing the room name
//             //Given a user creates a username in the application

//             var dictionary = new Dictionary<string, string> { { "name", userName } };
//             var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
//             var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
//             var response = await client.SendAsync(request);
//             response.EnsureSuccessStatusCode();

//             //When the user creates a room

//             var roomBody = RoomFormData.RoomBody(roomName);
//             var roomActions = RestService.For<IRoom>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var info = await roomActions.NewRoom(roomBody);
//             var newRoomName = RoomFormData.RoomBody(newName);
//             var newRoomNameActions = RestService.For<IRoom>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });



//             //Then the user can change the room name
//             var newInfo = await newRoomNameActions.NewRoomName(newRoomName);
//         }

//         [Fact]
//         public async void DeteleRoom()
//         {
//             //Scenario: Deleting a room
//             //Given a user creates a username in the application

//             var dictionary = new Dictionary<string, string> { { "name", userName } };
//             var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
//             var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
//             var response = await client.SendAsync(request);
//             response.EnsureSuccessStatusCode();

//             //When the user creates a room

//             var roomBody = RoomFormData.RoomBody(roomName);
//             var roomActions = RestService.For<IRoom>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var info = await roomActions.NewRoom(roomBody);

//             //Then the user can delete the room
//             var delete = RestService.For<IRoom>(adress, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });


//         }

//         [Fact]
//         public async void CardSelection()
//         {
//             //Screnatio: Setting the card type
//             //Given the user created a temporary username

//             var dictionary = new Dictionary<string, string> { { "name", userName } };
//             var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
//             var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
//             var response = await client.SendAsync(request);
//             response.EnsureSuccessStatusCode();

//             //When the user creates a room

//             var roomBody = RoomFormData.CardTypeBody(roomName, cardType);
//             var roomActions = RestService.For<IRoom>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var info = await roomActions.NewRoom(roomBody);
//             //Then the user can set a card type

//             Assert.NotNull(info);
//         }

//         [Fact]
//         public async void CreateStory()
//         {
//             //Scenario: Creating a story
//             //Given a user creates a username in the application

//             var dictionary = new Dictionary<string, string> { { "name", userName } };
//             var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
//             var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
//             var response = await client.SendAsync(request);
//             response.EnsureSuccessStatusCode();

//             //When the user creates a room

//             var roomBody = RoomFormData.RoomBody(roomName);
//             var createRoom = RoomFormData.CreateRoom(roomName, userName, adress);
//             var createStory = StoryFormData.CreateStoryInfo(storyName, info);
//             var storyDetails = StoryFormData.StoryDetails(info);

//             //Then the user can create a story
//             Assert.NotNull(storyDetails);
//         }


//         [Fact]
//         public async void NewStoryName()
//         {
//             //Scenario: Changeing the story name
//             // Given a user creates a temporary account

//             var dictionary = new Dictionary<string, string> { { "name", userName } };
//             var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
//             var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
//             var response = await client.SendAsync(request);
//             response.EnsureSuccessStatusCode();

//             // When the user creates a voting session

//             var roomBody = RoomFormData.RoomBody(roomName);
//             var roomActions = RestService.For<IRoom>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var info = await roomActions.NewRoom(roomBody);
//             var createRoom = RoomFormData.CreateRoom(roomName, userName, adress);
//             var createStory = StoryFormData.CreateStoryInfo(storyName, info);
//             var storyActions = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });

//             var storyDetails = StoryFormData.StoryDetails(info);
//             var storyDetailsList = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var allStoryDetails = await storyDetailsList.GetStoryDetails(storyDetails);


//             var newStoryNameDetails = new UpdateStory
//             {
//                 StoryId = allStoryDetails.Stories[0].Id,
//                 Title = newStoryName
//             };
//             var newstoryDetailsList = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });

//             allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

//             //Then the user cand change the name
//             Assert.Equal(allStoryDetails.Stories[0].Title, newStoryName);
//         }

//         [Fact]
//         public async void DeleteStory()
//         {
//             //Scenario: Deleting a story
//             //Given a user creates a temporary account

//             var dictionary = new Dictionary<string, string> { { "name", userName } };
//             var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
//             var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
//             var response = await client.SendAsync(request);
//             response.EnsureSuccessStatusCode();

//             //When the user creates a voting session

//             var roomDetails = new Room
//             {
//                 Name = roomName,
//                 CardSetType = 1,
//                 HaveStories = true,
//                 ShowVotingToObservers = true,
//                 ConfirmSkip = true,
//                 AutoReveal = true,
//                 ChangeVote = false,
//                 CountdownTimer = false,
//                 CountdownTimerValue = 30
//             };
//             var roomActions = RestService.For<IRoom>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var info = await roomActions.NewRoom(roomDetails);

//             var storyDetails = new Story
//             {
//                 GameId = info.GameId,
//                 Name = storyName
//             };
//             var storyActions = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//                     new JsonSerializerSettings
//                     {
//                         ContractResolver = new CamelCasePropertyNamesContractResolver()
//                     }
//             )
//             });

//             var allStoryNameDetails = new QueryInfo
//             {
//                 GameId = info.GameId,
//                 Page = 1,
//                 Skip = 0,
//                 PerPage = 25,
//                 Status = 0
//             };
//             var storyDetailsList = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

//             var deleteDetails = new DeleteStory
//             {
//                 GameId = info.GameId,
//                 StoryId = allStoryDetails.Stories[0].Id
//             };
//             var deleteStoryDetails = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });

//             //Then the user can detele a story


//         }

//         [Fact]
//         public async void StartVoting()
//         {
//             //Scenario: Starting a voting session
//             //Given a user creates a temporary account

//             var dictionary = new Dictionary<string, string> { { "name", userName } };
//             var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
//             var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
//             var response = await client.SendAsync(request);
//             response.EnsureSuccessStatusCode();

//             //When the user creates a room

//             var roomDetails = new Room
//             {
//                 Name = roomName,
//                 CardSetType = 1,
//                 HaveStories = true,
//                 ShowVotingToObservers = true,
//                 ConfirmSkip = true,
//                 AutoReveal = true,
//                 ChangeVote = false,
//                 CountdownTimer = false,
//                 CountdownTimerValue = 30
//             };
//             var roomActions = RestService.For<IRoom>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var info = await roomActions.NewRoom(roomDetails);

//             var storyDetails = new Story
//             {
//                 GameId = info.GameId,
//                 Name = storyName
//             };
//             var storyActions = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });

//             var allStoryNameDetails = new QueryInfo
//             {
//                 GameId = info.GameId,
//                 Page = 1,
//                 Skip = 0,
//                 PerPage = 25,
//                 Status = 0
//             };
//             var storyDetailsList = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

//             var startBody = new StartVoting
//             {
//                 GameId = info.GameId
//             };
//             var stratActions = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var startDetails = await stratActions.Start(startBody);

//             //Then the user cand start a voting session
//             Assert.NotNull(stratActions);
//         }

//         [Fact]
//         public async void SelectCard()
//         {
//             //Scenario: Card selectio
//             //Given a user creates a temporary account

//             var dictionary = new Dictionary<string, string> { { "name", userName } };
//             var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
//             var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
//             var response = await client.SendAsync(request);
//             response.EnsureSuccessStatusCode();

//             //When the user start a voting session

//             var roomDetails = new Room
//             {
//                 Name = roomName,
//                 CardSetType = 1,
//                 HaveStories = true,
//                 ShowVotingToObservers = true,
//                 ConfirmSkip = true,
//                 AutoReveal = true,
//                 ChangeVote = false,
//                 CountdownTimer = false,
//                 CountdownTimerValue = 30
//             };
//             var roomActions = RestService.For<IRoom>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var info = await roomActions.NewRoom(roomDetails);

//             var storyDetails = new Story
//             {
//                 GameId = info.GameId,
//                 Name = storyName
//             };
//             var storyActions = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });

//             var allStoryNameDetails = new QueryInfo
//             {
//                 GameId = info.GameId,
//                 Page = 1,
//                 Skip = 0,
//                 PerPage = 25,
//                 Status = 0
//             };
//             var storyDetailsList = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

//             var startBody = new StartVoting
//             {
//                 GameId = info.GameId
//             };
//             var stratActions = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var startDetails = await stratActions.Start(startBody);

//             var selectedVote = new Voting
//             {
//                 GameId = info.GameId,
//                 Vote = selectedCard
//             };
//             var voteActions = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });

//             //Then the user can select a card
//         }

//         [Fact]
//         public async void FinishVotingSession()
//         {
//             //Scenario: Card selectio
//             //Given a user creates a temporary account

//             var dictionary = new Dictionary<string, string> { { "name", userName } };
//             var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
//             var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
//             var response = await client.SendAsync(request);
//             response.EnsureSuccessStatusCode();

//             //When the user start a voting session

//             var roomDetails = new Room
//             {
//                 Name = roomName,
//                 CardSetType = 1,
//                 HaveStories = true,
//                 ShowVotingToObservers = true,
//                 ConfirmSkip = true,
//                 AutoReveal = true,
//                 ChangeVote = false,
//                 CountdownTimer = false,
//                 CountdownTimerValue = 30
//             };
//             var roomActions = RestService.For<IRoom>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var info = await roomActions.NewRoom(roomDetails);

//             var storyDetails = new Story
//             {
//                 GameId = info.GameId,
//                 Name = storyName
//             };
//             var storyActions = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });

//             var allStoryNameDetails = new QueryInfo
//             {
//                 GameId = info.GameId,
//                 Page = 1,
//                 Skip = 0,
//                 PerPage = 25,
//                 Status = 0
//             };
//             var storyDetailsList = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

//             var startBody = new StartVoting
//             {
//                 GameId = info.GameId
//             };
//             var stratActions = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });
//             var startDetails = await stratActions.Start(startBody);

//             var selectedVote = new Voting
//             {
//                 GameId = info.GameId,
//                 Vote = selectedCard
//             };
//             var voteActions = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             ı
//     )
//             });


//             var finishVotingBody = new VoteEnd
//             {
//                 GameId = info.GameId,
//                 Estimate = selectedCard
//             };
//             var finishVotingActions = RestService.For<IStory>(client, new RefitSettings
//             {
//                 ContentSerializer = new JsonContentSerializer(
//             new JsonSerializerSettings
//             {
//                 ContractResolver = new CamelCasePropertyNamesContractResolver()
//             }
//     )
//             });

//             //Then the user cand finish the voting session

//         }
//     }
// }
