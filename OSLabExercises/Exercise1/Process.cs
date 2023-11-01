

namespace OSLabExercises.Exercise1
{
    internal class Process
    {
        public string Name;
        public int BurstTime;
        public int EntryTime;

        public int StartTime;

        public int WaitingTime;
        public int TurnAroundTime;

        public Process(string name, int burstTime, int entryTime)
        {
            Name = name;
            BurstTime = burstTime;
            EntryTime = entryTime;
        }
    }
}
