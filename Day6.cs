using System;

namespace Advent2022
{
    internal class Day6
    {
        private string[] lines;

        public Day6(string filename)
        {
            lines = System.IO.File.ReadAllLines(filename);
        }

        internal int FindMarkerLocation()
        {
            return FindLocation(4);
        }

        internal int FindMessageLocation()
        {
            return FindLocation(14);
        }

        private int FindLocation(int length)
        {
            var line = lines[0];
            for (int i = 0; i < line.Length; i++)
            {
                if (CheckMarker(line.Substring(i, length), length)) return i + length;
            }
            return -1;
        }

        private bool CheckMarker(string data, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (data.Substring(i+1).Contains(data[i])) return false;
            }
            return true;
        }
    }
}