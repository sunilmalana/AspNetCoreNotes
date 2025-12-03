using System.ComponentModel.DataAnnotations;

namespace NotesApp.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsEdited => UpdatedAt.HasValue;
    }
}