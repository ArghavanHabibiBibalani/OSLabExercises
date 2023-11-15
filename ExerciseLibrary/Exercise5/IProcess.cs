

namespace Exercise5
{
    internal interface IProcess
    {
        public string name { get; }
        public int volume { get; }

        public static IProcess Create(string name, int volume)
        {
            return new Process(name, volume);
        }
    }
}
