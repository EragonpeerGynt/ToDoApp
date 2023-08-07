using Newtonsoft.Json;
using System.ComponentModel;

namespace ToDoApp.Models
{
    public class CreateTaskRequest
    {
        [JsonProperty("Title", Required = Required.Always)]
        /// <summary>
        /// Naslov ToDo naloge, ki bo ustvarjena
        /// </summary>
        public string Title { set; get; }
        /// <summary>
        /// Opis ToDo naloge, ki bo ustvarjena
        /// </summary>
        public string? Description { set; get; }
        /// <summary>
        /// Status ToDo naloge, ki bo ustvarjena
        /// </summary>
        public bool? Completed { set; get; }
    }

    public class UpdateTaskRequest
    {
        /// <summary>
        /// Nov naslov ToDo naloge, ki jo posodabljamo
        /// </summary>
        public string? Title { set; get; }
        /// <summary>
        /// Nov opis ToDo naloge, ki jo posodabljamo
        /// </summary>
        public string? Description { set; get; }
        /// <summary>
        /// Sprememba statusa opravljenosti ToDo naloge
        /// </summary>
        public bool? Completed { set; get; }
    }
}
