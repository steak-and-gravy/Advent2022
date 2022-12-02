using System;

namespace Advent2022
{
    public class Day2
    {
        private string _filename;
        public Day2(string filename)
        {
            _filename = filename;
        }

        public int CalculateScore()
        {
            var score = 0;

            string[] lines = System.IO.File.ReadAllLines(_filename);
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    var opp = line.Split(' ')[0];
                    var me = line.Split(' ')[1];

                    score += GetOutcomePoints(opp, me);
                    if (me == "X") score += 1;
                    if (me == "Y") score += 2;
                    if (me == "Z") score += 3;
                }
            }
            return score;
        }



        public int CalculateRealScore()
        {
            var score = 0;

            string[] lines = System.IO.File.ReadAllLines(_filename);
            foreach (string line in lines)
            {
                if (line.Length > 0)
                {
                    var opp = line.Split(' ')[0];
                    var me = line.Split(' ')[1];

                    score += GetShapePoints(opp, me);
                    if (me == "X") score += 0;
                    if (me == "Y") score += 3;
                    if (me == "Z") score += 6;
                }
            }
            return score;
        }

        private int GetOutcomePoints(string opp, string me)
        {
            // Rock - A or X
            // Paper - B or Y
            // Scissors - C or Z
            switch (opp)
            {
                case "A":
                    if (me == "X") return 3;
                    if (me == "Y") return 6;
                    break;
                case "B":
                    if (me == "Y") return 3;
                    if (me == "Z") return 6;
                    break;
                case "C":
                    if (me == "Z") return 3;
                    if (me == "X") return 6;
                    break;
                default:
                    return 0;
            }
            return 0;
        }



        private int GetShapePoints(string opp, string me)
        {
            // Rock - A
            // Paper - B
            // Scissors - C
            // Lose - X
            // Draw - Y
            // Win = Z
            switch (opp)
            {
                case "A":
                    if (me == "Z") return 2;
                    if (me == "X") return 3;
                    break;
                case "B":
                    if (me == "Y") return 2;
                    if (me == "Z") return 3;
                    break;
                case "C":
                    if (me == "X") return 2;
                    if (me == "Y") return 3;
                    break;
                default:
                    return 0;
            }
            return 1;
        }
    }
}