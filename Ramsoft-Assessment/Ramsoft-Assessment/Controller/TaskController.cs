namespace Ramsoft_Assessment.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using Ramsoft_Assessment.Services;
    using Ramsoft_Assessment.modal;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/task
        [HttpGet]
        public ActionResult<IEnumerable<Task>> GetTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        // GET: api/task/{id}
        [HttpGet("{id}")]
        public ActionResult<Task> GetTask(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        // POST: api/task
        [HttpPost]
        public ActionResult<Task> AddTask([FromBody] Task task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            _taskService.AddTask(task);
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        // PUT: api/task/{id}
        [HttpPut("{id}")]
        public IActionResult EditTask(int id, [FromBody] Task updatedTask)
        {
            if (updatedTask == null || updatedTask.Id != id)
            {
                return BadRequest();
            }

            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            _taskService.EditTask(id, updatedTask);
            return NoContent();
        }

        // DELETE: api/task/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            _taskService.DeleteTask(id);
            return NoContent();
        }

        // PATCH: api/task/{id}/move
        [HttpPatch("{id}/move")]
        public IActionResult MoveTask(int id, [FromBody] MoveTaskRequest moveRequest)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            _taskService.MoveTask(id, moveRequest.Column);
            return NoContent();
        }

        // PATCH: api/task/{id}/favorite
        [HttpPatch("{id}/favorite")]
        public IActionResult FavoriteTask(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }

            _taskService.FavoriteTask(id);
            return NoContent();
        }
    }

    // Request body for move task
    public class MoveTaskRequest
    {
        public string Column { get; set; }
    }
}
