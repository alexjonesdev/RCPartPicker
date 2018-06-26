using System;
using System.Collections.Generic;

namespace RCPartPickerAPI.Models
{
    public partial class RCCategory
    {
        public RCCategory()
        {
            RCSubcategory = new HashSet<RCSubcategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RCSubcategory> RCSubcategory { get; set; }
    }
}
