using Ebay;
using Ebay.DataAccess;
using Ebay.Dtos;
using Ebay.Models;

using (var dbContext = new EbayContext())
{
    try
    {
        #region Retrieving and displaying data
        Console.WriteLine("Retrieving and displaying data");
        Table<Product>.CreateTable(dbContext.Products);
        Table<Customer>.CreateTable(dbContext.Customers);
        Table<Order>.CreateTable(dbContext.Orders);
        Table<OrderItem>.CreateTable(dbContext.OrderItems);
        #endregion

        Console.WriteLine();


        #region Exit or Continue
        var commands = new List<string>();
        commands.Add("Yes");
        commands.Add("No");

        Console.WriteLine();
        Console.WriteLine("Do you want to continue (Yes)");
        var cmdExit = Console.ReadLine().Trim();

        if (cmdExit.ToLower() != "Yes".ToLower())
        {
            return;
        }
        #endregion


        #region Creating a new item and saving it to the database
        var tables = new List<string>();
        tables.Add("Product");
        tables.Add("Customer");
        tables.Add("Order");

        var guides = String.Join(",", tables.ToArray())!;

        bool isWork = true;

        while (isWork)
        {
            var guideList = tables.ConvertAll(g => g.ToLower());

            Console.WriteLine($"Enter table name of : {guides}: ");
            var guide = Console.ReadLine().Trim();

            if (!guideList.Contains(guide.ToLower()))
            {
                Console.WriteLine($"Enter correct table name of : {guides}");
                continue;
            }

            Console.WriteLine("Enter attributes: ");
            if (guide.ToLower() == "Product".ToLower())
            {
                var itemDto = Table<ProductCreateDto>.CreateAttribute();
                var newProduct = new Product() { ProductName = itemDto.Name, Price = itemDto.Price };

                dbContext.Products.Add(newProduct);
            }
            else if (guide.ToLower() == "Customer".ToLower())
            {
                var itemDto = Table<CustomerCreateDto>.CreateAttribute();
                var newCustomer = new Customer() { FirstName = itemDto.FirstName, SecondName = itemDto.SecondName, LastName = itemDto.LastName, Birthdate = itemDto.Birthdate };

                dbContext.Customers.Add(newCustomer);
            }
            else //Orders + OrderItems
            {
                var itemDto = Table<OrderCreateDto>.CreateAttribute();

                var orderCustomer = dbContext.Customers.First(c => c.LastName == itemDto.LastName && c.Birthdate == itemDto.Birthdate);
                var orderProduct = dbContext.Products.First(p => p.ProductName == itemDto.ProductName);

                if (orderCustomer == null)
                {
                    Console.WriteLine("Customer does not exists. Enter correct customer");
                    continue;
                }

                if (orderProduct == null)
                {
                    Console.WriteLine("Product does not exists. Enter correct product");
                    continue;
                }

                var newOrder = new Order()
                {
                    ShippingAddress = itemDto.ShippingAddress,
                    ShippingDate = itemDto.ShippingDate,
                    Customer = orderCustomer,
                };

                var newOrderItem = new OrderItem()
                {
                    Quantity = itemDto.Quantity,
                    Product = orderProduct,
                    Order = newOrder
                };
                dbContext.Orders.Add(newOrder);
                dbContext.OrderItems.Add(newOrderItem);
            }


            dbContext.SaveChangesAsync();
            Console.WriteLine("Saved to database");

            while (true)
            {
                var cmdList = commands.ConvertAll(g => g.ToLower());

                Console.WriteLine();
                Console.WriteLine("Do you want to exit (Yes/No) ?");
                var cmd = Console.ReadLine().Trim();

                if (!cmdList.Contains(cmd.ToLower()))
                {
                    Console.WriteLine("Enter correct command of : Yes,No");
                    continue;
                }
                else if (cmd.ToLower() == "Yes".ToLower())
                {
                    isWork = false;
                    break;
                }
                else
                {
                    break;
                }
            }
        }
        #endregion
    }
    catch (Exception ex)
    {
        throw new Exception($"Error : {ex.Message}");
    }

}