//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projectmc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class customer
    {
        public int customerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public Nullable<int> DrugId { get; set; }
    
        public virtual Drug Drug { get; set; }
    }
}
