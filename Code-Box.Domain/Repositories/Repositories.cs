using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Code_Box.Domain.Models;

namespace Code_Box.Domain.Repositories
{
   public class Repositories : IRepo
    {
        up_skill_dbEntities1 entity = new up_skill_dbEntities1();

        public IList<Courses_tb> GetAllCoursesDetailsList()
        {
            var result = entity.Courses_tb.ToList();
               return result;
        }

       public IList<Vertical_Nav_tb> GetAllCourseDetailsByID(int courseId)
        {
            var result = entity.Vertical_Nav_tb
                         .Include(x =>x.Courses_tb)                         
                         .Where(c => c.CourseID == courseId)
                         .ToList();
            return result;
        }
        public bool PostBlog(int Courseid, int topicId, string Postheader, string Author, string Description, string Categories, string Details)
        {
            TopicDetails_tb model = new TopicDetails_tb();
            model.TopicId = topicId;
            model.CourseID = Courseid;
            model.TopicName = Postheader;
            model.PostedBy = Author;
            model.TopicDetails = Details;
            model.TechnologyType = Categories;
            entity.TopicDetails_tb.Add(model);
            var success = Convert.ToBoolean(entity.SaveChanges());
            return success;
        }

       public IList<TopicDetails_tb> GetDetailsByTopicId(int courseId, int topicId)
        {
            var result = entity.TopicDetails_tb.Where(id =>(id.CourseID == courseId) && (id.TopicId == topicId)).ToList();
            return result;
        }

        public IList<Vertical_Nav_tb> GetTopicListAll()
        {
            var result = entity.Vertical_Nav_tb.ToList();
            return result;
        }

        public List<Vertical_Nav_tb> GetTopicListById(int courseId)
        {
            var result = entity.Vertical_Nav_tb.AsQueryable()
                         .Where(id => id.CourseID == courseId)
                         .Include(x => x.TopicDetails_tb)                         
                         .ToList();
            return result;
                
        }

        public IList<SideNavigationMenuAdmin_tb> GetSideNavigationAll()
        {
            return entity.SideNavigationMenuAdmin_tb.ToList();
        }

        public TopicDetails_tb GetTopicDetailsById(int courseId)
        {
            return entity.TopicDetails_tb.Where(x => x.CourseID == courseId).FirstOrDefault();
        }

        public void InsertTopicDetails(int topicId, string topicName, string technologyType, string PostedBy,
                                       DateTime createdDate, DateTime updatedDate, bool isActive, int courseId, string topicPath)
        {
            TopicDetails_tb model = new TopicDetails_tb();
            model.TopicId = topicId;
            model.TopicName = topicName;
            model.TechnologyType = technologyType;
            model.PostedBy = PostedBy;
            model.CreatedDate = DateTime.Now;
            model.UpdateDate = updatedDate;
            model.Active = isActive;
            model.CourseID = courseId;
            model.TopicPath = topicPath;

            entity.TopicDetails_tb.Add(model);
            entity.SaveChanges();
        }

        IList<Vertical_Nav_tb> IRepo.GetTopicById(int TopicId)
        {
            throw new NotImplementedException();
        }

        public TopicDetails_tb GetDocumentPath(int CourseId, int TopicId)
        {
           return entity.TopicDetails_tb.Where(x => x.CourseID == CourseId && x.TopicId == TopicId).FirstOrDefault();
        }
    }
}
