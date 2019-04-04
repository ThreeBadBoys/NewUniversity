﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace newUniversity.Classes
{
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
            FileHandler.CreateBtreeFile(fileName, this.IDTree);
            FileHandler.CreateBtreeFile(fileName, this.NameTree);
            FileHandler.CreateFile(fileName);
        } // READ

        protected void loadTrees()
        {
            loadIdTree();
            loadNameTree();
        } //READ

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

        }

        public void loadRecordFromFile(FileStream file, int index)
        {

        }

        public int insertEdittedRecordToFile(int index)
        {
            return 0;
        }

        public int insertRecordToFile()
        {
            return 0;
        }

        public void save()
        {
            if (IDTree == null)
                loadTrees();
            int index = IDTree.get(dbObject.ID + "");
            if (index == -1)
                insertRecordToFile();
            else
                insertEdittedRecordToFile(index);
        }

        public void insert(T newObject)
        {
            try
            {
                getByID(newObject.ID);
            }
            catch (NotFoundException)
            {
                this.dbObject = newObject;
            }
            throw new DuplicateException();
        }

        public void loadObject(T newObject)
        {
            this.dbObject = newObject;
        }

        public void delete()
        {
            if (dbObject.ID != 0 && dbObject.Name != null)
            {
                IDTree.delete(dbObject.ID + "");
                NameTree.delete(dbObject.Name);
            }
            else
            {
                throw new Exception("argument to delete() is null");
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
                        IDTree.put(dbObject.ID + "", index);
                        NameTree.put(dbObject.Name, index);
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
