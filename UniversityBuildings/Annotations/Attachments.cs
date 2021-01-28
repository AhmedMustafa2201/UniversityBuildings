using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityBuildings.Models
{
    [MetadataType(typeof(AttachmentsAnnotations))]
    public partial class Attachments
    {
    }
    public class AttachmentsAnnotations
    {
        public int ID { get; set; }

        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا اسم المبنى الملحق")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا الاسم في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Display(Name = "اسم المبنى الملحق")]
        public string Att_Name { get; set; }

        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا اسم القسم")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا الاسم في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Display(Name = "اسم القسم")]
        public string Att_Section_Name { get; set; }

        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا اسم المكان")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا الاسم في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Display(Name = "اسم المكان الذي يقع فيه المبنى")]
        public string Att_Place_of_it { get; set; }

        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا اسم الكلية")]
        [Display(Name = "الرؤية")]
        public string Att_Vision { get; set; }

        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا اسم الكلية")]
        [Display(Name = "الرسالة")]
        public string Att_Message { get; set; }

        [RegularExpression(@"^[\u0621-\u064A\040\d*\r\n]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا اسم الكلية")]
        [Display(Name = "تفاصيل عن المبنى")]
        public string Att_Details { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "اكتب ارقام")]
        [Range(1, 100, ErrorMessage = "برجاء كتابة عدد المباني (من 1 الى 100) في الخانة")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا عدد مباني الكلية")]
        [Display(Name = "عدد المدرجات")]
        public Nullable<short> Att_Stages_Number { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "اكتب ارقام")]
        [Range(1, 100, ErrorMessage = "برجاء كتابة عدد المباني (من 1 الى 100) في الخانة")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا عدد مباني الكلية")]
        [Display(Name = "عدد الأدوار")]
        public Nullable<short> Att_Floors_Number { get; set; }

        [Display(Name ="داخل الكلية")]
        //[Range(0,1,ErrorMessage ="برجاء الاختيار من بين الاختيارات")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "أعلمنا اذا كان يوجد داخل الكلية أم لا")]
        public Nullable<bool> Att_Is_Inside { get; set; }

        [RegularExpression("[a-zA-Z\\s]+", ErrorMessage = "Enter with english.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا الاسم باللغة الانجليزية")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا الاسم باللغة الانجليزية في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Display(Name = "الاسم  باللغة الانجليزية")]
        public string Att_NameEN { get; set; }

        [RegularExpression("[a-zA-Z\\s]+", ErrorMessage = "Enter with english.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا اسم القسم باللغة الانجليزية")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا اسم القسم باللغة الانجليزية في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Display(Name = "اسم القسم باللغة الانجليزية")]
        public string Att_Section_NameEN { get; set; }

        [RegularExpression("[a-zA-Z\\s]+", ErrorMessage = "Enter with english.")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا مكان المبنى باللغة الانجليزية في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا مكان المبنى باللغة الانجليزية")]
        [Display(Name = "مكان المبنى باللغة الانجليزية")]
        public string Att_Place_of_itEN { get; set; }

        [RegularExpression("[a-zA-Z\\s]+", ErrorMessage = "Enter with english.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا الرؤية باللغة الانجليزية")]
        [Display(Name = "الرؤية باللغة الانجليزية")]
        public string Att_VisionEN { get; set; }

        [RegularExpression("[a-zA-Z\\s]+", ErrorMessage = "Enter with english.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا الرسالة باللغة الانجليزية")]
        [Display(Name = "الرسالة باللغة الانجليزية")]
        public string Att_MessageEN { get; set; }

        [RegularExpression("[a-zA-Z\\,\\s0-9]+", ErrorMessage = "Enter with english.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا التفاصيل باللغة الانجليزية")]
        [Display(Name = "التفاصيل باللغة الانجليزية")]
        public string Att_DetailsEN { get; set; }

        [Display(Name = "اسم الكلية")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اختر اسم الكلية")]
        public Nullable<int> fac_ID { get; set; }
    }
}