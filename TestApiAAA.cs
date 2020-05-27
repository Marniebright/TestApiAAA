using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace TestApiAAA
{
    [TestClass]
    public class TestApiAAA
    {
        [TestMethod]
        public void TestGetEmployees()
        {
            RestClient client = new RestClient("http://localhost:3000");
            ///RestClient client = new RestClient("http://dummy.restapiexample.com/");
            RestRequest request = new RestRequest("employee", Method.GET);
            IRestResponse response = client.Execute(request);
            
            Assert.AreEqual(response.ContentType, "application/json; charset=utf-8");
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void TestGetEmployeeById()
        {
            RestClient client = new RestClient("http://localhost:3000");
            ///RestClient client = new RestClient("http://dummy.restapiexample.com/");
            RestRequest request = new RestRequest("employee/{id}", Method.GET);
            request.AddUrlSegment("id", 1);
            //IRestResponse response = client.Execute(request);
        }
    }
}