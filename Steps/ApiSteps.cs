using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowDreanLotteryHome.Steps
{
    [Binding]
    class ApiSteps : BaseStepDefinition
    {

        [When(@"api testing")]
        public void WhenApiTesting()
        {
            var client = new RestClient();
            //client.Authenticator = new HttpBasicAuthenticator("testqaanuitex@gmail.com", "1111111");

            var request = new RestRequest("http://localhost:8888/api/raffles/?number=1&count=2");

            IRestResponse<List<Ruffles>> restResponse = client.Get<List<Ruffles>>(request);

            var response = client.Get(request);
            var result = response.Content;

            Console.WriteLine("!!restResponse!!: " + JsonConvert.DeserializeObject<List<Ruffles>>(restResponse.Content)[0]);
            
            //Console.WriteLine("JsonConvert.DeserializeObject(res: " + JsonConvert.DeserializeObject/*<List<Ruffles>>*/(result));

           /* Console.WriteLine("DataCount: " + restResponse.Data.Count);
            Console.WriteLine("Data: " + restResponse.Data);

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.IsSuccessful);*/
        }

    }
}
