using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA2Part1
{
    class PA2Part1
    {
        static void Main(string[] args)
        {
            // Boolean for while loop, will keep track if the user wants to take 
            // more square roots.
            bool anotherInt = true;
            // Used for getting user input
            string numSquares = "";
            // Used for calculations
            int numSquareInt = 0;
            // Used for the results of the square roots
            const double pi = 3.14159;

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
                        System.Console.WriteLine("You have asked to compute the square root of PI", numSquareInt, " times: ");
                        
                        // Display loop 
                        for (int i = 0; i < numSquareInt; ++i)
                        {
                            System.Console.WriteLine(i + 1);
                            Math.Sqrt(pi);
                        }
                        
                        // Output the square root of PI
                        System.Console.WriteLine("The square root of PI is ", Math.Round(Math.Sqrt(pi), 2, MidpointRounding.ToEven));

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
