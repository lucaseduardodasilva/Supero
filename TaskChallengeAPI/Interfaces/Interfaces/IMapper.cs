using Models.Dto;
using Models.Entities;

namespace Interfaces.Interfaces
{
    public interface IMapper
    {
        TaskDto MapTo(TaskEntity entity);
    }
}
