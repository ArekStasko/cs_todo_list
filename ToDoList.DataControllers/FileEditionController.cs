using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.DataAccess;
using ToDoList.DataAccess.Models;
using ToDoList.Views;

namespace ToDoList.DataControllers
{
    public class FileEditionController : FileDataController
    {
        private FileDataProvider dataProvider;
        private IEnumerable<string> categories;
        private IEnumerable<Item> items;

        public void GetSelectedEditionOption(int selectedOption)
        {
            var dataProvider = new FileDataProvider();
            var categories = dataProvider.GetCategories();
            var items = dataProvider.GetItems();

            switch (selectedOption)
            {
                case 1:
                    AddNewCategory();
                    break;
                case 2:
                    if (!categories.Any())
                    {
                        Console.WriteLine("Please first add at least one category");
                        AddNewCategory();
                    }
                    else
                    {
                        AddNewItem();
                    }
                    break;
                case 3:
                    ChangeItemCount();
                    break;
                case 4:
                    if (!items.Any())
                    {
                        Console.WriteLine("You don't have any items");
                    }
                    else
                    {
                        DeleteItem();
                    }
                    break;
                case 5:
                    if (!categories.Any())
                    {
                        Console.WriteLine("You don't have any category");
                    }
                    else
        {
                        DeleteCategory();
        }
                    break;
                default:
                    Console.WriteLine("You provide wrong option number");
                    break;

            }
        }


        private string GetCategory()
        {
            Console.WriteLine("- Please choose number of your item category -");

            var dataProvider = new FileDataProvider();
            var categories = dataProvider.GetCategories();

            var showProvider = new ShowProvider();
            showProvider.PrintCategories(categories);
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

            var dataProvider = new FileDataProvider();
            dataProvider.AddCategory(categoryName);

            var showProvider = new ShowProvider();
            showProvider.DisplayMessage("Successfully added new category");
        }

        private void AddNewItem()
        {
                Console.WriteLine("Insert Item Name");
                string ItemName = Console.ReadLine();

                while (String.IsNullOrEmpty(ItemName))
                {
                    Console.WriteLine("-You can't add empty Item Name-");
                    ItemName = Console.ReadLine();
                }

            int itemCount = GetNumericValue("Insert Item Count");

            string category = GetCategory();
            int itemID = GetNumericValue("Provide new item ID");

            var dataProvider = new FileDataProvider();
            var items = dataProvider.GetItems();

            if (items.Any(item=>item.ItemId == itemID))
            {
                Console.WriteLine("You already have item with this ID");
                itemID = GetNumericValue("Provide new item unique ID");
            }

            var newItem = new Item()
            {
                ItemName = ItemName,
                ItemCount = itemCount,
                ItemId = itemID,
                ItemCategory = category
            };

            dataProvider.AddItem(newItem);

            var showProvider = new ShowProvider();
            showProvider.DisplayMessage("Successfully added new item");
            }

        private void ChangeItemCount()
        {
            var dataProvider = new FileDataProvider();
            var items = dataProvider.GetItems();

            var showProvider = new ShowProvider();
            showProvider.PrintManyItems(items);
            
            var itemToChange = GetItemByID("Provide ID of item to change count");
            int countToAdd = GetNumericValue("How many you want to add ? :");

            itemToChange.ItemCount += countToAdd;
            dataProvider.UpdateItemCount(itemToChange);
        }

        private void DeleteItem()
        {

            Item itemToDelete = GetItemByID("Provide ID of item to delete");

            var dataProvider = new FileDataProvider();
            dataProvider.RemoveItem(itemToDelete);

            var showProvider = new ShowProvider();
            showProvider.DisplayMessage("Successfully deleted item");
        }

        private void DeleteCategory()
        {

            Console.WriteLine("Please provide the category name to delete");
            Console.WriteLine("- This will delete all items with this category -");
            string userInput = Console.ReadLine();

            IEnumerable<Item> ItemsToDelete = GetItemsByCategory(userInput);

            var dataProvider = new FileDataProvider();
            if (ItemsToDelete.Any())
            {
                dataProvider.RemoveItems(ItemsToDelete.ToList());
            }
            dataProvider.RemoveCategory(userInput);
            DisplayMessage("Successfully deleted category");
        }           
        
            var showProvider = new ShowProvider();
            showProvider.DisplayMessage("Successfully deleted category");
        }


    }
}
