﻿using System.Collections.Generic;

namespace TODOList.Application.ViewModels
{
    public class TodoItemListVm
    {
        public int ListId { get; set; }
        public List<TodoItemVm> Items { get; set; }
        public int Count { get; set; }
    }
}
