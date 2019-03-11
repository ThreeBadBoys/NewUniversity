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
        int ID = 0;
        string Name = null;

        public Database(string fileName)
        {
            this.fileName = fileName;
            BTree newTree = new BTree();
            this.IDTree = newTree;
            FileStream file = File.Create(fileName + "idtree");
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, this.IDTree);
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
            File.Move(this.fileName + "tree", "temp" + this.fileName + "tree");
            FileStream file = File.Create(this.fileName);
            FileStream treefile = File.Create(this.fileName + "tree");
            List<int> indexes = IDTree.toArray();
            //some code
            File.Delete("temp" + this.fileName);
        }
    }
}
