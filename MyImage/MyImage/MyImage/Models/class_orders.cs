using System.ComponentModel.DataAnnotations;

namespace MyImage.Models
{
    public class class_orders
    {
        [Key]
        public int order_id { get; set; }
        public string user_id { get; set; }
        public string order_date { get; set; }
        public string order_invoice { get; set; }
        public string card_type { get; set; }
        public string card_number { get; set; }
        public string V_car_number { get; set; }
        public string order_total_amount { get; set; }
    }
}
