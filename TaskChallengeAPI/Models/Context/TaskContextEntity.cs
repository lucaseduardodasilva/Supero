using Microsoft.EntityFrameworkCore;

namespace Models.Entities
{
    public class TaskContextEntity : DbContext
    {
        public TaskContextEntity(DbContextOptions<TaskContextEntity> options) : base(options)
        {

        }

        public DbSet<TaskEntity> TaskEntities { get; set; }
    }
}
