using System;
using System.Collections.Generic;

namespace Advent2022
{
    internal class Day3
    {
        private string[] lines;

        public Day3(string filename)
        {
            lines = System.IO.File.ReadAllLines(filename);
        }

        public int CalculatePriorities()
        {
            var priorities = 0;
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    var left = line.Substring(0, line.Length/2);
                    var right = line.Substring(line.Length/2);
                    
                    var letter = GetDuplicate(left, right);
                    priorities += GetLetterValue(letter);
                }
            }
            return priorities;
        }

        private int GetLetterValue(char letter)
        {
            if (letter < 91) // 90 is capital Z
                return letter - 38;  
            else
                return letter - 96;
        }

        private char GetDuplicate(string left, string right)
        {
            foreach (var letter in left)
            {
                if (right.Contains(letter)) return letter;
            }
            throw new Exception("No duplicates");
        }

        public int CalculateGroupPriorities()
        {
            var priorities = 0;
            var individual = 0;
            List<string> groupItems = new List<string>();
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    groupItems.Add(line);
                    individual++;
                    if (individual == 3)
                    {
                        var letter = FindCommonLetter(groupItems);
                        priorities += GetLetterValue(letter);
                        individual = 0;
                        groupItems.Clear();
                    }
                }
            }
            return priorities;
        }

        private char FindCommonLetter(List<string> groupItems)
        {
            foreach (var letter in groupItems[0])
            {
                if (groupItems[1].Contains(letter) && groupItems[2].Contains(letter)) return letter;
            }
            throw new Exception("No duplicates");
        }
    }
}