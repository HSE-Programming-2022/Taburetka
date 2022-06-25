using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignTaburetka.Models
{
    internal class Storage
    {
        private const string filePath = "../../ToDoData/ToDoList.json";

        static public List<ToDoItem> items = new List<ToDoItem>();


        public static void ReadItems()
        {

            string item = File.ReadAllText(filePath);
            List<ToDoItem> itemsInfo = JsonConvert.DeserializeObject<List<ToDoItem>>(item);

            if (itemsInfo != null) { items = itemsInfo; }
            else { items = new List<ToDoItem>(); }
        }

        public static void SaveItem(List<ToDoItem> items)
        {
            string itemsInfo = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(filePath, itemsInfo);
        }

        public static void DeleteItem(ToDoItem item)
        {
            if (!string.IsNullOrEmpty(item.FileSource))
            {
                string folderFiles = "../../ToDoData/Files/";
                File.Delete(folderFiles + item.FileSource);
            }
            if (!string.IsNullOrEmpty(item.FileSource))
            {
                string folderImages = "../../ToDoData/Images/";
                File.Delete(folderImages + item.ImageSource);
            }
            items.Remove(item);
            SaveItem(items);
        }
    }
}
