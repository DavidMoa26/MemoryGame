using System;
using System.Collections.Generic;
using System.Text;

namespace _1.MemoryGame
{
    class Game
    {       
        Player[] players = new Player[2];
        Board board;
        bool GameStatus = true;
        int Turn = new Random().Next(0, 2);
        int Card1Row;
        int Card2Row;
        int Card1Col;
        int Card2Col;

        public Game(string name1, string name2)
        {
            players[0] = new Player(name1);
            players[1] = new Player(name2);
            board = new Board();
        }

        public void Play()
        {
            AskForBoardSize();
            string[,] CopyBoard = new string[BoardSize(),BoardSize()];
            board.SetRandomValues();
            CreateCopyOfBoard(BoardSize(), CopyBoard);                  
            board.Print();
            Console.WriteLine("\n\nThe game is starting...");
            System.Threading.Thread.Sleep(5 * 600);
            board = new Board(BoardSize());
            FreeAllTheCells();
            UpdateTheBoard();

            while (GameStatus == true)
            {
                PrintPlayerDetails(Turn, players);
                Card1Move(BoardSize());
                board.SetSymbol(Card1Row - 1, Card1Col - 1, CopyBoard[Card1Row - 1, Card1Col - 1]);
                UpdateTheBoard();
                PrintPlayerDetails(Turn, players);
                Card2Move(BoardSize());
                board.SetSymbol(Card2Row - 1, Card2Col - 1, CopyBoard[Card2Row - 1, Card2Col - 1]);
                UpdateTheBoard();
                CheckIfTheCardsEven();
                CheckIfTheGameEnd(BoardSize());
            }
        }
        public void AskForBoardSize()
        {
            int Size;
            do
            {
                Console.WriteLine("Enter board size : ");
                Console.WriteLine("2X2 - press 2");
                Console.WriteLine("4X4 - press 4");
                Console.WriteLine("6X6 - press 6");
                Console.WriteLine("8X8 - press 8");
                Size = int.Parse(Console.ReadLine());              
            } while (Size % 2 != 0 && Size >= 1 && Size <= 9 || Size <= 0);
            board.SetSize(Size);
            board = new Board(Size);
        }
        public int BoardSize() { return board.GetSize();}
        public void Card1Move(int size)
        {
            do
            {
                Console.WriteLine("\nCard 1 : ");
                Console.WriteLine("Choose number between 1-" + size + " : ");
                Card1Row = players[Turn].MakeRowMove();
                Card1Col = players[Turn].MakeColMove();
                if (Card1Row < 1 || Card1Row > size || Card1Col < 1 || Card1Col > size || board.CellFree(Card1Row - 1, Card1Col - 1) == false)
                    Console.WriteLine("Try again - out of range or card not avillble");
            } while (Card1Row < 1 || Card1Row > size || Card1Col < 1 || Card1Col > size || board.CellFree(Card1Row - 1, Card1Col - 1) == false);           
        }
        public void Card2Move(int size)
        {
            do
            {
                Console.WriteLine("\nCard 2 : ");
                Console.WriteLine("Choose number between 1-" + size + " : ");
                Card2Row = players[Turn].MakeRowMove();
                Card2Col = players[Turn].MakeColMove();
                Console.WriteLine(board.CellFree(Card2Row - 1, Card2Col - 1));
                if (Card2Row < 1 || Card2Row > size || Card2Col < 1 || Card2Col > size || board.CellFree(Card2Row - 1, Card2Col - 1) == false)
                    Console.WriteLine("Try again - out of range or card not avillble");
            } while (Card2Row < 1 || Card2Row > size || Card2Col < 1 || Card2Col > size || board.CellFree(Card2Row - 1, Card2Col - 1) == false);
        }
        public void CheckIfTheGameEnd(int size)
        {
            if (board.Count(size) == size * size)
            {
                Console.WriteLine("\n\nGame ends : ");
                if (players[0].GetPoints() > players[1].GetPoints())
                    Console.WriteLine(players[0].GetName() + " wins !");
                else if (players[0].GetPoints() < players[1].GetPoints())
                    Console.WriteLine(players[1].GetName() + " wins !");
                else
                    Console.WriteLine("Draw !");
                Console.WriteLine(players[0].GetName() + " points : " + players[0].GetPoints());
                Console.WriteLine(players[1].GetName() + " points : " + players[1].GetPoints());
                GameStatus = false;
            }
        }
        public void CheckIfTheCardsEven()
        {
            if (board.CellsEven(Card1Row - 1, Card1Col - 1, Card2Row - 1, Card2Col - 1))
            {
                Console.WriteLine("\n\n+1 points to " + players[Turn].GetName());
                players[Turn].RaisePoint();
            }
            else
            {
                board.RenewCell(Card1Row - 1, Card1Col - 1);
                board.RenewCell(Card2Row - 1, Card2Col - 1);
                UpdateTheBoard();
                ChangeTurn();
            }
        }
        public void FreeAllTheCells()
        {
            for (int i = 0; i < board.GetBoardSize(); i++)
                for (int j = 0; j < board.GetBoardSize(); j++)
                    board.SetFreeCell(i, j);                                          
        }
        public void UpdateTheBoard()
        {
            Console.Clear();
            board.Print();
        }
        public void ChangeTurn()
        {
            if (Turn == 1)
                Turn--;
            else
                Turn++;
        }
        public void PrintPlayerDetails(int index,Player[] player)
        {
            Console.WriteLine("\n\nNow " + player[index].name + " turn");
            Console.WriteLine("Points : " + players[index].points);
        }
        public void CreateCopyOfBoard(int Size,string[,] Copy)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    Copy[i, j] = board.GetSymbol(i, j);
        }
    }
}
