using System.Collections.Generic;

namespace newUniversity.Classes
{
    class Manager : User
    {
        static public bool removeCourse(int courseID)
        {
            var course = Universal.instance.courses.getByID(courseID) as DatabaseObject;
            if (course == null)
                throw new NotFoundException("entered courseId not exists!");
            else
            {
                
                Universal.instance.courses.delete(course);
                Universal.instance.courses.save();
                return true;
            }
        }

        static public bool chooseCourse(StudentObject student , int courseID)
        {
            try
            {
                var course = Universal.instance.courses.getByID(courseID) as CourseObject;
                if (student.currentSemisterCourses.Contains(courseID))
                    throw new DuplicateException("entered course ID recently selected!");
                else
                {
                    student.currentSemisterCourses.Add(courseID);
                    Universal.instance.students.loadObject(student);
                    Universal.instance.students.save();
                    course.studentsID.Add(student.ID);
                    Universal.instance.courses.loadObject(course);
                    Universal.instance.courses.save();
                    return true;
                }
            }
            catch (NotFoundException)
            {
                throw new NotFoundException("entered course ID not exists!");
            }
        }

        static public bool deleteCourse(StudentObject student, int courseID)
        {
            if (student.currentSemisterCourses.Contains(int.Parse(student.ID + "" + courseID)))
            {
                student.currentSemisterCourses.Remove(int.Parse(student.ID + "" + courseID));
                Universal.instance.students.loadObject(student);
                Universal.instance.students.save();
                Universal.instance.studentLessons.delete(Universal.instance.studentLessons.getByID(int.Parse(student.ID + "" + courseID)) as StudentLessonObject);
                CourseObject course = Universal.instance.courses.getByID(courseID) as CourseObject;
                course.studentsID.Remove(student.ID);
                Universal.instance.courses.loadObject(course);
                Universal.instance.courses.save();
                return true;
            }
            else
                throw new NotFoundException("entered course ID was not selected recently!");
        }
    

        public static bool addStudent(string name, string family, string field)
        {
            if (name != null && family != null && field != null)
            {
                Universal.instance.students.loadTrees();
                var student = new StudentObject(name, family, field);
                Universal.instance.students.insert(student);
                return true;
            }
            else
                return false;
        }

        public static bool addMaster(string name, string family, string field)
        {
        if (name != null && family != null && field != null)
        {
            Universal.instance.masters.loadTrees();
            var master = new MasterObject(name, family, field);
            Universal.instance.masters.insert(master);
            return true;
            }
        else
            return false;
        }
        public static bool addManager(string name, string family)
        {
            if (name != null && family != null)
            {
                var manager = new ManagerObject(name, family);
                Universal.instance.managers.insert(manager);
                return true;
            }
            else
                return false;
        }

        static public void finishCurrentTerm()
        {
            List<object> stds = allStudents();
            for(int i = 0; i < stds.Count; i++)
            {
                int[] ids = ((StudentObject)stds[i]).currentSemisterCourses.ToArray();
                for(int j = 0; j < ids.Length; j++)
                {
                    StudentLessonObject stdlsn = Universal.instance.studentLessons.getByID(ids[j]) as StudentLessonObject;
                    if (stdlsn.grade > 10)
                        ((StudentObject)stds[i]).passedUnits+=stdlsn.unitsCount;
                   ( (StudentObject)stds[i]).passedLessons.Add(stdlsn.ID);
                    ((StudentObject)stds[i]).currentSemisterCourses.Remove(stdlsn.ID);
                    Universal.instance.students.loadObject((StudentObject)stds[i]);
                    Universal.instance.students.save();
                }
            }
            List<object> msts = allMasters();
            for (int i = 0; i < msts.Count; i++)
            {
                ((MasterObject)msts[i]).courses = new List<int>();
            }
            Universal.instance.courses = new Database<CourseObject>("courses");
        }
    }
}
