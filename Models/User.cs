using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp.Models
{
    public class User
    {
        [Key]
        public string username { get; set; }
        
        [Required, Column(TypeName ="varchar(50)")]
        public string firstName { get; set; }
        
        [Required, Column(TypeName = "varchar(50)")]
        public string lastName { get; set; }
    }
}
