using System;
using System.Collections.Generic;
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

        public int getUserSelection(string message)
        {
            Console.WriteLine($"{message}");
            string userSelection = Console.ReadLine();
            while(!int.TryParse(userSelection, out int n))
            {
                Console.WriteLine("- Please insert number of option -");
                userSelection = Console.ReadLine();
            }

            return Int32.Parse(userSelection);
        }

        public void itemRowCreator(Item item)
        {
            string itemRow = String.Format(" | {0,5} | {1,5} | {2,5} | {3,5}| ", item.ItemId, item.ItemCategory, item.ItemName, item.ItemDescription);
            Console.WriteLine(itemRow);
        }



        public string wantedItemFeature()
        {
            string[] itemOptions = new string[] { "Get single item from ID", "Get items with specific category" };

            Console.WriteLine("You want to get single item or items of specific category ?");
            for (int i = 0; i < itemOptions.Length; i++) 
            {
                Console.WriteLine($"{i + 1}. {itemOptions[i]}");
            }           

            return Console.ReadLine();
        }
    }
}
