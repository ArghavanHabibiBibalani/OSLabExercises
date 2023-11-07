

namespace Exercise4
{
    public class Exercise4Main
    {
        public Exercise4Main()
        {
            Run();
        } 
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("Choose the algorithm:\n1.MFT\n2.MVT");
                switch (Console.ReadLine())
                {
                    case "1":
                        MFT(); break;
                    case "2":
                        MVT(); break;
                    default: continue;
                }
            }
        }
        private void MFT()
        {
            Console.WriteLine("Enter total volume: ");
            var totalVolume = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter page volume: ");
            var page = Convert.ToInt32(Console.ReadLine());
            var count = totalVolume / page;
            var totalInternalExcess = 0;

            PromptInput();
            while (count > 0)
            {
                var rawInput = Console.ReadLine();
                if (rawInput.ToLower().Equals("q")) { break; }
                var input = rawInput.Split(',');
                var inputMemory = Convert.ToInt32(input[1]);
                if (inputMemory > page) { Console.WriteLine($"Process {input[0]} can't fit in a page."); continue; }
                var message = $"Process: {input[0]}, Requiered memory: {input[1]}, Internal excess: {page - inputMemory}";
                totalInternalExcess += page - inputMemory;
                count--;
                Console.WriteLine(message);
            }
            Console.WriteLine($"Total internal excess: {totalInternalExcess}");
            Console.WriteLine($"External excess: {totalVolume % page}");
            Console.WriteLine($"Total excess: {totalInternalExcess + (totalVolume % page) + (count * page)}");
        }
        private void MVT()
        {
            Console.WriteLine("Enter total volume: ");
            var totalVolume = Convert.ToInt32(Console.ReadLine());
            var totalOccupied = 0;

            PromptInput();
            while (true)
            {
                var rawInput = Console.ReadLine();
                if (rawInput.ToLower().Equals("q")) { break; }
                var input = rawInput.Split(',');
                if (Convert.ToInt32(input[1]) + totalOccupied > totalVolume) { Console.WriteLine($"Process {input[0]} can't fit."); continue; }
                totalOccupied += Convert.ToInt32(input[1]);
                Console.WriteLine($"Remaining space: {totalVolume - totalOccupied}");
            }
        }
        private void PromptInput()
        {
            Console.WriteLine("Enter processes in the following format: [Name], [Requiered memory]");
            Console.WriteLine("Enter 'q' to begin calculation.");
        }
    }
}
