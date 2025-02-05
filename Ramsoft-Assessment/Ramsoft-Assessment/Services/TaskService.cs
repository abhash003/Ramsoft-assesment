using Ramsoft_Assessment.modal;
using Task = Ramsoft_Assessment.modal.Task;

namespace Ramsoft_Assessment.Services
{
    public class TaskService
    {
        private readonly TaskBoard _taskBoard;

        public TaskService()
        {
            _taskBoard = new TaskBoard();
        }

        public List<Task> GetAllTasks()
        {
            return _taskBoard.ToDo
                .Concat(_taskBoard.InProgress)
                .Concat(_taskBoard.Done)
                .OrderBy(t => t.IsFavorite ? 0 : 1) // Favorites first
                .ThenBy(t => t.Name) // Then sort alphabetically
                .ToList();
        }

        public Task GetTaskById(int id)
        {
            return _taskBoard.ToDo
                .Concat(_taskBoard.InProgress)
                .Concat(_taskBoard.Done)
                .FirstOrDefault(t => t.Id == id);
        }

        public void AddTask(Task task)
        {
            _taskBoard.ToDo.Add(task);
        }

        public void EditTask(int id, Task updatedTask)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                task.Name = updatedTask.Name;
                task.Description = updatedTask.Description;
                task.Deadline = updatedTask.Deadline;
            }
        }

        public void DeleteTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                _taskBoard.ToDo.Remove(task);
                _taskBoard.InProgress.Remove(task);
                _taskBoard.Done.Remove(task);
            }
        }

        public void MoveTask(int id, string targetColumn)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                // Remove task from any column
                _taskBoard.ToDo.Remove(task);
                _taskBoard.InProgress.Remove(task);
                _taskBoard.Done.Remove(task);

                // Add task to the target column
                if (targetColumn == "ToDo")
                    _taskBoard.ToDo.Add(task);
                else if (targetColumn == "InProgress")
                    _taskBoard.InProgress.Add(task);
                else if (targetColumn == "Done")
                    _taskBoard.Done.Add(task);
            }
        }

        public void FavoriteTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                task.IsFavorite = true;
            }
        }

        public void UnfavoriteTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                task.IsFavorite = false;
            }
        }
    }
}
