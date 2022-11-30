namespace Ebay.Models
{
    /// <summary>
    /// Список покупателей
    /// </summary>
    public class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        /// <summary>
        /// Уникальный идентификатор покупателя. Первичный ключ
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Имя покупателя
        /// </summary>
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// Отчество покупателя
        /// </summary>
        public string? SecondName { get; set; }
        /// <summary>
        /// Фамилия покупателя
        /// </summary>
        public string LastName { get; set; } = null!;
        /// <summary>
        /// День рождения покупателя
        /// </summary>
        public DateOnly Birthdate { get; set; }
        /// <summary>
        /// Время создания записи в таблице
        /// </summary>
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
