//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViennaRuns
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Runs = new HashSet<Run>();
        }
    
        public string u_username { get; set; }
        public string u_password { get; set; }
        public Nullable<int> u_runninggroup { get; set; }
        public Nullable<decimal> u_weight { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Run> Runs { get; set; }
        public virtual RunningGroup RunningGroup { get; set; }
        public virtual RunningGroup RunningGroup1 { get; set; }
    }
}
