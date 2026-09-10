using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class MapGenerator
    {
        private Random random = new Random();
        private char[,] map = new char[20, 20];
        int[,] numMap = new int[20, 20];

        public char[,] GenerateMap()
        {
            numMap = Numbering();
            map = CharMap(numMap);
            return map;
        }

        private int[,] Numbering()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (numMap[i, j] == 10) continue; 
                    if (random.Next(100) < 25)
                    {
                        numMap[i, j] = 9;
                        for (int x = -1; x <= 1; x++)
                        {
                            for (int y = -1; y <= 1; y++)
                            {
                                int neighborRow = i + x;
                                int neighborCol = j + y;
                                if (neighborRow >= 0 && neighborRow < 20 &&
                                    neighborCol >= 0 && neighborCol < 20)
                                {
                                    if (numMap[neighborRow, neighborCol] == 10)
                                    {
                                        numMap[i,j] = 0;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        numMap[i, j] = 0;
                    }
                }
            }


            for (int row = 0; row < 20; row++)
            {
                for (int col = 0; col < 20; col++)
                {
                    if (numMap[row, col] == 9) continue;

                    int mineCount = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int neighborRow = row + i;
                            int neighborCol = col + j;

                            if (neighborRow >= 0 && neighborRow < 20 &&
                                neighborCol >= 0 && neighborCol < 20)
                            {
                                //if (numMap[row,col] == 10)
                                //{
                                //    if(numMap[neighborRow, neighborCol] == 9)
                                //    {
                                //        numMap[neighborRow, neighborCol] = 0;
                                //    }
                                //    continue;
                                //}
                                if (numMap[neighborRow, neighborCol] == 9)
                                {
                                    mineCount++;
                                }
                            }
                        }
                    }

                    numMap[row, col] = mineCount;
                }
            }

            return numMap;
        }
        private char[,] CharMap(int[,] numMap)
        {
            char[,] charMap = new char[20, 20];
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (numMap[i, j] == 9)
                    {
                        charMap[i, j] = 'X';
                    }
                    else if (numMap[i,j] == 10)
                    {
                        charMap[i, j] = 'O';
                    }
                    else
                    {
                        charMap[i, j] = (char)(numMap[i, j] + '0');
                    }
                }
            }
            return charMap;
        }
        private bool IsInBounds(int x, int y)
        {
            return x >= 0 && x < 20 && y >= 0 && y < 20;
        }
        private int[,] startOcupation1 = {
        { -1, -1, -1, 0, 0, 0, 1, 1, 1, -1, 0, 1, 0},
        { -1, 0, 1, -1, 1, 0, -1, 0, 1, 2, 2, 2, 3 }
        };
        private int[,] startOcupation2 = {
        { -1, -1, -1, 0, 0, 0, 1, 1, 1, -1, 0, 1, 0},
        { -1, 0, 1, -1, 1, 0, -1, 0, 1, 2, 2, 2, 3 } 
        };
        private int[,] startOcupation3 = {
        { -1, -1, -1, 0, 0, 0, 1, 1, 1, 2, 2, 2, 2, 1, 0, 1},
        { -1, 0, 1, -1, 1, 0, -1, 0, 1, 2, 1, -1, - 2, -2, -2, 2} 
        };
        public void StartOcupation(int x, int y)
        {
            //int[] dx = { -1, -1, -1, 0, 0, 0, 1, 1, 1, -1, 0, 1, 0};
            //int[] dy = { -1, 0, 1, -1, 1, 0, -1, 0, 1, 2, 2, 2, 3};
            int startNum = random.Next(0, 2);
            switch (startNum)
            {
                case 0:
                    DoOcupation(x, y, startOcupation1);
                    break;
                case 1:
                    DoOcupation(x, y, startOcupation2);
                    break;
                case 2:
                    DoOcupation(x, y, startOcupation3);
                    break;
            }
            
        }
        private void DoOcupation (int x, int y, int[,] cords)
        {
            for (int i = 0; i < cords.GetLength(0); i++)
            {
                for (int j = 0; j < cords.GetLength(1); j++)
                {
                    int newX = x + cords[i, j];
                    int newY = y + cords[i, j];
                    if (IsInBounds(newX, newY))
                    {
                        numMap[newX, newY] = 10;
                    }
                }
            }
        }
        public int GetMineCount()
        {
            int count = 0;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (numMap[i, j] == 9)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
