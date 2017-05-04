using System;
using Academy.Models.Common;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;

namespace Academy.Models
{
    public class CourseResult : ICourseResult
    {
        private ICourse course;
        private float examPoints;
        private float coursePoints;
        private Grade grade;

        public CourseResult(ICourse course, string examPoints, string coursePoints) 
        {
            this.course = course;
            this.ExamPoints = float.Parse(examPoints);
            this.CoursePoints = float.Parse(coursePoints);
        }

        public ICourse Course
        {
            get
            {
                return this.course;
            }
        }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }
            private set
            {
                if (value < Constants.MinExamPoints || value > Constants.MaxExamPoints)
                {
                    throw new ArgumentException(string.Format(Constants.ExamPointsErrorExceptionMessage, Constants.MinExamPoints, Constants.MaxExamPoints));
                }

                this.examPoints = value;
            }
        }

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }
            private set
            {
                if (value < Constants.MinCoursePoints || value > Constants.MaxCoursePoints)
                {
                    throw new ArgumentException(string.Format(Constants.CoursePointsErrorExceptionMessage, Constants.MinCoursePoints, Constants.MaxCoursePoints));
                }

                this.coursePoints = value;
            }
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }
            private set
            {
                if (this.ExamPoints >= 65 && this.CoursePoints >= 75)
                {
                    this.grade = Grade.Excellent;
                }
                else if (this.ExamPoints < 60 && this.ExamPoints >= 30 && this.CoursePoints < 75 && this.CoursePoints >= 45)
                {
                    this.grade = Grade.Passed;
                }
                else
                {
                    this.grade = Grade.Failed;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("  * {0}: Points - {1}, Grade - {2}", this.Course.Name, this.CoursePoints, this.Grade);
        }
    }
}
