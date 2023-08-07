using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
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
            _taskManager = (TaskManager)taskManager;
        }

        /// <summary>
        /// Endpoint namenjen pridobivanju ToDo nalog iz zaledne baze.
        /// </summary>
        /// <param name="id">Id po katerem iščemo med ToDo nalogami</param>
        /// <param name="createdfrom">Iskanje ToDo nalog narejenih po vnešenem datumu</param>
        /// <param name="createdto">Iskanje ToDo nalog narejenih pred vnešenim datumom</param>
        /// <param name="completed">Iskanje ToDo nalog, ki so v specifičnem statusu opravljenosti</param>
        /// <param name="title">Naslov po katerem iščemo med ToDo nalogami</param>
        /// <returns>Seznam vseh ToDo nalog, ki ustrezajo specificiranim pogojem</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<RetrieveTaskResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Id([FromQuery]int? id, [FromQuery]DateTime? createdfrom, [FromQuery]DateTime? createdto, [FromQuery]bool? completed, [FromQuery]string? title)
        {
            try
            {
                return Ok(_taskManager.RetrieveTasks(id, createdfrom, createdto, completed, title));
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint namenjen ustvarjanju novih ToDo nalog.
        /// </summary>
        /// <param name="task">Objekt v katerem so shranjeni podatki za ustvarjanje nove ToDo naloge</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
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

        /// <summary>
        /// Endpoint namenjen posodabljanu obstoječih ToDo nalog.
        /// </summary>
        /// <param name="id">Id ToDo naloge, ki jo želimo posodobiti</param>
        /// <param name="task">Objekt v katerem so shranjeni podatki za posodobitev obstoječe ToDo naloge</param>
        /// <returns></returns>
        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [Route("id/{id}")]
        public IActionResult Update([Required][FromRoute]int id, [FromBody]UpdateTaskRequest task)
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

        /// <summary>
        /// Endpoint namenjen brisanju obstoječih ToDo nalog.
        /// </summary>
        /// <param name="id">Id ToDo naloge, ki jo želimo izbrisati</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [Route("id/{id}")]
        public IActionResult Delete([Required][FromRoute]int id)
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
