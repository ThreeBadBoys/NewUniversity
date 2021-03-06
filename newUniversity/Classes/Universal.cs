﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace newUniversity.Classes
{
    [Serializable]
    class Universal 
    {
        public Database<StudentObject> students;                  //students database
        public Database<ManagerObject> managers;                  //managers database
        public Database<MasterObject> masters;                    //masters database
        public Database<CourseObject> courses;                    //courses database
        public Database<StudentLessonObject> studentLessons;        //passed lessons database

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
                if (File.Exists("Uni.data"))
                {
                    //File exists.
                    FileStream file = File.Open("Uni.data", FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    if (new FileInfo("Uni.data").Length == 0)
                    {
                        //File exists but it is empty.
                        instance.students = new Database<StudentObject>("students");
                        instance.managers = new Database<ManagerObject>("managers");
                        instance.masters = new Database<MasterObject>("masters");
                        instance.courses = new Database<CourseObject>("courses");
                        instance.studentLessons = new Database<StudentLessonObject>("studentLessons");
                        bf.Serialize(file, instance);
                        file.Close();
                        ManagerObject manager = new ManagerObject();
                        instance.managers.insert(manager);
                        instance.managers.save();
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
                    instance.students = new Database<StudentObject>("students");
                    instance.managers = new Database<ManagerObject>("managers");
                    instance.masters = new Database<MasterObject>("masters");
                    instance.courses = new Database<CourseObject>("courses");
                    instance.studentLessons = new Database<StudentLessonObject>("studentLessons");
                    FileStream file = File.Create("Uni.data");
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(file, instance);
                    file.Close();
                    ManagerObject manager = new ManagerObject();
                    instance.managers.insert(manager);
                    instance.managers.save();
                }
            }
        }        
    }
}