using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class Student : User
    {
        public void chooseCourse(StudentObject student, int courseId)
        {
            try
            {
                CourseObject course = Universal.instance.courses.getByID(courseId);
                if (student.currentSemisterCourses.Contains(courseId))
                    throw new duplicateException("entered course ID recently selected!");
                else
                {
                    student.currentSemisterCourses.Add(courseId);
                    Universal.instance.students.loadObject(student);
                    Universal.instance.students.save();
                    course.studentsID.Add(student.ID);
                    Universal.instance.courses.loadObject(course);
                    Universal.instance.courses.save();
                }
            }
            catch(notFoundException)
            {
                throw new notFoundException("entered course ID not exists!");
            }
        }

        public void deleteCourse(StudentObject student, int courseId)
        {
            if (student.currentSemisterCourses.Contains(courseId))
            {
                student.currentSemisterCourses.Remove(courseId);
                Universal.instance.students.loadObject(student);
                Universal.instance.students.save();
                CourseObject course = Universal.instance.courses.getByID(courseId);
                course.studentsID.Remove(student.ID);
                Universal.instance.courses.loadObject(course);
                Universal.instance.courses.save();
            }
            else
                throw new notFoundException("entered course ID was not selected recently!");
        }
    }
}
