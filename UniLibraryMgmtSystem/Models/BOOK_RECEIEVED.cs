//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UniLibraryMgmtSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BOOK_RECEIEVED
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> DATE { get; set; }
        public Nullable<int> BOOK_ID { get; set; }
        public Nullable<int> MEMBER_ID { get; set; }
        public Nullable<decimal> FINE { get; set; }
        public string REMARKS { get; set; }
    
        public virtual BOOK BOOK { get; set; }
        public virtual MEMBER MEMBER { get; set; }
    }
}