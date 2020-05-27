using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace TestEmployeeApi
{
    [TestClass]
    public class TestDeleteEmployeeProd
    {
        private static string endpoint = "http://dummy.restapiexample.com/api/v1";
        private static string route = "delete/{id}";
        
        [TestMethod]
        public void TestEmployeeDeletion()
        {
            RestClient client = new RestClient(endpoint);
            RestRequest request = new RestRequest(route, Method.DELETE);
            request.AddParameter("id", "18", ParameterType.UrlSegment);
            IRestResponse response = client.Execute(request);
            
            Assert.AreEqual("application/json; charset=utf-8", response.ContentType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        // [TestMethod]
        // public void TestInvalidEmployeeDeletion()
        // {
        //     RestClient client = new RestClient(endpoint);
        //     RestRequest request = new RestRequest(route, Method.DELETE);
        //     request.AddParameter("id", "aaaa", ParameterType.UrlSegment);
        //     IRestResponse response = client.Execute(request);
            
        //     Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        // }
    }
}