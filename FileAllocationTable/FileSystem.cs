using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileAllocationTable
{
    internal class FileSystem
    {
        const int MaxBlocks = 16;
        const int FreeMark = 0;
        const int NillMark = 255;
        const int BlockSize = 1024;
        
        int FreeBlocks = MaxBlocks;

        public class Directory
        {
            public string Name { get; set; } = "";
            public int Size { get; set; } = 0;
            public int FirstBlock { get; set; } = -1;
        }

        class FATBlock
        {
            public int NextBlock { get; set; }
        }

        public class FATEntry
        {
            public int BlockIndex { get; set; }
            public int NextBlock { get; set; }
            public string NextBlockDisplay
            {
                get 
                {
                    if (NextBlock == FreeMark)
                    {
                        return "Free";
                    }

                    if(NextBlock == NillMark)
                    {
                        return "EOF";
                    }
                    return NextBlock.ToString();
                }
            }
        }

        Directory[] Dir = new Directory[MaxBlocks];
        FATBlock[] FAT = new FATBlock[MaxBlocks];

        public BindingList<Directory> ActiveFiles { get; set; } 
        public BindingList<FATEntry> FatList { get; set; }
        public FileSystem()
        {

            FAT = new FATBlock[MaxBlocks];
            //инициализация на FAT
            for (int i =0; i < MaxBlocks; i++)
            {
                FAT[i] = new FATBlock { NextBlock = FreeMark };
            }

            //инициализация на директорията
            Dir = new Directory[MaxBlocks];
            for (int i=0; i<MaxBlocks; i++)
            {
                Dir[i] = new Directory 
                { 
                    Name = "", 
                    Size = 0, 
                    FirstBlock = -1 
                };
            }

            ActiveFiles = new BindingList<Directory>();
            FatList = new BindingList<FATEntry>();

            for(int i=0; i < MaxBlocks; i++)
            {
                FatList.Add(new FATEntry { BlockIndex = i, NextBlock = FAT[i].NextBlock });
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
            if(string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Името на файла е празно.");
                return;
            }

            if(ActiveFiles.Any(f => f.Name == name))
            {
                MessageBox.Show("Файл с това име вече съществува.");
                return;
            }

            int requiredBlocks = (size + BlockSize - 1) / BlockSize;

            if(requiredBlocks == 0)
            {
                requiredBlocks = 1;
            }

            if(requiredBlocks > FreeBlocks)
            {
                MessageBox.Show("Няма достатъчно свободни блокове.");
                return;
            }

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
                if (string.IsNullOrEmpty(Dir[i].Name))
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

            ActiveFiles.Add(Dir[dirIndex]);

            //свързване на FAT блокове
            for(int i=0; i<blocks.Count-1; i++)
            {
                FAT[blocks[i]].NextBlock = blocks[i + 1];
                FatList[blocks[i]].NextBlock = FAT[blocks[i]].NextBlock;
                FatList.ResetItem(blocks[i]);
            }

            FAT[blocks.Last()].NextBlock = NillMark;
            FatList[blocks.Last()].NextBlock = NillMark;
            FatList.ResetItem(blocks.Last());

            FreeBlocks -= blocks.Count;
            MessageBox.Show($"Файлът {name} е записан ({blocks.Count} блок/блока).");
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

            if (current == -1)
            {
                ActiveFiles.Remove(Dir[dirIndex]);
                Dir[dirIndex].Name = "";
                Dir[dirIndex].Size = 0;
                Dir[dirIndex].FirstBlock = -1;
                MessageBox.Show("Файлът е изтрит.");
                return;
            }

            int freed = 0;
            var safety = 0;

            while(current != NillMark && safety < MaxBlocks + 5)
            {
                if (current < 0 || current >= MaxBlocks) break;

                int next = FAT[current].NextBlock;
                FAT[current].NextBlock = FreeMark;
                
                FatList[current].NextBlock = FreeMark;
                FatList.ResetItem(current);
                
                freed++;
                current = next;
                safety++;
            }

            FreeBlocks += freed;

            ActiveFiles.Remove(Dir[dirIndex]);

            Dir[dirIndex].Name = "";
            Dir[dirIndex].Size = 0;
            Dir[dirIndex].FirstBlock = -1;

            MessageBox.Show($"Файлът е изтрит. Освободени блокове: {freed}.");
        }

        //метод за показване на състоянието на основните структури
        public string Show()
        {
            return GetState();
        }

        public string GetState()
        {
            var output = new StringBuilder();

            output.AppendLine($"Свободни блокове: {FreeBlocks} / {MaxBlocks}");
            output.AppendLine();
            output.AppendLine("Директория:");

            for (int i=0; i<Dir.Length; i++)
            {
                var file = Dir[i];

                if (file == null || string.IsNullOrEmpty(file.Name))
                    continue;

                output.AppendLine($"Име на файла: {file.Name}");
                output.AppendLine($"Размер: {file.Size}");
                output.AppendLine($"Блокове: ");

                int currentBlock = file.FirstBlock;

                if (currentBlock == -1)
                {
                    output.Append("(няма първи блок)");
                }
                else 
                {
                    var blocks = new List<int>();
                    int safetyCounter = 0;
                    while(currentBlock != NillMark && safetyCounter < MaxBlocks + 5)
                    {
                        if(currentBlock < 0 || currentBlock >= MaxBlocks)
                        {
                            blocks.Add(-1);
                            break;
                        }

                        blocks.Add(currentBlock);
                        int next = FAT[currentBlock].NextBlock;

                        if (next == currentBlock) break;

                        currentBlock = next;
                        safetyCounter++;
                    }

                    output.Append(string.Join(",", blocks));
                }

                output.AppendLine();
                output.AppendLine(new string('-', 30));  
            }

            output.AppendLine();
            output.AppendLine("-- FAT -- ");
            for (int i = 0; i < FatList.Count; i++)
            {
                output.AppendLine($"Блок {FatList[i].BlockIndex} -> {FatList[i].NextBlockDisplay}");
            }

            return output.ToString();
        }
    }
}