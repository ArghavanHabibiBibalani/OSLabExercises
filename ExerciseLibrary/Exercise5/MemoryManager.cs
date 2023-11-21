

namespace Exercise5
{
    internal class MemoryManager : IMemoryManager
    {
        public Dictionary<IProcess, int> processIndexPairs { get; private set; }
        private List<IProcess[]> _processList;
        private int _totalMemorySlots;

        public MemoryManager(int totalMemorySlots, int memoryFragments)
        {
            processIndexPairs = new Dictionary<IProcess, int>();
            _processList = new List<IProcess[]>();
            _totalMemorySlots = totalMemorySlots;
            PartitionMemory(memoryFragments);
            // Console.WriteLine(ProcessListToString());
        }
        public void AllocateFirstFit(IProcess process)
        {
            foreach (IProcess[] array in _processList)
            {
                if (process.volume <= array.Length)
                {
                    if (process.volume <= ArrayCountEmpty(array))
                    {
                        for (int i = 0; i < process.volume; i++)
                        {
                            array[LastIndex(array)] = process;
                        }
                        processIndexPairs.Add(process, _processList.IndexOf(array));
                        break;
                    }
                }
            }
        }

        public void AllocateBestFit(IProcess process)
        {
            var bestIndex = 0;
            var leastWaste = int.MaxValue;
            for (int i = 0; i < _processList.Count; i++)
            {
                if (ArrayCountEmpty(_processList[i]) >= process.volume)
                {
                    if (ArrayCountEmpty(_processList[i]) - process.volume < leastWaste)
                    {
                        leastWaste = ArrayCountEmpty(_processList[i]) - process.volume;
                        bestIndex = i;
                    }
                }
            }
            processIndexPairs.Add(process, bestIndex);
            for (int i = 0; i < process.volume; i++)
            {
                _processList[bestIndex][LastIndex(_processList[bestIndex])] = process;
            }
        }

        public void AllocateWorstFit(IProcess process)
        {
            var worstIndex = 0;
            var mostWaste = 0;
            for (int i = 0; i < _processList.Count; i++)
            {
                if (ArrayCountEmpty(_processList[i]) >= process.volume)
                {
                    if (ArrayCountEmpty(_processList[i]) - process.volume > mostWaste) {
                        mostWaste = ArrayCountEmpty(_processList[i]) - process.volume;
                        worstIndex = i;
                    }
                }
            }
            processIndexPairs.Add(process, worstIndex);
            for (int i = 0; i < process.volume; i++)
            {
                _processList[worstIndex][LastIndex(_processList[worstIndex])] = process;
            }
        }

        public void Deallocate(string processName)
        {
            var process = processIndexPairs.Where(pair => pair.Key.name == processName).Select(pair => pair.Key).ToList()[0];
            var index = processIndexPairs.Where(pair => pair.Key.name == processName).Select(pair => pair.Value).ToList()[0];
            for (int i = 0; i < process.volume;)
            {
                if (_processList[index][i] == process)
                {
                    _processList[index][i] = null;
                    i++;
                }
            }
            processIndexPairs.Remove(process);
        }

        public void DisplayMemory()
        {
            Console.WriteLine(ProcessListToString());
        }

        private void PartitionMemory(int memoryFragments)
        {
            var random = new Random();
            var spaceLeft = _totalMemorySlots;
            var averageFragmentSize = _totalMemorySlots / memoryFragments;
            // var arrayIndex = 1;
            for (int i = 0; i < memoryFragments; i++)
            {
                var fragmentSize = i == memoryFragments - 1 ? spaceLeft : random.Next(averageFragmentSize - 1, averageFragmentSize + 2);
                var newArray = new IProcess[fragmentSize];
                // PopulateProcessArray(newArray, ref arrayIndex);
                _processList.Add(newArray);
                spaceLeft -= fragmentSize;
                averageFragmentSize = spaceLeft / (memoryFragments - i) == 0 ? spaceLeft : spaceLeft / (memoryFragments - i);
            }
        }

        private string ArrayToString(IProcess[] processes)
        {
            var output = "{ ";
            for (int i = 0; i < processes.Length; i++)
            {
                output += processes[i] == null ? "[Null]" : processes[i].name;
                if (i != processes.Length - 1) { output += " , "; }
            }
            output += " }";
            return output;
        }

        private string ProcessListToString()
        {
            var output = "[ ";
            for (int i = 0; i < _processList.Count; i++)
            {
                output += ArrayToString(_processList[i]);
                if (i != _processList.Count - 1) { output += " ,\n"; }
            }
            output += " ]";
            return output;
        }

        private void PopulateProcessArray(IProcess[] array, ref int index)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = IProcess.Create(index++.ToString(), 1);
            }
        }

        private int ArrayCountEmpty(object[] array)
        {
            var output = 0;
            foreach (object obj in array)
            {
                if (obj == null) { output++; }
            }
            return output;
        }

        private int LastIndex(object[] array)
        {
            var output = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null) { output = i; return output; }
            }
            return output;
        }
    }
}
