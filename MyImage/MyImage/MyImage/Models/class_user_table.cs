using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;

namespace MyImage.Models
{
    public class class_user_table
    {
        
        [Required]
        [Key]
        public int costumer_id { get; set; }
        
        [Required]
        public string f_name { get; set; }
        
        [Required]
        public string l_name { get; set; }
        
        [Required]
        public string gander {  get; set; }
        
        [Required]
        public string dob { get; set; }
        
        [Required]
        public long p_number { get; set; }
        
        [Required]
        public string addres { get; set; }
        [Required]
        public string e_mail { get; set; }
    }
}
