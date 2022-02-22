using System;
using NUnit.Framework;
using RestSharp;


namespace NewProject
{
    public class ApiTest
    {
        [Test]
        public void Test()
        {
            var client = new RestClient("https://petstore.swagger.io/v2/pet/");
            var restRequest = new RestRequest("findByStatus?status=available");
            var restResponse = client.Get(restRequest);
            
            Assert.AreEqual(200, (int)restResponse.StatusCode);
            Assert.IsNotEmpty(restResponse.Content);

           // Console.WriteLine(restResponse.Content);
        }
        
    }
}