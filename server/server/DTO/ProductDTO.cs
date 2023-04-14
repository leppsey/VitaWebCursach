namespace server.DTO
{
    public class ProductDTO
    {
        public ulong Id { get; set; }
        public string Title { get; set; }
        public int ItemsInbox { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
    }
}
