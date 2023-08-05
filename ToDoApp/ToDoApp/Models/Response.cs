using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ToDoApp.Models
{
    public class RetrieveTaskResponse
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool Completed { get; set; }

        public static RetrieveTaskResponse MapTaskToResponse(Models.Task task) 
        {
            return new RetrieveTaskResponse
            {
                Id = task.Id,
                Title = task.Naslov,
                Description = task.Opis,
                CreatedOn = task.DatumUstvarjanja,
                Completed = task.Opravljeno,
            };
        }
    }

    public class GeneralModificationResponse
    {
        public bool Success { get; set; }
        public string Description { get; set; }

        public GeneralModificationResponse(bool success = true, string description = null)
        {
            Success = success;
            Description = description;
        }
    }

    public class UpdateResponse : GeneralModificationResponse
    {
        public UpdateResponse(bool success = true, string description = null) : base(success, description) { }
    }

    public class DeleteResponse : GeneralModificationResponse
    {
        public DeleteResponse(bool success = true, string description = null) : base(success, description) { }
    }

    public class CreateResponse : GeneralModificationResponse
    {
        public CreateResponse(bool success = true, string description = null) : base(success, description) { }
    }
}
