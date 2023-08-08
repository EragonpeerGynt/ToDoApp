using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json.Serialization;

namespace ToDoApp.Models
{
    public class RetrieveTaskResponse
    {
        /// <summary>
        /// Id naloge
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Naslov naloge
        /// </summary>
        public string Title { get; set; } = null!;

        /// <summary>
        /// Opis naloge
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Datum in ura, ko je bila naloga ustvarjena
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Status opravljenosti naloge
        /// </summary>
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
        [JsonIgnore]
        public bool Success { get; set; }

        /// <summary>
        /// Opis napake
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Description { get; set; }

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
        /// <summary>
        /// Id ustvarjene naloge
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Id { get; set; }
        public CreateResponse(bool success = true, string description = null) : base(success, description) { }

        public CreateResponse(int id) : base()
        {
            Id = id;
        }
    }

    public class CreateResponseException : GeneralModificationResponse
    {
        public CreateResponseException(bool success = true, string description = null) : base(success, description) { }
    }

    public class CreateResponseOnlyId
    {
        /// <summary>
        /// Id ustvarjene naloge
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Id { get; set; }

        public CreateResponseOnlyId(int? id)
        {
            Id = id;
        }
    }
}
