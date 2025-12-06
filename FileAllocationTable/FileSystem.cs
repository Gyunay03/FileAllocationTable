using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAllocationTable
{
    internal class FileSystem
    {
        const int MaxBlocks = 16;
        const int FreeMark = 0;
        const int NillMark = 255;
        
        int FreeBlocks = MaxBlocks;

        class Directory
        {
            public string Name;
            public int Size;
            public int FirstBlock;
        }

        class FATBlock
        {
            public int NextBlock { get; set; }
        }

        Directory[] Dir = new Directory[MaxBlocks];
        FATBlock[] FAT = new FATBlock[MaxBlocks];

        public FileSystem()
        {
            //инициализация на FAT
            for (int i =0; i < MaxBlocks; i++)
            {
                FAT[i] = new FATBlock { NextBlock = FreeMark };
            }

            //инициализация на директорията
            for(int i=0; i<MaxBlocks; i++)
            {
                Dir[i] = new Directory 
                { 
                    Name = "", 
                    Size = 0, 
                    FirstBlock = -1 
                };
            }
        }

        //метод за намиране на свободни блокове
        public List <int> FindFreeBlocks(int requiredBlocks)
        {
            List<int> freeBlocks = new List<int>();
            for(int i=0; i<FAT.Length; i++)
            {
                if (FAT[i].NextBlock == FreeMark)
                {
                    freeBlocks.Add(i);
                    if(freeBlocks.Count == requiredBlocks)
                    {
                        break;
                    }
                }
            }
            return freeBlocks;
        }

        //метод за създаване на файл
        public void SaveFile(string name, int size)
        {
            int requiredBlocks = size;
            var blocks = FindFreeBlocks(requiredBlocks);

            if(blocks.Count < requiredBlocks)
            {
                MessageBox.Show("Няма достатъчно свободни блокове.");
                return;
            }

            //намиране на свободен индекс в директорията
            int dirIndex = -1;
            for(int i=0; i < Dir.Length; i++)
            {
                if (Dir[i].Name == "")
                {
                    dirIndex = i;
                    break;
                }
            }

            if(dirIndex == -1)
            {
                MessageBox.Show("Директорията е пълна.");
                return;
            }

            //запис в директорията
            Dir[dirIndex] = new Directory
            {
                Name = name,
                Size = size,
                FirstBlock = blocks[0]
            };

            //свързване на FAT блокове
            for(int i=0; i<blocks.Count-1; i++)
            {
                FAT[blocks[i]].NextBlock = blocks[i + 1];
            }

            FAT[blocks.Last()].NextBlock = NillMark;
        }
    }
}