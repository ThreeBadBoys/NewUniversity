using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() : base("invalidPasswordException") { }
        public InvalidPasswordException(string message) : base(message) { }
        public InvalidPasswordException(string message, System.Exception inner) : base(message, inner) { }
    }
}
