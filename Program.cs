using System;
using System.Collections;
using System.Collections.Generic;

namespace Advent2022
{
    class Program
    {
        static void Main(string[] args)
        {
            var day1 = new Day1("input");
            var mostCalories = day1.GetMostCalories();
            Console.WriteLine("Most Calories: {0}", mostCalories);

            var top3Calories = day1.GetCaloriesByIndex(0) +
                day1.GetCaloriesByIndex(1) +
                day1.GetCaloriesByIndex(2);
            
            Console.WriteLine("Top 3 Calories: {0}", top3Calories);

            var day2 = new Day2("input2.txt");
            var score = day2.CalculateScore();
            Console.WriteLine("Score: {0}", score);
            
            var realScore = day2.CalculateRealScore();
            Console.WriteLine("Real Score: {0}", realScore);

            var day3 = new Day3("input3.txt");
            var priorities = day3.CalculatePriorities();
            Console.WriteLine("Priorities: {0}", priorities);
            var groupPriorities = day3.CalculateGroupPriorities();
            Console.WriteLine("Group Priorities: {0}", groupPriorities);
            
            var day4 = new Day4("input4.txt");
            var assignmentDuplicate = day4.FindTotalDuplication();
            Console.WriteLine("# of assignment duplicates: {0}", assignmentDuplicate);
            var assignmentOverlaps = day4.FindPartialDuplication();
            Console.WriteLine("# of assignment overlaps: {0}", assignmentOverlaps);
        }
    }
}
