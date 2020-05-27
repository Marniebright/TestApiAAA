using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace TestEmployeeApi
{
    [TestClass]
    public class TestGetEmployee
    {
        private string localhost = "http://localhost:3000";
    
        [TestMethod]
        public void TestGetAllEmployees()
        {
            RestClient client = new RestClient(localhost);
            RestRequest request = new RestRequest("employees", Method.GET);
            IRestResponse response = client.Execute(request);
             
            Assert.AreEqual("application/json; charset=utf-8", response.ContentType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void TestNotFoundEmployees()
        {
            RestClient client = new RestClient(localhost);
            RestRequest request = new RestRequest("employee", Method.GET);
            IRestResponse response = client.Execute(request);
             
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void TestGetEmployeeById()
        {
            RestClient client = new RestClient(localhost);
            //RestClient client = new RestClient(endPoint);
            RestRequest request = new RestRequest("employees/{id}", Method.GET);
            request.AddParameter("id", "1", ParameterType.UrlSegment);
            IRestResponse response = client.Execute(request);

            Assert.AreEqual("application/json; charset=utf-8", response.ContentType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}