using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityBuildings.Models
{
    [MetadataType(typeof(Faculty_BuildingsAnnotations))]
    public partial class Faculty_Buildings
    {
    }

    public class Faculty_BuildingsAnnotations
    {
        public int ID { get; set; }



        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا اسم الكلية")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا اسم الكلية في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Display(Name = "اسم الكلية")]
        public string Faculty_Name { get; set; }


        [RegularExpression("[a-zA-Z\\s]+", ErrorMessage = "Enter with english.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا اسم الكلية باللغة الانجليزية")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا اسم الكلية باللغة الانجليزية في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Display(Name = "اسم الكلية باللغة الانجليزية")]
        public string Faculty_NameEN { get; set; }


        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا عميد الكلية")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا عميد الكلية في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Display(Name = "عميد الكلية")]
        public string Faculty_Dean { get; set; }


        [RegularExpression("[a-zA-Z\\s]+", ErrorMessage = "Enter with english.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا عميد الكلية باللغة الانجليزية")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "اكتب هنا عميد الكلية باللغة الانجليزية في حجم لا يزيد عن 50 حرف ولا يقل عن 10 احرف")]
        [Display(Name = "عميد الكلية باللغة الانجليزية")]
        public string Faculty_DeanEN { get; set; }


        [RegularExpression("^[0-9]*$", ErrorMessage = "اكتب ارقام")]
        [Range(1, 100, ErrorMessage = "برجاء كتابة عدد المباني (من 1 الى 100) في الخانة")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا عدد مباني الكلية")]
        [Display(Name = "عدد مباني الكلية")]
        public Nullable<short> Faculty_Buildings_Number { get; set; }


        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا نشأة الكلية")]
        [Display(Name = "نشأة الكلية")]
        public string Faculty_Genesis { get; set; }


        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا رؤية الكلية")]
        [Display(Name = "رؤية الكلية")]
        public string Faculty_Vision { get; set; }


        [RegularExpression("[a-zA-Z\\,\\s]+", ErrorMessage = "Enter with english.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا رؤية الكلية باللغة الانجليزية")]
        [Display(Name = "رؤية الكلية باللغة الانجليزية")]
        public string Faculty_VisionEN { get; set; }


        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا رسالة الكلية")]
        [Display(Name = "رسالة الكلية")]
        public string Faculty_Message { get; set; }


        [RegularExpression("[a-zA-Z\\,\\s]+", ErrorMessage = "Enter with english.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا رسالة الكلية باللغة الانجليزية")]
        [Display(Name = "رسالة الكلية باللغة الانجليزية")]
        public string Faculty_MessageEN { get; set; }


        [RegularExpression(@"^[\u0621-\u064A\040\d*\r\n]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا تفاصيل عن الكلية")]
        [Display(Name = "تفاصيل عن الكلية")]
        public string Faculty_Details { get; set; }


        [RegularExpression("[a-zA-Z\\,\\s0-9\r\n]+", ErrorMessage = "Enter with english.")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا تفاصيل عن الكلية باللغة الانجليزية")]
        [Display(Name = "تفاصيل عن الكلية باللغة الانجليزية")]
        public string Faculty_DetailsEN { get; set; }


        [DataType(DataType.Url)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا رابط موقع الكلية")]
        [Display(Name = "رابط موقع الكلية")]
        public string Faculty_Link { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "اكتب ارقام")]
        [Range(1, 100, ErrorMessage = "برجاء كتابة عدد المباني (من 1 الى 100) في الخانة")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا عدد طوابق المبنى الرئيسي للكلية")]
        [Display(Name = "عدد طوابق المبنى الرئيسي للكلية")]
        public Nullable<short> Faculty_Main_Building_Floors { get; set; }


        [RegularExpression("^[0-9]*$", ErrorMessage = "اكتب ارقام")]
        [Range(1, 100, ErrorMessage = "برجاء كتابة عدد المباني (من 1 الى 100) في الخانة")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا عدد مدرجات المبنى الرئيسي للكلية")]
        [Display(Name = "عدد مدرجات المبنى الرئيسي للكلية")]
        public Nullable<short> Faculty_Main_Building_Stages { get; set; }


        [RegularExpression("^[0-9]*$", ErrorMessage = "اكتب ارقام")]
        [Range(0, 100, ErrorMessage = "برجاء كتابة عدد المباني (من 1 الى 100) في الخانة")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا عدد معامل المبنى الرئيسي للكلية")]
        [Display(Name = "عدد معامل المبنى الرئيسي للكلية")]
        public Nullable<short> Faculty_Main_Building_Labs { get; set; }


        [RegularExpression(@"^[\u0621-\u064A\040]+$", ErrorMessage = "اكتب باللغة العربية")]
        [Display(Name = "(*) مكان تواجد مطعم الكلية")]
        public string Faculty_Restaurant_Place { get; set; }


        [RegularExpression("[a-zA-Z\\s]+", ErrorMessage = "Enter with english.")]
        [Display(Name = "(*) مكان تواجد مطعم الكلية باللغة الانجليزية")]
        public string Faculty_Restaurant_PlaceEN { get; set; }


        [DataType(DataType.Url)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا رابط الكلية فيسبوك")]
        [Display(Name = "رابط الكلية فيسبوك")]
        public string Faculty_Link_FaceBook { get; set; }

        [DataType(DataType.Url)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا رابط الكلية تويتر")]
        [Display(Name = "رابط الكلية تويتر")]
        public string Faculty_Link_Twitter { get; set; }

        [DataType(DataType.Url)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "اكتب هنا رابط الكلية يوتيوب")]
        [Display(Name = "رابط الكلية يوتيوب")]
        public string Faculty_Link_YouTube { get; set; }

        
        [RegularExpression(@"^(\d{11})$", ErrorMessage = "اكتب رقم الهاتف")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "برجاء كتابة رقم الهاتف الخاص بالكلية")]
        [Display(Name ="رقم الهاتف الخاص بالكلية")]
        public string Faculty_Phone_Number { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "برجاء كتابة البريد الالكتروني الخاص بالكلية")]
        [Display(Name = "البريد الالكتروني الخاص بالكلية")]
        [EmailAddress(ErrorMessage ="اكتب هنا البريد الالكتروني")]
        public string Faculty_Email { get; set; }

    }
}