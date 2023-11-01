

namespace OSLabExercises.Exercise2
{
    internal interface IProcess // Dalam
    {
        public void StartProcess();

        public event Action<bool, IManager> ChangedBuffer;

        public static IProcess Create(ProcessType processType, IManager manager, int sleepDuration) // Factory method
        {
            switch (processType)
            {
                case ProcessType.PRODUCER: return new Producer(manager, sleepDuration);
                case ProcessType.CONSUMER: return new Consumer(manager, sleepDuration);
                default: throw new NotSupportedException();
            }
        }
    }
}
