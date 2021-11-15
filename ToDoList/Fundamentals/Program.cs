using System;
using ToDoList.DataAccess;
using ToDoList.Views;

namespace ToDoList
{
    //ZADANIE DOMOWE
    //1. Zrobić tak, żeby aplikacja się kompliwała
    //2. Dopisać brakujące testy jednostokowe do projektu ToDoList.DataAccess

    public class Program
    {
        static void Main(string[] args)
        {
            Options options = new Options();
            var mainStorage = new FileDataProvider();
            
            EditionServices actionServices = new EditionServices(mainStorage);
            /*ShowServices showServices = new ShowServices(mainStorage, mainStorage.categories);

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
            Console.WriteLine("Goodbye !");*/

        }
    }
}