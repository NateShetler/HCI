using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PA2Part3
{
    class PA2Part3
    {
        // Used for counting the calculations.
        static int numCalcs = 0;

        // Keep track if the user has entered a number before
        static int keepTrack = 0;

        // This will calculate the square root of PI.
        static void DoCalculation()
        {
            Math.Sqrt(3.14159);
        }

        // This will be used as the input thread.
        static void InputFunc(ref bool quit, ref bool anotherInt, ref int display, ref bool stop, ref int numCalcs)
        {
            // For converting input to integer
            int numSquareInt = 0;

            while (anotherInt)
            {
                // For getting the user input
                string input;

                //std::cin >> input;
                input = Console.ReadLine();

                if (input == "q")
                {
                    anotherInt = false;
                    quit = true;
                }
                else if (input == "s")
                {
                    quit = true;
                    stop = true;
                }
                else
                {
                    try
                    {
                        // Convert user input to int
                        numSquareInt = Convert.ToInt32(input);
                        System.Console.WriteLine("You have asked to compute the square root of PI " + numSquareInt + " times: ");
                        display = numSquareInt;

                        // Add to numCalcs
                        ++numCalcs;
                    }
                    catch (FormatException)
                    {
                        System.Console.WriteLine("Please only enter integers or 'q'.");
                    }
                }
            }
        }

        // This will be used as the output thread.
        static void OutputFunc(ref bool quit, ref bool anotherInt, ref int display, ref bool stop, ref int numCalcs)
        {
            // Used as the iterator
            int loopInt = 0;

            while (anotherInt)
            {
                System.Console.WriteLine("Please enter an integer or 'q' to quit.");

                // This is to give the user time to enter something
                Thread.Sleep(4000);

                // Reset loopInt
                loopInt = 0;

                // If the user stopped the computation before, then reset the booleans
                if (stop && quit)
                {
                    stop = false;
                    quit = false;
                }

                // Only display if there is another calculation to be made.
                if (keepTrack < numCalcs)
                {
                    // Display how many times the calculation happens
                    while ((loopInt < display) && !quit)
                    {
                        // Output how many times
                        System.Console.WriteLine(loopInt + 1);

                        // Call the calculation
                        DoCalculation();

                        // Add to display
                        ++loopInt;

                        // To slow down the process a bit
                        Thread.Sleep(1000);
                    }

                    // Add to keep track of how many calcualtions have been done
                    ++keepTrack;

                    if (quit == false)
                    {
                        // Display the calculation.
                        System.Console.WriteLine("The square root of PI is " + Math.Round(Math.Sqrt(3.14159), 2, MidpointRounding.ToEven));
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            // more square roots.
            bool anotherInt = true;

            // Keeping track of if the user tries to stop a computation
            bool stop = false;

            // Used for figuring out how many numbers to display
            int display = 0;

            // For the display loop
            bool quit = false;

            // Used for counting the calculations.
            int numCalcs = 0;

            // The input and output threads
            //std::thread inp(input_func, std::ref (quit), std::ref (anotherInt), std::ref (display), std::ref (stop), std::ref (numCalcs));
            //std::thread outp(output_func, std::ref (quit), std::ref (anotherInt), std::ref (display), std::ref (stop), std::ref (numCalcs));
            Thread inThread = new Thread(() => InputFunc(ref quit, ref anotherInt, ref display, ref stop, ref numCalcs));
            Thread outThread = new Thread(() => OutputFunc(ref quit, ref anotherInt, ref display, ref stop, ref numCalcs));

            inThread.Start();
            outThread.Start();

            // Join the threads together.
            inThread.Join();
            outThread.Join();

            System.Console.WriteLine("The program has ended.");
        }
    }
}
