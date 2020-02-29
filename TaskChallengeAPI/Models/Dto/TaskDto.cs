using System;

namespace Models.Dto
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int TaskExecutionId { get; set; }
        public string Status { get; set; }
    }
}
