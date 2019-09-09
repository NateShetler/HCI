#include <iostream>
#include <thread>
#include <chrono>
#include <string>
#include <cmath>
#include <iomanip>
#define PI 3.14159

// This will calculate the square root of PI.
void doCalculation()
{
    std::sqrt(PI);
}

// This will be used as the input thread.
void input_func(bool &quit, bool &anotherInt, int &display, bool &stop, int &numCalcs)
{
    // For converting input to integer
    int  numSquareInt = 0;
    
    while(anotherInt)
    {
        // For getting the user input
        std::string input;

        std::cin >> input;

        if (input == "q")
        {
            anotherInt = false;
            quit = true;
        }
        else if(input == "s")
        {
            quit = true;
            stop = true;
        }
        else
        {
            try
            {
                // Convert user input to int
                numSquareInt = std::stoi(input);
                std::cout << "You have asked to compute the square root of PI " << numSquareInt << " times:" << std::endl;
                display = numSquareInt;

                // Add to numCalcs
                ++numCalcs;
            }
            catch (std::invalid_argument& e)
            {
                std::cerr << "Please only enter integers or 'q'." << std::endl;
            }
        }
    }
}

// This will be used as the output thread.
void output_func(bool &quit, bool &anotherInt, int &display, bool &stop, int &numCalcs)
{   
    // Used as the iterator
    int loopInt = 0;

    // Keep track if the user has entered a number before
    static int keepTrack = 0;

    while (anotherInt)
    {
        std::cout << "Please enter an integer or ‘q’ to quit." << std::endl;
       
        std::this_thread::sleep_for (std::chrono::seconds(5));

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
            while((loopInt < display) && !quit)
            {
                // Output how many times
                std::cout << loopInt + 1 << std::endl;

                // Call the calculation
                doCalculation();

                // Add to display
                ++loopInt; 

                // To slow down the process a bit
                std::this_thread::sleep_for (std::chrono::seconds(1));
            }

            // Add to keep track of how many calcualtions have been done
            ++keepTrack;

            if (quit == false)
            {
                // Display the calculation.
                std::cout << "The square root of PI is " << std::setprecision(3) << std::sqrt(PI) << std::endl;
                std::cout << std::endl;
            }
        }   
    }  
}

int main()
{
    // more square roots.
    bool anotherInt = true;

    // Keeping track of if the user tries to stop a computation
    bool stop = false;

    bool stopRepeat = false;
    
    // Used for getting user input
    std::string numSquares = "";

    // Used for figuring out how many numbers to display
    int display = 0;

    // For the display loop
    bool quit = false;

    // Used for counting the calculations.
    static int numCalcs = 0;

    // The input and output threads
    std::thread inp(input_func, std::ref(quit), std::ref(anotherInt), std::ref(display), std::ref(stop), std::ref(numCalcs));
    std::thread outp(output_func, std::ref(quit), std::ref(anotherInt), std::ref(display), std::ref(stop), std::ref(numCalcs));

    // Join the threads together.
    outp.join();
    inp.join();

    std::cout << "The program has ended." << std::endl;

    return 0;
}
