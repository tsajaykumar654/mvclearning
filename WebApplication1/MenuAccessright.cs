//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class MenuAccessright
    {
        public int id { get; set; }
        public Nullable<int> MenuId { get; set; }
        public Nullable<bool> IsView { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<bool> IsUpdate { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual MainMenu MainMenu { get; set; }
    }
}
