using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantReviews.Library;
using NLog;
namespace RestaurantReviews.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;
            bool execute = true;
            string restName;
            MethodCalls.SetLibRest();
            Logger log = LogManager.GetCurrentClassLogger();
            log.Info("Starting application");
            while (execute)
            {
                Console.WriteLine("Press the number corresponding to the option you want:");
                Console.WriteLine("1. Display the top 3 restaurants by average rating.");
                Console.WriteLine("2. Display all restaurants.");
                Console.WriteLine("3. Display details of a restaurant.");
                Console.WriteLine("4. Display all the reviews of a restaurant");
                Console.WriteLine("5. Search for a restaurant.");
                Console.WriteLine("6. Quit Application");
                x = Convert.ToInt32(Console.ReadLine());
                while (x>6 || x<1)
                {
                    Console.WriteLine("That is an invalid input. Please try again: ");
                    x = Convert.ToInt32(Console.ReadKey());
                }
                switch(x)
                {
                    case 1 :
                        {
                            MethodCalls.Topthree();
                            break;
                        }
                    case 2 :
                        {
                            Console.WriteLine("Press the number corresponding to the method of sorting the restaurants");
                            Console.WriteLine("1. Sort Alphabetically");
                            Console.WriteLine("2. Sort Reverse Alphabetically");
                            Console.WriteLine("3. Sort by size of restaurant name");
                            Console.WriteLine("4. Sort by Average Rating Descending");
                            x = Convert.ToInt32(Console.ReadLine());
                            while (x > 5 || x < 1)
                            {
                                Console.WriteLine("That is an invalid input. Please try again: ");
                                x = Convert.ToInt32(Console.ReadLine());
                            }
                            MethodCalls.chooseSort(x);
                            break;
                        }
                    case 3 :
                        {
                            Console.WriteLine("Choose the method of selecting a restaurant");
                            Console.WriteLine("1. By Name");
                            Console.WriteLine("2. By ID");
                            x = Convert.ToInt32(Console.ReadLine());
                            while (x > 2 || x < 1)
                            {
                                Console.WriteLine("That is an invalid input. Please try again: ");
                                x = Convert.ToInt32(Console.ReadLine());
                            }
                            if (x == 1)
                            {
                                Console.WriteLine("Enter the name of the restaurant");
                                restName = Console.ReadLine();
                                MethodCalls.returnRestByName(restName);
                            }
                            if (x == 2)
                            {
                                Console.WriteLine("Enter the ID of the restaurant");
                                x = Convert.ToInt32(Console.ReadLine());
                                MethodCalls.returnRestById(x);
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Choose the method of selecting a restaurant");
                            Console.WriteLine("1. By Name");
                            Console.WriteLine("2. By ID");
                            x = Convert.ToInt32(Console.ReadLine());
                            while (x > 2 || x < 1)
                            {
                                Console.WriteLine("That is an invalid input. Please try again: ");
                                x = Convert.ToInt32(Console.ReadLine());
                            }
                            if (x == 1)
                            {
                                Console.WriteLine("Enter the name of the restaurant");
                                restName = Console.ReadLine();
                                MethodCalls.getReviewsByName(restName);
                            }
                            if (x == 2)
                            {
                                Console.WriteLine("Enter the ID of the restaurant");
                                x = Convert.ToInt32(Console.ReadLine());
                                MethodCalls.MCReviewsById(x);
                            }
                            break;
                        }
                    case 5 :
                        {
                            Console.WriteLine("Enter the string to search");
                            restName = Console.ReadLine();
                            MethodCalls.searchRestName(restName);
                            break;
                        }
                    case 6 :
                        {
                            log.Info(x);
                            execute =false;
                            break;
                        }
                }
            }            
        }
    }
}
