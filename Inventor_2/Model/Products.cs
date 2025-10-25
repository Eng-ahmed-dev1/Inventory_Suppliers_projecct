using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventor_2.Model
{
    class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductID { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ? Price { get; set; }
        public int Quantity { get; set; }
        public int SupplierID { get; set; }
        [ForeignKey(nameof(SupplierID))]
        public Suppliers? suppliers { get; set; }

    }
}
