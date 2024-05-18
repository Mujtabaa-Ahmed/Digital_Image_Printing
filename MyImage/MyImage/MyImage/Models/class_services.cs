using System.ComponentModel.DataAnnotations;

namespace MyImage.Models
{
    public class class_services
    {
        [Key]
        public int service_id { get; set; }
        public string service_name { get; set; }
        public string service_image { get; set; }
        public string service_description { get; set; }
        public int cat_id { get; set; }
        public int subCat_id { get; set; }
    }
}
