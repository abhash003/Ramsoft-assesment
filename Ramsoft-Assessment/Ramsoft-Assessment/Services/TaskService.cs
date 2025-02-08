using Ramsoft_Assessment.modal;
using WebApi.Data.Repository.DataBase;
using Task = Ramsoft_Assessment.modal.Task;

namespace Ramsoft_Assessment.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskBoard _taskBoard;
        private TaskDBContext _taskDBContext;

        public TaskService(TaskDBContext dBContext)
        {
            _taskDBContext = dBContext;
            _taskBoard = new TaskBoard();
        }

        public List<Task> GetAllTasks()
        {
            return _taskDBContext.Tasks.ToList();
        }

        public Task GetTaskById(int id)
        {
            return _taskDBContext.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public void AddTask(Task task)
        {
            _taskBoard.ToDo.Add(task);
            _taskDBContext.SaveChanges();
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
            _taskDBContext.SaveChanges();
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

            _taskDBContext.SaveChanges();
        }

        public void FavoriteTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                task.IsFavorite = true;
            }
            _taskDBContext.SaveChanges();
        }

        public void UnfavoriteTask(int id)
        {
            var task = GetTaskById(id);
            if (task != null)
            {
                task.IsFavorite = false;
            }
            _taskDBContext.SaveChanges();
        }
    }
}
