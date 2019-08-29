#include <iostream>
#include <string>
#include <cmath> 
#include <iomanip>

int main()
{
    // Boolean for while loop, will keep track if the user wants to take 
    // more square roots.
    bool anotherInt = true;
    // Used for getting user input
    std::string numSquares = "";
    // Used for calculations
    int numSquareInt = 0;
    // Used for the results of the square roots
    const double pi = M_PI;

    while (anotherInt)
    {
        std::cout << "Please enter an integer or ‘q’ to quit." << std::endl;
        std::cin >> numSquares;
        std::cout << "\n";

        if (numSquares == "q")
        {
            anotherInt = false;
        }
        else
        {
            try
            {
                // Convert user input to int
                numSquareInt = std::stoi(numSquares);

                std::cout << "You have asked to compute the square root of PI " << numSquareInt << " times:" << std::endl;
                // Display loop 
                for (int i = 0; i < numSquareInt; ++i)
                {
                    std::cout << i + 1 << std::endl;
                    std::sqrt(pi);
                }

                std::cout << "The square root of PI is " << std::setprecision(3) << std::sqrt(pi) << std::endl;

            }
            catch (std::invalid_argument& e)
            {
                std::cerr << "Please only enter integers or 'q'." << std::endl;
            }
        }
    }
}