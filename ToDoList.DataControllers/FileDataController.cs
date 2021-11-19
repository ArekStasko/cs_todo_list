using System;

namespace ToDoList.DataControllers
{
    public class FileDataController :  IFileDataControllersProvider
    {

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
            int userSelection = GetUserSelection();

            if (userSelection == 1)
            {
                Console.WriteLine("show all items method call");
            }
            else if (userSelection == 2)
            {
                Console.WriteLine("Call method for choosing which specification user want to use id or category");
            }
            else if (userSelection == 3)
            {

                Console.WriteLine("Print edition options method");
            }
            else if (userSelection == 4)
            {
                Console.WriteLine("Close app");
            }
            else
            {
                Console.WriteLine("You provide wrong option number");
            }


        }

    }
}
