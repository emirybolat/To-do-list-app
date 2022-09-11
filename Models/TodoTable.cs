using System;
using System.Collections.Generic;

namespace ToDoListApp.Models
{
    public partial class TodoTable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Done { get; set; }
        public bool Urgent { get; set; }
    }
}
