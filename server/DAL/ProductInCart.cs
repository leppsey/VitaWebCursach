namespace DAL;

public class ProductInCart
{
    public ulong Id { get; set; }
    public Product Product { get; set; }
    public ulong ProductId { get; set; }
    public ulong ProductCount { get; set; }
}
