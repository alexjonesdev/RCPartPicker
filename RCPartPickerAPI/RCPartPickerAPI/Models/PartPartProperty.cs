using System;
using System.Collections.Generic;

namespace RCPartPickerAPI.Models
{
    public partial class PartPartProperty
    {
        public int Id { get; set; }
        public int PartId { get; set; }
        public int PartPropertyId { get; set; }

        public Part Part { get; set; }
        public PartProperty PartProperty { get; set; }
    }
}
