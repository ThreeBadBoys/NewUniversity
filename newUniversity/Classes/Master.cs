using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class Master : User
    {
        public void addCourse(MasterObject master, int courseId, string courseTitle, short courseUnitsCount, string examTime, string courseTime)
        {
            Universal.instance.courses.insert(new CourseObject(courseId,courseTitle, courseUnitsCount, master.ID));
            Universal.instance.courses.save();
            master.courses.Add(courseId);
        }

        public void deleteCourse(MasterObject master, int courseId)
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
    }
}
