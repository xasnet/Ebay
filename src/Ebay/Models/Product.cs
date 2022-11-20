namespace Ebay.Models
{
    /// <summary>
    /// Список покупателей
    /// </summary>
    public partial class Product
    {
        /// <summary>
        /// Идентификатор продукта. Первичный ключ
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// Наименование продукта
        /// </summary>
        public string ProductName { get; set; } = null!;
        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Время создания записи в таблице
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
