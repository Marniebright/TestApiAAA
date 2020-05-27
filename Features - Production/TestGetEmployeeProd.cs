using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace TestEmployeeApi
{
    [TestClass]
    public class TestGetEmployeeProd
    {
        private static string endpoint = "http://dummy.restapiexample.com/api/v1";
        private static string routeForAllEmployee = "employees";
        private static string routeForSingleEmployee = "employee/{id}";
    
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

        // [TestMethod]
        // public void TestGetEmployeeById()
        // {
        //     RestClient client = new RestClient(endpoint);
        //     RestRequest request = new RestRequest(routeForSingleEmployee, Method.GET);
        //     request.AddParameter("id", "1", ParameterType.UrlSegment);
        //     IRestResponse response = client.Execute(request);

        //     Assert.AreEqual("application/json; charset=utf-8", response.ContentType);
        //     Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        // }

        [TestMethod]
        public void TestGetEmployeeByInvalidId()
        {
            RestClient client = new RestClient(endpoint);
            RestRequest request = new RestRequest(routeForSingleEmployee, Method.GET);
            request.AddParameter("id", "11010101", ParameterType.UrlSegment);
            IRestResponse response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}