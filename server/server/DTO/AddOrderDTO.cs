namespace server.DTO
{
    public record AddOrderDTO
    {
        public List<ProductCountDTO> ProductCount { get; set; }
        public string PhoneNumber { get; set; }
    }


    public record ProductCountDTO
    {
        public ulong Id { get; set; }
        public ulong Count { get; set; }
    }
}
