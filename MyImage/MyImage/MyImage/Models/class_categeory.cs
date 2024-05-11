using System.ComponentModel.DataAnnotations;

namespace MyImage.Models
{
    public class class_categeory
    {
        [Required]
        [Key]
        public int cat_id { get; set; }
        [Required]
        public string cat_name { get; set; }
        
        [Required]
        public int cat_status { get; set; }
    }
}
