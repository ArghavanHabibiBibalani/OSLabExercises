
using System.Diagnostics;

namespace Exercise1
{
    internal class Program
    {
        static bool takeInput = true;
        static Queue<Process> ProcessQueue = new Queue<Process>();
        
        static int turn = 0;
        static Stopwatch stopWatch = new Stopwatch();
        static int totalWaitingTime = 0;
        static float averageWaitingTime = 0f;
        static int totalTurnAroundTime = 0;
        static float averageTurnAroundTime = 0f;

        static void Main(string[] args)
        {
            TakeInput();

            if (IsEmpty())
            {
                Console.WriteLine("No processes to run");
                return;
            }

            ProcessQueue.OrderBy(p => p.EntryTime); // Sort processes by entry time

            RunCalculations();

            PrintResults();
        }

        private static void TakeInput()
        {
            Console.WriteLine("Enter process name, burst time and entry time ([Name],[Burst time],[Entry time])\nEnter 'Q' to continue: ");

            while (takeInput)
            {
                if (Console.ReadLine().ToLower().Equals("q")) { takeInput = false; break; }

                string[] input = Console.ReadLine().Split(",");

                ProcessQueue.Enqueue(new Process(input[0], Convert.ToInt32(input[1]), Convert.ToInt32(input[2])));

            }
        }

        private static bool IsEmpty()
        {
            return ProcessQueue.Peek() == null;
        }

        private static void RunCalculations()
        {
            stopWatch.Start();

            foreach (var currentProcess in ProcessQueue)
            {
                currentProcess.StartTime = turn;

                for (int n = 0; n < currentProcess.BurstTime; n++) { turn++; }

                currentProcess.WaitingTime = currentProcess.StartTime - currentProcess.EntryTime;

                totalWaitingTime += currentProcess.WaitingTime;

                currentProcess.TurnAroundTime = turn - currentProcess.EntryTime;

                totalTurnAroundTime += currentProcess.TurnAroundTime;
            }

            stopWatch.Stop();

            averageWaitingTime = totalWaitingTime / ProcessQueue.Count;

            averageTurnAroundTime = totalTurnAroundTime / ProcessQueue.Count;
        }

        private static void PrintResults()
        {

            Console.WriteLine(string.Format("{0,-10}{1,-10}{2,-10}", "Name", "Waiting", "Turn-around"));

            foreach (Process process in ProcessQueue)
            {
                Console.WriteLine(string.Format("{0,-10}{1,-10}{2,-10}", process.Name, process.WaitingTime.ToString(), process.TurnAroundTime.ToString()));
            }

            Console.WriteLine($"Average waiting time: {averageWaitingTime}");
            Console.WriteLine($"Average turn-around time: {averageTurnAroundTime}");
            Console.WriteLine($"Execution time: {stopWatch.Elapsed}");
        }
    }
}