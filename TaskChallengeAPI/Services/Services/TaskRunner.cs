using Interfaces.Interfaces;
using Models.Entities;
using Models.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Services
{
    public class TaskRunner : ITaskRunner
    {
        public void ExecuteTask(TaskEntity taskEntity)
        {
            try
            {
                Task[] tasks = new Task[1];

                Random rnd = new Random();

                for (int n = 0; n < 1; n++)
                {
                    tasks[n] = Task.Run(() =>
                    {
                        Thread.Sleep(rnd.Next(500, 3000));
                    });
                }

                int index = Task.WaitAny(tasks);

                foreach (Task t in tasks)
                {
                    t.Wait();
                    taskEntity.TaskExecutionId = t.Id.ToString();

                    if (t.IsCompleted)
                    {
                        taskEntity.Status = Status.Completed.ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
