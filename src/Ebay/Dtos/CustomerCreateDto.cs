namespace Ebay.Dtos
{
    public class CustomerCreateDto
    {
        public string FirstName { get; set; } = null!;
        public string? SecondName { get; set; }
        public string LastName { get; set; } = null!;
        public DateOnly Birthdate { get; set; }
    }
}