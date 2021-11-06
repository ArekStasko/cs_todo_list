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
                case 4:
                    if (_mainStorage.categories.Count == 0)
                        Console.WriteLine("You don't have any category to delete");

                    else deleteCategory();
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
            string userSelection = serviceHelpers.wantedCategoriesOrItems("delete");
            string userInput;

            switch (userSelection)
            {
                case "1":
                    Console.WriteLine("- Please insert ID of item to delete -");
                    userInput = Console.ReadLine();
                    int itemID = serviceHelpers.validateID(userInput);
                    var itemToDelete = _mainStorage.items.Find(item => item.ItemID == itemID);

                    if (itemToDelete != null)
                    {
                        _mainStorage.items.Remove(itemToDelete);
                        _mainStorage.removeItemFromFile();
                        Console.WriteLine("Successfully deleted item");
                    }
                    else Console.WriteLine("Sorry we couldn't find this item");
                    break;
                case "2":
                    Console.WriteLine("- Please insert category of items to delete -");
                    userInput = Console.ReadLine();
                    var wantedItemByCategory = _mainStorage.items.FindAll(item => item.ItemCategory == userInput);
                    if (wantedItemByCategory != null)
                    {
                        foreach (var item in wantedItemByCategory)
                        {
                            _mainStorage.items.Remove(item);
                            _mainStorage.removeItemFromFile();
                            Console.WriteLine("Successfully deleted items");
                        }
                    }
                    else Console.WriteLine("- You don't have any items with this category -");
                    break;
            }
            
        }

        public void deleteCategory()
        {
            Console.WriteLine("Please provide the category name to delete");
            Console.WriteLine("- This will not delete all items with this category -");
            string userInput = Console.ReadLine();
            var categoryToDelete = _mainStorage.categories.Find(category => category == userInput);
            
            if(categoryToDelete != null)
            {
                _mainStorage.categories.Remove(categoryToDelete);
                _mainStorage.categoriesEdition();
                Console.WriteLine("Successfully deleted category");
            }
            else Console.WriteLine("Sorry we couldn't find this category");
        }
    }
}
