using System;
using ToDoList.Storage;

namespace ToDoList.Services
{
    public class ServiceHelpers
    {


        public Item createNewItem(string category)
        {
            string[] itemQuery = new string[] { "Item Name", "Item Description", "Item ID" };
            string[] itemData = new string[4];

            for(int i=0; i<itemQuery.Length; i++)
            {
                Console.WriteLine($"Insert {itemQuery[i]}");
                itemData[i] = Console.ReadLine();
            }

            Item newItem = new Item() {
                ItemName = itemData[0],
                ItemDescription = itemData[1],
                ItemId = itemData[2],
                ItemCategory = category
            };

            return newItem;
        }

        public string getItemID(string action)
        {
            Console.WriteLine($"Please provide the item ID to {action}");
            return Console.ReadLine();
        }
    }
}
