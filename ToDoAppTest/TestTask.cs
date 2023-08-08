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
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace ToDoAppTest
{
    [TestClass]
    public class TestTask
    {
        private HttpClient _httpClient { get; set; }
        private static string _title1 = "Automatic Test Task 1";
        private static string _title2 = "Automatic Test Task 2";
        private static string _title3 = "Automatic Test Task 3";
        private int? _id1 { set; get; }
        private int? _id2 { set; get; }
        private int? _id3 { set; get; }

        public TestTask()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        //Try to create new incomplete task with title and description
        //Try to retrieve this task by title
        //Try to update this task to completed
        //Try to delete this task
        public async System.Threading.Tasks.Task Test_NormalProcess()
        {
            var response = await _httpClient.PostAsJsonAsync<CreateTaskRequest>("task", new CreateTaskRequest
            {
                Title = _title1,
                Description = "Automatic Test full description"
            });

            var statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode);

            response = await _httpClient.GetAsync($"task?title={_title1}");
            var stringResult = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<RetrieveTaskResponse>? matchedTasks =
                JsonSerializer.Deserialize<List<RetrieveTaskResponse>>(stringResult, options);

            statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode, "Status code should be OK");

            Assert.IsTrue(matchedTasks?.Any() ?? false, "Should retrieve at least 1 record");

            string? foundTitle = matchedTasks?.OrderByDescending(task => task.CreatedOn).FirstOrDefault()?.Title;
            Assert.AreEqual(foundTitle, _title1, $"Title should be same as searched title");

            _id1 = matchedTasks?.OrderByDescending(task => task.CreatedOn).FirstOrDefault()?.Id;

            response = await _httpClient.PatchAsJsonAsync($"task/id/{_id1}", new CreateTaskRequest
            {
                Completed = true
            });
            statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode);

            response = await _httpClient.GetAsync($"task?id={_id1}");
            stringResult = await response.Content.ReadAsStringAsync();

            matchedTasks =
                JsonSerializer.Deserialize<List<RetrieveTaskResponse>>(stringResult, options);

            statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode, "Status code should be OK");

            Assert.IsTrue(matchedTasks?.Any() ?? false, "Should retrieve at least 1 record");

            bool? completed = matchedTasks?.OrderByDescending(task => task.CreatedOn).FirstOrDefault()?.Completed;
            Assert.AreEqual(completed, true, $"Title should be same as searched title");

            response = await _httpClient.DeleteAsync($"task/id/{_id1}");

            statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode);
        }

        [TestMethod]
        //Try to create new incomplete task with only title
        //Try to retrieve this task by title
        //Try to update this task with description
        //Try to delete this task
        public async System.Threading.Tasks.Task Test_NormalProcessForgottenDescription()
        {
            var response = await _httpClient.PostAsJsonAsync<CreateTaskRequest>("task", new CreateTaskRequest
            {
                Title = _title2
            });

            var statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode);

            response = await _httpClient.GetAsync($"task?title={_title2}");
            var stringResult = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<RetrieveTaskResponse>? matchedTasks =
                JsonSerializer.Deserialize<List<RetrieveTaskResponse>>(stringResult, options);

            statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode, "Status code should be OK");

            Assert.IsTrue(matchedTasks?.Any() ?? false, "Should retrieve at least 1 record");

            string? foundTitle = matchedTasks?.OrderByDescending(task => task.CreatedOn).FirstOrDefault()?.Title;
            Assert.AreEqual(foundTitle, _title2, $"Title should be same as searched title");

            _id2 = matchedTasks?.OrderByDescending(task => task.CreatedOn).FirstOrDefault()?.Id;

            response = await _httpClient.PatchAsJsonAsync($"task/id/{_id2}", new CreateTaskRequest
            {
                Description = _title2
            });
            statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode);

            response = await _httpClient.GetAsync($"task?id={_id2}");
            stringResult = await response.Content.ReadAsStringAsync();

            matchedTasks =
                JsonSerializer.Deserialize<List<RetrieveTaskResponse>>(stringResult, options);

            statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode, "Status code should be OK");

            Assert.IsTrue(matchedTasks?.Any() ?? false, "Should retrieve at least 1 record");

            string? foundDescription = matchedTasks?.OrderByDescending(task => task.CreatedOn).FirstOrDefault()?.Description;
            Assert.AreEqual(foundTitle, _title2, $"Title should be same as searched title");

            response = await _httpClient.DeleteAsync($"task/id/{_id2}");

            statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode);
        }

        [TestMethod]
        //Try to create new complete task with title and description
        //Try to retrieve this task by title
        //Try to delete this task
        public async System.Threading.Tasks.Task Test_IninitiallyCompletedTaskThatWasntCompleted()
        {
            var response = await _httpClient.PostAsJsonAsync<CreateTaskRequest>("task", new CreateTaskRequest
            {
                Title = _title3,
                Description = "Automatic Test full description",
                Completed = true
            }) ;

            var statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode);

            response = await _httpClient.GetAsync($"task?title={_title3}");
            var stringResult = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<RetrieveTaskResponse>? matchedTasks =
                JsonSerializer.Deserialize<List<RetrieveTaskResponse>>(stringResult, options);

            statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode, "Status code should be OK");

            Assert.IsTrue(matchedTasks?.Any() ?? false, "Should retrieve at least 1 record");

            string? foundTitle = matchedTasks?.OrderByDescending(task => task.CreatedOn).FirstOrDefault()?.Title;
            Assert.AreEqual(foundTitle, _title3, $"Title should be same as searched title");

            _id3 = matchedTasks?.OrderByDescending(task => task.CreatedOn).FirstOrDefault()?.Id;

            response = await _httpClient.DeleteAsync($"task/id/{_id3}");

            statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode);
        }

        [TestMethod]
        //Try to create new complete task without title that should be rejected
        public async System.Threading.Tasks.Task Test_CreateTaskWithoutTitle()
        {
            var response = await _httpClient.PostAsJsonAsync<CreateTaskRequest>("task", new CreateTaskRequest());

            var statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, statusCode);
        }

        [TestMethod]
        //Try to get all tasks currently in database
        public async System.Threading.Tasks.Task Test_GetAllTasks()
        {
            var response = await _httpClient.GetAsync("task");

            var statusCode = response.StatusCode;
            Assert.AreEqual(System.Net.HttpStatusCode.OK, statusCode, "Status code should be OK");
        }
    }
}
