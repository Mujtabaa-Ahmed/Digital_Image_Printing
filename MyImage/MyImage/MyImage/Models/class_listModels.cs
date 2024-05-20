namespace MyImage.Models
{
    public class class_listModels
    {
        public List<class_categeory> categeories { get; set; }
        public List<class_subCategeory> SubCategeories { get; set; }
        public List<class_subCategeory> SubCategeoriesForMenue { get; set; }
        public List<class_user_table> userTable { get; set; }
        public  List<class_services> service { get; set; }
        public  List<class_prices> price { get; set; }
        public List<class_sizes> size { get; set; }
        public List<class_cart> cart { get; set; }

        public static class selected
        {
            public static string Ssize { get; set; }
            public static string Sprice { get; set; }
            public static string Scprice { get; set; }

        }
    }
}
