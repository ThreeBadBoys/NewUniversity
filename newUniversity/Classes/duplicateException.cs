using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class DuplicateException : Exception
    {
        public DuplicateException() : base("duplicateException") { }
        public DuplicateException(string message) : base(message) { }
        public DuplicateException(string message, System.Exception inner) : base(message, inner) { }
    }
}
