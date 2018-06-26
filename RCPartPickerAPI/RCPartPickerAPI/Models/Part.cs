using System;
using System.Collections.Generic;

namespace RCPartPickerAPI.Models
{
    public partial class Part
    {
        public Part()
        {
            PartPartProperty = new HashSet<PartPartProperty>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PartSubcategoryId { get; set; }

        public PartSubcategory PartSubcategory { get; set; }
        public ICollection<PartPartProperty> PartPartProperty { get; set; }
    }
}
