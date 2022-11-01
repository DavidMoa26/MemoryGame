using System;
using System.Collections.Generic;
using System.Text;

namespace _1.MemoryGame
{
    class Cell
    {

        public string cell;
        public bool free = true;

        public Cell()
        {
            cell = "X";
            free = true;
        }

        public void SetCellSymbol(string Sign)
        {
            if (free == true)
            cell = Sign;
        }
        public string GetCellSymbol() { return cell; }
        public bool IsFree()
        {
            return free;
        }

    }
}
