using System.ComponentModel.DataAnnotations;

namespace WebApi.Data
{
    public class Photos : BaseEntity
    { 
        public int id{ get; set; }
        
        [Required]
        public string publicId { get; set; }
        
        [Required]
        public string imageUrl { get; set; }
        
        public bool isPrimary { get; set; }
        
        public Car Car { get; set; }
        
        
    }
}