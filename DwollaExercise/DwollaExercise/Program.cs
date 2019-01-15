using System;
using System.Threading.Tasks;

// Kristin Lau
// 11 January 2019
// Technical Exercise - Use OpenWeatherMap API to retrieve temperature in user specified city

namespace DwollaExercise
{
    class Program
    {
        static void Main()
        {
            string output;

            //Declare variables
            string strUserLocation;

            //Prompt user for city name
            Console.Write("Enter your city name: ");
            strUserLocation = Console.ReadLine();

            try
            {
                API api = new API(strUserLocation);

                //Retrieve data from API
                Task<string> callTask = Task.Run(() => api.CallWebAPI());
                callTask.Wait();

                //Get the result
                output = callTask.Result;
                Console.WriteLine(output);

                if (output == "Invalid city name. \n")
                {
                    Main();
                }

                else
                {
                    //Quit application
                    Console.WriteLine("Press the ENTER key to quit the application.");
                    Console.ReadLine();
                }
            }

            catch (Exception)
            {
                Console.WriteLine("Invalid city name. \n");
                Main();
            }
        }
    }
}
