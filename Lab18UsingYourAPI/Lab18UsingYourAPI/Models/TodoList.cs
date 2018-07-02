using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18UsingYourAPI.Models
{
    public class TodoList
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<TodoItem> TodoItems { get; set; }
    }
}
