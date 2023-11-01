

namespace Exercise2
{
    internal interface IManager 
    {
        public string[] Buffer { get; }
        public int Capacity { get; }
        public int BufferIndex { get; internal set; }
        public bool Locked { get; }
        public bool IsCurrentlyProducing { get; internal set; }
        internal int CountBuffer();
        internal void Lock();
        internal void Unlock();
        
        public static IManager Create(int capacity)
        {
            return new Manager(capacity);
        }
    }
}
