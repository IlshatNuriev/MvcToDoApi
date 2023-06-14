using Microsoft.Identity.Client;

namespace MvcToDoApi.Models
{
    public class TaskItemsViewModel
    {
        public ProjectItem? ProjectItem { get; set; }
        public TaskItem? TaskItem { get; set; }
        public ICollection<TaskItem>? TaskItems { get; set;}
    }
}
