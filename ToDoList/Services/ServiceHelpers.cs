using System;
using System.Collections.Generic;
using ToDoList.DataAccess.Models;

namespace ToDoList.Services
{
    public class ServiceHelpers
    {

        public Item createNewItem(string category)
        {
            string[] itemQuery = new string[] { "Item Name", "Item Description", "Item ID" };
            List<string> itemData = new List<string>(4) { "", "", "", "" };

            for (int i = 0; i < itemQuery.Length; i++)
            {
                Console.WriteLine($"Insert {itemQuery[i]}");
                string providedData = Console.ReadLine();

                while (String.IsNullOrEmpty(providedData))
                {
                    Console.WriteLine("-You can't add empty data-");
                    providedData = Console.ReadLine();
                }

                itemData[i] = providedData;
            }

            while (!Int32.TryParse(itemData[2], out int n))
            {
                Console.WriteLine("-ID of item must be number-");
                itemData[2] = Console.ReadLine();
            }

            var newItem = new Item()
            {
                ItemName = itemData[0],
                ItemDescription = itemData[1],
                ItemId = Int32.Parse(itemData[2]),
                ItemCategory = category
            };

            return newItem;
        }

        public int getUserSelection(string message)
        {
            Console.WriteLine($"{message}");
            string userSelection = Console.ReadLine();
            bool isSelectionCorrect = Int32.TryParse(userSelection, out int n);
            while (!isSelectionCorrect)
            {
                Console.WriteLine("- Please insert number of option -");
                userSelection = Console.ReadLine();
                isSelectionCorrect = Int32.TryParse(userSelection, out n);
            }

            return Int32.Parse(userSelection);
        }

        public void itemRowCreator(Item item)
        {
            string itemRow = String.Format(" | {0,5} | {1,5} | {2,5} | {3,5}| ",
                item.ItemId,
                item.ItemCategory,
                item.ItemName,
                item.ItemDescription
                );
            Console.WriteLine(itemRow);
        }

        public void manyItemsRowCreator(List<Item> items)
        {
            foreach (var item in items)
            {
                this.itemRowCreator(item);
            }
        }



        public string wantedCategoriesOrItems(string action)
        {
            string[] itemOptions = new string[] { $"{action} single item from ID", $"{action} items with specific category" };

            Console.WriteLine($"You want to {action} single item or items of specific category ?");
            for (int i = 0; i < itemOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {itemOptions[i]}");
            }

            string userSelection = Console.ReadLine();
            while (String.IsNullOrEmpty(userSelection) || !Int32.TryParse(userSelection, out int n))
            {
                Console.WriteLine("-Please insert correct option-");
                userSelection = Console.ReadLine();
            }

            return userSelection;
        }

        public int validateID(string userInput)
        {
            string ID = userInput;
            while (!Int32.TryParse(ID, out int n))
            {
                Console.WriteLine("ID must be number");
                ID = Console.ReadLine();
            }
            return Int32.Parse(ID);
        }
    }
}