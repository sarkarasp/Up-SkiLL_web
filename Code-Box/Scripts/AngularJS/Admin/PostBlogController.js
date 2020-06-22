
AdminAppModule.controller('CourseController', function ($scope, CourseListService) {

    var getAllcouseList = CourseListService.GetCourseAll();
    getAllcouseList.then(function (courses) {
        $scope.Courses = courses.data;

    }, function () {
        alert('Records not found for courses');
    });

    $scope.FillTopic = function () {
        var getAllTopicList = CourseListService.GetAllTopic();
        getAllTopicList.then(function (topices) {
            $scope.Topices = topices.data;            
        },
     function () {
         alert('Record not found for Topices');

     });
    }
});


