

namespace Exercise6
{
    public class Exercise6Main
    {
        /// <summary>
        /// ATTENTION: EVERY SINGLE LINE OF CODE IN THIS PROJECT HAS BEEN AND WILL BE WRITTEN ONLY
        /// BY ARGHAVAN HABIBI BIBALANI AND YASHAR POURALI BEHZAD AND NO SUGGESTIONS WERE TAKEN BY
        /// ANOTHER INDIVIDUAL, TEAM OR AI MODEL
        /// </summary>
        /// /// /////////////////////////////////////////////////////////////////////////////////////////
        /// Implementation of FIFO page management simulation algorithm
        public static void Run()
        {
            Console.WriteLine("Enter the number of pages: ");
            var pageCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of processes:");
            var inputCount = Convert.ToInt32(Console.ReadLine());
            var inputArray = new string[inputCount];

            Console.WriteLine("Enter the names of the processes: ");
            for (int i = 0; i <  inputCount; i++)
            {
                inputArray[i] = Console.ReadLine();
            }

            var manager = new PageManager(pageCount);
            manager.StartProccessing(inputArray);
        }
    }
}
