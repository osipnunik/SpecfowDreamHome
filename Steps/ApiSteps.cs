using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Authenticators;
using SpecFlowDreanLotteryHome.entities;
using System;
using System.Collections.Generic;
using System.Net;
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


        [When(@"get list of basket items id")]
        public void WhenGetListOfBasketItemsId()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"delete product")]
        public void ThenDeleteProduct()
        {          
            var client = new RestClient("https://staging-api.rafflehouse.com");
            client.Authenticator = new HttpBasicAuthenticator("proton001@lenta.ru", "sobaka1");
            var request = new RestRequest("/api/orders/", Method.DELETE); ///{id}
            //request.AddParameter("order", "6059b30c43924400342eb1c8");
            request.AddParameter("application/json", "{order: \"6059e7fd43924400342f4078\"}", ParameterType.RequestBody);
            var response = client.Execute(request);
            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;
            Assert.AreEqual(200, numericStatusCode, response.Content);
        }

        /*[Then(@"get all fixed odds")]
        public void ThenGetAllFixedOdds()
        {
            var client = new RestClient("https://staging-api.rafflehouse.com/api/fixedOdds?pageNumber=1&pageCount=12");
            client.Authenticator = new HttpBasicAuthenticator("proton001@lenta.ru", "sobaka");
            var request = new RestRequest("/api/orders/{id}", Method.GET);
            //request.AddParameter("id", "6054a7297c3eef003daa7821");

            var response = client.Execute(request);
            
            Assert.AreEqual("", JsonConvert.DeserializeObject<List<Object>>(response.Content)[0]);
        }*/

    }
}
