using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventor_2.Model
{
    
    internal class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [MaxLength(50)]
        public string? Role { get; set; }

    }
}
