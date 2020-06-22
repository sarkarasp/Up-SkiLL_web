using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code_Box.Domain.Models;

namespace Code_Box.Domain.Repositories
{
     interface IRepo
    {
         IList<Courses_tb> GetAllCoursesDetailsList();
        IList<Vertical_Nav_tb> GetAllCourseDetailsByID(int courseId);
        bool PostBlog(int Courseid, int topicId, string Postheader, string Author, string Description, string Categories, string Details);
        IList<TopicDetails_tb> GetDetailsByTopicId(int courseId, int topicId);
        IList<Vertical_Nav_tb> GetTopicListAll();       
        IList<Vertical_Nav_tb> GetTopicById(int courseId);
        IList<SideNavigationMenuAdmin_tb> GetSideNavigationAll();
        TopicDetails_tb GetTopicDetailsById(int courseId);
        void InsertTopicDetails(int topicId, string topicName, string technologyType, string PostedBy, DateTime createdDate, DateTime updatedDate, bool isActive, int courseId, string topicPath);
        TopicDetails_tb GetDocumentPath(int CourseId, int TopicId);
    }
}
