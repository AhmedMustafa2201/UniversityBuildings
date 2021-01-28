using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityBuildings.Models;

namespace UniversityBuildings.ViewModel
{
    public class OtherImagesViewModel
    {
        public Other_Buildings other_buildings { get; set; }
        public IEnumerable<Images> images { get; set; }
    }
}