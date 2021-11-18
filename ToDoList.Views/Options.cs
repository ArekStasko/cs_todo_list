using System;
using ToDoList.DataControllers;

namespace ToDoList.Views
{
    public class Options : IOptionsProvider
    {
        private FileDataController dataController;
        private void printOptions(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
        }

        public void PrintMainOptions()
        {
        dataController = new FileDataController();
        string[] mainOptions = new string[] { "Show all items", "Show specific item", "Edit items", "Close ToDo list" };

            Console.WriteLine("Please select one option :");
            printOptions(mainOptions);
            dataController.ChooseMainOption();
        }

        public void PrintEditionOptions()
        {
        string[] editionOptions = new string[] { "Add new Category", "Add new item", "Delete item", "Delete category" };

            Console.WriteLine("Please select one edition option :");
            printOptions(editionOptions);
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