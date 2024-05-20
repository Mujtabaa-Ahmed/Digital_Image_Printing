namespace MyImage.Models
{
    public class class_cart
    {
        public string service_id { get; set; }
        public string service_name { get; set; }
        public string service_size { get; set; }
        public string service_price { get; set; }
        public string service_quantity { get; set; }
        public string image_stored { get; set; }
        public string cart_id { get; set; }
        public IFormFile image_for_printing { get; set; }
    }
    public static class list
    {
        public static List<class_cart> carts = new List<class_cart>();
    }

}
