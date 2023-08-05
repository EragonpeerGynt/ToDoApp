using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using ToDoApp.Interfaces;
using ToDoApp.Models;

namespace ToDoApp.BusinessLogic
{
    public class TaskManager : ITaskManager
    {
        private ToDoAppContext _context { get; }
        public TaskManager(ToDoAppContext context)
        {
            _context = context;
        }

        public List<RetrieveTaskResponse> RetrieveTasks(
            int? id, 
            DateTime? createdFrom, 
            DateTime? createdTo, 
            bool? completed, 
            string? title)
        {
            var selectedTasks = _context.Tasks
                .Where(task => id == null || task.Id == id.Value)
                .Where(task => createdFrom == null || task.DatumUstvarjanja >= createdFrom.Value)
                .Where(task => createdTo == null || task.DatumUstvarjanja <= createdTo.Value)
                .Where(task => completed == null || task.Opravljeno == completed.Value)
                .Where(task => title == null || task.Naslov == title);

            return selectedTasks.Select(task => RetrieveTaskResponse.MapTaskToResponse(task)).ToList(); ;
        }

        public CreateResponse CreateTask(CreateTaskRequest request)
        {
            try
            {
                if (request.Title == null)
                {
                    return new CreateResponse(false, "Each task requires to have at least a title");
                }

                var task = new Models.Task()
                {
                    Naslov = request.Title,
                    Opis = request.Description,
                    DatumUstvarjanja = DateTime.Now,
                    Opravljeno = false
                };
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return new CreateResponse();
            }

            catch (Exception ex)
            {
                return new CreateResponse(false, ex.Message);
            }
            
        }

        public UpdateResponse UpdateTask(int? id, UpdateTaskRequest update)
        {
            try
            {
                if (id == null)
                {
                    return new UpdateResponse(false, "No id provided");
                }

                var selectedTask = _context.Tasks.FirstOrDefault(task => task.Id == id);
                if (selectedTask == null)
                {
                    return new UpdateResponse(false, "No matching id found");
                }

                selectedTask.Naslov = update.Title ?? selectedTask.Naslov;
                selectedTask.Opis = update.Description ?? selectedTask.Opis;
                selectedTask.Opravljeno = update.Completed ?? selectedTask.Opravljeno;

                _context.SaveChanges();
                return new UpdateResponse();
            }
            catch(Exception ex)
            {
                return new UpdateResponse(false, ex.Message);
            }
        }

        public DeleteResponse DeleteTask(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new DeleteResponse(false, "No id provided");
                }

                var selectedTask = _context.Tasks.FirstOrDefault(task => task.Id == id.Value);
                if (selectedTask == null)
                {
                    return new DeleteResponse(false, "No matching id found");
                }
                _context.Tasks.Remove(selectedTask);
                _context.SaveChanges();
                return new DeleteResponse();
            }
            catch(Exception ex)
            {
                return new DeleteResponse(false, ex.Message);
            }
        }
    }
}
