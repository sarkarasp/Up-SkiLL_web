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
    
    public partial class Vertical_Nav_tb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vertical_Nav_tb()
        {
            this.TopicDetails_tb = new HashSet<TopicDetails_tb>();
            this.vertical_tab_list_tb = new HashSet<vertical_tab_list_tb>();
        }
    
        public int id { get; set; }
        public string navName { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> CourseID { get; set; }
    
        public virtual Courses_tb Courses_tb { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TopicDetails_tb> TopicDetails_tb { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vertical_tab_list_tb> vertical_tab_list_tb { get; set; }
    }
}
