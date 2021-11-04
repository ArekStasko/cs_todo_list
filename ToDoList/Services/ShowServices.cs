using System;
using System.Collections.Generic;
using System.IO;
using ToDoList.Storage;

namespace ToDoList.Services
{
    public class ShowServices
    {
        private List<Item> _mainStorageItems;
        private List<string> _mainStorageCategories;
        public ShowServices(List<Item> storageItems, List<string> storageCategories)
        {
            _mainStorageItems = storageItems;
            _mainStorageCategories = storageCategories;
        }

        ServiceHelpers serviceHelpers = new ServiceHelpers();

        public void ShowAllItems()
        {
            Console.WriteLine(String.Format(" | {0,5} | {1,5} | {2,5} | {3,5} | ", "Item ID", "Item Category", "Item Name", "Item Description"));

            foreach(var item in _mainStorageItems)
            {
                serviceHelpers.itemRowCreator(item);
            }



        }

        public void ShowSingleItem()
        {


            string userSelection = serviceHelpers.wantedItemFeature();

            switch (userSelection)
            {
                case "1":
                    Console.WriteLine("- Please insert item ID -");
                    string userInput = Console.ReadLine();
                    int itemID = serviceHelpers.validateID(userInput);
                    var wantedItemByID = _mainStorageItems.Find(item => item.ItemID == itemID);
                    if(wantedItemByID == null) Console.WriteLine("-You don't have item with this ID-");
                    else serviceHelpers.itemRowCreator(wantedItemByID);
                    break;
                case "2":
                    Console.WriteLine("- Please insert items category -");
                    string itemCategory = Console.ReadLine();
                    var wantedItemByCategory = _mainStorageItems.FindAll(item => item.ItemCategory == itemCategory);
                    if (wantedItemByCategory != null) serviceHelpers.manyItemsRowCreator(wantedItemByCategory);
                    else Console.WriteLine("You don't have item with this category");
                    break;
            }

        }

    }
}
