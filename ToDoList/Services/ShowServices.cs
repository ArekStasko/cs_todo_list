using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Storage;

namespace ToDoList.Services
{
    public class ShowServices
    {
        private List<Item> _mainStorageItems;
        private List<Category> _mainStorageCategories;
        public ShowServices(List<Item> storageItems, List<Category> storageCategories)
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
                // I will separate the wantedItemByID and wantedItemByCategory
                case "1":
                    Console.WriteLine("- Please insert item ID -");
                    string itemID = Console.ReadLine();
                    var wantedItemByID = _mainStorageItems.Find(item => item.ItemId == itemID);
                    serviceHelpers.itemRowCreator(wantedItemByID);
                    break;
                case "2":
                    Console.WriteLine("- Please insert items category -");
                    string itemCategory = Console.ReadLine();
                    var wantedItemByCategory = _mainStorageItems.Find(item => item.ItemCategory == itemCategory);
                    serviceHelpers.itemRowCreator(wantedItemByCategory);
                    break;
            }

        }

    }
}
