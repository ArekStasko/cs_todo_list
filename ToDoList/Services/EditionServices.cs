using System;
using System.Linq;
using ToDoList.DataAccess;
using ToDoList.Services;

namespace ToDoList
{
    public class EditionServices
    {
        ServiceHelpers serviceHelpers = new ServiceHelpers();
        private readonly IDataProvider _dataProvider;

        public EditionServices(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void ChooseEditionMethod(int selection)
        {
            switch (selection)
            {
      /*
                case 2:
                    if (!_dataProvider.GetCategories().Any())
                    {
                        Console.WriteLine("Whoops, you don't have any category yet, please add at least one");
                        this.AddCategory();
                    }
      */
            }
        }

    }
}