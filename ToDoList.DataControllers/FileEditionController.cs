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

            return categories.ElementAt(categoryNumber-1);
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
            int itemID = base.GetID("Provide new item ID");

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

        private void DeleteItem()
        {
            Item itemToDelete = GetItemByID("Provide ID of item to delete");
            dataProvider.RemoveItem(itemToDelete);
        }

        private void DeleteCategory()
        {
            Console.WriteLine("Please provide the category name to delete");
            Console.WriteLine("- This will delete all items with this category -");

            IEnumerable<Item> ItemsToDelete = GetItemsByCategory();
            string categoryToDelete = ItemsToDelete.First().ItemCategory;

            foreach (var item in ItemsToDelete)
            {
                dataProvider.RemoveItem(item);
            }

            dataProvider.RemoveCategory(categoryToDelete);
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
                DeleteItem();
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
