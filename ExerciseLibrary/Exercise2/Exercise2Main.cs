

namespace Exercise2
{
    public class Exercise2Main
    {
        /// <summary>
        /// ATTENTION: EVERY SINGLE LINE OF CODE IN THIS PROJECT HAS BEEN AND WILL BE WRITTEN ONLY
        /// BY ARGHAVAN HABIBI BIBALANI AND YASHAR POURALI BEHZAD AND NO SUGGESTIONS WERE TAKEN BY
        /// ANOTHER INDIVIDUAL, TEAM OR AI MODEL
        /// /////////////////////////////////////////////////////////////////////////////////////////
        /// Implementation of a solution to the producer-consumer problem with manager, producer and
        /// consumer triod. Each trio uses a boolean variable as its lock which is managed by
        /// the manager and the processes add or remove elements from the shared buffer (array of 
        /// strings) according to their manager's fields. Output is handled by events sent by any
        /// process subscribed to by the Exercise2Main class and printed as some sort of log. 
        /// 
        /// Our goal was to take the exercise an step further and let it be able to handle multiple
        /// trios. We have tried our best to abide by common C# and .NET conventions as well as the 
        /// SOLID design principles.
        /// </summary>
        private static int OutputLineCounter;
        public static void Run(int bufferCapacity ,int sleepDuration)
        {

            var manager = IManager.Create(bufferCapacity);
            var producer = IProcess.Create(ProcessType.PRODUCER, manager, sleepDuration);
            var consumer = IProcess.Create(ProcessType.CONSUMER, manager, sleepDuration);

            producer.ChangedBuffer += OnChangedBuffer;
            consumer.ChangedBuffer += OnChangedBuffer;
            
            var producerThread = new Thread(() => producer.StartProcess());
            var consumerThread = new Thread(() => consumer.StartProcess());

            producerThread.Start();
            consumerThread.Start();

            Console.ReadLine();
        }
        private static void OnChangedBuffer(bool isFromProducer, IManager manager)
        {
            var message = ++OutputLineCounter + ". ";
            if (isFromProducer )
            {
                if (manager.BufferIndex == manager.Capacity - 1) { message += manager.Buffer[manager.BufferIndex] + " was added."; }
                else { message += manager.Buffer[manager.BufferIndex - 1] + " was added."; }
            }
            else
            {
                message += manager.Buffer[manager.BufferIndex] + " was removed.";
            }
            Console.WriteLine(message);
        }
    }
}
