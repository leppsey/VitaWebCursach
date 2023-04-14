namespace DAL
{
    public class Order
    {
        public ulong Id { get; set; }
        public string PhoneNumber { get; set; }
        public List<Product> Products { get; set; }
    }
}