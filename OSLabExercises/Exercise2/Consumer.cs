using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLabExercises.Exercise2
{
    internal class Consumer : IProcess
    {
        private IManager _manager;
        internal Consumer(IManager manager)
        {
            _manager = manager;
        }
        public void StartProcess()
        {
            while (true)
            {
                // Fix counting the buffer's contents
                if (_manager.Buffer.Count() > 0 && _manager.Locked == false)
                {
                    _manager.Lock();
                    Consume();
                    _manager.Unlock();
                }
            }
        }
        
        private void Consume()
        {
            _manager.Buffer[_manager.BufferIndex] = "";
            if (_manager.BufferIndex > 0) { _manager.BufferIndex--; }
            _manager.IsCurrentlyProducing = false;
        }
    }
}
