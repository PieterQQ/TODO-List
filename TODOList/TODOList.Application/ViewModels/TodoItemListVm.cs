﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TODOList.Application.ViewModels
{
    public class TodoItemListVm
    {
        public List<TodoItemVm> Items { get; set; }
        public int Count { get; set; }
    }
}
