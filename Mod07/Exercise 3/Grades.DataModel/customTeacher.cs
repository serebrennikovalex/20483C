using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.DataModel
{
    public partial class Teacher
    {
        private const int MAX_CLASS_SIZE = 8;

        public void EnrollInClass(Student student)
        {
            int studentCount = (from s in Students
                                        where s.TeacherUserId == UserId
                                        select s).Count();

            if (studentCount == MAX_CLASS_SIZE)
            {
                throw new ClassFullException("The class if full", "Student");
            }

            if (student.TeacherUserId != null)
            {
                throw new ArgumentException("Already assigned to a class", "Student");
            } else
            {
                student.TeacherUserId = UserId;
            }
        }
    }
}
