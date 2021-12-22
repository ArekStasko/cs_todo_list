using System;
using Warehouse.DataControllers;

namespace Warehouse
{
    public class Program
    {
        static void Main(string[] args)
        {

            var dataController = new FileDataController();

            while (true)
            {
                dataController.ChooseMainOption();
            }

        }
    }
}