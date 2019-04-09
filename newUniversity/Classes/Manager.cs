using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (student.currentSemisterCourses.Contains(courseID))
            {
                student.currentSemisterCourses.Remove(courseID);
                Universal.instance.students.loadObject(student);
                Universal.instance.students.save();
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
            StudentObject[] stds = allStudents();
            for(int i = 0; i < stds.Length; i++)
            {
                int[] ids = stds[i].currentSemisterCourses.ToArray();
                for(int j = 0; j < ids.Length; j++)
                {
                    StudentLessonObject stdlsn = Universal.instance.studentLessons.getByID(ids[j]) as StudentLessonObject;
                    if (stdlsn.grade > 10)
                        stds[i].passedUnits+=stdlsn.unitsCount;
                    stds[i].passedLessons.Add(stdlsn.ID);
                    stds[i].currentSemisterCourses.Remove(stdlsn.ID);
                    Universal.instance.students.loadObject(stds[i]);
                    Universal.instance.students.save();
                }
            }
            MasterObject[] msts = allMasters();
            for (int i = 0; i < msts.Length; i++)
            {
                msts[i].courses = new List<int>();
            }
            Universal.instance.courses = new Database<CourseObject>("courses");
        }
    }
}
