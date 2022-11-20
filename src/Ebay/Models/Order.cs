namespace Ebay.Models
{
    /// <summary>
    /// Список заказов
    /// </summary>
    public partial class Order
    {
        /// <summary>
        /// Идентификатор заказа. Первичный ключ
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Идентификатор покупателя. Внешний ключ
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Адрес доставки заказа
        /// </summary>
        public string ShippingAddress { get; set; } = null!;
        /// <summary>
        /// Дата доставки
        /// </summary>
        public DateOnly ShippingDate { get; set; }
        /// <summary>
        /// Время создания записи в таблице
        /// </summary>
        public DateTime CreatedAt { get; set; }

        public virtual Customer Customer { get; set; } = null!;
    }
}
