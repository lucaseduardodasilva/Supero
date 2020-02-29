using Exceptions.General;
using Exceptions.Messages;
using Interfaces.Interfaces;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessLayer
{
    public class Access : IAccess
    {
        private readonly TaskContextEntity _context;

        public Access
        (TaskContextEntity context)
        {
            _context = context;
        }

        public IEnumerable<TaskEntity> GetTaskEntities()
        {
            try
            {
                return _context.TaskEntities;
            }
            catch (Exception)
            {
                throw new BusinessException(ExceptionMessages.ErrorOnRetrievingData);
            }
        }
    }
}
