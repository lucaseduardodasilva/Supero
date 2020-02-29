using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.Interfaces
{
    public interface ITaskRunner
    {
        void ExecuteTask(TaskEntity taskEntity);
    }
}
