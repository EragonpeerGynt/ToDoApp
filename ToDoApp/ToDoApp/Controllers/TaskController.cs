using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoApp.BusinessLogic;
using ToDoApp.Interfaces;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    [Route("taskcontroller")]
    public class TaskController : Controller
    {
        private ITaskManager _taskManager { get; }

        public TaskController(ITaskManager taskManager)
        {
            _taskManager = taskManager as TaskManager;
        }

        [HttpGet]
        public IActionResult Id([FromQuery]int? id, [FromQuery]DateTime? createdfrom, [FromQuery]DateTime? createdto, [FromQuery]bool? completed, [FromQuery]string? title)
        {
            return Ok(_taskManager.RetrieveTasks(id, createdfrom, createdto, completed, title));
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateTaskRequest task)
        {
            CreateResponse response = _taskManager.CreateTask(task);
            if (response.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response.Description);
            }
        }

        [HttpPatch]
        public IActionResult Update([FromQuery] int? id, [FromBody]UpdateTaskRequest task)
        {
            UpdateResponse response = _taskManager.UpdateTask(id, task);
            if (response.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response.Description);
            }
        }

        [HttpDelete]
        public IActionResult Update([FromQuery] int? id)
        {
            DeleteResponse response = _taskManager.DeleteTask(id);

            if (response.Success)
            {
                return Ok();
            }
            else
            {
                return BadRequest(response.Description);
            }
        }
    }
}
