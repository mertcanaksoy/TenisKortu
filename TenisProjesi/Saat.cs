//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TenisProjesi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Saat
    {
        public int Id { get; set; }
        public int kortId { get; set; }
        public Nullable<System.DateTime> tarih { get; set; }
        public string baslangicSaati { get; set; }
        public string bitisSaati { get; set; }
        public Nullable<bool> enable { get; set; }
    }
}
