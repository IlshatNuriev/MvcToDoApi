using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcToDoApi.Models
{
    public enum StatusOfProject
    {
        [Display(Name = "Not started")]
        NotStarted,

        [Display(Name = "Active")]
        Active,

        [Display(Name = "Completed")]
        Completed
    }
    public class ProjectItem
    {
        public long Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Display(Name = "Status")]
        public StatusOfProject StatusOfProject { get; set; }

        public int Priority { get; set; }

        public ICollection<TaskItem>? TaskItems { get; set; }

        
    }
}
