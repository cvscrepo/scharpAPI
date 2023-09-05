using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoEF.Models
{
    public class Task
    {
        //Data Anotations       
        //[Key]
        public Guid Id { get; set; }
        

        //[ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        //[Required]
        //[MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime DateOfCompletion { get; set;}
        public Priority PriorityTask { get; set; }
        public virtual Category Category { get; set; }

        //[NotMapped]
        public string Summary { get; set; }
    }


    public enum Priority
    {
        Low,
        Medium,
        Hight
    }
}
