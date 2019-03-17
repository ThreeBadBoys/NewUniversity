using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace newUniversity.Classes
{
    class Universal
    {
        public StudentDB students;                  //students database
        public ManagerDB managers;                  //managers database
        public MasterDB masters;                    //masters database
        public CourseDB courses;                    //courses database

        public bool isAbleUnitChoice = false;       //UnitChoice ability
        public bool isAbleUnitEdit = false;         //UnitEdit ability

        public static Universal instance;

        /**
         * Initializes main file and BTrees.
         */
        static Universal()
        {
            if (instance == null)
            {
                instance = new Universal();
                if (File.Exists("Uni"))
                {
                    //File exists.
                    FileStream file = File.Open("Uni", FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    if (new FileInfo("Uni").Length == 0)
                    {
                        //File exists but is empty.
                        instance.students = new StudentDB("students");
                        instance.managers = new ManagerDB("managers");
                        instance.masters = new MasterDB("masters");
                        instance.courses = new CourseDB("courses");
                        instance.managers.newManager("admin", "admin");
                        instance.managers.save();
                        bf.Serialize(file, instance);
                        file.Close();
                    }
                    else
                    {
                        //File was already created.
                        instance = bf.Deserialize(file) as Universal;
                        file.Close();
                    }
                }
                else
                {
                    //File not exists
                    instance.students = new StudentDB("students");
                    instance.managers = new ManagerDB("managers");
                    instance.masters = new MasterDB("masters");
                    instance.courses = new CourseDB("courses");
                    FileStream file = File.Create("Uni");
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(file, instance);
                    file.Close();
                }
            }
        }        
    }
}