using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class duplicateException : Exception
    {
        public duplicateException() : base("duplicateException") { }
        public duplicateException(string message) : base(message) { }
        public duplicateException(string message, System.Exception inner) : base(message, inner) { }
    }
}
