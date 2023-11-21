

using System.Buffers;

namespace Exercise5
{
    public class Exercise5Main
    {
        private static IMemoryManager _memoryManager;
        public static void Run()
        {
            Console.WriteLine("Enter the total memory slots: ");
            var totalMemorySlots = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the number of fragments: ");
            var memroyFragments = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            _memoryManager = IMemoryManager.Create(totalMemorySlots, memroyFragments);

            while (true)
            {
                Console.Clear();

                DisplayMenu();

                var input = Convert.ToInt32(Console.ReadLine());

                ExecuteInput(input);
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Enter the desired number: ");
            Console.WriteLine("1. Allocate memory with \"First fit\"");
            Console.WriteLine("2. Allocate memory with \"Best fit\"");
            Console.WriteLine("3. Allocate memory with \"Worst fit\"");
            Console.WriteLine("4. Deallocate memory by name");
            Console.WriteLine("5. Display memory");
        }

        private static void ExecuteInput(int input)
        {
            Console.Clear();

            var name = "";
            var volume = 0;

            IProcess currentInputProcess;

            

            if (input < 4)
            {
                Console.WriteLine("Enter process name: ");
                name = Console.ReadLine();

                if (_memoryManager.processIndexPairs.Where(pair => pair.Key.name.Equals(name)).ToList().Count != 0)
                {
                    Console.WriteLine("A process with that name already exists...");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("Enter process volume; ");
                volume = Convert.ToInt32(Console.ReadLine());

                currentInputProcess = IProcess.Create(name, volume);

                switch (input)
                {
                    case 1:
                        _memoryManager.AllocateFirstFit(currentInputProcess); break;
                    case 2:
                        _memoryManager.AllocateBestFit(currentInputProcess); break;
                    default:
                        _memoryManager.AllocateWorstFit(currentInputProcess); break;
                }
            }
            else
            {
                if (input == 4)
                {
                    Console.WriteLine("Enter process name: ");
                    name = Console.ReadLine();
                    _memoryManager.Deallocate(name);
                }
                else
                {
                    _memoryManager.DisplayMemory();
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
