namespace newUniversity.Classes
{
    class Student : User
    {
        public void chooseCourse(StudentObject student, int courseId)
        {
            try
            {
                CourseObject course = Universal.instance.courses.getByID(courseId) as CourseObject;
                if (student.currentSemisterCourses.Contains(courseId))
                    throw new DuplicateException("entered course ID recently selected!");
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
            catch(NotFoundException)
            {
                throw new NotFoundException("entered course ID not exists!");
            }
        }

        public void deleteCourse(StudentObject student, int courseId)
        {
            if (student.currentSemisterCourses.Contains(courseId))
            {
                student.currentSemisterCourses.Remove(courseId);
                Universal.instance.students.loadObject(student);
                Universal.instance.students.save();
                CourseObject course = Universal.instance.courses.getByID(courseId) as CourseObject;
                course.studentsID.Remove(student.ID);
                Universal.instance.courses.loadObject(course);
                Universal.instance.courses.save();
            }
            else
                throw new NotFoundException("entered course ID was not selected recently!");
        }
    }
}
