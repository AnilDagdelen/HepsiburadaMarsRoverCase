using System;
using System.Collections.Generic;
using System.Linq;

namespace HepsiBuradaCase
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter board size :");
                    string boardSize = Console.ReadLine().Trim();

                    List<int> XAndY = boardSize.Split(' ').ToList().Select(x => Convert.ToInt32(x)).ToList();

                    if (XAndY.Count != 2 || XAndY.Any(x => x < 0))
                    {
                        //Rover class also checks validity
                        throw new Exception("Invalid board input.");
                    }

                    while (true)
                    {
                        try
                        {

                            Console.WriteLine("Please enter : RoverX RoverY HeadingDirection(N,S,E,W)");
                            List<string> roverStartingStats = Console.ReadLine().Trim().Split(' ').ToList();

                            if (roverStartingStats.Count != 3)
                            {
                                //Rover class also checks validity
                                throw new Exception("Invalid rover input.");
                            }
                            int startingX = Convert.ToInt32(roverStartingStats[0]);
                            int startingY = Convert.ToInt32(roverStartingStats[1]);

                            CardinalDirections direction = (CardinalDirections)Enum.Parse(typeof(CardinalDirections), roverStartingStats[2]);

                            Console.WriteLine("Please enter comands :");
                            string roverCommands = Console.ReadLine();

                            Rover rover = new Rover(startingX, startingY, direction, XAndY[0], XAndY[1]);

                            Console.WriteLine(rover.ApplyCommands(roverCommands));

                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
