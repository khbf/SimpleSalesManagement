//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QL_SaleManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class n_Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public n_Customer()
        {
            this.n_SalesOrderHeader = new HashSet<n_SalesOrderHeader>();
        }
    
        public int CustomerID { get; set; }
        public Nullable<int> PersonID { get; set; }
        public Nullable<int> StoreID { get; set; }
        public Nullable<int> TerritoryID { get; set; }
        public string AccountNumber { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<n_SalesOrderHeader> n_SalesOrderHeader { get; set; }
    }
}
