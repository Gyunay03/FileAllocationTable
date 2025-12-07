using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
        const int BlockSize = 1024;
        
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
            int requiredBlocks = (size + BlockSize - 1) / BlockSize;
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

        //метод за изтриване на файл
        public void DeleteFile(string name)
        {
            int dirIndex = -1;
            for(int i=0; i<Dir.Length; i++)
            {
                if (Dir[i].Name == name)
                {
                    dirIndex = i;
                    break;
                }
            }

            if (dirIndex == -1)
            {
                MessageBox.Show("Файлът не съществува.");
                return;
            }

            int current = Dir[dirIndex].FirstBlock;

            while(current != NillMark)
            {
                int next = FAT[current].NextBlock;
                FAT[current].NextBlock = FreeMark;
                current = next;
                FreeBlocks++;
            }

            Dir[dirIndex].Name = "";
            Dir[dirIndex].Size = 0;
            Dir[dirIndex].FirstBlock = -1;

            MessageBox.Show("Файлът е изтрит.");
        }

        //метод за показване на състоянието на основните структури
        public void Show()
        {
            for(int i=0; i < Dir.Length; i++)
            {
                var file = Dir[i];
                
                if (file == null || file.Name == "")
                {
                    continue;
                }

                var message = new StringBuilder();
                message.AppendLine("Име на файла: " + file.Name);
                message.AppendLine("Размер: " + file.Size);
                message.AppendLine("Блокове: ");

                int currentBlock = file.FirstBlock;

                if (currentBlock == -1)
                {
                    message.Append("(няма първи блок)");
                }

                else
                {
                    var blocks = new List<int>();
                    var safetyCounter = 0;

                    while (currentBlock != NillMark)
                    {
                        if (currentBlock < 0 || currentBlock >= MaxBlocks)
                        {
                            blocks.Add(-1);
                            MessageBox.Show("Невалиден блок.");
                            break;
                        }

                        blocks.Add(currentBlock);
                        int next = FAT[currentBlock].NextBlock;

                        if (next == currentBlock)
                        {
                            break;
                        }

                        currentBlock = next;
                        safetyCounter++;
                        
                        if(safetyCounter > MaxBlocks + 5)
                        {
                            break;
                        }
                    }

                    message.Append(string.Join(",", blocks));
                }

                MessageBox.Show(message.ToString());
            }
        }
    }
}