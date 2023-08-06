using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApp.Models;

namespace ToDoAppTest
{
    [TestClass]
    public class TestCreateTask
    {
        private HttpClient _httpClient { get; set; }
        public TestCreateTask()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        //Try to create new incomplete task with title and description
        public async System.Threading.Tasks.Task Test_CreateTask1()
        {
            var response = await _httpClient.PostAsJsonAsync<CreateTaskRequest>("taskcontroller", new CreateTaskRequest
            {
                Title = "Automatic Test Task 1",
                Description = "Automatic Test full description"
            });

            var statusCode = response.StatusCode;
            Assert.AreEqual(statusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        //Try to create new incomplete task with only title
        public async System.Threading.Tasks.Task Test_CreateTask2()
        {
            var response = await _httpClient.PostAsJsonAsync<CreateTaskRequest>("taskcontroller", new CreateTaskRequest
            {
                Title = "Automatic Test Task 2"
            });

            var statusCode = response.StatusCode;
            Assert.AreEqual(statusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        //Try to create new complete task with title and description
        public async System.Threading.Tasks.Task Test_CreateTask3()
        {
            var response = await _httpClient.PostAsJsonAsync<CreateTaskRequest>("taskcontroller", new CreateTaskRequest
            {
                Title = "Automatic Test Task 3",
                Description = "Automatic Test full description",
                Completed = true
            }) ;

            var statusCode = response.StatusCode;
            Assert.AreEqual(statusCode, System.Net.HttpStatusCode.OK);
        }

        [TestMethod]
        //Try to create new complete task without title that should be rejected
        public async System.Threading.Tasks.Task Test_CreateTask4()
        {
            var response = await _httpClient.PostAsJsonAsync<CreateTaskRequest>("taskcontroller", new CreateTaskRequest());

            var statusCode = response.StatusCode;
            Assert.AreEqual(statusCode, System.Net.HttpStatusCode.BadRequest);
        }

        [TestMethod]
        //Try to get all tasks currently in database
        public async System.Threading.Tasks.Task Test_GetAllTasks()
        {
            var response = await _httpClient.GetAsync("taskcontroller");
            //var stringResult = await response.Content.ReadAsStringAsync();
            var statusCode = response.StatusCode;
            Assert.AreEqual(statusCode, System.Net.HttpStatusCode.OK);
        }
    }
}
