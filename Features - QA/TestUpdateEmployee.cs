using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Serialization.Json;

namespace TestEmployeeApi
{
    [TestClass]
    public class TestUpdateEmployee
    {
        private string endpoint = "http://localhost:3000";
       
        private Employee employee = new Employee {
            employee_name = "aba",
            employee_salary = "20,000",
            employee_age = "20",
            profile_image = "aa.jpg"
        };

        [TestMethod]
        public void TestEmployeeUpdate()
        {
            RestClient client = new RestClient(endpoint);
            RestRequest request = new RestRequest("employees/{id}", Method.PUT);
            request.AddParameter("id", "2", ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(employee);
            IRestResponse response = client.Execute(request);
            
            JsonDeserializer jsonDeserializer = new JsonDeserializer();
            var output = jsonDeserializer.Deserialize<Dictionary<string,string>>(response);
           
            Assert.AreEqual("application/json; charset=utf-8", response.ContentType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(output["id"], "2");
        }

        [TestMethod]
        public void TestInvalidUpdateEmployee()
        {
            RestClient client = new RestClient(endpoint);
            RestRequest request = new RestRequest("employees/{id}", Method.PUT);
            request.AddParameter("id", "1010101", ParameterType.UrlSegment);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(employee);
            IRestResponse response = client.Execute(request);
            
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}