namespace MvcToDoApi.Models
{
    public enum StatusOfTask
    {
        ToDo,
        InProgress,
        Done
    }
    public class TaskItem
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public StatusOfTask StatusOfTask { get; set; }
        public string? Description { get; set; }
        public int Priority { get; set; }
        public long ProjectItemId { get; set; }
        public ProjectItem? ProjectItem { get; set; }



    }
}
