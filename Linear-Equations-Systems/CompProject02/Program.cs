using System;

namespace CompProject02
{
    class Program
    {
        static void Main(string[] args)
        {
            string whileValue;
            do
            {
                Console.Clear();
                Console.WriteLine("Fill in the blanks with linear equations in augmented matrix notation: " +
                                    "\na1 a2... aN d, where a1..N are coefficients and d is a constant.");
                Console.WriteLine("Space divides them to complete entering equations, type END.\n");

                RunEqu RunEqu = new RunEqu();
                int NumbEqu = 1;

                try
                {
                    while (true)
                    {
                        Console.Write($"Eq #{NumbEqu}: ");
                        string get_input = Console.ReadLine();
                        if (get_input.ToLower() == "end")
                        {
                            Console.WriteLine("\nThe equations are:");
                            break;
                        }
                        RunEqu.AddEquation(new MainEquation(get_input));
                        NumbEqu++;
                    }

                    RunEqu.EquPrint();

                    Console.WriteLine("\nAnd solutions are: ");
                    RunEqu.PrintSolution();
                }

                catch (Exception Except)
                {
                    Console.WriteLine(Except.Message + " Please try again");
                }

                Console.WriteLine("Please type any to continue.. or exit");
                whileValue = Console.ReadLine();
              
            } while (whileValue != "exit");
            
        }
    }
}
