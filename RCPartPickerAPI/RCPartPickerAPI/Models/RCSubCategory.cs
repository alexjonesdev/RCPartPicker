using System;
using System.Collections.Generic;

namespace RCPartPickerAPI.Models
{
    public partial class RCSubcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RCCategoryId { get; set; }

        public RCCategory RCCategory { get; set; }
    }
}
