using System.Collections.Generic;

namespace ToDoList.Storage
{
    public class Item
    {
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string ItemDescription { get; set; }
        public int ItemId { get; set; }

    }

    public class Category
    {
        public string CategoryName { get; set; }
    }
    public class MainStorage
    {
        public List<Item> items = new List<Item>();
        public List<Category> categories = new List<Category>();
    }
}
