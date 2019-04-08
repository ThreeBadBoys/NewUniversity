using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    // internal nodes: only use key and next
    // external nodes: only use key and address
    [Serializable]
    public class Entry
    {
        public string key;
        public int index;
        public Node next;     // helper field to iterate over array entries
        public Entry(string key, int index, Node next)
        {
            this.key = key;
            this.index = index;
            this.next = next;
        }
    }
}