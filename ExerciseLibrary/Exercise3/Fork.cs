using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    internal class Fork
    {
        private static int _counter = 0;
        public string Name { get; private set; }

        public Fork()
        {
            this.Name = "Fork " + _counter++;
        }
    }
}
