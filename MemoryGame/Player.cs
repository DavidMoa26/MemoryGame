using System;
using System.Collections.Generic;
using System.Text;

namespace _1.MemoryGame
{
    class Player
    {
        public string name;
        public int points = 0;

        public Player()
        {
            name = null;
        }
        public Player(string _name)
        {
            name = _name;
        }

        public int MakeRowMove() 
        {
            Console.WriteLine("Enter row number : ");
            int row = int.Parse(Console.ReadLine());
            return row;
        }
        public int MakeColMove() 
        {
            Console.WriteLine("Enter col number : ");
            int col = int.Parse(Console.ReadLine());
            return col;
        }
        public string GetName() { return name; }
        public void SetName()
        {
            string _name = Console.ReadLine();
            name = _name;
        }
        public void RaisePoint() { points++;}
        public int GetPoints() { return points;}       


    }
}
