namespace Ebay.Models
{
    /// <summary>
    /// Состав заказов
    /// </summary>
    public partial class OrderItem
    {
        /// <summary>
        /// Идентификатор состава заказа. Первичный ключ
        /// </summary>
        public int OrderItemId { get; set; }
        /// <summary>
        /// Идентификатор заказа. Внешний ключ
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Идентификатор продукта. Внешний ключ
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Время создания записи в таблице
        /// </summary>
        public DateTime CreatedAt { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
