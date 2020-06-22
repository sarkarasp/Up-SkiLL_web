using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code_Box.Models
{
    public class TopicDetailModel
    {
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public string TechnologyType { get; set; }
        public string PostedBy { get; set; }
        public DateTime CreatedDate { get; set; }   
        public DateTime UpdateDate { get; set; }
        public bool isActive { get; set; }
        public string TopicDetails { get; set; }
        public int CourseId { get; set; }
        public HttpPostedFileBase TopicPath { get; set; }
        public IList<SelectListItem> CourseNames { get; set; }
        public IList<SelectListItem> TopicNames { get; set; }
    }
}