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

        public FileEditionController(FileDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        private int GetID()
        {
            Console.WriteLine("Provide item ID number");
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
            IEnumerable<string> categories = dataProvider.GetCategories();

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
            int itemID = GetID();

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
                int newItemID = GetID();
                newItem.ItemId = newItemID;
            }

            dataProvider.AddItem(newItem);
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

            }
            else if (selectedOption == 4)
            {

            }
            else
            {
                Console.WriteLine("You provide wrong option number");
            }
        }


    }
}
