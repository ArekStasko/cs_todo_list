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
        private List<Item> _mainStorageItems;
        private List<Category> _mainStorageCategories;

        public EditionServices(List<Item> storageItems, List<Category> storageCategories)
        {
            _mainStorageItems = storageItems;
            _mainStorageCategories = storageCategories;
        }

        public void ChooseEditionMethod(int selection)
        {
            switch (selection)
            {
                case 1:
                    AddCategory(null);
                    break;
                case 2:
                    if(_mainStorageCategories.Count == 0)
                    {
                        Console.WriteLine("Whoops, you don't have any category yet, please add at least one");
                        AddCategory(null);
                    }
                    else AddProduct();
                    break;
                case 3:
                    if (_mainStorageItems.Count != 0) DeleteProduct();
                    else Console.WriteLine("Whoops, you don't have any items");
                    break;
            }
        }

        public void AddCategory(string ctgName)
        {
            Console.WriteLine("- Please insert new category name -");
            string categoryName = ctgName != null ? ctgName : Console.ReadLine();
            Category newCategory = new Category() { CategoryName = categoryName };

            _mainStorageCategories.Add(newCategory);
        }

        public void AddProduct()
        {
            Console.WriteLine("- Please choose category of your product -");

            int index = 0;
            foreach(var cat in _mainStorageCategories)
            {
                Console.WriteLine($"{index+1}. {cat.CategoryName}");
                index++;
            }
            int selectedCategory = serviceHelpers.getUserSelection("- Please choose one category -");

            Item newItem = serviceHelpers.createNewItem(_mainStorageCategories[selectedCategory-1].CategoryName);

            while (_mainStorageItems.SingleOrDefault(item => item.ItemId == newItem.ItemId) != null)
            {
                Console.WriteLine("- You already have item with this ID -");
                newItem.ItemId = Console.ReadLine();
            }

            _mainStorageItems.Add(newItem);
        }

        public void DeleteProduct()
        {
            Console.WriteLine("Please provide the item ID to delete");
            string itemID = Console.ReadLine();
            var itemToDelete = _mainStorageItems.Find(item => item.ItemId == itemID);

            if (itemToDelete != null)
            {
                _mainStorageItems.Remove(itemToDelete);
                Console.WriteLine("Successfull deleted item");
            }
            else Console.WriteLine("Sorry we couldn't find this item");
        }
    }
}
