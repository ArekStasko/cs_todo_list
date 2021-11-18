using System;

namespace ToDoList.DataControllers
{
    public class FileDataController : IFileDataControllersProvider
    {

        public void ChooseMainOption()
        {
            string selectedOption = Console.ReadLine();
            int optionNumber;

             while (!Int32.TryParse(selectedOption, out optionNumber))
            {
                Console.WriteLine("You have to choose the number of option");
                selectedOption = Console.ReadLine();
            }

            

        }

    }
}
