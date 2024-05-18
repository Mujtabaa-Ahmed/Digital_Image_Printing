using System.ComponentModel.DataAnnotations;

namespace MyImage.Models
{
    public class class_prices
    {
        [Key]
        public int price_id { get; set; }
        public int prices { get; set; }
        public int cancleed_prices { get; set; }
        public int size_id { get; set; }
        public string material { get; set; }
    }
}
