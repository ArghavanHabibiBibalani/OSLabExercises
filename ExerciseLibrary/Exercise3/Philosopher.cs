using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exercise3
{
    internal class Philosopher
    {

        private List<Philosopher> _Philosophers;
        private int _indexOfPhilosophers;
        int _sleepTime = 1000;

        public Philosopher(List<Philosopher> philosophers, int indexOfPhilosophers)
        {
            _Philosophers = philosophers;
            _indexOfPhilosophers = indexOfPhilosophers;
            this.Name = string.Format("Philosopher {0}", _indexOfPhilosophers);
            this.EPhiloswopherState = EPhilosopherState.THINKING; 
        }

        public string Name { get; private set; }
        public EPhilosopherState EPhiloswopherState { get; private set; }
        public Fork LeftFork { get; set; }
        public Fork RightChopstick { get; set; }

        public Philosopher LeftPhilosopher
        {
            get
            {
                if (_indexOfPhilosophers == 0)
                    return _Philosophers[_Philosophers.Count - 1];
                else
                    return _Philosophers[_indexOfPhilosophers - 1];
            }
        }

        public Philosopher RightPhilosopher
        {
            get
            {
                if (_indexOfPhilosophers == _Philosophers.Count - 1)
                    return _Philosophers[0];
                else
                    return _Philosophers[_indexOfPhilosophers + 1];
            }
        }

        public void EndOfEating()
        { 
            while (true)
            {
                this.Think();

                if (this.PickUp())
                {
                    this.Eat();
                    this.PutDownLeft();
                    this.PutDownRight();
                }
            }
        }
        private bool PickUp()
        {
            if (Monitor.TryEnter(this.LeftFork))
            {
                Console.WriteLine(this.Name + " picks up left fork.");

                Thread.Sleep(_sleepTime);

                if (Monitor.TryEnter(this.RightChopstick))
                {
                    Console.WriteLine(this.Name + " picks up right fork.");

                    Thread.Sleep(_sleepTime);

                    return true;
                }
                else
                {

                    this.PutDownLeft();
                }
            }

            return false;
        }

        private void Eat()
        {
            Console.WriteLine(this.Name + " eats.");
            Thread.Sleep(_sleepTime);
        }
        private void PutDownLeft()
        {
            Monitor.Exit(this.LeftFork);
            Console.WriteLine(this.Name + " puts down left fork.");
            Thread.Sleep(_sleepTime);
        }
        private void PutDownRight()
        {
            Monitor.Exit(this.RightChopstick);
            Console.WriteLine(this.Name + " puts down right fork.");
            Thread.Sleep(_sleepTime);
        }
        private void Think()
        {
            this.EPhiloswopherState = EPhilosopherState.THINKING;
        }
    }
}

