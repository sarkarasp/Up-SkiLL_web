
AdminAppModule.service("CourseListService", function ($http) {
   
    this.GetCourseAll = function () {
        return $http.get("/PostBlog/GetCourseList");
    }
        
    this.GetAllTopic = function () {
        var courseId = $('#courseId').val();
        var param = {
            courseId: courseId
        };        
        if (courseId != null || courseId != "" || courseId != 'undefined') {
            
            return $http.post('/PostBlog/FillTopic', JSON.stringify(param));
        }
       
    }

});

