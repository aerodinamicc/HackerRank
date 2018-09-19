using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStops
{
    public class Street
    {
        static void Main()
        {
            int busStopsCount = Convert.ToInt32(Console.ReadLine());

            double[] busStops = Array.ConvertAll(Console.ReadLine().Split(' '), xTemp => double.Parse(xTemp));
            var wv = Console.ReadLine().Split(' ').Select(x => double.Parse(x)).ToList();
            double busSpeed = wv[0];
            double busFreq = wv[1];

            int peopleCount = Convert.ToInt32(Console.ReadLine());

            var stringInput = new List<string>();

            for (int i = 0; i < peopleCount; i++)
            {
                stringInput.Add(Console.ReadLine());
            }

            var result = MinimumTimeToEnd(busStops, busSpeed, busFreq, stringInput);

            result.Length -= 1;
            Console.WriteLine(result.ToString());
        }

        public static StringBuilder MinimumTimeToEnd(double[] busStops, double busSpeed, double busFreq, List<string> people)
        {
            var builder = new StringBuilder();

            for (int i = 0; i < people.Count; i++)
            {
                var inputPerson = people[i].Split(' ').ToList();
                var startPoint = int.Parse(inputPerson[0]);
                var startTime = double.Parse(inputPerson[1]);
                var personSpeed = double.Parse(inputPerson[2]);

                //if he live on the end of the street
                if ((int)startPoint == 100)
                {
                    builder.AppendLine(0.ToString());
                    continue;
                }
                
                double personWalking = double.MaxValue;
                double livesOnAStop = double.MaxValue;
                double goesToStopBefore = double.MaxValue;
                double goesToStopAfter = double.MaxValue;

                //if he walks the distance
                if (personSpeed > 0)
                {
                    personWalking = ((100 - startPoint) / personSpeed) + startTime;
                }

                //if he lives on a bus stop
                if (busStops.Contains(startPoint))
                {
                    var missedTheBusBy = startTime + (startPoint/busSpeed) % busFreq;
                    if (missedTheBusBy == 0)
                    {
                        livesOnAStop = (100 - startPoint) / busSpeed;
                    }
                    else
                    {
                        livesOnAStop = (busFreq - missedTheBusBy) + (100 - startPoint) / busSpeed;
                    }
                }
                else
                {
                    //two closest stops - one before and one after
                    var stopBefore = busStops.LastOrDefault(x => x < startPoint);
                    var stopAfter = busStops.FirstOrDefault(x => x > startPoint);
                    if (stopBefore != null)
                    {
                        var personReachesTheStopIn = startTime + (startPoint - stopBefore)/personSpeed;
                        var timeToWait = (stopBefore / busSpeed + busFreq) % personReachesTheStopIn;
                        if (timeToWait == 0)
                        {
                            goesToStopBefore = personReachesTheStopIn + (100 - stopBefore) / busSpeed;
                        }
                        else
                        {
                            goesToStopBefore = personReachesTheStopIn + timeToWait + (100 - stopBefore) / busSpeed;
                        }
                    }

                    if (stopAfter != null)
                    {
                        var personReachesTheStopIn = startTime + (stopAfter - startPoint) / personSpeed;
                        var timeToWait = (stopAfter / busSpeed + busFreq) % personReachesTheStopIn;
                        if (timeToWait == 0)
                        {
                            goesToStopAfter = personReachesTheStopIn + (100 - stopAfter) / busSpeed;
                        }
                        else
                        {
                            goesToStopAfter = personReachesTheStopIn + timeToWait + (100 - stopAfter) / busSpeed;
                        }
                    }
                }

                var result = Math.Min(Math.Min(personWalking, livesOnAStop), Math.Min(goesToStopBefore, goesToStopAfter));
                builder.AppendLine($"{result:f10}");
            }

            return builder;
        }
    }
}
