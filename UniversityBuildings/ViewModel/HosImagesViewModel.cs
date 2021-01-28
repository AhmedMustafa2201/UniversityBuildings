using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityBuildings.Models;

namespace UniversityBuildings.ViewModel
{
    public class HosImagesViewModel
    {
        public Hospital_Buildings hospital_buildings { get; set; }
        public IEnumerable<Images> images { get; set; }
    }
}