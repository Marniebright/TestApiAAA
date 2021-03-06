using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Serialization.Json;

namespace TestEmployeeApi
{
    [TestClass]
    public class TestGetEmployee
    {
        private static string endpoint = "http://localhost:3000";
        private static string routeForAllEmployee = "employees";
        private static string routeForSingleEmployee = "employees/{id}";
    
        [TestMethod]
        public void TestGetAllEmployees()
        {
            RestClient client = new RestClient(endpoint);
            RestRequest request = new RestRequest(routeForAllEmployee, Method.GET);
            IRestResponse response = client.Execute(request);
             
            Assert.AreEqual("application/json; charset=utf-8", response.ContentType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void TestNotFoundEmployees()
        {
            RestClient client = new RestClient(endpoint);
            RestRequest request = new RestRequest("employee", Method.GET);
            IRestResponse response = client.Execute(request);
             
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        [TestMethod]
        public void TestGetEmployeeById()
        {
            RestClient client = new RestClient(endpoint);
            RestRequest request = new RestRequest(routeForSingleEmployee, Method.GET);
            request.AddParameter("id", "1", ParameterType.UrlSegment);
            IRestResponse response = client.Execute(request);

            JsonDeserializer jsonDeserializer = new JsonDeserializer();
            var output = jsonDeserializer.Deserialize<Dictionary<string,string>>(response);
           
            Assert.AreEqual("application/json; charset=utf-8", response.ContentType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(output["id"], "1");
        }

        [TestMethod]
        public void TestGetEmployeeByInvalidId()
        {
            RestClient client = new RestClient(endpoint);
            RestRequest request = new RestRequest(routeForSingleEmployee, Method.GET);
            request.AddParameter("id", "11010101", ParameterType.UrlSegment);
            IRestResponse response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}