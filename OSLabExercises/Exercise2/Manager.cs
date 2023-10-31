using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLabExercises.Exercise2
{
    internal class Manager : IManager
    {
        private string[] _buffer;
        private int _capacity;
        private int _bufferIndex;
        private bool _locked;
        private bool _isCurrentlyProducing;

        internal Manager(int capacity)
        {
            _buffer = new string[capacity];
            _capacity = capacity;
            _bufferIndex = 0;
            _locked = false;
            _isCurrentlyProducing = true;
        }

        public string[] Buffer { get => _buffer; private set { _buffer = value; } }

        public int BufferIndex { get => _bufferIndex; set { _bufferIndex = value; } }

        public bool Locked { get => _locked; private set { _locked = value; } }

        public bool IsCurrentlyProducing { get => _isCurrentlyProducing; set { _isCurrentlyProducing = value; } }

        public void Lock() { _locked = true; }  

        public void Unlock() {  _locked = false; }
    }
}
