using Task = Ramsoft_Assessment.modal.Task;

namespace Ramsoft_Assessment.Services
{
    public interface ITaskService
    {

        List<Task> GetAllTasks();

        Task GetTaskById(int id);

        void AddTask(Task task);

        void EditTask(int id, Task updatedTask);

        void DeleteTask(int id);

        void MoveTask(int id, string targetColumn);

        void FavoriteTask(int id);

        void UnfavoriteTask(int id);

    }
}
