using System.ComponentModel.DataAnnotations;

namespace MyImage.Models
{
    public class class_order_details
    {
        [Key]
        public int order_details_id { get; set; }
        public string user_id { get; set; }
        public string order_date { get; set; }
        public string order_invoice { get; set; }
        public string order_service { get; set; }
        public string user_uploaded_image { get; set; }
        public string order_quantity { get; set; }
    }
}
