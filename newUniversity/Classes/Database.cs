using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace University.Classes
{
    abstract class Database
    {
        string fileName = "";
        BTree IDTree;
        BTree NameTree;
        public int ID = 0;
        string Name = null;

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

        private void loadTree()
        {
            FileStream file = File.Open(fileName + "idTree", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            this.IDTree = bf.Deserialize(file) as BTree;
            file = File.Open(fileName + "nameTree", FileMode.Open);
            this.NameTree = bf.Deserialize(file) as BTree;
            file.Close();
        }

        public abstract void loadRecordFromFile(int index);

        public abstract void loadRecordFromFile(FileStream file, int index);

        public abstract int insertRecordToFile();

        public abstract void save();

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

        public abstract void getByID(int id);

        public abstract void getByName(string Name);

        public void update()
        {
            File.Move(this.fileName, "temp" + this.fileName);
            FileStream file = File.Open("temp" + this.fileName, FileMode.Open);
            File.Create(this.fileName);
            BinaryFormatter bf = new BinaryFormatter();
            List<int> indexes = IDTree.toArray();
            IDTree = new BTree();
            NameTree = new BTree();
            for(int i = 0 ; i<indexes.Count ; i++)
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
}
