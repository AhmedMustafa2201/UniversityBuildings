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
    
    public partial class Images
    {
        public int ID { get; set; }
        public string Image_Path { get; set; }
        public Nullable<int> Fac_ID { get; set; }
        public Nullable<int> Hos_ID { get; set; }
        public Nullable<int> Other_ID { get; set; }
    
        public virtual Faculty_Buildings Faculty_Buildings { get; set; }
        public virtual Hospital_Buildings Hospital_Buildings { get; set; }
        public virtual Other_Buildings Other_Buildings { get; set; }
    }
}
