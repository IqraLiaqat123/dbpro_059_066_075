//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Timetable
    {
        public int id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> ClassId { get; set; }
        public Nullable<int> CourseId { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Class Class { get; set; }
    }
}
