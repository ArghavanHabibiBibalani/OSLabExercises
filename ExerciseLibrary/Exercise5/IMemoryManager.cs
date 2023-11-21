

namespace Exercise5
{
    internal interface IMemoryManager
    {
        public Dictionary<IProcess, int> processIndexPairs { get; }
        public void AllocateFirstFit(IProcess process);

        public void AllocateBestFit(IProcess process);

        public void AllocateWorstFit(IProcess process);

        public void Deallocate(string processName);

        public void DisplayMemory();

        public static IMemoryManager Create(int totalMemorySlots, int memoryFragments)
        {
            return new MemoryManager(totalMemorySlots, memoryFragments);
        }
    }
}
