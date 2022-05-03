using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DiamondCoreAppCS.Models
{
    public partial class Diamond
    {
        public int DiamondId { get; set; }
        public string DiamondCut { get; set; }
        public string DiamondColor { get; set; }
        public string DiamondClarity { get; set; }
        public string DiamondCarat { get; set; }
    }
}
