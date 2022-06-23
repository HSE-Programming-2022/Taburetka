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
            string itemInfo = JsonConvert.SerializeObject(item);
            File.WriteAllText(filePath, itemInfo);
        }

        public static void DeleteItem(ToDoItem item)
        {
            if (item.FileSource != "" || item.FileSource != null)
            {
                string folderFiles = "../../Data/Files/";
                File.Delete(folderFiles + item.FileSource);
            }
            if (item.ImageSource != "" || item.ImageSource != null)
            {
                string folderImages = "../../Data/Images/";
                File.Delete(folderImages + item.ImageSource);
            }
            items.Remove(item);
            SaveItem(items);
        }
    }
}
