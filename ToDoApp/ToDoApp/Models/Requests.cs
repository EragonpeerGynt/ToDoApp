using Newtonsoft.Json;
using System.ComponentModel;

namespace ToDoApp.Models
{
    public class CreateTaskRequest
    {
        [JsonProperty("Title", Required = Required.Always)]
        public string Title { set; get; }
        public string? Description { set; get; }
        public bool? Completed { set; get; }
    }

    public class UpdateTaskRequest
    {
        public string Title { set; get; }
        public string? Description { set; get; }
        public bool? Completed { set; get; }
    }
}
