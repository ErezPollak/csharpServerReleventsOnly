using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.A_DTO
{
    public class CourseTestDTO
    {
        public decimal CourseID { get; set; }
        public decimal groupID { get; set; }
        public decimal TeacherID { get; set; }
        public decimal ScheduleHoursIndex { get; set; }
        public decimal numberDayOfWeek { get; set; }

        public CourseTestDTO(decimal courseID, decimal groupID, decimal teacherID, decimal scheduleHoursIndex, decimal numberDayOfWeek)
        {
            CourseID = courseID;
            this.groupID = groupID;
            TeacherID = teacherID;
            ScheduleHoursIndex = scheduleHoursIndex;
            this.numberDayOfWeek = numberDayOfWeek;
        }

        public CourseTestDTO()
        {
        }
    }
}
