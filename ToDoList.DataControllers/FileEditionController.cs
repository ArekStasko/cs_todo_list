using System;
using System.Collections.Generic;
using ToDoList.DataAccess;

namespace ToDoList.DataControllers
{
    public class FileEditionController
    {
        private FileDataProvider dataProvider;

        public FileEditionController(FileDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
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
            Console.WriteLine("- Please choose category of your product -");

            IEnumerable<string> categories = dataProvider.GetCategories();
       

            int index = 0;
            foreach (var category in categories)
            {
                Console.WriteLine($"{index + 1}. {category}");
                index++;
            }


            /*
             

            Item newItem = serviceHelpers.createNewItem(_dataProvider.categories[selectedCategory - 1]);

            while (_dataProvider.items.SingleOrDefault(item => item.ItemID == newItem.ItemId) != null)
            {
                Console.WriteLine("- You already have item with this ID -");
                string userInput = Console.ReadLine();
                int newItemID = serviceHelpers.validateID(userInput);
                newItem.ItemId = newItemID;
            }

            _dataProvider.items.Add(newItem);
            _dataProvider.addItemToFile(newItem);*/
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
