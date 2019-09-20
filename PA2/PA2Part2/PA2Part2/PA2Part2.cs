using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace PA2Part2
{
    class PA2Part2
    {
        void doCalculation(int numSquareInt, bool quit)
        {
            // Display counter
            int display = 0;
            // Used for the results of the square roots
            const double pi = 3.14159;
            // Look into key press
            ConsoleKeyInfo cki;

            // Display loop 
            while ((display < numSquareInt) && (quit == false))
            {
                //std::this_thread::sleep_for(std::chrono::seconds(1));
                Thread.Sleep(1000);

                // This will check to see if the user enters something while
                // the console is outputting. If they enter 's' then the program 
                // will stop
                if (Console.KeyAvailable)
                {
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.S)
                    {
                        quit = true;
                        break;
                    }
                }
                else
                {
                    //std::cout << display + 1 << std::endl;
                    Console.WriteLine(display + 1);
                    Math.Sqrt(pi);
                    // Add to display
                    ++display;
                }
            }
        }
        static void Main(string[] args)
        {
            // Boolean for while loop, will keep track if the user wants to take 
            // more square roots.
            bool anotherInt = true;
            // Used for 'stopping' the program
            bool quit = false;
            // Used for getting user input for stopping
            string quitOut = "";
            // Used for getting user input
            string numSquares = "";
            // Used for calculations
            int numSquareInt = 0;
            // Used for the results of the square roots
            const double pi = 3.14159;

            PA2Part2 program = new PA2Part2();

            while (anotherInt)
            {
                System.Console.WriteLine("Please enter an integer or 'q' to quit.");
                numSquares = Console.ReadLine();

                if (numSquares == "q")
                {
                    anotherInt = false;
                }
                else
                {
                    try
                    {
                        // Convert user input to int
                        numSquareInt = Convert.ToInt32(numSquares);
                        System.Console.WriteLine("You have asked to compute the square root of PI " + numSquareInt + " times: ");

                        program.doCalculation(numSquareInt, quit);

                        // Display the calculation.
                        System.Console.WriteLine("The square root of PI is " + Math.Round(Math.Sqrt(pi), 2, MidpointRounding.ToEven));
                    }
                    catch (FormatException)
                    {
                        System.Console.WriteLine("Please only enter integers or 'q' ");
                    }
                }
            }
        }
    }
}
