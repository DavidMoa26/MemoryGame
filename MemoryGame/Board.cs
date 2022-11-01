using System;
using System.Collections.Generic;
using System.Text;

namespace _1.MemoryGame
{
    class Board
    {
        Cell[,] board;
        int size;

        public Board()
        {
            board = null;
            size = 0;
        }
        public Board(int Size)
        {
            size = Size;
            board = new Cell[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    board[i, j] = new Cell();

        }


        public void SetSymbol(int row, int col, string num)
        {
            board[row, col].cell = num;
            board[row, col].free = false;
        }
        public int Count(int counter)
        {
            counter = size*size;
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (board[i, j].IsFree())
                        counter--;
            return counter;
        }
        public string GetSymbol(int row, int col)
        {
            return board[row, col].GetCellSymbol();
        }
        public void Print()
        {
            if (size == 2)
            {
                Console.WriteLine("Board : ");
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("\t");
                    Console.WriteLine("\n");
                    for (int j = 0; j < 2; j++)
                    {
                        Console.Write("\t");
                        Console.Write(board[i, j].cell);
                    }
                    Console.WriteLine();
                }
            }
            if (size == 4)
            {
                Console.WriteLine("Board : ");
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("\t");
                    Console.WriteLine("\n");
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write("\t");
                        Console.Write(board[i, j].cell);
                    }
                    Console.WriteLine();
                }
            }
            if (size == 6)
            {
                Console.WriteLine("Board : "); ;
                for (int i = 0; i < 6; i++)
                {
                    Console.WriteLine("\t");
                    Console.WriteLine("\n");
                    for (int j = 0; j < 6; j++)
                    {
                        Console.Write("\t");
                        Console.Write(board[i, j].cell);
                    }
                    Console.WriteLine();
                }
            }
            if (size == 8)
            {
                Console.WriteLine("Board : ");
                for (int i = 0; i < 8; i++)
                {
                    Console.WriteLine("\t");
                    Console.WriteLine("\n");
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("\t");
                        Console.Write(board[i, j].cell);
                    }
                    Console.WriteLine();
                }
            }

        }
        public void SetRandomValues()
        {
            int col = new Random().Next(0, size);
            int row = new Random().Next(0, size);
            int value = 1;
            while (value <= (size * size) / 2)
            {

                while (true)
                {
                    if (this.GetSymbol(row,col) == "X")
                    {
                        this.SetSymbol(row, col, value.ToString());
                        break;
                    }
                    col = new Random().Next(0, size);
                    row = new Random().Next(0, size);
                }
                col = new Random().Next(0, size);
                row = new Random().Next(0, size);
                while (true)
                {
                    if (this.GetSymbol(row, col) == "X")
                    {
                        this.SetSymbol(row, col, value.ToString());
                        break;
                    }
                    col = new Random().Next(0, size);
                    row = new Random().Next(0, size);
                }
                value++;
            }
        }
        public void SetSize(int _Size) { size = _Size; }
        public int GetSize() { return size; }
        public bool CellFree(int row,int col)
        {
            if (row < 0 || row > size - 1 || col < 0 || col > size - 1)
                return false;
            return board[row,col].free;
        }
        public bool CellsEven(int row1,int col1,int row2,int col2)
        {
            if (board[row1, col1].cell == board[row2, col2].cell)
                return true;
            else return false;
        }
        public void PrintCell(int row,int col)
        {
            board[row, col].GetCellSymbol();
        }
        public void SetFreeCell(int row,int col)
        {              
           board[row,col].free = true;       
        }
        public int GetBoardSize()
        {
            return size;
        }
        public void RenewCell(int row,int col)
        {
            board[row, col] = new Cell();
        }
    }
}
