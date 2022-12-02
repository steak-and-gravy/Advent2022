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
        }
    }
}
