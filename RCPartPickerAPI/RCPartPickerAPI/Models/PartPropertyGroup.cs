using System;
using System.Collections.Generic;

namespace RCPartPickerAPI.Models
{
    public partial class PartPropertyGroup
    {
        public PartPropertyGroup()
        {
            PartProperty = new HashSet<PartProperty>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PartProperty> PartProperty { get; set; }
    }
}
