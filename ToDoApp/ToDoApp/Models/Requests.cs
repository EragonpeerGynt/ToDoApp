namespace ToDoApp.Models
{
    public class CreateTaskRequest
    {
        public string Title { set; get; }
        public string? Description { set; get; } 
    }

    public class UpdateTaskRequest
    {
        public string Title { set; get; }
        public string? Description { set; get; }
        public bool? Completed { set; get; }
    }
}
