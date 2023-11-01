

namespace Exercise2
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
        public int Capacity { get => _capacity; private set { _capacity = value; } }
        public int BufferIndex { get => _bufferIndex; set { _bufferIndex = value; } }

        public bool Locked { get => _locked; private set { _locked = value; } }

        public bool IsCurrentlyProducing { get => _isCurrentlyProducing; set { _isCurrentlyProducing = value; } }

        public int CountBuffer() // Count the contents of the buffer if their not null and not equal to "".
        {
            var output = 0;
            foreach (var str in _buffer)
            {
                if (str != null && str != "") { output++; }
            }
            return output;
        }
        public void Lock() { _locked = true; }  

        public void Unlock() {  _locked = false; }
    }
}
