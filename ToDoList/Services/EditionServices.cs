using System;
using System.Collections.Generic;
using ToDoList.Storage;
using ToDoList.Services;
using System.Linq;

namespace ToDoList
{
    public class EditionServices
    {
        ServiceHelpers serviceHelpers = new ServiceHelpers();
        //private List<Item> _mainStorageItems;
        //private List<string> _mainStorageCategories;
        private MainStorage _mainStorage;

        public EditionServices(MainStorage mainStorage)
        {
            _mainStorage = mainStorage;
        }

        public void ChooseEditionMethod(int selection)
        {
            switch (selection)
            {
                case 1:
                    this.AddCategory();
                    break;
                case 2:
                    if(_mainStorage.categories.Count == 0)
                    {
                        Console.WriteLine("Whoops, you don't have any category yet, please add at least one");
                       this.AddCategory();
                    }
                    else AddItem();
                    break;
                case 3:
                    if (_mainStorage.items.Count != 0) DeleteItem();
                    else Console.WriteLine("Whoops, you don't have any item");
                    break;
            }
        }

        public void AddCategory()
        {
            Console.WriteLine("- Please insert new category name -");
            string categoryName = Console.ReadLine();
            while (String.IsNullOrEmpty(categoryName))
            {
                Console.WriteLine("-Category can't be empty-");
                categoryName = Console.ReadLine();
            }

            _mainStorage.categories.Add(categoryName);
            _mainStorage.categoriesEdition();
            
        }

        public void AddItem()
        {
            Console.WriteLine("- Please choose category of your product -");

            int index = 0;
            foreach(var category in _mainStorage.categories)
            {
                Console.WriteLine($"{index+1}. {category}");
                index++;
            }
            int selectedCategory = serviceHelpers.getUserSelection("- Please choose one category -");

            Item newItem = serviceHelpers.createNewItem(_mainStorage.categories[selectedCategory-1]);

            while (_mainStorage.items.SingleOrDefault(item => item.ItemID == newItem.ItemID) != null)
            {
                Console.WriteLine("- You already have item with this ID -");
                string userInput = Console.ReadLine();
                int newItemID = serviceHelpers.validateID(userInput);
                newItem.ItemID = newItemID;
            }

            _mainStorage.items.Add(newItem);
            _mainStorage.addItemToFile(newItem);
        }

        public void DeleteItem()
        {
            Console.WriteLine("Please provide the item ID to delete");
            string userInput = Console.ReadLine();
            int itemID = serviceHelpers.validateID(userInput);
            var itemToDelete = _mainStorage.items.Find(item => item.ItemID == itemID);

            if (itemToDelete != null)
            {
                _mainStorage.items.Remove(itemToDelete);
                _mainStorage.removeItemFromFile();
                Console.WriteLine("Successfull deleted item");
            }
            else Console.WriteLine("Sorry we couldn't find this item");
        }
    }
}
