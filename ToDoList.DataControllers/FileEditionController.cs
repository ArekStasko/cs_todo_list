﻿using System;
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
        private IEnumerable<Item> items;

        public FileEditionController(FileDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
            categories = dataProvider.GetCategories();
            items = dataProvider.GetItems();
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
            DisplayMessage("Successfully added new category");
        }

        private void AddNewItem()
        {
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

            if(items.Any(item=>item.ItemId == itemID))
            {
                Console.WriteLine("You already have item with this ID");
                itemID = GetID("Provide new item unique ID");
            }

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
            DisplayMessage("Successfully added new item");
        }

        private void DeleteItem()
        {

            Item itemToDelete = GetItemByID("Provide ID of item to delete");
            dataProvider.RemoveItem(itemToDelete);
            DisplayMessage("Successfully deleted item");
        }

        private void DeleteCategory()
        {

            Console.WriteLine("Please provide the category name to delete");
            Console.WriteLine("- This will delete all items with this category -");
            string userInput = Console.ReadLine();

            IEnumerable<Item> ItemsToDelete = GetItemsByCategory(userInput);
            if (ItemsToDelete.Any())
            {
                dataProvider.RemoveItems(ItemsToDelete.ToList());
            }
            dataProvider.RemoveCategory(userInput);
            DisplayMessage("Successfully deleted category");
        }           
        

        public void GetSelectedEditionOption(int selectedOption)
        {
            if (selectedOption == 1)
            {
                AddNewCategory();
            }
            else if (selectedOption == 2)
            {
                if (!categories.Any())
                {
                    Console.WriteLine("Please first add at least one category");
                    AddNewCategory();
                }
                else
                {
                    AddNewItem();
                }
            }
            else if (selectedOption == 3)
            {
                if (!items.Any())
                {
                    Console.WriteLine("You don't have any items");
                }
                else
                {
                    DeleteItem();
                }
            }
            else if (selectedOption == 4)
            {
                if (!categories.Any())
                {
                    Console.WriteLine("You don't have any category");
                }
                else
                {
                    DeleteCategory();
                }
            }
            else
            {
                Console.WriteLine("You provide wrong option number");
            }
        }


    }
}
