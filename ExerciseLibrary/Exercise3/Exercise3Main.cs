using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class Exercise3Main
    {
        /// <summary>
        /// ATTENTION: EVERY SINGLE LINE OF CODE IN THIS PROJECT HAS BEEN AND WILL BE WRITTEN ONLY
        /// BY ARGHAVAN HABIBI BIBALANI AND YASHAR POURALI BEHZAD AND NO SUGGESTIONS WERE TAKEN BY
        /// ANOTHER INDIVIDUAL, TEAM OR AI MODEL
        /// </summary>
        public static void Run()
        {
            
            var philosophers = InitializePhilosophers();

            Console.WriteLine("Start");

            var philosopherList = new List<Thread>();
            foreach (var philosopher in philosophers)
            {
                var philosopherThread = new Thread(new ThreadStart(philosopher.EndOfEating));
                philosopherList.Add(philosopherThread);
                philosopherThread.Start();
            }

            foreach (var thread in philosopherList)
            {
                thread.Join();
            }
        }

        private static List<Philosopher> InitializePhilosophers()
        {
            Console.WriteLine("Enter Philosophers number: ");

            int philosophersNumber = int.Parse(Console.ReadLine());
            
            var philosophers = new List<Philosopher>(philosophersNumber);

            for (int count = 0; count < philosophersNumber; count++)
            {
                philosophers.Add(new Philosopher(philosophers, count));
            }

            foreach (var philosopher in philosophers)
            {
                philosopher.LeftFork = philosopher.LeftPhilosopher.RightChopstick ?? new Fork();

                philosopher.RightChopstick = philosopher.RightPhilosopher.LeftFork ?? new Fork();
            }

            return philosophers;
        }
    }
}

        

    
