using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    public class Option
    {
        public string OptionName { get; set; }
        public int OptionID { get; set; }
    }

    public class Options
    {
        private List<Option> options = new List<Option>();
        private string[] optionList = new string[] { "Show all items", "Show single item", "Edit items" };
        
        public List<Option> initializeOptions()
        {
            for(int i=0; i<optionList.Length; i++)
            {
                options.Add(new Option() { OptionName=$"{i+1}. {optionList[i]}", OptionID=i });
            }
            Console.WriteLine("- Hello in my ToDo App ! -");
            return options;
        }

        public int getOptions()
        {
            foreach(var option in options)
            {
                Console.WriteLine(option.OptionName);
            }
            Console.WriteLine("- Please choose one option - ");
            string choseOption = Console.ReadLine();
            return Int32.Parse(choseOption);
        }
    }
}
