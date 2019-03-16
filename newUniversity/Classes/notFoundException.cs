using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Classes
{
    class notFoundException : Exception
    {
        public notFoundException() : base() { }
        public notFoundException(string message) : base(message) { }
        public notFoundException(string message, System.Exception inner) : base(message, inner) { }
    }
}
