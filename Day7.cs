using System;

namespace Advent2022
{
    internal class Folder
    {
        internal string Name;
        internal int Size = 0;
    }

    internal class Day7
    {
        private NTree folders = new NTree(new Folder { Name = "/", Size = 0}, null);

        public Day7(string filename)
        {
            var lines = System.IO.File.ReadAllLines(filename);
            Process(lines);
        }

        private void Process(string[] lines)
        {
            NTree currentFolder = folders;
            foreach (var line in lines)
            {
                if (line[0] == '$')
                {
                    if (line.StartsWith("$ cd"))
                    {
                        if (line == "$ cd /")
                        {
                            // root
                        }
                        else if (line == "$ cd ..")
                        {
                            currentFolder = currentFolder.GetParent();
                        }
                        else
                        {
                            currentFolder = currentFolder.GetChild(line.Substring(5));
                        }
                    }
                    else if (line == "$ ls")
                    {
                        // list files/folders
                    }
                }
                else if (line.StartsWith("dir"))
                {
                    var f = new Folder();
                    f.Name = line.Split(" ")[1];
                    currentFolder.AddChild(f);
                }
                else
                {
                    currentFolder.IncreaseSize(Convert.ToInt32(line.Split(" ")[0]));
                }
            }
        }

        private int totalSize = 0;

        internal int SizeOfDirectories(int maxSizeToCount)
        {
            totalSize = 0;
            totalSize += GetSizeIfAppropriate(folders, maxSizeToCount);
            ProcessChildren(folders, maxSizeToCount);
            return totalSize;
        }

        private int GetSizeIfAppropriate(NTree node, int maxSizeToCount)
        {
            if (node.Size < maxSizeToCount)
                return node.Size;
            return 0;
        }

        private void ProcessChildren(NTree node, int maxSizeToCount)
        {
            foreach (var child in node.Children)
            {
                totalSize += GetSizeIfAppropriate(child, maxSizeToCount);
                ProcessChildren(child, maxSizeToCount);
            }
        }

        private int closestSize = 0;

        internal int SizeOfDirectoryToDelete(int sizeNeeded)
        {
            closestSize = 0;
            var sizeToCompare = sizeNeeded - (70000000 - folders.Size);
            GetSize(folders, sizeToCompare);
            ProcessChildren2(folders, sizeToCompare);

            return closestSize;
        }

        private void GetSize(NTree node, int sizeToCompare)
        {
            if (node.Size >= sizeToCompare && (node.Size < closestSize || closestSize == 0))
                closestSize = node.Size;
        }

        private void ProcessChildren2(NTree node, int sizeToCompare)
        {
            foreach (var child in node.Children)
            {
                GetSize(child, sizeToCompare);
                ProcessChildren2(child, sizeToCompare);
            }
        }
    }
}