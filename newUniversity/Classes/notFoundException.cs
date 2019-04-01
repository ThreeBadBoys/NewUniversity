using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class NotFoundException : Exception
    {
        public NotFoundException() : base("notFoundException") { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, System.Exception inner) : base(message, inner) { }
    }
}
