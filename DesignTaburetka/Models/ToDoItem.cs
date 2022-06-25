using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignTaburetka.Models
{
    public class ToDoItem
    {
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public string Deadline { get; set; }
        [JsonProperty]
        public string ImageSource { get; set; }
        [JsonProperty]
        public string FileSource { get; set; }
        [JsonProperty]
        public string IsDone { get; set; }

        public ToDoItem()
        {

        }
        public ToDoItem(string description, string deadline, string imageSource, string fileSource, string isDone)
        {
            Description = description;
            Deadline = deadline;
            ImageSource = imageSource;
            FileSource = fileSource;
            IsDone = isDone;
        }

        public ToDoItem(string description, string imageSource, string fileSource, string isDone)
        {
            Description = description;
            ImageSource = imageSource;
            FileSource = fileSource;
            IsDone = isDone;
        }
    }
}
