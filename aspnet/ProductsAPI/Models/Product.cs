namespace ProductsAPI.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }=null!;
        public decimal price { get; set; }
        public bool IsActive { get; set; }

    }
    
}