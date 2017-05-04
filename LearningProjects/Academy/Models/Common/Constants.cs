namespace Academy.Models.Common
{
    public class Constants
    {
        // Numbers 
        public const int MinUserNameLenght = 3;
        public const int MaxUserNameLenght = 45;
        public const int MinCourseLecturesPerWeek = 1;
        public const int MaxCourseLecturesPerWeek = 7;
        public const int MinTrainerAndStudentNameLenght = 3;
        public const int MaxTrainerAndStudentNameLenght = 16;
        public const float MinExamPoints = 0;
        public const float MaxExamPoints = 1000;
        public const float MinCoursePoints = 0;
        public const float MaxCoursePoints = 125;
        public const int MinLectureNameLenght = 5;
        public const int MaxLectureNameLenght = 30;
        public const int MinDemoResourceNameLenght = 3;
        public const int MaxDemoResourceNameLenght = 15;
        public const int MinUrlNameLenght = 5;
        public const int MaxUrlNameLenght = 150;

        //Exception <essages
        public const string ResourceUrlLenghtExceptionMessage = "Resource url should be between {0} and {1} symbols long!";
        public const string ResourceNameLenghtExceptionMessage = "Resource name should be between {0} and {1} symbols long!";
        public const string LectureNameLenghtExceptionMessage = "Lecture's name should be between {0} and {1} symbols long!";
        public const string CoursePointsErrorExceptionMessage = "Course result's course points should be between {0} and {1}!";
        public const string ExamPointsErrorExceptionMessage = "Course result's exam points should be between {0} and {1}!";
        public const string TrainerAndStudentNameLenghtExceptionMessage = "User's username should be between {0} and {1} symbols long!";
        public const string CourseNameLenghtExceptionMessage = "The name of the course must be between {0} and {1} symbols!";
        public const string CourseLecturesPerWeekExceptionMessage = "The number of lectures per week must be between {0} and {1}!";
        public const string InvalidTrackExceptionMessage = "The provided track is not valid!";
        public const string NullExceptionMessage = "{0} cannot be null or empty!";

        //Messages
        public const string NoListedUsersErrorMessage = "There are no registered users!";
        public const string NoResorsesInLectureMessage = "    * There are no resources in this lecture.";
        public const string StudentHasNoCourseResultsMessage = "  * User has no course results!";
        public const string PrintNoLecturesInTheCourseMessage = "  * There are no lectures in this course!";
        
    }
}
