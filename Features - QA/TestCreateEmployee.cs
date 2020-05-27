using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace TestEmployeeApi
{
    [TestClass]
    public class TestCreateEmployee
    {
        private static string endpoint = "http://localhost:3000";
        private static string route = "employees";
        private Employee employee = new Employee {
            id = "18",
            employee_name = "aba",
            employee_salary = "20,000",
            employee_age = "20",
            profile_image = "aa.jpg"
        };

        [TestMethod]
        public void TestEmployeeCreation()
        {
            RestClient client = new RestClient(endpoint);
            RestRequest request = new RestRequest(route, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(employee);
            IRestResponse response = client.Execute(request);

            Assert.AreEqual("application/json; charset=utf-8", response.ContentType);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
    }
}