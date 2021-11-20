using System;
using System.Collections.Generic;
using ToDoList.Views;
using ToDoList.DataAccess;
using ToDoList.DataAccess.Models;

namespace ToDoList.DataControllers
{
    public class FileDataController : Options, IFileDataControllersProvider
    {
        private FileDataProvider dataProvider;


        private int GetUserSelection()
        {
            string selectedOption = Console.ReadLine();
            int optionNumber;

            while (!Int32.TryParse(selectedOption, out optionNumber))
            {
                Console.WriteLine("You have to choose the number of option");
                selectedOption = Console.ReadLine();
            }

            return optionNumber;
        }



        public void ChooseMainOption()
        {
            base.PrintMainOptions();
            int userSelection = GetUserSelection();
            dataProvider = new FileDataProvider();

            if (userSelection == 1)
            {
                IEnumerable<Item> items = dataProvider.GetItems();

                foreach(var item in items)
                {
                    base.PrintItem(item);
                }
                
            }
            else if (userSelection == 2)
            {
                Console.WriteLine("Call method for choosing which specification user want to use id or category");
            }
            else if (userSelection == 3)
            {
                base.PrintEditionOptions();
                int selectedEditionOption = GetUserSelection();

                FileEditionController editionController = new FileEditionController(dataProvider);
                editionController.GetSelectedEditionOption(selectedEditionOption);
            }
            else if (userSelection == 4)
            {
                Console.WriteLine("Goodbye ! :D");
            }
            else
            {
                Console.WriteLine("You provide wrong option number");
            }


        }

    }
}
