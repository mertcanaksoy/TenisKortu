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
    
    public partial class User_Kiralama
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_Kiralama()
        {
            this.Faturas = new HashSet<Fatura>();
            this.KiralamaDetays = new HashSet<KiralamaDetay>();
        }
    
        public int Id { get; set; }
        public int userId { get; set; }
        public int saatId { get; set; }
        public Nullable<bool> chekin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fatura> Faturas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KiralamaDetay> KiralamaDetays { get; set; }
    }
}
