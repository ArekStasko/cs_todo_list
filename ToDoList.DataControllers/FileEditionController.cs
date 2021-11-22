using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.DataAccess;
using ToDoList.DataAccess.Models;

namespace ToDoList.DataControllers
{
    public class FileEditionController : FileDataController
    {
        private FileDataProvider dataProvider;
        private IEnumerable<string> categories;

        public FileEditionController(FileDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
            this.categories = dataProvider.GetCategories();
        }

        private int GetID(string message)
        {
            Console.WriteLine(message);
            string ID = Console.ReadLine();
            while (!Int32.TryParse(ID, out int n))
            {
                Console.WriteLine("ID must be number");
                ID = Console.ReadLine();
            }
            return Int32.Parse(ID);
        }

        private string GetCategory()
        {
            Console.WriteLine("- Please choose number of your item category -");

            base.PrintCategories(categories);
            string category = Console.ReadLine();
            int categoryNumber;

            while (!Int32.TryParse(category, out categoryNumber))
            {
                Console.WriteLine("- Please provide number of category -");
                category = Console.ReadLine();
            };

            return categories.ElementAt(categoryNumber);
        }

        private void AddNewCategory()
        {
            Console.WriteLine("- Please insert new category name -");
            string categoryName = Console.ReadLine();
            while (String.IsNullOrEmpty(categoryName))
            {
                Console.WriteLine("-Category can't be empty-");
                categoryName = Console.ReadLine();
            }

            dataProvider.AddCategory(categoryName);
        }

        private void AddNewItem()
        {
            IEnumerable<Item> items = dataProvider.GetItems();
            string[] itemQuery = new string[] { "Item Name", "Item Description" };
            List<string> itemData = new List<string>(2) { "", "" };

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

            string category = GetCategory();
            int itemID = GetID("Provide new item ID");

            var newItem = new Item()
            {
                ItemName = itemData[0],
                ItemDescription = itemData[1],
                ItemId = itemID,
                ItemCategory = category
            };

            while (items.SingleOrDefault(item => item.ItemId == newItem.ItemId) != null)
            {
                Console.WriteLine("- You already have item with this ID -");
                int newItemID = GetID("- Provide unique ID number -");
                newItem.ItemId = newItemID;
            }

            dataProvider.AddItem(newItem);
        }

        private void DeleteItem(int IdOfItemToDelete)
        {
            IEnumerable<Item> items = dataProvider.GetItems();
            var itemToDelete = items.Single(item => item.ItemId == IdOfItemToDelete);

            if (itemToDelete != null)
            {
                dataProvider.RemoveItem(itemToDelete);
            }
        }

        private void DeleteCategory()
        {
            IEnumerable<Item> items = dataProvider.GetItems();

            Console.WriteLine("Please provide the category name to delete");
            Console.WriteLine("- This will delete all items with this category -");
            string userInput = Console.ReadLine();
            var IsCategory = categories.Where(category => category == userInput);

            string categoryToDelete = IsCategory.ToString();

            if (IsCategory != null)
            {
                var ItemsToDelete = items.Where(item => item.ItemCategory == categoryToDelete);
                foreach(var item in ItemsToDelete)
                {
                    DeleteItem(item.ItemId);
                }

                dataProvider.RemoveCategory(categoryToDelete);
                Console.WriteLine("Successfully deleted category");
            }
            else Console.WriteLine("Sorry we couldn't find this category");
        }

        public void GetSelectedEditionOption(int selectedOption)
        {
            if (selectedOption == 1)
            {
                AddNewCategory();
            }
            else if (selectedOption == 2)
            {
                AddNewItem();
            }
            else if (selectedOption == 3)
            {
                int IdOfItemToDelete = GetID("- Please insert ID of item to delete -");
                DeleteItem(IdOfItemToDelete);
            }
            else if (selectedOption == 4)
            {
                DeleteCategory();
            }
            else
            {
                Console.WriteLine("You provide wrong option number");
            }
        }


    }
}
