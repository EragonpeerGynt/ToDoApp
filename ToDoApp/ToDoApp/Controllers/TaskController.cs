using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        // GET: TaskController/Details/5
        public List<ToDoApp.Models.Task> Id([FromQuery]int? id, [FromQuery]DateTime? createdfrom, [FromQuery]DateTime? createdto, [FromQuery]bool? completed, [FromQuery]string? title)
        {
            //return new List<string>() { $"Requested id {id ?? 0}" };
            return _taskManager.RetrieveTasks(id, createdfrom, createdto, completed, title);
        }

        //// GET: TaskController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TaskController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TaskController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TaskController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TaskController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
