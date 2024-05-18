using System.ComponentModel.DataAnnotations;

namespace MyImage.Models
{
    public class class_sizes
    {
        [Key]
        public int size_id { get; set; }
        public string size { get; set; }
        public int service_id { get; set; }
    }
}
