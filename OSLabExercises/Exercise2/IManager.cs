using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLabExercises.Exercise2
{
    internal interface IManager
    {
        public string[] Buffer { get; }
        public int BufferIndex { get; internal set; }
        public bool Locked { get; }
        public bool IsCurrentlyProducing { get; internal set; }
        public void Lock();
        public void Unlock();

        // Need a public buffer-counting method here
        public IManager Create(int capacity)
        {
            return new Manager(capacity);
        }
    }
}
