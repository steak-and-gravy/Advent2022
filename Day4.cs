using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2022
{
    internal class Day4
    {
        private string[] lines;

        public Day4(string filename)
        {
            lines = System.IO.File.ReadAllLines(filename);
        }

        internal int FindTotalDuplication()
        {
            var howMany = 0;
            foreach (var line in lines)
            {
                var leftString = line.Split(",")[0];
                var rightString = line.Split(",")[1];
                var leftMin = 0;
                var leftMax = 0;
                var rightMin = 0;
                var rightMax = 0;
                GetMinMax(leftString, ref leftMin, ref leftMax);
                GetMinMax(rightString, ref rightMin, ref rightMax);
                bool contained = OneContainsAnother(leftMin, leftMax, rightMin, rightMax);
                if (contained) howMany++;
            }
            return howMany;
        }

        internal int FindPartialDuplication()
        {
            //var watch = new System.Diagnostics.Stopwatch();
            //watch.Start();
            var howMany = 0;
            foreach (var line in lines)
            {
                var leftString = line.Split(",")[0];
                var rightString = line.Split(",")[1];
                var leftMin = 0;
                var leftMax = 0;
                var rightMin = 0;
                var rightMax = 0;
                GetMinMax(leftString, ref leftMin, ref leftMax);
                GetMinMax(rightString, ref rightMin, ref rightMax);
                var lstLeft = FillListOfAssignments(leftMin, leftMax);
                var lstRight = FillListOfAssignments(rightMin, rightMax);
                bool overlaps = OverlapsAnother(lstLeft, lstRight);
                if (overlaps) howMany++;
            }
            //watch.Stop();
            //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");    
            return howMany;
        }

        private void GetMinMax(string input, ref int min, ref int max)
        {
            min = Int32.Parse(input.Split("-")[0]);
            max = Int32.Parse(input.Split("-")[1]);
        }

        private bool OneContainsAnother(int leftMin, int leftMax, int rightMin, int rightMax)
        {
            if (leftMin >= rightMin && leftMax <= rightMax) return true;
            if (rightMin >= leftMin && rightMax <= leftMax) return true;
            return false;
        }

        private List<int> FillListOfAssignments(int min, int max)
        {
            var lstNumbers = new List<int>();
            for (int i = min; i <= max; i++)
            {
                lstNumbers.Add(i);
            }
            return lstNumbers;
        }

        private bool OverlapsAnother(List<int> left, List<int> right)
        {
            foreach (var item in left)
            {
                if (right.Contains(item)) return true;
            }
            return false;
        }
    }
}