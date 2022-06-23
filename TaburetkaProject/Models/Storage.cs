using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TaburetkaProject.Models
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

        public static void SaveItem(List<ToDoItem> item)
        {
            string itemInfo = JsonConvert.SerializeObject(item, Formatting.Indented);
            File.WriteAllText(filePath, itemInfo);
        }

        public static void DeleteItem(ToDoItem item)
        {
            if (!string.IsNullOrEmpty(item.FileSource))
            {
                string folderFiles = "../../Data/Files/";
                File.Delete(folderFiles + item.FileSource);
            }
            if (!string.IsNullOrEmpty(item.FileSource))
            {
                string folderImages = "../../Data/Images/";
                File.Delete(folderImages + item.ImageSource);
            }
            items.Remove(item);
            SaveItem(items);
        }
    }
}
