using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityBuildings.Models
{
    [MetadataType(typeof(ImagesAnnotations))]
    public partial class Images
    {
    }

    public class ImagesAnnotations
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="اختر الصورة المناسبة")]
        public string Image_Path { get; set; }

        [Range(1,int.MaxValue)]
        public Nullable<int> Fac_ID { get; set; }

        public Nullable<int> Hos_ID { get; set; }

        public Nullable<int> Other_ID { get; set; }

    }
}