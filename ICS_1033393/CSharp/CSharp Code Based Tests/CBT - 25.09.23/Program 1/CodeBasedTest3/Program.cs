using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program to find the Sum and the Average points scored by the teams in the IPL.
//Create a Class called Cricket that has a function called Pointscalculation(int no_of_matches)
//that takes no.of matches as input and accepts that many scores from the user.
//The function should then display the Average and Sum of the scores.

namespace CodeBasedTest3
{
    public class Cricket
    {
        
        
        static int totalRuns;
        static double averageRuns;
        static double totalPoints;

        public static void Pointscalculation(int no_of_matches)
        {
            int[] MI = new int[no_of_matches];
            int[] CSK = new int[no_of_matches];
            int[] RCB = new int[no_of_matches];
            int[] SRH = new int[no_of_matches];
            Console.WriteLine("Select A Team To Enter Scores: 1. MI    2. CSK    3. RCB    4. SRH");
            byte choice = Convert.ToByte(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    for (int i = 0; i < no_of_matches; i++)
                    {
                        Console.Write($"Match {i + 1}: ");
                        MI[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Scores Updated");
                    break;
                case 2:
                    for (int i = 0; i < no_of_matches; i++)
                    {
                        Console.Write($"Match {i + 1}: ");
                        CSK[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Scores Updated");
                    break;
                case 3:
                    for (int i = 0; i < no_of_matches; i++)
                    {
                        Console.Write($"Match {i + 1}: ");
                        RCB[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Scores Updated");
                    break;
                case 4:
                    for (int i = 0; i < no_of_matches; i++)
                    {
                        Console.Write($"Match {i + 1}: ");
                        SRH[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    Console.WriteLine("Scores Updated");
                    break;
            }

            Console.WriteLine("Data Available, Please Select A Team To View Stats");
            Console.WriteLine("Select Team: 1. MI    2. CSK    3. RCB    4. SRH");
            byte choiceNew = Convert.ToByte(Console.ReadLine());
            switch (choiceNew)
            {
                case 1: for(int i =0; i<no_of_matches; i++)
                    {
                        totalRuns = MI.Sum();
                        averageRuns = MI.Average();
                        totalPoints = totalRuns * 0.2;
                    }
                    Console.WriteLine($"Total Runs: {totalRuns} \n" +
                        $"Average Per Match: {averageRuns} \n" +
                        $"Points Scored: {totalPoints}");
                    break;
                case 2:
                    for (int i = 0; i < no_of_matches; i++)
                    {
                        totalRuns = CSK.Sum();
                        averageRuns = CSK.Average();
                        totalPoints = totalRuns * 0.2;
                    }
                    Console.WriteLine($"Total Runs: {totalRuns} \n" +
                        $"Average Per Match: {averageRuns} \n" +
                        $"Points Scored: {totalPoints}");
                    break;
                case 3:
                    for (int i = 0; i < no_of_matches; i++)
                    {
                        totalRuns = RCB.Sum();
                        averageRuns = RCB.Average();
                        totalPoints = totalRuns * 0.2;
                    }
                    Console.WriteLine($"Total Runs: {totalRuns} \n" +
                        $"Average Per Match: {averageRuns} \n" +
                        $"Points Scored: {totalPoints}");
                    break;
                case 4:
                    for (int i = 0; i < no_of_matches; i++)
                    {
                        totalRuns = SRH.Sum();
                        averageRuns = SRH.Average();
                        totalPoints = totalRuns * 0.2;
                    }
                    Console.WriteLine($"Total Runs: {totalRuns} \n" +
                        $"Average Per Match: {averageRuns} \n" +
                        $"Points Scored: {totalPoints}");
                    break;
            }
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** WELCOME ***");
            Console.WriteLine("How Many IPL Matches?");
            int numberOfMatches = int.Parse(Console.ReadLine());
            Cricket.Pointscalculation(numberOfMatches);
            Console.Read();
        }
    }
}
