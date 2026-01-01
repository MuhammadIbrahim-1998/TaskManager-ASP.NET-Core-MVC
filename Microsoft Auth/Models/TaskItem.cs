using System;
using System.ComponentModel.DataAnnotations;

namespace Microsoft_Auth.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }
    }
}
