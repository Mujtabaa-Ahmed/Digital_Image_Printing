using System.ComponentModel.DataAnnotations;

namespace MyImage.Models
{
    public class class_roles
    {
        [Key]
        [Required]
        public int roles_id { get; set; }
        [Required]
        public string roles_name { get; set; }
    }
}
