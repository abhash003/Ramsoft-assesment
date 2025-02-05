namespace Ramsoft_Assessment.modal
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsFavorite { get; set; }
        public List<string> Attachments { get; set; } = new List<string>(); // URLs or paths to images
        public string Column { get; set; } // ToDo, In Progress, Done
    }
}
