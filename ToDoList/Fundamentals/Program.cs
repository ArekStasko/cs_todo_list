using System;
using System.Collections.Generic;

namespace ToDoList
{
    public class Program
    {
        static void Main(string[] args)
        {
            Options optionsInitializer = new Options();
            optionsInitializer.initializeOptions();

            ActionService actionService = new ActionService();

            int selectedOption = optionsInitializer.getOptions();

            
            switch (selectedOption)
            {
                case 1:
                    Console.WriteLine(selectedOption);
                    break;
                case 2:
                    Console.WriteLine(selectedOption);
                    break;
                case 3:
                    int userSelection = optionsInitializer.GetEditionOptions();
                    actionService.ChooseEditionMethod(userSelection);
                    break;
            }
        }
    }
}
