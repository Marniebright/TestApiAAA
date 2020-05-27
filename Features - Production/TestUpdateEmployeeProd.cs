using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace TestEmployeeApi
{
    [TestClass]
    public class TestUpdateEmployeeProd
    {
        private static string endpoint = "http://dummy.restapiexample.com/api/v1";
        private static string route = "update/{id}";
        private static string employee =  @"{
            id = '128',
            name = 'aba',
            salary = '20,000',
            age = '20'
        }";

        [TestMethod]
        public void TestEmployeeUpdate()
        {
            RestClient client = new RestClient(endpoint);
            RestRequest request = new RestRequest(route, Method.PUT);
            request.AddParameter("id", "2", ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(employee);
            IRestResponse response = client.Execute(request);
            
            Assert.AreEqual("application/json; charset=utf-8", response.ContentType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        // [TestMethod]
        // public void TestInvalidUpdateEmployee()
        // {
        //     RestClient client = new RestClient(endpoint);
        //     RestRequest request = new RestRequest(route, Method.PUT);
        //     request.AddParameter("id", "aaaa", ParameterType.UrlSegment);
        //     request.RequestFormat = DataFormat.Json;
        //     request.AddJsonBody(employee);
        //     IRestResponse response = client.Execute(request);
            
        //     Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        // }
    }
}