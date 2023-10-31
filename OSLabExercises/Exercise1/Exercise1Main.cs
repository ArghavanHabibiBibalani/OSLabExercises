

namespace Exercise1
{
    public class Exercise1Main
    {
        static bool takeInput = true;
        static Queue<Process> ProcessQueue = new Queue<Process>();
        static Queue<Process> OutputQueue = new Queue<Process>();

        static int turn = 0;
        static int totalWaitingTime = 0;
        static float averageWaitingTime = 0f;
        static int totalTurnAroundTime = 0;
        static float averageTurnAroundTime = 0f;

        public Exercise1Main() { Run(); }

        private void Run()
        {
            TakeInput();

            if (IsEmpty())
            {
                Console.WriteLine("No processes to run");
                return;
            }

            ProcessQueue = new Queue<Process>(ProcessQueue.OrderBy(p => p.EntryTime)); // Sort processes by entry time

            RunCalculations();

            PrintResults();
        }

        // Take all the inputs at once. Keep taking input untill the user enters 'q'.
        private static void TakeInput()
        {
            Console.WriteLine("Enter process name, burst time and entry time ([Name],[Burst time],[Entry time])\nEnter 'Q' to continue: ");

            while (takeInput)
            {
                var input = Console.ReadLine();
                if (input.ToLower().Equals("q")) { takeInput = false; return; }

                string[] inputArray = input.Split(',');

                ProcessQueue.Enqueue(new Process(inputArray[0], Convert.ToInt32(inputArray[1]), Convert.ToInt32(inputArray[2])));
            }
        }

        private static bool IsEmpty()
        {
            return ProcessQueue.Count == 0;
        }

        private static void RunCalculations()
        {
            while (ProcessQueue.Count > 0)
            {
                while (ProcessQueue.Peek().EntryTime > turn) { turn++; } // Ensure every blank time block is counted.

                var currentProcess = ProcessQueue.Dequeue();

                currentProcess.StartTime = turn;

                for (int n = 0; n < currentProcess.BurstTime; n++) { turn++; }

                currentProcess.WaitingTime = currentProcess.StartTime - currentProcess.EntryTime;

                totalWaitingTime += currentProcess.WaitingTime;

                currentProcess.TurnAroundTime = turn - currentProcess.EntryTime;

                totalTurnAroundTime += currentProcess.TurnAroundTime;

                OutputQueue.Enqueue(currentProcess);
            }

            averageWaitingTime = (float)totalWaitingTime / OutputQueue.Count;

            averageTurnAroundTime = (float)totalTurnAroundTime / OutputQueue.Count;
        }

        private static void PrintResults()
        {

            Console.WriteLine(string.Format("{0,-10}{1,-10}{2,-10}", "Name", "Waiting", "Turn-around"));

            foreach (var process in OutputQueue)
            {
                Console.WriteLine(string.Format("{0,-10}{1,-10}{2,-10}", process.Name, process.WaitingTime.ToString(), process.TurnAroundTime.ToString()));
            }

            Console.WriteLine($"Average waiting time: {averageWaitingTime}");
            Console.WriteLine($"Average turn-around time: {averageTurnAroundTime}");
        }
    }
}