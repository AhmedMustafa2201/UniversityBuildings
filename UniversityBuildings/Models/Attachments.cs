//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniversityBuildings.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attachments
    {
        public int ID { get; set; }
        public string Att_Name { get; set; }
        public string Att_Section_Name { get; set; }
        public string Att_Place_of_it { get; set; }
        public string Att_Vision { get; set; }
        public string Att_Message { get; set; }
        public string Att_Details { get; set; }
        public Nullable<short> Att_Stages_Number { get; set; }
        public Nullable<short> Att_Floors_Number { get; set; }
        public Nullable<bool> Att_Is_Inside { get; set; }
        public string Att_NameEN { get; set; }
        public string Att_Section_NameEN { get; set; }
        public string Att_Place_of_itEN { get; set; }
        public string Att_VisionEN { get; set; }
        public string Att_MessageEN { get; set; }
        public string Att_DetailsEN { get; set; }
        public Nullable<int> fac_ID { get; set; }
    
        public virtual Faculty_Buildings Faculty_Buildings { get; set; }
    }
}
