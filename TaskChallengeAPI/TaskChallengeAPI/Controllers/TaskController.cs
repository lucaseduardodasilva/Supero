using Exceptions.General;
using Exceptions.Messages;
using Interfaces.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChallengeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskContextEntity _context;
        private readonly IMapper _mapper;
        private readonly ITaskRunner _taskRunner;

        public TaskController
        (
        TaskContextEntity context,
        IMapper mapper,
        ITaskRunner taskRunner
        )
        {
            _context = context;
            _mapper = mapper;
            _taskRunner = taskRunner;
        }

        [HttpGet("GetTasks")]
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


        [HttpPut("UpdateTask/{id}")]
        public async Task<IActionResult> PutTaskEntity([FromRoute] int id, [FromBody] TaskEntity taskEntity)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskEntity.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(taskEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw new BusinessException(ExceptionMessages.ExceptionOnUpdatingTask);
                }
            }

            return NoContent();
        }

        [HttpPost("CreateTask")]
        public async Task<IActionResult> PostTaskEntity(TaskEntity taskEntity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _taskRunner.ExecuteTask(taskEntity);
                var taskDto = _mapper.MapTo(taskEntity);
                
                taskEntity.RegistrationDate = DateTime.UtcNow;
                _context.TaskEntities.Add(taskEntity);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTaskEntity", new { id = taskDto.TaskId }, taskDto);
            }
            catch (Exception)
            {

                throw new BusinessException(ExceptionMessages.ExceptionOnCreateTask);
            }        
        }

        [HttpDelete("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTaskEntity([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var taskEntity = await _context.TaskEntities.FindAsync(id);
                if (taskEntity == null)
                {
                    return NotFound();
                }

                _context.TaskEntities.Remove(taskEntity);
                await _context.SaveChangesAsync();

                return Ok(taskEntity);
            }
            catch (Exception)
            {

                throw new BusinessException(ExceptionMessages.ExceptionOnDelete);
            }
            
        }

        private bool TaskEntityExists(int id)
        {
            return _context.TaskEntities.Any(e => e.TaskId == id);
        }
    }
}