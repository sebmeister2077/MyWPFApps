using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafuri
{
    class Connection
    {
        ushort i, j;
        Node n1, n2;
        public Connection() { }
        public Connection(ushort i,ushort j)
        {
            this.i = i;this.j = j;
        }
        public ushort I
        {
            get { return i; }
        }
        public ushort J
        {
            get { return j; }
        }

    }
}
