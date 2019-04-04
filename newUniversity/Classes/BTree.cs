using System;
using System.Collections.Generic;

namespace newUniversity.Classes
{
    [Serializable]
    class BTree
    {
        public static int M = 4;

        private Node root;       // root of the B-tree
        private int height;      // height of the B-tree
        private int n;           // number of key-value pairs in the B-tree

        /**
         * Initializes an empty B-tree.
         */
        public BTree()
        {
            root = new Node(0);
        }

        /**
         * Returns true if this symbol table is empty.
         * @return {@code true} if this symbol table is empty; {@code false} otherwise
         */
        public bool isEmpty()
        {
            return size() == 0;
        }

        /**
         * Returns the number of key-value pairs in this symbol table.
         * @return the number of key-value pairs in this symbol table
         */
        public int size()
        {
            return n;
        }

        /**
         * Returns the height of this B-tree (for debugging).
         *
         * @return the height of this B-tree
         */
        public int Height()
        {
            return height;
        }

        /**
         * Returns the file index associated with the biggest key.
         */
        public int getLastIndex()
        {
            return searchIndex(root, height);
        }

        private int searchIndex(Node x, int ht)
        {
            Entry[] children = x.children;

            // external node
            if (ht == 0)
            {
                return children[x.m - 1].index;
            }

            // internal node
            else
            {
                return searchIndex(children[x.m - 1].next, ht - 1);
            }
        }

        public string getLastID()
        {
            return searchID(root, height);
        }

        private string searchID(Node x, int ht)
        {
            Entry[] children = x.children;

            // external node
            if (ht == 0)
            {
                return children[x.m - 1].key;
            }

            // internal node
            else
            {
                return searchID(children[x.m - 1].next, ht - 1);
            }
        }

        /**
         * Returns the file index associated with the given key.
         *
         * @param  key the key
         * @return the file index associated with the given key if the key is in the symbol table
         *         and {@code null} if the key is not in the symbol table
         * @throws ArgumentOutOfRangeException if {@code key} is {@code null}
         */
        public int get(string key)
        {
            if (key == null) throw new ArgumentOutOfRangeException("argument to get() is null");
            return search(root, key, height);
        }

        private int search(Node x, string key, int ht)
        {
            Entry[] children = x.children;

            // external node
            if (ht == 0)
            {
                for (int j = 0; j < x.m; j++)
                {
                    if (equal(key, children[j].key)) return children[j].index;
                }
            }

            // internal node
            else
            {
                for (int j = 0; j < x.m; j++)
                {
                    if (j + 1 == x.m || less(key, children[j + 1].key))
                        return search(children[j].next, key, ht - 1);
                }
            }
            return -1;
        }

        /**
         * Inserts the key-index pair into the symbol table, overwriting the old index
         * with the new index if the key is already in the symbol table.
         *
         * @param  key the string
         * @param  index the string
         * @throws ArgumentOutOfRangeException if {@code key} is {@code null}
         */
        public void put(string key, int index)
        {
            if (key == null) throw new ArgumentOutOfRangeException("argument key to put() is null");
            Node u = insert(root, key, index, height);
            n++;
            if (u == null) return;

            // need to split root
            Node t = new Node(2);
            t.children[0] = new Entry(root.children[0].key, -1, root);
            t.children[1] = new Entry(u.children[0].key, -1, u);
            root = t;
            height++;
        }

        /**
         * this effectively deletes the key from the symbol table.
         */
        public void delete(string key)
        {
            if (key == null) throw new ArgumentOutOfRangeException("argument key to put() is null");
            Node u = insert(root, key, -1, height);
            n++;
            if (u == null) return;

            // need to split root
            Node t = new Node(2);
            t.children[0] = new Entry(root.children[0].key, -1, root);
            t.children[1] = new Entry(u.children[0].key, -1, u);
            root = t;
            height++;
        }

        private Node insert(Node h, string key, int index, int ht)
        {
            int j;
            Entry t = new Entry(key, index, null);

            // external node
            if (ht == 0)
            {
                for (j = 0; j < h.m; j++)
                {
                    if (less(key, h.children[j].key)) break;
                }
            }

            // internal node
            else
            {
                for (j = 0; j < h.m; j++)
                {
                    if ((j + 1 == h.m) || less(key, h.children[j + 1].key))
                    {
                        Node u = insert(h.children[j++].next, key, index, ht - 1);
                        if (u == null) return null;
                        t.key = u.children[0].key;
                        t.next = u;
                        break;
                    }
                }
            }

            for (int i = h.m; i > j; i--)
                h.children[i] = h.children[i - 1];
            h.children[j] = t;
            h.m++;
            if (h.m < M) return null;
            else return split(h);
        }

        // split node in half
        private Node split(Node h)
        {
            Node t = new Node(M / 2);
            h.m = M / 2;
            for (int j = 0; j < M / 2; j++)
                t.children[j] = h.children[M / 2 + j];
            return t;
        }

        /**
         * Returns a string representation of this B-tree (for debugging).
         *
         * @return a string representation of this B-tree.
         */
        public string toString()
        {
            return toString(root, height, "") + "\n";
        }

        private string toString(Node h, int ht, string indent)
        {
            string s = null;
            Entry[] children = h.children;

            if (ht == 0)
            {
                for (int j = 0; j < h.m; j++)
                {
                    s += indent + children[j].key + " " + children[j].index + "\n";
                }
            }
            else
            {
                for (int j = 0; j < h.m; j++)
                {
                    if (j > 0) s += indent + "(" + children[j].key + ")\n";
                    s += toString(children[j].next, ht - 1, indent + "     ");
                }
            }
            return s;
        }

        /**
         * Returns an array representation of this B-tree.
         *
         * @return an array representation of this B-tree.
         */
        public List<int> toArray()
        {
            return toArray(root, height);
        }

        private List<int> toArray(Node h, int ht)
        {
            List<int> array = new List<int>();
            Entry[] children = h.children;

            if (ht == 0)
            {
                for (int j = 0; j < h.m; j++)
                {
                    if (children[j].index != -1)
                    {
                        array.Add(children[j].index);
                    }
                }
            }
            else
            {
                for (int j = 0; j < h.m; j++)
                {
                    array.AddRange(toArray(children[j].next, ht - 1));
                }
            }
            return array;
        }

        // comparison functions - make Comparable instead of Key to avoid casts
        private bool less(string k1, string k2)
        {
            return k1.CompareTo(k2) < 0;
        }

        private bool equal(string k1, string k2)
        {
            return k1.Equals(k2);
        }
    }
}