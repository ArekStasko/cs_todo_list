using System;
using ToDoList.Storage;
using ToDoList.Services;

namespace ToDoList
{
    public class Program
    {
        static void Main(string[] args)
        {
            Options options = new Options();
            MainStorage mainStorage = new MainStorage();

            EditionServices actionServices = new EditionServices(mainStorage);
            ShowServices showServices = new ShowServices(mainStorage.items, mainStorage.categories);
            
            int selectedOption = 0;

            while (selectedOption != 4)
            {
                selectedOption = options.getOptions();
                switch (selectedOption)
                {
                    case 1:
                        showServices.ShowAllItems();
                        break;
                    case 2:
                        showServices.ShowSingleItem();
                        break;
                    case 3:
                        int userSelection = options.GetEditionOptions();
                        actionServices.ChooseEditionMethod(userSelection);
                        break;
                }
            }
            Console.WriteLine("Goodbye !");
            
        }
    }
}
