namespace newUniversity.Classes
{
    class Student : User
    {
        static public void chooseCourse(StudentObject student, int courseId)
        {
            try
            {
                CourseObject course = Universal.instance.courses.getByID(courseId) as CourseObject;
                if (student.currentSemisterCourses.Contains(int.Parse(courseId+student.ID+"")))
                    throw new DuplicateException("entered course ID recently selected!");
                else
                {
                    StudentLessonObject lesson = new StudentLessonObject(course, student.ID);
                    Universal.instance.studentLessons.insert(lesson);
                    Universal.instance.studentLessons.loadObject(lesson);
                    Universal.instance.students.save();
                    student.currentSemisterCourses.Add(int.Parse(courseId + student.ID + ""));
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

        static public void deleteCourse(StudentObject student, int courseId)
        {
            if (student.currentSemisterCourses.Contains(int.Parse(courseId + student.ID + "")))
            {
                Universal.instance.studentLessons.delete(Universal.instance.studentLessons.getByID(int.Parse(courseId + student.ID + "")) as StudentLessonObject);
                Universal.instance.studentLessons.save();
                student.currentSemisterCourses.Remove(int.Parse(courseId + student.ID + ""));
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

        static public CourseObject[] getCurrentCourses(StudentObject std)
        {
            int[] arr = new int[20];
            for(int i = 0;i< std.currentSemisterCourses.Count; i++)
            {
                arr[i] = int.Parse(std.currentSemisterCourses[i].ToString().Substring(0,5));
            }
            return (Universal.instance.studentLessons.getAll(arr).ToArray() as CourseObject[]);
        }

        static public void deleteTerm(StudentObject std)
        {
            std.currentSemisterCourses.Clear();
        }
    }
}
