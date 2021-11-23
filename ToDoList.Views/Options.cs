using System;
using System.Collections.Generic;
using ToDoList.DataAccess.Models;

namespace ToDoList.Views
{
    public class Options : IOptionsProvider
    {
        private void printOptions(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
        }

        public void PrintMainOptions()
        {
            string[] mainOptions = new string[] { 
                "Show all items", 
                "Show specific item", 
                "Edit items", 
                "Close ToDo list" 
            };

            Console.WriteLine("Please select one option :");
            printOptions(mainOptions);
        }

        public void PrintEditionOptions()
        {
            string[] editionOptions = new string[] { 
                "Add new Category", 
                "Add new item", 
                "Delete item", 
                "Delete category" 
            };

            Console.WriteLine("Please select one edition option :");
            printOptions(editionOptions);
        }

        public void PrintItemSearchOptions()
        {
            string[] itemOptions = new string[] { 
                "Get single item from ID", 
                "Get items with specific category" 
            };

            Console.WriteLine("Please select one item search option :");
            printOptions(itemOptions);
        }

        public void PrintItem(Item item)
        {
            string itemRow = String.Format(" | {0,5} | {1,5} | {2,5} | {3,5}| ",
            item.ItemId,
            item.ItemCategory,
            item.ItemName,
            item.ItemDescription
            );
            Console.WriteLine(itemRow);
        }

        public void PrintCategories(IEnumerable<string> categories)
        {
            int index = 0;
            foreach (var category in categories)
            {
                Console.WriteLine($"{index + 1}. {category}");
                index++;
            }
        }

    }
}