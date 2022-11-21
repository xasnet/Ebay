using ConsoleTables;
using Microsoft.EntityFrameworkCore;

namespace Ebay
{
    public static class Table<T> where T : class, new()
    {
        public static void Create(DbSet<T> guide)
        {
            var tableName = typeof(T).ToString().Split(".").Last();

            Console.WriteLine($"Data from database, table : {tableName}");

            var table = new ConsoleTable(typeof(T)
                .GetProperties()
                .Select(p => p.Name)
                .ToArray());

            foreach (var attribute in guide)
            {
                var columnValue =
                    attribute.GetType()
                             .GetProperties()
                             .Select(p => p.GetAccessors()[0].IsVirtual ? "Foreign Key" : p.GetValue(attribute))
                             .ToArray();

                table.AddRow(columnValue);
            }

            table.Write();
        }
        public static T CreateAttribute()
        {
            T newItem = new();

            foreach (var columnName in typeof(T).GetProperties().Select(p => p.Name).ToArray())
            {
                bool isWork = true;

                while (isWork)
                {
                    isWork = false;
                    var columnProperty = newItem.GetType().GetProperty(columnName)!;
                    var columnType = columnProperty.PropertyType;

                    var attributeName = columnType == typeof(DateOnly) ? $"{columnName} (format: YYYY-MM-DD) : " : $"{columnName} : ";

                    Console.Write($"{attributeName}");

                    var enteredData = Console.ReadLine()!.Trim();

                    if (columnType == typeof(int))
                    {
                        var value = Int32.TryParse(enteredData, out var intValue);
                        if (value)
                        {
                            columnProperty.SetValue(newItem, intValue);
                        }
                        else
                        {
                            Console.WriteLine($"Incorrect attribute {columnName}");
                            isWork = true;
                        }
                    }
                    else if (columnType == typeof(string))
                    {
                        var value = enteredData;
                        columnProperty.SetValue(newItem, value);
                    }
                    else if (columnType == typeof(decimal))
                    {
                        var value = Decimal.TryParse(enteredData, out var decimalValue);
                        if (value)
                        {
                            columnProperty.SetValue(newItem, decimalValue);
                        }
                        else
                        {
                            Console.WriteLine($"Incorrect attribute {columnName}");
                            isWork = true;
                        }
                    }
                    else if (columnType == typeof(DateOnly))
                    {
                        var value = DateOnly.TryParse(enteredData, out var dateOnlyValue);
                        if (value)
                        {
                            columnProperty.SetValue(newItem, dateOnlyValue);
                        }
                        else
                        {
                            Console.WriteLine($"Incorrect attribute {columnName}. Please enter correct attribute: ");
                            isWork = true;
                        }
                    }
                }
            }

            return newItem;
        }
    }
}