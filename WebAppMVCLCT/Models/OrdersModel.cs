using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMVCLCT.Models
{

    [Table("TableOrders")]
    public class OrdersModel
    {
        [Key]
        public int OrderID { get; set; }
        public string OrderCategory { get; set; }
        public decimal Price { get; set; }
    }
}
