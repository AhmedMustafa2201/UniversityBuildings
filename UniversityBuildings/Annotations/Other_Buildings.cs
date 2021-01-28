using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityBuildings.Models
{
    [MetadataType(typeof(Other_BuildingsAnnotations))]
    public partial class Other_Buildings
    {
    }

    public class Other_BuildingsAnnotations
    {
        public int ID { get; set; }

        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا اسم المبنى في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "اكتب هنا اسم المبنى")]
        [Display(Name ="اسم المبنى")]
        public string Building_Name { get; set; }

        [RegularExpression("[a-zA-Z\\s]+", ErrorMessage = "Enter with english.")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا اسم المبنى باللغة الانجليزية في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "اكتب هنا اسم المبنى باللغة الانجليزية")]
        [Display(Name = "اسم المبنى باللغة الانجليزية")]
        public string Building_NameEN { get; set; }

        [RegularExpression(@"^[\u0621-\u064A\040\d*]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "اكتب هنا تفاصيل لوحدات المبنى")]
        [Display(Name = "تفاصيل لوحدات المبنى")]
        public string Building_Units { get; set; }

        [RegularExpression("[a-zA-Z\\,\\s0-9]+", ErrorMessage = "Enter with english.")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "اكتب هنا تفاصيل لوحدات المبنى باللغة الانجليزية")]
        [Display(Name = "تفاصيل لوحدات المبنى باللغة الانجليزية")]
        public string Building_UnitsEN { get; set; }

        [RegularExpression(@"^[\u0621-\u064A\040\d*]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "اكتب هنا تفاصيل لخدمات المبنى")]
        [Display(Name = "تفاصيل لخدمات المبنى")]
        public string Building_Services { get; set; }

        [RegularExpression("[a-zA-Z\\,\\s0-9]+", ErrorMessage = "Enter with english.")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "اكتب هنا تفاصيل لخدمات المبنى باللغة الانجليزية")]
        [Display(Name = "تفاصيل لخدمات المبنى باللغة الانجليزية")]
        public string Building_ServicesEN { get; set; }

        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا مسئول المبنى في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "اكتب هنا مسئول المبنى")]
        [Display(Name = "مسئول المبنى")]
        public string Building_Responsible_Name { get; set; }

        [RegularExpression("[a-zA-Z\\s]+", ErrorMessage = "Enter with english.")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا مسئول المبنى باللغة الانجليزية في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "اكتب هنا مسئول المبنى باللغة الانجليزية")]
        [Display(Name = "مسئول المبنى باللغة الانجليزية")]
        public string Building_Responsible_NameEN { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "اكتب هنا نشأة المبنى")]
        [Display(Name = "نشأة المبنى")]
        public string Building_Genesis { get; set; }

    }
}