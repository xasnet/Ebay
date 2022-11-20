using Ebay.Models;
using Microsoft.EntityFrameworkCore;

namespace Ebay.DataAccess
{
    public partial class ebayContext : DbContext
    {
        public ebayContext()
        {
        }

        public ebayContext(DbContextOptions<ebayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=ebay;User Id=postgres;Password=PGAdmin;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasComment("Список покупателей");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasComment("Уникальный идентификатор покупателя. Первичный ключ");

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasComment("День рождения покупателя");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()")
                    .HasComment("Время создания записи в таблице");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name")
                    .HasComment("Имя покупателя");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name")
                    .HasComment("Фамилия покупателя");

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .HasColumnName("second_name")
                    .HasComment("Отчество покупателя");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasComment("Список заказов");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasComment("Идентификатор заказа. Первичный ключ");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()")
                    .HasComment("Время создания записи в таблице");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasComment("Идентификатор покупателя. Внешний ключ");

                entity.Property(e => e.ShippingAddress)
                    .HasColumnName("shipping_address")
                    .HasComment("Адрес доставки заказа");

                entity.Property(e => e.ShippingDate)
                    .HasColumnName("shipping_date")
                    .HasComment("Дата доставки");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_customer");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("order_items");

                entity.HasComment("Состав заказов");

                entity.Property(e => e.OrderItemId)
                    .HasColumnName("order_item_id")
                    .HasComment("Идентификатор состава заказа. Первичный ключ");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()")
                    .HasComment("Время создания записи в таблице");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasComment("Идентификатор заказа. Внешний ключ");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("Идентификатор продукта. Внешний ключ");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasComment("Количество");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_order");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasComment("Список покупателей");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasComment("Идентификатор продукта. Первичный ключ");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()")
                    .HasComment("Время создания записи в таблице");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasComment("Цена");

                entity.Property(e => e.ProductName)
                    .HasColumnName("product_name")
                    .HasComment("Наименование продукта");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
