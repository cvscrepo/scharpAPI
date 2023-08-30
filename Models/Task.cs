using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoEF.Models
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }
        
        [ForeignKey("CategorieId")]
        public Guid CategorieId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set;}
        public Priority PriorityTask { get; set; }
        public virtual Category Category { get; set; }

        [NotMapped]
        public string Summary { get; set; }
    }


    public enum Priority
    {
        Low,
        Medium,
        Hight
    }
}
