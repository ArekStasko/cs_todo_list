using System;
using System.Collections.Generic;
using ToDoList.DataAccess.Models;

namespace ToDoList.Services
{
    public class ServiceHelpers
    {


        public string wantedCategoriesOrItems(string action)
        {
            string[] itemOptions = new string[] { $"{action} single item from ID", $"{action} items with specific category" };

            Console.WriteLine($"You want to {action} single item or items of specific category ?");
            for (int i = 0; i < itemOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {itemOptions[i]}");
            }

            string userSelection = Console.ReadLine();
            while (String.IsNullOrEmpty(userSelection) || !Int32.TryParse(userSelection, out int n))
            {
                Console.WriteLine("-Please insert correct option-");
                userSelection = Console.ReadLine();
            }

            return userSelection;
        }


    }
}