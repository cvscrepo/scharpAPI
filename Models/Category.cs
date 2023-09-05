using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProyectoEF.Models
{
    public class Category
    {
        //[Key]
        public Guid Id { get; set; }
        
        //[Required]
        //[MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<Task> Tasks { get; set; }
        public int Peso { get; set; }
        public Category() 
        { 
            
        }
    }
}
