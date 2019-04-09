using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    static class FileHandler
    {
        public static int Add<T>(BTree whichTree, object objectToAdd, string fileDirectoryPlusName)
        {
            byte[] objectArray = ObjectToByteArray(objectToAdd);
            int tempindex;
            if (whichTree.isEmpty())
                tempindex = -1;
            else
                tempindex = whichTree.getLastIndex();
            // Get a handle to an existing memory mapped file
            using (MemoryMappedFile mmf =
                MemoryMappedFile.CreateFromFile
                (fileDirectoryPlusName, FileMode.Open, "mmf", (tempindex + 2) * objectArray.Length))
            // (UP)  Here we created a filefrom  a memoryMappedFile that it's capacity is (tempindex + 2) times larger than objectArray.Length
            //HERE WE SHOULD THINK ABOUT IT!!!!
            {
                // Create a view accessor from which to read the data
                using (MemoryMappedViewAccessor mmfReader = mmf.CreateViewAccessor())
                {
                    //Then to access the file created from MemoryMappedFile ,we use MemoryMappedViewAccessor

                    byte[] buffer = new byte[objectArray.Length];//HERE WE Have an array of bytes to read the data to it
                                                                 //With length = objectArray.Length


                    //HERE IS THE TRICK
                    //TO SAVE THE DATA IN FILE ==>> We navigate over the file to find the null place to save the data


                    mmfReader.WriteArray<byte>((tempindex + 1 )* objectArray.Length, objectArray, 0, buffer.Length);//DATA is written to File                             
                    return tempindex + 1;
                }
            }
        }//DECODED SUCCESSFULLY

        public static object Load(object objectTempToLoad, out bool Readable, string fileDirectoryPlusName, int index)
        {
            if (index == -1)
            {
                Readable = false;
                return null;
            }
            objectTempToLoad = LoadObj(objectTempToLoad, fileDirectoryPlusName, index, out Readable);

            return objectTempToLoad;
        }

        private static object LoadObj(object objectTempToLoad, string fileDirectoryPlusName, int index, out bool Readable)
        {
            byte[] buffer = ObjectToByteArray(objectTempToLoad);


            using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(fileDirectoryPlusName, FileMode.Open))
            {
                using (MemoryMappedViewAccessor mmfReader = mmf.CreateViewAccessor())
                {
                    Readable = mmfReader.CanRead;
                    if (Readable)
                        mmfReader.ReadArray<byte>(index * buffer.Length, buffer, 0, buffer.Length);
                }
            }
            objectTempToLoad = ByteArrayToObject(buffer);
            return objectTempToLoad;
        }

        public static void SaveEdited(int index, object objectToEdit, string fileDirectoryPlusName)
        {
            byte[] buffer = ObjectToByteArray(objectToEdit);

            using (MemoryMappedFile mmf = MemoryMappedFile.CreateFromFile(fileDirectoryPlusName, FileMode.Open))
            {
                using (MemoryMappedViewAccessor mmfWriter = mmf.CreateViewAccessor())
                {
                    mmfWriter.WriteArray<byte>(index * buffer.Length, buffer, 0, buffer.Length);
                }
            }
        }

        private static byte[] ObjectToByteArray(object objectToGetBytes)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();    // Create new BinaryFormatter
            MemoryStream memoryStream = new MemoryStream();             // Create target memory stream
            binaryFormatter.Serialize(memoryStream, objectToGetBytes);  // Serialize object to stream
            return memoryStream.ToArray();
        }

        public static object ByteArrayToObject(byte[] buffer)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter(); // Create new BinaryFormatter
            MemoryStream memoryStream = new MemoryStream(buffer);    // Convert buffer to memorystream
            try
            {
                return binaryFormatter.Deserialize(memoryStream);        // Deserialize stream to an object
            }
            catch (SerializationException)
            {
                return null;
            }
        }

        public static void CreateBtreeFile(string fileName,BTree IDTree)
        {
            FileStream file = File.Create(fileName);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, IDTree);
            file.Close();
        }
        public static void CreateFile(string fileName)
        {
            FileStream file = File.Create(fileName);
            file.Close();
        }

        public static BTree loadBTreeFromFile(string fileName , bool isIDTree)
        {
            BTree btree;
            if (File.Exists(fileName + (isIDTree ?"idtree" : "nametree")))
            {
                FileStream file = File.Open(fileName + (isIDTree ? "idtree" : "nametree"), FileMode.Open);
                if (new FileInfo(fileName + (isIDTree ? "idtree" : "nametree")).Length != 0)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    btree = bf.Deserialize(file) as BTree;
                    file.Close();
                    return btree;
                }
                else
                    throw new NotFoundException("tree file is empty");
            }
            else
                throw new NotFoundException("tree file not found");
        }
    }
}
