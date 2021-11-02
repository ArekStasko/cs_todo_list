using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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
        private string categoriesFilePath = @"D:\apps\toDoList\categories.txt";
        private string itemsFilePath = @"D:\apps\toDoList\items.txt";
        public List<Item> items = new List<Item>();
        public List<string> categories = new List<string>();

        public MainStorage()
        {
            foreach(string line in File.ReadLines(categoriesFilePath))
            {
                categories.Add(line);
            }
            foreach(string line in File.ReadLines(itemsFilePath))
            {
                string[] data = line.Split("|");
                Item newItem = new Item(){
                    ItemID = Int32.Parse(data[0]),
                    ItemCategory = data[1],
                    ItemName = data[2],
                    ItemDescription = data[3],
                    
                };
                items.Add(newItem);
            }
            
        }

      
        public void categoriesEdition()
        {
            File.WriteAllLines(categoriesFilePath, categories);
        }

        public void itemsEdition(Item newItem)
        {
            string[] item = new string[] { newItem.ItemID.ToString(), newItem.ItemCategory, newItem.ItemName, newItem.ItemDescription };
            string line = string.Join("|", item);
            File.AppendAllText(itemsFilePath, line + Environment.NewLine);
        } 
    }
}
