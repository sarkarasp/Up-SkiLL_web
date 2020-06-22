using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Code_Box.Domain.Models;
using Code_Box.Domain.Repositories;

namespace Code_Box.DominTest
{
    [TestClass]
    public class UnitTest1
    {
        Repositories repo = new Repositories();
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                var result = repo.GetAllCoursesDetailsList();
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        [TestMethod]
        public void GetAllCourseDetailsByIDTest()
        {
            var result = repo.GetAllCourseDetailsByID(1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetDetailsByTopicIdTest()
        {
            var result = repo.GetDetailsByTopicId(1, 1);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        
        public void PostBlogTest()

        {
            
            string Postheader = "C# ";
            string Author = "sudipto Sarkar";
            string Details = "abc";
            string Description = "c# project";
            string Categories = "c#";

            var result = repo.PostBlog(1, 2, Postheader, Author, Description, Categories, Details);
            Assert.IsNotNull(result);
        }

        [TestMethod]
       public void GetSideNavigationAllTest()
        {
            //Arrange
            bool Expected = true;

            //Act
            var actual = repo.GetSideNavigationAll();

            //Assert

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void GetTopicDetails()
        {
           TopicDetails_tb model = new TopicDetails_tb();

           var result = repo.GetTopicDetailsById(1);

            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void AddTopicDetails()
        {
            var createddate = DateTime.Now;
            repo.InsertTopicDetails(1, "Variable in C#", "C#.net", "Sudipto Sarkar", createddate, DateTime.Now,true, 1, "c://Documents/variableinC#.docs");
        }

    }
}
