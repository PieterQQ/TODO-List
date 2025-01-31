﻿using System;

namespace TODOList.Domain.Model
{
    public class TodoItem : BaseEntity
    {
        public string Task { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int TodoListId { get; set; }
        public string TodoListName { get; set; }

    }
}
