//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shopping.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OTable
    {
        public int OID { get; set; }
        public string PName { get; set; }
        public string CName { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Total_Price { get; set; }
    
        public virtual CustomerTable CustomerTable { get; set; }
        public virtual ProductTable1 ProductTable1 { get; set; }
    }
}
