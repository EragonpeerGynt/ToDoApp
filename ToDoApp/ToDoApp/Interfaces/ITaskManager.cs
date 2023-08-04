using ToDoApp.Models;

namespace ToDoApp.Interfaces
{
    public interface ITaskManager
    {

        public List<ToDoApp.Models.Task> RetrieveTasks(
            int? id,
            DateTime? createdFrom,
            DateTime? createdTo,
            bool? completed,
            string? title);
    }
}
