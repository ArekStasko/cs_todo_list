using System;
using System.Linq;
using ToDoList.DataAccess;
using ToDoList.Services;

namespace ToDoList
{
    public class EditionServices
    {
        ServiceHelpers serviceHelpers = new ServiceHelpers();
        private readonly IDataProvider _dataProvider;

        public EditionServices(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void ChooseEditionMethod(int selection)
        {
            switch (selection)
            {
                case 1:
                    this.AddCategory();
                    break;
                case 2:
                    if (!_dataProvider.GetCategories().Any())
                    {
                        Console.WriteLine("Whoops, you don't have any category yet, please add at least one");
                        this.AddCategory();
                    }
                    else AddItem();
                    break;
                /*case 3:
                    if (_dataProvider.items.Count != 0) DeleteItem();
                    else Console.WriteLine("Whoops, you don't have any item");
                    break;
                case 4:
                    if (_dataProvider.categories.Count == 0)
                        Console.WriteLine("You don't have any category to delete");

                    else deleteCategory();
                    break;*/
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

           // _dataProvider.categories.Add(categoryName);
            //_dataProvider.categoriesEdition();

        }

        public void AddItem()
        {
            Console.WriteLine("- Please choose category of your product -");
            /*
            int index = 0;
            foreach (var category in _dataProvider.categories)
            {
                Console.WriteLine($"{index + 1}. {category}");
                index++;
            }
            int selectedCategory = serviceHelpers.getUserSelection("- Please choose one category -");

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

        public void DeleteItem()
        {
            string userSelection = serviceHelpers.wantedCategoriesOrItems("delete");
            /*
            string userInput;

            switch (userSelection)
            {
                case "1":
                    Console.WriteLine("- Please insert ID of item to delete -");
                    userInput = Console.ReadLine();
                    int itemID = serviceHelpers.validateID(userInput);
                    var itemToDelete = _dataProvider.items.Find(item => item.ItemID == itemID);

                    if (itemToDelete != null)
                    {
                        _dataProvider.items.Remove(itemToDelete);
                        _dataProvider.removeItemFromFile();
                        Console.WriteLine("Successfully deleted item");
                    }
                    else Console.WriteLine("Sorry we couldn't find this item");
                    break;
                case "2":
                    Console.WriteLine("- Please insert category of items to delete -");
                    userInput = Console.ReadLine();
                    var wantedItemByCategory = _dataProvider.items.FindAll(item => item.ItemCategory == userInput);
                    if (wantedItemByCategory != null)
                    {
                        foreach (var item in wantedItemByCategory)
                        {
                            _dataProvider.items.Remove(item);
                            _dataProvider.removeItemFromFile();
                            Console.WriteLine("Successfully deleted items");
                        }
                    }
                    else Console.WriteLine("- You don't have any items with this category -");
                    break;
            }*/

        }

        public void deleteCategory()
        {
           /* Console.WriteLine("Please provide the category name to delete");
            Console.WriteLine("- This will not delete all items with this category -");
            string userInput = Console.ReadLine();
            var categoryToDelete = _dataProvider.categories.Find(category => category == userInput);

            if (categoryToDelete != null)
            {
                _dataProvider.categories.Remove(categoryToDelete);
                _dataProvider.categoriesEdition();
                Console.WriteLine("Successfully deleted category");
            }
            else Console.WriteLine("Sorry we couldn't find this category");*/
        }
    }
}