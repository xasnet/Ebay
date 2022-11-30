namespace Ebay.Dtos
{
    public class OrderCreateDto
    {
        public string LastName { get; set; } = null!;
        public DateOnly Birthdate { get; set; }
        public string ShippingAddress { get; set; } = null!;
        public DateOnly ShippingDate { get; set; }
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
