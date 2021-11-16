using System;
using System.Collections.Generic;

namespace ToDoList.Views
{
    public class Options : IOptionsProvider
    {
        private string[] editionOptions = new string[] { "Add new Category", "Add new item", "Delete item", "Delete category" };


        public void PrintMainOptions()
        {
        string[] options = new string[] { "Show all items", "Show specific item", "Edit items", "Close ToDo list" };

            for(int i = 0; i<options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
        }


        public void PrintShowAllItem()
        {
            /*
             * For now i have to comment out it becouse i cant provide correct data type
             
               string itemRow = String.Format(" | {0,5} | {1,5} | {2,5} | {3,5}| ",
               item.ItemId,
               item.ItemCategory,
               item.ItemName,
               item.ItemDescription
               );
                Console.WriteLine(itemRow);
            */
        }
    }
       
}


/*
 * Methods to rebuild 
 
  public int getOptions()
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            return serviceHelpers.getUserSelection("- Please choose one option -");
        }


        public int GetEditionOptions()
        {
            Console.WriteLine("- What you want to do ? -");

            for (int i = 0; i < editionOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {editionOptions[i]}");
            }
            return serviceHelpers.getUserSelection("- Please choose one option -");
        }
 
 
 */