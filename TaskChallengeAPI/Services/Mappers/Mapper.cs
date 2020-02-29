using Interfaces.Interfaces;
using Models.Dto;
using Models.Entities;
using System;

namespace Services.Mappers
{
    public class Mapper : IMapper
    {
        public TaskDto MapTo(TaskEntity entity)
        {
            return new TaskDto
            {
                TaskId = entity.TaskId,
                Title = entity.Title,
                Description = entity.Description,
                RegistrationDate = DateTime.UtcNow,
                Status = entity.Status
                
            };
        }
    }
}
