

namespace Exercise5
{
    internal class Process : IProcess
    {
        private string _name;

        private int _volume;

        public string name { get => _name; private set => _name = value; }

        public int volume { get => _volume; private set => _volume = value; }

        public Process(string name, int volume)
        {
            this.name = name;
            this.volume = volume;
        }
    }
}
