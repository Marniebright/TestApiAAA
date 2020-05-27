using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace TestEmployeeApi
{
    [TestClass]
    public class TestDeleteEmployee
    {
        private string localhost = "http://localhost:3000";
        private string endPoint = "http://dummy.restapiexample.com/api/v1";
        
        [TestMethod]
        public void TestEmployeeDeletion()
        {
            RestClient client = new RestClient(localhost);
            //RestClient client = new RestClient(endPoint);
            RestRequest request = new RestRequest("employees/{id}", Method.DELETE);
            request.AddParameter("id", "18", ParameterType.UrlSegment);
            IRestResponse response = client.Execute(request);
            
            Assert.AreEqual("application/json; charset=utf-8", response.ContentType);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    }
}