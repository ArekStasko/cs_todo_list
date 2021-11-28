using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.DataAccess;
using ToDoList.DataAccess.Models;
using ToDoList.Views;

namespace ToDoList.DataControllers
{
    public class FileDataController : Options, IFileDataControllersProvider
    {
        private FileDataProvider dataProvider = new FileDataProvider();

        private int GetUserSelection()
        {
            string selectedOption = Console.ReadLine();
            int optionNumber;

            while (!Int32.TryParse(selectedOption, out optionNumber))
            {
                Console.WriteLine("You have to choose the number of option");
                selectedOption = Console.ReadLine();
            }

            return optionNumber;
        }

        protected int GetID(string message)
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

        protected Item GetItemByID(string msg)
        {
            IEnumerable<Item> items = dataProvider.GetItems();

            int itemID = GetID(msg);

            try
            {
                var item = items.Single(item => item.ItemId == itemID);
                return item;
            }
            catch(Exception)
            {
                throw new Exception($"You don't have item with {itemID} ID");
            }

        }


        protected IEnumerable<Item> GetItemsByCategory(string category)
        {
            IEnumerable<string> categories = dataProvider.GetCategories();
            IEnumerable<Item> items = dataProvider.GetItems();
            try
            {
                return items.Where(item => item.ItemCategory == category);
            }
            catch(Exception)
            {
                throw new Exception($"You don't have {category} category");
            }
        }


        public void ChooseMainOption()
        {
            base.PrintMainOptions();
            int userSelection = GetUserSelection();


            if (userSelection == 1)
            {
                IEnumerable<Item> items = dataProvider.GetItems();

                foreach (var item in items)
                {
                    base.PrintItem(item);
                }

            }
            else if (userSelection == 2)
            {
                base.PrintItemSearchOptions();
                int selectedSearchItemOption = GetUserSelection();

                if (selectedSearchItemOption == 1)
                {
                    Item searchedItem = GetItemByID("Provide item ID to find");
                    base.PrintItem(searchedItem);
                }
                else if (selectedSearchItemOption == 2)
                {

                    Console.WriteLine("Provide items category to find");
                    string userInput = Console.ReadLine();

                    IEnumerable<Item> searchedItems = GetItemsByCategory(userInput);
                    foreach (var item in searchedItems)
                    {
                        base.PrintItem(item);
                    }
                }

            }
            else if (userSelection == 3)
            {
                base.PrintEditionOptions();
                int selectedEditionOption = GetUserSelection();

                FileEditionController editionController = new FileEditionController(dataProvider);
                editionController.GetSelectedEditionOption(selectedEditionOption);
            }
            else if (userSelection == 4)
            {
                Console.WriteLine("Goodbye ! :D");
            }
            else
            {
                Console.WriteLine("You provide wrong option number");
            }
        }
    }
}
