using ToDoList.DataAccess.Models;
using System.Collections.Generic;

namespace ToDoList.Views
{
    public interface IOptions
    {

        void PrintMainOptions();
        void PrintEditionOptions();
        void PrintItemSearchOptions();
        void PrintItem(Item item);
        void PrintCategories(IEnumerable<string> categories);
    }
}
