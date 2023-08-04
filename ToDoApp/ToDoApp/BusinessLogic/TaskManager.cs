using Microsoft.AspNetCore.Mvc;
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

        public List<ToDoApp.Models.Task> RetrieveTasks(
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

            return selectedTasks.ToList(); ;
        }
    }
}
