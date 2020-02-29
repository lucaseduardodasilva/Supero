using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Context
{
    public class Access
    {
        private readonly TaskContextEntity _context;

        public Access(TaskContextEntity context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskEntity>> LoadAsync()
        {
            try
            {
                return await _context.TaskEntities;
            }
            catch (System.Exception)
            {

                throw;
            }

        }

    }
}
