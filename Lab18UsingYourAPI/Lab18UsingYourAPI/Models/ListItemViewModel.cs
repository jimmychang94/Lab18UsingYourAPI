using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab18UsingYourAPI.Models
{
    /// <summary>
    /// This class is used so that more data can be put into the views
    /// </summary>
    public class ListItemViewModel
    {
        public List<TodoItem> TodoItems { get; set; }
        public List<TodoList> TodoLists { get; set; }
    }
}
