using System;
using System.Collections.Generic;
using Warehouse.DataAccess.Models;

namespace Warehouse.Views
{
    public class ShowProvider
    {
        public void PrintItem(Item item)
        {
            string itemRow = $"| {item.ItemId} | {item.ItemCategory} | {item.ItemName} | {item.ItemCount} |";
            Console.WriteLine(itemRow);
        }

        public void PrintManyItems(IEnumerable<Item> items)
        {
            foreach(var item in items)
            {
                PrintItem(item);
            }
        }

        public void PrintCategories(IEnumerable<string> categories)
        {
            int index = 0;
            foreach (var category in categories)
            {
                Console.WriteLine($"{index + 1}. {category}");
                index++;
            }
        }

        public void DisplayMessage(string msg)
        {
            Console.Clear();
            Console.WriteLine($"{msg}");
        }
    }
}
