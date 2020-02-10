using System;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace Refit
{
    public class StartVotingSession
    {
        private string url;
        private string cookie;

        public StartVotingSession(string url, string cookie)
        {
            this.url = url;
            this.cookie = cookie;
        }


        
            public interface IVoting
            {
                [Post("/stories/next/")]
                Task<StartVotingDetails> Start([Body(BodySerializationMethod.UrlEncoded)] StartVoting gameId);
            }
    }
}