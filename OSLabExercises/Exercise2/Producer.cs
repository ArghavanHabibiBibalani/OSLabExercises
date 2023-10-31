using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLabExercises.Exercise2
{
    internal class Producer : IProcess
    {
        private IManager _manager;

        internal Producer(IManager manager)
        {
            _manager = manager;
        }
        public void StartProcess()
        {
            while(true)
            {
                // Fix counting the buffer's contents
                if (_manager.Buffer.Count() < _manager.Buffer.Length && _manager.Locked == false)
                {
                    _manager.Lock();
                    Produce();
                    _manager.Unlock();
                }
            }
        }

        private void Produce()
        {
            _manager.Buffer[_manager.BufferIndex] = "Item " + _manager.BufferIndex + 1;
            if (_manager.BufferIndex < _manager.Buffer.Length - 1) { _manager.BufferIndex++; }
            _manager.IsCurrentlyProducing = true;
        }
    }
}
