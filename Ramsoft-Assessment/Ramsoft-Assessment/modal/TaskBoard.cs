namespace Ramsoft_Assessment.modal
{
    public class TaskBoard
    {
        public List<Task> ToDo { get; set; } = new List<Task>();
        public List<Task> InProgress { get; set; } = new List<Task>();
        public List<Task> Done { get; set; } = new List<Task>();
    }
}
