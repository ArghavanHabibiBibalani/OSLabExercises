

namespace Exercise6
{
    internal class PageManager
    {
        private int _pageCount;
        private int _pageFaults;
        private int _pageHits;
        private Queue<string> _pageQueue;
        
        public PageManager(int pageCount)
        {
            _pageQueue = new Queue<string>();
            _pageCount = pageCount;
        }
        public void StartProccessing(string[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (UpdateQueue(inputArray[i]) == false)
                {
                    Console.WriteLine($"{i + 1}. Page fault ({inputArray[i]})\n");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. Page hit ({inputArray[i]})\n");
                }
                Console.WriteLine(string.Join(", ", _pageQueue.ToArray()) + "\n");
            }
            Console.WriteLine($"Total page faults: {_pageFaults}");
            Console.WriteLine($"Total page hits: {_pageHits}");
        }
        private bool UpdateQueue(string input)
        {
            if (_pageQueue.Contains(input) == false)
            {
                _pageFaults++;
                _pageQueue.Enqueue(input);
                if (_pageQueue.Count > _pageCount) { _pageQueue.Dequeue(); }
                return false;
            } 
            else
            {
                _pageHits++;
                return true;
            }
        }
    }
}
