

namespace Exercise2
{
    internal class Consumer : IProcess
    {
        private int _sleepDuration;
        private IManager _manager;
        internal Consumer(IManager manager, int sleepDuration)
        {
            _sleepDuration = sleepDuration;
            _manager = manager;
        }

        public event Action<bool, IManager> ChangedBuffer;

        public void StartProcess()
        {
            while (true)
            {
                if (_manager.CountBuffer() > 0 && _manager.Locked == false)
                {
                    _manager.Lock();
                    Consume();
                    Thread.Sleep(_sleepDuration);
                }
            }
        }
        
        private void Consume()
        {
            _manager.Buffer[_manager.BufferIndex] = "";
            if (_manager.BufferIndex > 0) { _manager.BufferIndex--; }
            _manager.IsCurrentlyProducing = false;
            ChangedBuffer?.Invoke(false, _manager);
            _manager.Unlock();
        }
    }
}
