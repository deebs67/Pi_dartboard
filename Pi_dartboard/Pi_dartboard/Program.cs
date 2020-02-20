using System;
using System.Diagnostics;   // For the Debug.Assert() statements

namespace Pi_dartboard
{
    class Program
    // This is a program to estimate Pi using the 'dartboard' Monte-Carlo method, as described here: https://github.com/deebs67/Pi_dartboard
    {
        static void Main(string[] args)
        {
            Console.Title = "Pi dartboard";
            Console.WriteLine("Pi dartboard");
            Console.WriteLine("============\n");

            Random my_random = new Random(); // See: https://stackoverflow.com/questions/3975290/produce-a-random-number-in-a-range-using-c-sharp

            // Get number of iterations from the user
            Console.WriteLine("Enter required number of Monte-Carlo iterations:");
            long number_of_MC_iterations = Convert.ToInt64( Console.ReadLine() );

            // Information to console
            Console.WriteLine($"\nNumber of Monte-Carlo iterations: {number_of_MC_iterations}");

            // Monte-Carlo main loop
            long hit_dartboard = 0;   // Counter
            long missed_dartboard = 0;   // Counter
            for (int i=0; i< number_of_MC_iterations; i++)
            {
                // Calculate random x-coordinate in range 0.0 <= x < 1.0
                double this_x = my_random.NextDouble();
                Debug.Assert((this_x >= 0.0) && (this_x < 1.0));  // Paranoid sanity check

                // Calculate random y-coordinate in range 0.0 <= y < 1.0
                double this_y = my_random.NextDouble();
                Debug.Assert((this_y >= 0.0) && (this_y < 1.0));  // Paranoid sanity check

                // Calculate squared distance from origin, z, using Pythagoras
                double this_z_squared = this_x * this_x + this_y * this_y;
                Debug.Assert((this_z_squared >= 0.0) && (this_z_squared < 2.0));  // Paranoid sanity check

                // Was it a hit or a miss?
                if (this_z_squared < 1.0) // A hit!
                    hit_dartboard += 1;

                else
                    missed_dartboard += 1;
            }

            // Calculate the hit ratio
            Debug.Assert(hit_dartboard + missed_dartboard == number_of_MC_iterations);    // Paranoid sanity check
            double hit_ratio = hit_dartboard / Convert.ToDouble(number_of_MC_iterations);

            // From the hit_ratio, calculate Pi
            double Pi_estimate = hit_ratio * 4.0;

            // Write results to console
            Console.WriteLine($"Hit ratio: {hit_ratio}, Pi_estimate: {Pi_estimate}");

            // Prompt user to complete
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
