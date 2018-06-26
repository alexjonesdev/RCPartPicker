using System;
using System.Collections.Generic;

namespace RCPartPickerAPI.Models
{
    public partial class PartCategory
    {
        public PartCategory()
        {
            PartSubcategory = new HashSet<PartSubcategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PartSubcategory> PartSubcategory { get; set; }
    }
}
