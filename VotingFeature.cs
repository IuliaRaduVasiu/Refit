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
    public class VotingFeature
    {
        private const string adress = "https://www.planitpoker.com/api";
     private const string userName = "Iulia";
     private const string roomName = "Teste Room";
     private const string newName = "Test Room2";
     private const string storyName = "Test Story";
     private const string newStoryName = "Gigel";
     private const int cardType = 4;
     private const int selectedCard = 6;
    
        [Fact]
        public async void Authentification()
        {
            //Scenario: Authentification page
            // Given the user is in the authentification page
            // When he inputs the username

             var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // A temporary user is created

            Assert.NotNull(response);
        }



        [Fact]
        public async void CreateRoom()
        {
             //Scenario: Creating a room
            //Given the user has created a username
             var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

              //When the user creates a room

            var roomDetails = new Room
            {
                name = roomName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<CreateRoom.IRoom>(client);
            var info = await roomActions.NewRoom(roomDetails);

            //Then the room is created

            Assert.NotNull(info);
        }
              [Fact]
        public async void NewRommName()
        {
             //Scenario: Changing the room name
            //Given a user creates a username in the application

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user creates a room

            var roomDetails = new Room
            {
                name = roomName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<CreateRoom.IRoom>(client);
            var info = await roomActions.NewRoom(roomDetails);   

              var newRoomDetails = new Room
            {
                name = newName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var newRoomName = RestService.For<NewName.IChangeRoomName>(client);
           

            //Then the user can change the room name
            var newInfo = await newRoomName.NewRoomName(newRoomDetails);
        }

              [Fact]
        public async void DeteleRoom()
        {
            //Scenario: Deleting a room
            //Given a user creates a username in the application

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user creates a room

            var roomDetails = new Room
            {
                name = roomName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<CreateRoom.IRoom>(client);
            var info = await roomActions.NewRoom(roomDetails);

            //Then the user can delete the room
            var delete = RestService.For<RoomDelete.IDelete>(adress);


        }

             [Fact]
        public async void CardSelection()
        {
            //Screnatio: Setting the card type
            //Given the user created a temporary username

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user creates a room

            var roomDetails = new Room
            {
                name = roomName,
                cardSetType = cardType,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<CreateRoom.IRoom>(client);

            //Then the user can set a card type
            var info = await roomActions.NewRoom(roomDetails);
        }

              [Fact]
        public async void CreateStory()
        {
             //Scenario: Creating a story
            //Given a user creates a username in the application

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user creates a room

            var roomDetails = new Room
            {
                name = roomName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<CreateRoom.IRoom>(client);
            var info = await roomActions.NewRoom(roomDetails);

            var storyDetails = new Story
            {
                RoomId = info.GameId,
                name = storyName
            };
            var storyActions = RestService.For<NewStory.IStory>(client);
            var storyInfo = await storyActions.CreateStory(storyDetails, storyDetails);

              var allStoryNameDetails = new StoryDetails
            {
                gameId = info.GameId,
                page = 1, 
                skip = 0,
                perPage = 25,
                status = 0
            };
            var storyDetailsList = RestService.For<GetDetails.IDetails>(client);
            var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

            //Then the user can create a story
            Assert.Equal(allStoryDetails.Stories[0].Title, storyName);
        }


              [Fact]
        public async void NewStoryName()
        {
            //Scenario: Changeing the story name
            // Given a user creates a temporary account

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // When the user creates a voting session

            var roomDetails = new Room
            {
                name = roomName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<CreateRoom.IRoom>(client);
            var info = await roomActions.NewRoom(roomDetails);

            var storyDetails = new Story
            {
                RoomId = info.GameId,
                name = storyName
            };
            var storyActions = RestService.For<NewStory.IStory>(client);
            var storyInfo = await storyActions.CreateStory(storyDetails, storyDetails);

            var allStoryNameDetails = new StoryDetails
            {
                gameId = info.GameId,
                page = 1, 
                skip = 0,
                perPage = 25,
                status = 0
            };
            var storyDetailsList = RestService.For<GetDetails.IDetails>(client);
            var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

            
             var newStoryNameDetails = new UpdateStory
            {
                StoryId = allStoryDetails.Stories[0].Id,
                Title = newStoryName
            };
            var newstoryDetailsList = RestService.For<NewStoryName.INewName>(client);
            var newStoryDetails = await newstoryDetailsList.ChangeStoryName(newStoryNameDetails);

            allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

            //Then the user cand change the name
            Assert.Equal(allStoryDetails.Stories[0].Title, newStoryName);
        }

                 [Fact]
        public async void DeleteStory()
        {
            //Scenario: Deleting a story
            //Given a user creates a temporary account

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user creates a voting session

            var roomDetails = new Room
            {
                name = roomName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<CreateRoom.IRoom>(client);
            var info = await roomActions.NewRoom(roomDetails);

            var storyDetails = new Story
            {
                RoomId = info.GameId,
                name = storyName
            };
            var storyActions = RestService.For<NewStory.IStory>(client);
            var storyInfo = await storyActions.CreateStory(storyDetails, storyDetails);

            var allStoryNameDetails = new StoryDetails
            {
                gameId = info.GameId,
                page = 1, 
                skip = 0,
                perPage = 25,
                status = 0
            };
            var storyDetailsList = RestService.For<GetDetails.IDetails>(client);
            var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

            var deleteDetails = new DeleteStory
            {
                GameId = info.GameId,
                StoryId = allStoryDetails.Stories[0].Id
            };
            var deleteStoryDetails = RestService.For<StoryDelete.IDeleteAStory>(client);

            //Then the user can detele a story

            var deleteInfo = await deleteStoryDetails.DeleteStory(deleteDetails);

        }

             [Fact]
             public async void StartVoting()
        {
            //Scenario: Starting a voting session
            //Given a user creates a temporary account

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

             //When the user creates a room

            var roomDetails = new Room
            {
                name = roomName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<CreateRoom.IRoom>(client);
            var info = await roomActions.NewRoom(roomDetails);

            var storyDetails = new Story
            {
                RoomId = info.GameId,
                name = storyName
            };
            var storyActions = RestService.For<NewStory.IStory>(client);
            var storyInfo = await storyActions.CreateStory(storyDetails, storyDetails);

              var allStoryNameDetails = new StoryDetails
            {
                gameId = info.GameId,
                page = 1, 
                skip = 0,
                perPage = 25,
                status = 0
            };
            var storyDetailsList = RestService.For<GetDetails.IDetails>(client);
            var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

               var startBody = new  StartVoting
            {
                GameId = info.GameId
            };
            var stratActions = RestService.For<StartVotingSession.IVoting>(client);
            var startDetails = await stratActions.Start(startBody);

            //Then the user cand start a voting session
            Assert.NotNull(stratActions);
        }

            [Fact]
             public async void SelectCard()
        {
            //Scenario: Card selectio
            //Given a user creates a temporary account

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user start a voting session

            var roomDetails = new Room
            {
                name = roomName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<CreateRoom.IRoom>(client);
            var info = await roomActions.NewRoom(roomDetails);

            var storyDetails = new Story
            {
                RoomId = info.GameId,
                name = storyName
            };
            var storyActions = RestService.For<NewStory.IStory>(client);
            var storyInfo = await storyActions.CreateStory(storyDetails, storyDetails);

              var allStoryNameDetails = new StoryDetails
            {
                gameId = info.GameId,
                page = 1, 
                skip = 0,
                perPage = 25,
                status = 0
            };
            var storyDetailsList = RestService.For<GetDetails.IDetails>(client);
            var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

               var startBody = new  StartVoting
            {
                GameId = info.GameId
            };
            var stratActions = RestService.For<StartVotingSession.IVoting>(client);
            var startDetails = await stratActions.Start(startBody);

            var selectedVote = new Voting
            {
                GameId = info.GameId,
                Vote = selectedCard
            };
            var voteActions = RestService.For<StartVotingSession.IVoting>(client);

            //Then the user can select a card
        }

            [Fact]
             public async void FinishVotingSession()
        {
            //Scenario: Card selectio
            //Given a user creates a temporary account

            var dictionary = new Dictionary<string, string> { { "name", userName } };
            var client = new HttpClient() { BaseAddress = new Uri(adress, UriKind.Absolute) };
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/authentication/anonymous") { Content = new FormUrlEncodedContent(dictionary) };
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            //When the user start a voting session

            var roomDetails = new Room
            {
                name = roomName,
                cardSetType = 1,
                haveStories = true,
                showVotingToObservers = true,
                confirmSkip = true,
                autoReveal = true,
                changeVote = false,
                countdownTimer = false,
                countdownTimerValue = 30
            };
            var roomActions = RestService.For<CreateRoom.IRoom>(client);
            var info = await roomActions.NewRoom(roomDetails);

            var storyDetails = new Story
            {
                RoomId = info.GameId,
                name = storyName
            };
            var storyActions = RestService.For<NewStory.IStory>(client);
            var storyInfo = await storyActions.CreateStory(storyDetails, storyDetails);

              var allStoryNameDetails = new StoryDetails
            {
                gameId = info.GameId,
                page = 1, 
                skip = 0,
                perPage = 25,
                status = 0
            };
            var storyDetailsList = RestService.For<GetDetails.IDetails>(client);
            var allStoryDetails = await storyDetailsList.GetStoryDetails(allStoryNameDetails);

               var startBody = new  StartVoting
            {
                GameId = info.GameId
            };
            var stratActions = RestService.For<StartVotingSession.IVoting>(client);
            var startDetails = await stratActions.Start(startBody);

            var selectedVote = new Voting
            {
                GameId = info.GameId,
                Vote = selectedCard
            };
            var voteActions = RestService.For<StartVotingSession.IVoting>(client);   

            
            var finishVotingBody = new FinishVoting
            {
                GameId = info.GameId,
                Estimate = selectedCard
            };
            var finishVotingActions = RestService.For<EndVoting.IFinishVoting>(client); 

            //Then the user cand finish the voting session
            
        }
    }
}