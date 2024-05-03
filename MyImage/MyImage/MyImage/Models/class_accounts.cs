using System.ComponentModel.DataAnnotations;

namespace MyImage.Models
{
    public class class_accounts
    {
        [Key]
        public int signin_id { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [Required]
        public string e_mail { get; set; }
        [Required]
        public string password { get; set; }


        public static class accountData 
        {
            public static List<class_accounts> accData = new List<class_accounts>();
        }
    }
}
