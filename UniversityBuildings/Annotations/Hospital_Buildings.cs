using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityBuildings.Models
{
    [MetadataType(typeof(Hospital_BuildingsAnnotations))]
    public partial class Hospital_Buildings
    {
    }

    public class Hospital_BuildingsAnnotations
    {
        public int ID { get; set; }

        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا اسم المستشفى في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا اسم المستشفى")]
        [Display(Name = "اسم المستشفى")]
        public string Hospital_Name { get; set; }

        [RegularExpression("[a-zA-Z\\s]+", ErrorMessage = "Enter with english.")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا اسم المستشفى باللغة الانجليزية في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا اسم المستشفى باللغة الانجليزية")]
        [Display(Name = "اسم المستشفى باللغة الانجليزية")]
        public string Hospital_NameEN { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا نشأة المستشفى")]
        [Display(Name = "نشأة المستشفى")]
        public string Hospital_Genesis { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "اكتب ارقام")]
        [Range(1, 7, ErrorMessage = "برجاء كتابة عدد طوابق المستشفى (من 1 الى 9) في الخانة")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا عدد طوابق المستشفى")]
        [Display(Name = "عدد طوابق المستشفى")]
        public Nullable<short> Hospital_Floors { get; set; }

        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا مدير المستشفى في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا مدير المستشفى")]
        [Display(Name = "مدير المستشفى")]
        public string Hospital_Manager_Name { get; set; }

        [RegularExpression("[a-zA-Z\\s]+", ErrorMessage = "Enter with english.")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا مدير المستشفى باللغة الانجليزية في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا مدير المستشفى باللغة الانجليزية")]
        [Display(Name = "مدير المستشفى باللغة الانجليزية")]
        public string Hospital_Manager_NameEN { get; set; }

        [RegularExpression(@"^[\u0621-\u064A\040\d*]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا أقسام المستشفى بتفاصيلها")]
        [Display(Name = "أقسام المستشفى بتفاصيلها")]
        public string Hospital_Sections { get; set; }

        [RegularExpression("[a-zA-Z\\,\\s0-9]+", ErrorMessage = "Enter with english.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا أقسام المستشفى بتفاصيلها باللغة الانجليزية")]
        [Display(Name = "أقسام المستشفى بتفاصيلها باللغة الانجليزية")]
        public string Hospital_SectionsEN { get; set; }

    }
}