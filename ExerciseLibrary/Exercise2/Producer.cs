

namespace Exercise2
{
    internal class Producer : IProcess
    {
        private int _sleepDuration;
        private IManager _manager;

        internal Producer(IManager manager, int sleepDuration)
        {
            _sleepDuration = sleepDuration;
            _manager = manager;
            
        }
        public event Action<bool, IManager> ChangedBuffer;

        public void StartProcess()
        {
            while(true)
            {
                if (_manager.CountBuffer() < _manager.Capacity && _manager.Locked == false)
                {
                    _manager.Lock();
                    Produce();
                    Thread.Sleep(_sleepDuration);
                }
            }
        }

        private void Produce()
        {
            _manager.Buffer[_manager.BufferIndex] = "Item " + (_manager.BufferIndex + 1).ToString();
            if (_manager.BufferIndex < _manager.Buffer.Length - 1) { _manager.BufferIndex++; }
            _manager.IsCurrentlyProducing = true;
            ChangedBuffer?.Invoke(true, _manager);
            _manager.Unlock();
        }
    }
}
