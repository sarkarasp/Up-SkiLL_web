//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Code_Box.Domain.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vertical_tab_list_tb
    {
        public Nullable<int> CourseID { get; set; }
        public Nullable<int> TopicID { get; set; }
        public Nullable<bool> Active { get; set; }
        public int id { get; set; }
    
        public virtual Courses_tb Courses_tb { get; set; }
        public virtual Vertical_Nav_tb Vertical_Nav_tb { get; set; }
    }
}
