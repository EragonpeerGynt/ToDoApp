using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Interfaces
{
    public interface ITaskManager
    {

        public List<RetrieveTaskResponse> RetrieveTasks(
            int? id,
            DateTime? createdFrom,
            DateTime? createdTo,
            bool? completed,
            string? title);

        public CreateResponse CreateTask(CreateTaskRequest task);

        public UpdateResponse UpdateTask(int? id, UpdateTaskRequest task);

        public DeleteResponse DeleteTask(int? id);
    }
}
