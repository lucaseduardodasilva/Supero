using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class TaskEntity
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(30)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string TaskExecutionId { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string Status { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
