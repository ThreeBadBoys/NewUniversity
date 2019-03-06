using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Classes
{

    // helper B-tree node data type
    [Serializable]
    public class Node
    {
        public int m;                                   // number of children
        public Entry[] children = new Entry[BTree.M];   // the array of children

        // create a node with k children
        public Node(int k)
        {
            m = k;
        }
    }
}


