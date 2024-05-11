using System.ComponentModel.DataAnnotations;

namespace MyImage.Models
{
    public class class_subCategeory
    {
        [Required]
        [Key]
        public int subCat_id { get; set; }
        [Required]
        public string subCat_name { get; set; }
        [Required]
        public int cat_id { get; set; }
        [Required]
        public int subCat_status { get; set; }
    }
}
