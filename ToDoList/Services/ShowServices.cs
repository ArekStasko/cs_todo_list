using System;
using System.Collections.Generic;
using ToDoList.DataAccess.Models;

namespace ToDoList.Services
{
    public class ShowServices
    {
        /*

        For rebuild time this have to be comment out because it causes errors


        private List<Item> _mainStorageItems; //Tego nie powinno tu być
        public ShowServices(List<Item> storageItems)
        {
            _mainStorageItems = storageItems;
        }

        ServiceHelpers serviceHelpers = new ServiceHelpers();

        public void ShowAllItems()
        {
            Console.WriteLine(String.Format(" | {0,5} | {1,5} | {2,5} | {3,5} | ", "Item ID", "Item Category", "Item Name", "Item Description"));

            foreach (var item in _mainStorageItems)
            {
                serviceHelpers.itemRowCreator(item);
            }



        }

        public void ShowSingleItem()
        {


            string userSelection = serviceHelpers.wantedCategoriesOrItems("get");
            string userInput;

            switch (userSelection)
            {
                case "1":
                    Console.WriteLine("- Please insert item ID -");
                    userInput = Console.ReadLine();
                    int itemID = serviceHelpers.validateID(userInput);
                    var wantedItemByID = _mainStorageItems.Find(item => item.ItemId == itemID);
                    if (wantedItemByID == null) Console.WriteLine("- You don't have item with this ID -");
                    else serviceHelpers.itemRowCreator(wantedItemByID);
                    break;
                case "2":
                    Console.WriteLine("- Please insert items category -");
                    userInput = Console.ReadLine();
                    var wantedItemByCategory = _mainStorageItems.FindAll(item => item.ItemCategory == userInput);
                    if (wantedItemByCategory != null) serviceHelpers.manyItemsRowCreator(wantedItemByCategory);
                    else Console.WriteLine("- You don't have item with this category -");
                    break;
            }

        }


        */

    }
}