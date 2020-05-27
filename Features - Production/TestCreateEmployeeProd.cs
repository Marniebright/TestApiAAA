using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace TestEmployeeApi
{
    [TestClass]
    public class TestCreateEmployeeProd
    {
        private static string endpoint = "http://dummy.restapiexample.com/api/v1";
        private static string route = "create";
        private static string employee =  @"{
            id = '18',
            name = 'aba',
            salary = '20,000',
            age = '20'
        }";

        [TestMethod]
        public void TestEmployeeCreation()
        {
            RestClient client = new RestClient(endpoint);
            RestRequest request = new RestRequest(route, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(employee);
            IRestResponse response = client.Execute(request);

            Assert.AreEqual("application/json; charset=utf-8", response.ContentType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}