using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_Box.Models
{
    public class PageDetailsModel
    {
        public PageDetailsModel()
        {
            verticalViewModels = new List<VerticalViewModel>();
        }
        public int CourseIds { get; set; }
        public int topicIds { get; set; }
       public List<VerticalViewModel> verticalViewModels { get; set; }
    }
    public class VerticalViewModel
    {
        public string DocPath { get; set; }
        public int TopicId { get; set; }
        public int CourseId { get; set; }
        public string TopicName { get; set; }
        public string CourseName { get; set; }
    }
}