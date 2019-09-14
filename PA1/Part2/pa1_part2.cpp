#include <iostream>
#include <string>
#include <cmath> 
#include <iomanip>
#include <thread>
#include <chrono>


void doCalculation(int &numSquareInt, bool &quit)
{
    // Static variable for keeping track of calculations
    static int numCalcs = 0;
    // Display counter
    int display = 0;
    // Used for the results of the square roots
    const double pi = 3.14159;
    // Peek into the stream
    char peekChar;

    // Display loop 
    while ((display < numSquareInt) && (quit == false))
    {
        std::this_thread::sleep_for (std::chrono::seconds(1));
        peekChar = std::cin.peek();
        if (peekChar == 's')
        {
            quit = true;
            break;
        }
        else
        {
            std::cout << display + 1 << std::endl;
            std::sqrt(pi);
            // Add to display
            ++display;
            
            // Add to calculations
            ++numCalcs;                    
        }
    }
}

int main()
{
    // Boolean for while loop, will keep track if the user wants to take 
    // more square roots.
    bool anotherInt = true;
    // Used for 'stopping' the program
    bool quit = false;
    // Used for getting user input for stopping
    std::string quitOut = "";
    // Used for getting user input
    std::string numSquares = "";
    // Used for calculations
    int numSquareInt = 0;
    // Used for the results of the square roots
    const double pi = 3.14159;

    while (anotherInt)
    {
        std::cout << "Please enter an integer or 'q' to quit." << std::endl;
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
                
                if (std::cin.peek() != 's')
                {
                    doCalculation(numSquareInt, quit);
                }

                if (quit == true)
                {
                    std::cout << quit << std::endl;
                }
                // Display the calculation.
                std::cout << "The square root of PI is " << std::setprecision(3) << std::sqrt(pi) << std::endl;
                
            }
            catch (std::invalid_argument& e)
            {
                std::cerr << "Please only enter integers or 'q'." << std::endl;
            }
        }
    }   
}   
