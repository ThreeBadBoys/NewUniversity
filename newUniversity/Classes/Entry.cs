using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Classes
{

    // internal nodes: only use key and next
    // external nodes: only use key and address
    [Serializable]
    public class Entry
    {
        public int key;
        public int address;
        public Node next;     // helper field to iterate over array entries
        public Entry(int key, int address, Node next)
        {
            this.key = key;
            this.address = address;
            this.next = next;
        }
    }
}


