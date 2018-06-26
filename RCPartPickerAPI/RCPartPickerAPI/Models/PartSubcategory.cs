using System;
using System.Collections.Generic;

namespace RCPartPickerAPI.Models
{
    public partial class PartSubcategory
    {
        public PartSubcategory()
        {
            Part = new HashSet<Part>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PartCategoryId { get; set; }

        public PartCategory PartCategory { get; set; }
        public ICollection<Part> Part { get; set; }
    }
}
