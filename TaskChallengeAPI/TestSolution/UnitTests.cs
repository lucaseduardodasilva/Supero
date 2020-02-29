using Interfaces.Interfaces;
using Models.Entities;
using Services.Services;
using System;
using Xunit;

namespace TestSolution
{
    public class UnitTests
    {
        [Fact]
        public void Test_TaskRunner()
        {
            TaskRunner tRunner = new TaskRunner();
            TaskEntity task = new TaskEntity()
            {
                Title = "Test",
                Description = "This is a Test",
                RegistrationDate = DateTime.UtcNow,
                TaskId = 0
            };

            tRunner.ExecuteTask(task);
        }
    }
}
