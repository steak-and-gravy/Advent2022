using System;
using System.Collections.Generic;

namespace Advent2022
{
    public class Day1
    {
        List<int> lstElfCals;

        public Day1(string filename)
        {
            lstElfCals = new List<int>();
            ProcessInputFile(filename);
        }

        private void ProcessInputFile(string filename)
        {
            var currentElf = 0;
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(filename);
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
            lstElfCals.Reverse(); // put most calories first
        }

        public int GetMostCalories()
        {
            return GetCaloriesByIndex(0);
        }

        public int GetCaloriesByIndex(int i)
        {
            if (lstElfCals.Count <= i)
                return -1;
            return lstElfCals[i];
        }
    }
}