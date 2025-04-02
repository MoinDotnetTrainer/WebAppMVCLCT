using System.ComponentModel.DataAnnotations;

namespace WebAppMVCLCT.Models
{
    public class ProductsModel
    {
        [Key]
        public int ProductId { get; set; }
        public string PName { get; set; }
        public string Category { get; set; }
        public int Qty { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
