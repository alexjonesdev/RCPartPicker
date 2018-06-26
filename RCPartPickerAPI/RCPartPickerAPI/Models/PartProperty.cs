using System;
using System.Collections.Generic;

namespace RCPartPickerAPI.Models
{
    public partial class PartProperty
    {
        public PartProperty()
        {
            PartPartProperty = new HashSet<PartPartProperty>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PartPropertyGroupId { get; set; }

        public PartPropertyGroup PartPropertyGroup { get; set; }
        public ICollection<PartPartProperty> PartPartProperty { get; set; }
    }
}
