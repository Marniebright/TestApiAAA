using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace TestEmployeeApi
{
    [TestClass]
    public class TestUpdateEmployee
    {
        private string localhost = "http://localhost:3000";
       
        private Employee employee = new Employee {
            employee_name = "aba",
            employee_salary = "20,000",
            employee_age = "20",
            profile_image = "aa.jpg"
        };

        [TestMethod]
        public void TestEmployeeUpdate()
        {
            RestClient client = new RestClient(localhost);
            RestRequest request = new RestRequest("employees/{id}", Method.PUT);
            request.AddParameter("id", "2", ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(employee);
            IRestResponse response = client.Execute(request);
            
            Assert.AreEqual("application/json; charset=utf-8", response.ContentType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void TestInvalidUpdateEmployee()
        {
            RestClient client = new RestClient(localhost);
            RestRequest request = new RestRequest("employees/{id}", Method.PUT);
            request.AddParameter("id", "1010101", ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(employee);
            IRestResponse response = client.Execute(request);
            
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}