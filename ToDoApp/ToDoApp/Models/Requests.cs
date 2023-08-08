using Newtonsoft.Json;
using System.ComponentModel;

namespace ToDoApp.Models
{
    public class CreateTaskRequest
    {

        /// <summary>
        /// Naslov ToDo naloge
        /// </summary>
        [JsonProperty("Title", Required = Required.Always)]
        public string Title { set; get; }
        /// <summary>
        /// Opis ToDo naloge
        /// </summary>
        public string? Description { set; get; }
        /// <summary>
        /// Statusa opravljenosti ToDo naloge (Če ni definiran se nastavi na "false")
        /// </summary>
        public bool? Completed { set; get; }
    }

    public class UpdateTaskRequest
    {
        /// <summary>
        /// Nov naslov ToDo naloge
        /// </summary>
        public string? Title { set; get; }
        /// <summary>
        /// Nov opis ToDo naloge
        /// </summary>
        public string? Description { set; get; }
        /// <summary>
        /// Statusa opravljenosti ToDo naloge
        /// </summary>
        public bool? Completed { set; get; }
    }
}
