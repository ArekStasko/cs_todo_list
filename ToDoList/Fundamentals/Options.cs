using System;
using ToDoList.Services;

namespace ToDoList
{
    public class Options
    {
        ServiceHelpers serviceHelpers = new ServiceHelpers();
        private string[] options = new string[] { "Show all items", "Show specific item", "Edit items", "Close ToDo list" };
        private string[] editionOptions = new string[] { "Add new Category", "Add new item", "Delete item", "Delete category" };


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
    }
}