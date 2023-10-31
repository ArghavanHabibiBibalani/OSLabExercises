using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSLabExercises.Exercise2
{
    internal interface IProcess
    { 
        public void StartProcess();

        public IProcess Create(ProcessType processType, IManager manager)
        {
            switch (processType)
            {
                case ProcessType.PRODUCER: return new Producer(manager);
                case ProcessType.CONSUMER: return new Consumer(manager);
                default: throw new NotSupportedException();
            }
        }
    }
}
