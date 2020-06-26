using System;
using System.Collections.Generic;
using System.Text;

namespace TODOList.Domain.Model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
