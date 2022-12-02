using System;
using System.Collections;
using System.Collections.Generic;

namespace Advent2022
{
    class Program
    {
        static void Main(string[] args)
        {
            var lstElfCals = new List<int>();
            var currentElf = 0;
            // Read each line of the file into a string array. Each element
                // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(@"input");
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    currentElf += Int32.Parse(line);
                }
                else
                {
                    lstElfCals.Add(currentElf);
                    currentElf = 0;
                }
            }
            lstElfCals.Sort();
            lstElfCals.Reverse();
            
            Console.WriteLine(lstElfCals[0]+lstElfCals[1]+lstElfCals[2]);
        }
    }
}
