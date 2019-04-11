using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class Master : User
    {
        static public void addCourse(MasterObject master, int courseId, string courseTitle, short courseUnitsCount, string examDate, string examTime, string courseTime, string classDays)
        {
            Universal.instance.courses.insert(new CourseObject(courseId,courseTitle, courseUnitsCount, master.ID, examDate, examTime, courseTime, classDays));
            master.courses.Add(courseId);
            Universal.instance.masters.loadObject(master);
            Universal.instance.masters.save();
        }

        static public void deleteCourse(MasterObject master, int courseId)
        {
            if (!master.courses.Contains(courseId))
                throw new NotFoundException("entered courseId not exists!");
            else
            {
                var course = Universal.instance.courses.getByID(courseId) as DatabaseObject;
                Universal.instance.courses.delete(course);
                Universal.instance.courses.save();
                master.courses.Remove(courseId);
                Universal.instance.masters.loadObject(master);
                Universal.instance.masters.save();
            }
        }

        static public void insertGrade(object master, int stdID, int crsID, double grade)
        {
            try
            {
                StudentObject std = Universal.instance.students.getByID(stdID) as StudentObject;
                if (!std.currentSemisterCourses.Contains(int.Parse(crsID + "" + stdID)))
                    throw new NotFoundException();
                else
                {
                    StudentLessonObject stdlsn = Universal.instance.studentLessons.getByID(int.Parse(crsID + "" + stdID)) as StudentLessonObject;
                    if ((master as MasterObject).ID != stdlsn.masterID)
                        throw new Exception("permission denied!");
                    stdlsn.grade = grade;
                    Universal.instance.studentLessons.loadObject(stdlsn);
                    Universal.instance.studentLessons.save();
                }
            }
            catch
            {
                throw new NotFoundException("course not found or this student hadn't choose it");
            }
        }

        static public  List<object> getAllCourses(MasterObject mst)
        {
            return Universal.instance.courses.getAll(mst.courses.ToArray());
        }
    }
}
