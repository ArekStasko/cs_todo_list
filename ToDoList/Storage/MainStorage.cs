using System.Collections.Generic;

namespace ToDoList.Storage
{
    public class Item
    {
        public string ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string ItemDescription { get; set; }
        public int ItemID { get; set; }

    }
    
    public class MainStorage
    {
        public List<Item> items = new List<Item>();
        public List<string> categories = new List<string>();
    }
}
