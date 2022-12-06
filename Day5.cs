using System;
using System.Collections;
using System.Collections.Generic;

namespace Advent2022
{
    internal class Day5
    {
        private string[] instructions;
        private Stack stack1 = new Stack();
        private Stack stack2 = new Stack();
        private Stack stack3 = new Stack();
        private Stack stack4 = new Stack();
        private Stack stack5 = new Stack();
        private Stack stack6 = new Stack();
        private Stack stack7 = new Stack();
        private Stack stack8 = new Stack();
        private Stack stack9 = new Stack();

        public Day5(string filename, string instructionFile)
        {
            var lines = System.IO.File.ReadAllLines(filename);
            instructions = System.IO.File.ReadAllLines(instructionFile);
            ProcessStacks(lines);
        }

        private void ProcessStacks(string[] lines)
        {
            for (int i = lines.Length - 1; i >= 0; i--)
            {
                ProcessCrate(stack1, lines[i][1]);
                ProcessCrate(stack2, lines[i][5]);
                ProcessCrate(stack3, lines[i][9]);
                ProcessCrate(stack4, lines[i][13]);
                ProcessCrate(stack5, lines[i][17]);
                ProcessCrate(stack6, lines[i][21]);
                ProcessCrate(stack7, lines[i][25]);
                ProcessCrate(stack8, lines[i][29]);
                ProcessCrate(stack9, lines[i][33]);
            }
        }

        private void ProcessCrate(Stack stack, char crate)
        {
            if (crate != ' ') stack.Push(crate);
        }

        internal void MoveCrates()
        {
            foreach(var line in instructions)
            {
                var instruction = line.Replace("move ", "").Replace(" from ", ",").Replace(" to ", ",");
                ProcessInstruction(instruction.Split(","));
            }
        }

        private void ProcessInstruction(string[] instruction)
        {
            var howMany = Convert.ToInt32(instruction[0]);
            var from = FindStack(instruction[1]);
            var to = FindStack(instruction[2]);
            for (int i = 0; i < howMany; i++)
            {
                to.Push(from.Pop());
            }
        }

        internal void MoveCratesV9001()
        {
            foreach(var line in instructions)
            {
                var instruction = line.Replace("move ", "").Replace(" from ", ",").Replace(" to ", ",");
                ProcessInstructionV9001(instruction.Split(","));
            }
        }

        private void ProcessInstructionV9001(string[] instruction)
        {
            var howMany = Convert.ToInt32(instruction[0]);
            var from = FindStack(instruction[1]);
            var to = FindStack(instruction[2]);
            var hold = new Stack();
            for (int i = 0; i < howMany; i++)
            {
                hold.Push(from.Pop());
            }
            for (int i = 0; i < howMany; i++)
            {
                to.Push(hold.Pop());
            }
        }

        private Stack FindStack(string stack)
        {
            switch (stack)
            {
                case "1":
                    return stack1;
                case "2":
                    return stack2;
                case "3":
                    return stack3;
                case "4":
                    return stack4;
                case "5":
                    return stack5;
                case "6":
                    return stack6;
                case "7":
                    return stack7;
                case "8":
                    return stack8;
                case "9":
                    return stack9;
                default:
                    throw new NotImplementedException();
            }
        }

        internal List<string> TopOfEachStack()
        {
            var lstTops = new List<string>();
            lstTops.Add(stack1.Peek().ToString());
            lstTops.Add(stack2.Peek().ToString());
            lstTops.Add(stack3.Peek().ToString());
            lstTops.Add(stack4.Peek().ToString());
            lstTops.Add(stack5.Peek().ToString());
            lstTops.Add(stack6.Peek().ToString());
            lstTops.Add(stack7.Peek().ToString());
            lstTops.Add(stack8.Peek().ToString());
            lstTops.Add(stack9.Peek().ToString());

            return lstTops;
        }
    }
}