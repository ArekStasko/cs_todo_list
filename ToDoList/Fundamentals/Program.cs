using System;
using System.Collections.Generic;
using ToDoList.Storage;

namespace ToDoList
{
    public class Program
    {
        static void Main(string[] args)
        {
            Options optionsInitializer = new Options();
            MainStorage mainStorage = new MainStorage();
            optionsInitializer.initializeOptions();

            ActionService actionService = new ActionService(mainStorage.items, mainStorage.categories);

            int selectedOption = 0;

            while (selectedOption != 4)
            {
                selectedOption = optionsInitializer.getOptions();
                switch (selectedOption)
                {
                    case 1:
                        foreach (var item in mainStorage.items)
                        {
                            Console.WriteLine(item.ItemName);
                        }
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
            Console.WriteLine("Goodbye !");
            
        }
    }
}
