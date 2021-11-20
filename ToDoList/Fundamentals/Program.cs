using System;
using ToDoList.DataControllers;

namespace ToDoList
{
    //ZADANIE DOMOWE
    //1. Zrobić tak, żeby aplikacja się kompliwała
    //2. Dopisać brakujące testy jednostokowe do projektu ToDoList.DataAccess

    public class Program
    {
        static void Main(string[] args)
        {
            var dataController = new FileDataController();
            dataController.ChooseMainOption();
            
        }
    }
}