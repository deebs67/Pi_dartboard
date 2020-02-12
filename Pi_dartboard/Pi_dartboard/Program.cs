using System;

namespace Pi_dartboard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Pi dartboard";
            Console.WriteLine("Pi dartboard");
            Console.WriteLine("============\n");

            Random my_random = new Random(); // See: https://stackoverflow.com/questions/3975290/produce-a-random-number-in-a-range-using-c-sharp
            //long number_of_MC_iterations = 10000000;
            long hit_dartboard = 0;
            long missed_dartboard = 0;
            double rDouble, this_x, this_y, this_z_squared;

            // Get number of iterations from the user
            Console.WriteLine("Enter required number of Monte-Carlo iterations:");
            long number_of_MC_iterations = Convert.ToInt64( Console.ReadLine() );

            // Information to console
            Console.WriteLine($"\nNumber of Monte-Carlo iterations: {number_of_MC_iterations}");

            // Monte-Carlo main loop
            for (int i=0; i< number_of_MC_iterations; i++)
            {
                // Calculate random x-coordinate in range 0.0 <= x < 1.0
                rDouble = my_random.NextDouble();
                this_x = rDouble;

                // Calculate random y-coordinate in range 0.0 <= y < 1.0
                rDouble = my_random.NextDouble();
                this_y = rDouble;

                // Calculate squared distance from origin, z, using Pythagoras
                this_z_squared = this_x * this_x + this_y * this_y;

                // Was it a hit or a miss?
                if (this_z_squared < 1.0) // A hit!
                    hit_dartboard += 1;

                else
                    missed_dartboard += 1;
            }

            // TODO:
            // - Assert that 0.0 <= each x and y < 1.0
            // - Assert that hits+misses = MC_iterations

            // Calculate the hit ratio
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
