using System;
using System.Collections.Generic;

namespace Advent2022
{
    internal class NTree
    {
        private Folder folder;
        private LinkedList<NTree> children;
        private NTree parent;
        
        public int Size { get { return folder.Size; } }
        public LinkedList<NTree> Children { get { return children; } }

        public NTree(Folder folder, NTree parent)
        {
            this.folder = folder;
            this.parent = parent;
            children = new LinkedList<NTree>();
        }

        public void IncreaseSize(int size)
        {
            folder.Size += size;
            var p = parent;
            while (p != null)
            { 
                p.folder.Size += size;
                p = p.GetParent();
            }
        }

        public void AddChild(Folder folder)
        {
            children.AddFirst(new NTree(folder, this));
        }

        public NTree GetChild(string folderName)
        {
            foreach (NTree n in children)
                if (n.folder.Name == folderName)
                    return n;
            return null;
        }

        public NTree GetParent()
        {
            return parent;
        }
    }
}