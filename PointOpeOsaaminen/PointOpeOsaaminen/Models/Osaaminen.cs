//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PointOpeOsaaminen.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Osaaminen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Osaaminen()
        {
            TamanOsaamisenOpettajat = new List<Opettaja>();
            this.OpettajaOsaaminen = new HashSet<OpettajaOsaaminen>();
        }
    
        public int OsaamisID { get; set; }
        public string OpenOsaaminen { get; set; }
        public string Kuvaus { get; set; }

        public virtual ICollection<Opettaja> TamanOsaamisenOpettajat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OpettajaOsaaminen> OpettajaOsaaminen { get; set; }
    }
}
