using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Code_Box.Models
{
    public class BlogViewModel
    {
        public BlogViewModel()
        {

        }
        public int CourseId { get; set; }
        public int TopicId { get; set; }
       
        //public SelectList CourseList { get; set; }
        //public SelectList TopicList { get; set; }
        public string Blog_Heading { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Categories { get; set; }
        [Required]
        [AllowHtml]
        [UIHint("tinymce_full")]
        [Display(Name = "Page Content")]
        public string PageContent { get; set; }

    }
}