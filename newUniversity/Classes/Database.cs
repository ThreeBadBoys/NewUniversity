using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace newUniversity.Classes
{
    [Serializable]
    class Database<T> where T : new ()
    {
        string fileName = "";
        public string getFileName()
        {
            return fileName;
        }
        protected BTree IDTree = null;
        protected BTree NameTree = null;
        protected object dbObject;

        public Database(string fileName)
        {
            this.fileName = fileName;
            IDTree = new BTree();
            NameTree = new BTree();
            FileHandler.CreateBtreeFile(fileName + "id", IDTree);
            FileHandler.CreateBtreeFile(fileName + "name", NameTree);
            FileHandler.CreateFile(fileName);
        } // READ

        protected void loadTrees()
        {
            loadIdTree();
            loadNameTree();
        } //READ

        protected void saveTrees()
        {
            saveIdTree();
            saveNameTree();
        } //WRITE

        protected void saveIdTree()
        {
            FileHandler.CreateBtreeFile(fileName + "id", IDTree);
        }//WRITE

        protected void saveNameTree()
        {
            FileHandler.CreateBtreeFile(fileName + "name", NameTree);
        }//WRITE

        protected void loadIdTree()
        {
            IDTree = FileHandler.loadBTreeFromFile(fileName, true);
        }//READ

        protected void loadNameTree()
        {
            NameTree = FileHandler.loadBTreeFromFile(fileName, false);
        }//READ

        public void loadRecordFromFile(int index)
        {
            bool read;
            dbObject = FileHandler.Load(new T(), out read, fileName, index);
        }

        public void loadRecordFromFile(string FileName, int index)
        {
            bool read;
            dbObject = FileHandler.Load(new T(), out read, FileName, index);
        }

        public void insertEdittedRecordToFile(int index)
        {
            FileHandler.SaveEdited(index, dbObject, fileName);
        }

        public int insertRecordToFile()
        {
            return FileHandler.Add<T>(IDTree, dbObject, fileName);
        }

        public void save()
        {
            if (IDTree == null)
                loadTrees();
            if (dbObject is StudentObject)
            {
                int index = IDTree.get((dbObject as StudentObject).ID + "");
                if (index == -1)
                    insertRecordToFile();
                else
                    insertEdittedRecordToFile(index);
            }
            else if (dbObject is MasterObject)
            {
                int index = IDTree.get((dbObject as MasterObject).ID + "");
                if (index == -1)
                    insertRecordToFile();
                else
                    insertEdittedRecordToFile(index);
            }
            else if (dbObject is ManagerObject)
            {
                int index = IDTree.get((dbObject as ManagerObject).ID + "");
                if (index == -1)
                {
                    insertRecordToFile();
                }
                else
                    insertEdittedRecordToFile(index);
            }
            else if (dbObject is CourseObject)
            {
                int index = IDTree.get((dbObject as CourseObject).ID + "");
                if (index == -1)
                    insertRecordToFile();
                else
                    insertEdittedRecordToFile(index);
            }
            else if (dbObject is StudentLessonObject)
            {
                int index = IDTree.get((dbObject as StudentLessonObject).ID + "");
                if (index == -1)
                    insertRecordToFile();
                else
                    insertEdittedRecordToFile(index);
            }
            saveTrees();
        }

        public void save(int index)
        {
            if (IDTree == null)
                loadTrees();
            if (dbObject is StudentObject)
            {
                IDTree.put((dbObject as StudentObject).ID + "", index);
                insertRecordToFile();
            }
            else if (dbObject is MasterObject)
            {
                IDTree.put((dbObject as MasterObject).ID + "", index);
                insertRecordToFile();
            }
            else if (dbObject is ManagerObject)
            {
                IDTree.put((dbObject as ManagerObject).ID + "", index);
                insertRecordToFile();
            }
            else if (dbObject is CourseObject)
            {
                IDTree.put((dbObject as CourseObject).ID + "", index);
                insertRecordToFile();
            }
            else if (dbObject is StudentLessonObject)
            {
                IDTree.put((dbObject as StudentLessonObject).ID + "", index);
                insertRecordToFile();
            }
            saveTrees();
        }

        public void insert(T newObject)
        {
            if (newObject is StudentObject)
            {
                try
                {
                    getByID((newObject as StudentObject).ID);
                    throw new DuplicateException();
                }
                catch (NotFoundException)
                {
                    dbObject = newObject;
                    int index = insertRecordToFile();
                    save(index);
                }
            }
            else if (newObject is MasterObject)
            {
                try
                {
                    getByID((newObject as MasterObject).ID);
                    throw new DuplicateException();
                }
                catch (NotFoundException)
                {
                    dbObject = newObject;
                    int index = insertRecordToFile();
                    save(index);
                }
            }
            else if (newObject is ManagerObject)
            {
                try
                {
                    getByID((newObject as ManagerObject).ID);
                    throw new DuplicateException();
                }
                catch (NotFoundException)
                {
                    dbObject = newObject;
                    int index = insertRecordToFile();
                    save(index);
                }
            }
            else if (newObject is CourseObject)
            {
                try
                {
                    getByID((newObject as CourseObject).ID);
                    throw new DuplicateException();
                }
                catch (NotFoundException)
                {
                    dbObject = newObject;
                    int index = insertRecordToFile();
                    save(index);
                }
            }
            else if (newObject is StudentLessonObject)
            {
                try
                {
                    getByID((newObject as StudentLessonObject).ID);
                    throw new DuplicateException();
                }
                catch (NotFoundException)
                {
                    dbObject = newObject;
                    int index = insertRecordToFile();
                    save(index);
                }
            }
        }

        public void loadObject(T newObject)
        {
            this.dbObject = newObject;
        }

        public void delete(DatabaseObject obj)
        {
            if (IDTree.get(obj.ID + "") != -1)
            {
                IDTree.delete(obj.ID + "");
                NameTree.delete(obj.name);
            }
            else
            {
                throw new NotFoundException("argument to delete() is null");
            }
        }

        public List<object> getAll()
        {
            List<object> items = new List<object>();
            List<int> indexes = IDTree.toArray();
            for(int i = 0; i < indexes.Count; i++)
            {
                loadRecordFromFile(indexes[i]);
                items.Add(dbObject);
            }
            return items;
        }

        public object getByID(int id)
        {
            loadTrees();
            int index = IDTree.get(id + "");
            if (index != -1)
                loadRecordFromFile(index);
            else
                throw new NotFoundException("record not found!");
            return dbObject;
        }

        public object getByName(string Name)
        {
            int index = IDTree.get(Name);
            if (index != -1)
                loadRecordFromFile(index);
            else
                throw new NotFoundException("record not found!");
            return dbObject;
        }

        public string getLastID()
        {
            return IDTree.getLastID();
        }

        public void update()
        {
            try
            {
                if (File.Exists(this.fileName))
                {
                    File.Move(this.fileName, "temp" + this.fileName);
                    File.Create(this.fileName);
                    BinaryFormatter bf = new BinaryFormatter();
                    List<int> indexes = IDTree.toArray();
                    IDTree = new BTree();
                    NameTree = new BTree();
                    if (dbObject is StudentObject)
                    {
                        for (int i = 0; i < indexes.Count; i++)
                        {
                            loadRecordFromFile("temp" + this.fileName, indexes[i]);
                            int index = insertRecordToFile();
                            IDTree.put((dbObject as StudentObject).ID + "", index);
                            NameTree.put((dbObject as StudentObject).name, index);
                        }
                    }
                    else if (dbObject is MasterObject)
                    {
                        for (int i = 0; i < indexes.Count; i++)
                        {
                            loadRecordFromFile("temp" + this.fileName, indexes[i]);
                            int index = insertRecordToFile();
                            IDTree.put((dbObject as MasterObject).ID + "", index);
                            NameTree.put((dbObject as MasterObject).name, index);
                        }
                    }
                    else if (dbObject is ManagerObject)
                    {
                        for (int i = 0; i < indexes.Count; i++)
                        {
                            loadRecordFromFile("temp" + this.fileName, indexes[i]);
                            int index = insertRecordToFile();
                            IDTree.put((dbObject as ManagerObject).ID + "", index);
                            NameTree.put((dbObject as ManagerObject).name, index);
                        }
                    }
                    else if (dbObject is CourseObject)
                    {
                        for (int i = 0; i < indexes.Count; i++)
                        {
                            loadRecordFromFile("temp" + this.fileName, indexes[i]);
                            int index = insertRecordToFile();
                            IDTree.put((dbObject as CourseObject).ID + "", index);
                            NameTree.put((dbObject as CourseObject).name, index);
                        }
                    }
                    File.Delete("temp" + this.fileName);
                    FileStream file = File.Open(this.fileName + "idtree", FileMode.Open);
                    bf.Serialize(file, IDTree);
                    file.Close();
                    file = File.Open(this.fileName + "nametree", FileMode.Open);
                    bf.Serialize(file, NameTree);
                    file.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }
    }
}
