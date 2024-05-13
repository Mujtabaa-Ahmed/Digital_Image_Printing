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
        [Required]
        public int roles_id { get; set; }
      

       
    }
}
