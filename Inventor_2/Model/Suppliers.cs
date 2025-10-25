using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventor_2.Model
{
    /*
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20),
    Email NVARCHAR(100)
     */
    class Suppliers
    {
        [Key]
        public int SupplierID { get; set; }
        [Required]
        public string? Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
