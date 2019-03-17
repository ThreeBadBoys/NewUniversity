using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace newUniversity.Classes
{
    abstract class Database
    {
        string fileName = "";
        protected BTree IDTree = null;
        protected BTree NameTree = null;
        public int ID = 0;
        protected string Name = null;

        public Database(string fileName)
        {
            this.fileName = fileName;
            this.IDTree = new BTree();
            this.NameTree = new BTree();
            FileStream file = File.Create(fileName + "idtree");
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, this.IDTree);
            file.Close();
            file = File.Create(fileName + "nametree");
            bf.Serialize(file, this.NameTree);
            file.Close();
            file = File.Create(fileName);
            file.Close();
        }

        protected bool loadTrees()
        {
            return loadIdTree() && loadNameTree();
        }
        protected bool loadIdTree()
        {
            if (File.Exists(fileName + "idTree"))
            {
                FileStream file = File.Open(fileName + "idTree", FileMode.Open);
                if (new FileInfo(fileName + "idTree").Length != 0)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    this.IDTree = bf.Deserialize(file) as BTree;
                    file.Close();
                    return true;
                }
            }
            return false;
        }
        protected bool loadNameTree()
        {
            if (File.Exists(fileName + "nameTree"))
            {
                FileStream file = File.Open(fileName + "nameTree", FileMode.Open);
                file = File.Open(fileName + "nameTree", FileMode.Open);
                if (new FileInfo(fileName + "nameTree").Length != 0)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    this.NameTree = bf.Deserialize(file) as BTree;
                    file.Close();
                    return true;
                }
            }
            return false;
        }

        public abstract void loadRecordFromFile(int index);

        public abstract void loadRecordFromFile(FileStream file, int index);

        public abstract int insertRecordToFile(int index);

        public abstract int insertRecordToFile();

        public void save()
        {
            if (IDTree == null)
                loadTrees();
            int index = IDTree.get(ID + "");
            if (index == -1)
                insertRecordToFile();
            else
                insertRecordToFile(index);
        }

        public void delete()
        {
            if (this.ID != 0 && this.Name != null)
            {
                IDTree.delete(this.ID + "");
                NameTree.delete(this.Name);
            }
            else
            {
                throw new Exception("argument to delete() is null");
            }
        }

        public Database getByID(int id)
        {
            int index = IDTree.get(id + "");
            if (index != -1)
                loadRecordFromFile(index);
            else
                throw new notFoundException("record not found!");
            return this;
        }

        public Database getByName(string Name)
        {
            int index = IDTree.get(Name);
            if (index != -1)
                loadRecordFromFile(index);
            else
                throw new notFoundException("record not found!");
            return this;
        }

        public void update()
        {
            try
            {
                if (File.Exists(this.fileName))
                {
                    File.Move(this.fileName, "temp" + this.fileName);
                    FileStream file = File.Open("temp" + this.fileName, FileMode.Open);
                    File.Create(this.fileName);
                    BinaryFormatter bf = new BinaryFormatter();
                    List<int> indexes = IDTree.toArray();
                    IDTree = new BTree();
                    NameTree = new BTree();
                    for (int i = 0; i < indexes.Count; i++)
                    {
                        loadRecordFromFile(file, indexes[i]);
                        int index = insertRecordToFile();
                        IDTree.put(ID + "", index);
                        NameTree.put(Name, index);
                    }
                    file.Close();
                    File.Delete("temp" + this.fileName);
                    file = File.Open(this.fileName + "idtree", FileMode.Open);
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
