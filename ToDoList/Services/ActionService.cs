using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Storage;

namespace ToDoList
{
    public class ActionService
    {
        
        MainStorage mainStorage = new MainStorage();

        public void ChooseEditionMethod(int selection)
        {
            switch (selection)
            {
                case 1:
                    AddCategory(null);
                    break;
                case 2:
                    if(mainStorage.categories.Count == 0)
                    {
                        Console.WriteLine("Whoops, you don't have any category yet, please add at least one");
                        AddCategory(null);
                    }
                    else
                    {
                        AddProduct();
                    }
                    break;
                case 3:
                    break;
            }
        }

        //I will separate ReadLines to separated class to make the code more responsibility
        public void AddCategory(string ctgName)
        {
            Console.WriteLine("- Please insert new category name -");
            string categoryName = ctgName != null ? ctgName : Console.ReadLine();
            Category newCategory = new Category() { CategoryName = categoryName };

            mainStorage.categories.Add(newCategory);
        }

        public void AddProduct()
        {
            Console.WriteLine("- Please choose category of your product -");

            int index = 0;
            foreach(var cat in mainStorage.categories)
            {
                index++;
                Console.WriteLine($"{index+1}. {cat}");
            }
        }
    }
}
