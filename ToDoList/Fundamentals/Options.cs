using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Services;

namespace ToDoList
{
    public class Option
    {
        public string OptionName { get; set; }
        public int OptionID { get; set; }
    }

    public class Options
    {
        ServiceHelpers serviceHelpers = new ServiceHelpers();
        private List<Option> options = new List<Option>();
        private string[] optionList = new string[] { "Show all items", "Show specific item", "Edit items", "Close ToDo list" };
        private string[] editionOptions = new string[] { "Add new Category", "Add new item", "Delete item" };
        
        public Options()
        {
            Console.WriteLine("- Hello in my ToDo App ! -");
            for (int i = 0; i < optionList.Length; i++)
            {
                options.Add(new Option() { OptionName = $"{i + 1}. {optionList[i]}", OptionID = i });
            }
        }


        public int getOptions()
        {
            foreach(var option in options)
            {
                Console.WriteLine(option.OptionName);
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
