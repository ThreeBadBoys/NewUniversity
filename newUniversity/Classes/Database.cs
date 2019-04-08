using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace newUniversity.Classes
{
    [Serializable]
    class Database<T>
    {
        string fileName = "";
        public string getFileName()
        {
            return fileName;
        }
        protected BTree IDTree = null;
        protected BTree NameTree = null;
        protected T dbObject;

        public Database(string fileName)
        {
            this.fileName = fileName;
            this.IDTree = new BTree();
            this.NameTree = new BTree();
            FileHandler.CreateBtreeFile(fileName+"idtree", this.IDTree);
            FileHandler.CreateBtreeFile(fileName + "nametree", this.NameTree);
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
            FileHandler.loadBTreeFromFile(fileName, true);
        }//WRITE

        protected void saveNameTree()
        {
            FileHandler.loadBTreeFromFile(fileName, false);
        }//WRITE

        protected void loadIdTree()
        {
            FileHandler.loadBTreeFromFile(fileName, true);
        }//READ

        protected void loadNameTree()
        {
            FileHandler.loadBTreeFromFile(fileName, false);
        }//READ

        public void loadRecordFromFile(int index)
        {
            bool read;
            FileHandler.Load(dbObject, out read, fileName, index);
        }

        public void loadRecordFromFile(string FileName, int index)
        {
            bool read;
            FileHandler.Load(dbObject, out read, FileName, index);
        }

        public void insertEdittedRecordToFile(int index)
        {
            FileHandler.SaveEdited(index, dbObject, fileName);
        }

        public int insertRecordToFile()
        {
            return FileHandler.Add<T>(IDTree,dbObject,fileName);
        }

        public void save()
        {
            if (dbObject is StudentObject)
            {
                if (IDTree == null)
                    loadTrees();
                int index = IDTree.get((dbObject as StudentObject).ID + "");
                if (index == -1)
                    insertRecordToFile();
                else
                    insertEdittedRecordToFile(index);
            } else if (dbObject is MasterObject)
            {
                if (IDTree == null)
                    loadTrees();
                int index = IDTree.get((dbObject as MasterObject).ID + "");
                if (index == -1)
                    insertRecordToFile();
                else
                    insertEdittedRecordToFile(index);
            }
            else if (dbObject is ManagerObject)
            {
                if (IDTree == null)
                    loadTrees();
                int index = IDTree.get((dbObject as ManagerObject).ID + "");
                if (index == -1)
                    insertRecordToFile();
                else
                    insertEdittedRecordToFile(index);
            }
            else if (dbObject is CourseObject)
            {
                if (IDTree == null)
                    loadTrees();
                int index = IDTree.get((dbObject as CourseObject).ID + "");
                if (index == -1)
                    insertRecordToFile();
                else
                    insertEdittedRecordToFile(index);
            }
            saveTrees();

        }

        public void insert(T newObject)
        {
            if (dbObject is StudentObject)
            {
                try
                {
                    getByID((newObject as StudentObject).ID);
                }
                catch (NotFoundException)
                {
                    this.dbObject = newObject;
                    int index = insertRecordToFile();
                    IDTree.put((newObject as StudentObject).ID+"",index);
                }
                throw new DuplicateException();
            }
            else if (dbObject is MasterObject)
            {
                try
                {
                    getByID((newObject as MasterObject).ID);
                }
                catch (NotFoundException)
                {
                    this.dbObject = newObject;
                    int index = insertRecordToFile();
                    IDTree.put((newObject as MasterObject).ID + "", index);
                }
                throw new DuplicateException();
            }
            else if (dbObject is ManagerObject)
            {
                try
                {
                    getByID((newObject as ManagerObject).ID);
                }
                catch (NotFoundException)
                {
                    this.dbObject = newObject;
                    int index = insertRecordToFile();
                    IDTree.put((newObject as ManagerObject).ID + "", index);
                }
                throw new DuplicateException();
            }
            else if (dbObject is CourseObject)
            {
                try
                {
                    getByID((newObject as CourseObject).ID);
                }
                catch (NotFoundException)
                {
                    this.dbObject = newObject;
                    int index = insertRecordToFile();
                    IDTree.put((newObject as CourseObject).ID + "", index);
                }
                throw new DuplicateException();
            }
            else if (dbObject is PassedLessonObject)
            {
                try
                {
                    getByID((newObject as PassedLessonObject).ID);
                }
                catch (NotFoundException)
                {
                    this.dbObject = newObject;
                    int index = insertRecordToFile();
                    IDTree.put((newObject as PassedLessonObject).ID + "", index);
                }
                throw new DuplicateException();
            }
        }

        public void loadObject(T newObject)
        {
            this.dbObject = newObject;
        }

        public void delete(DatabaseObject obj)
        {
            if (IDTree.get(obj.ID+"") != -1)
            {
                IDTree.delete(obj.ID + "");
                NameTree.delete(obj.name);
            }
            else
            {
                throw new NotFoundException("argument to delete() is null");
            }
        }

        public T getByID(int id)
        {
            int index = IDTree.get(id + "");
            if (index != -1)
                loadRecordFromFile(index);
            else
                throw new NotFoundException("record not found!");
            return dbObject;
        }

        public T getByName(string Name)
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
