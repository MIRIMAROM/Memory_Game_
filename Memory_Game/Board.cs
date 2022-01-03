using System;
using System.Collections.Generic;  
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    class Board
    {
        private BaseCard[] temp = { new IconCard(), new ColorCard(), new SignalCard(), new ExerciseCard() };
        public int Size { get; set; }
        public List<BaseCard> ListCards{ get; set; }
        public Board()
        {

        }
        public Board(int size)
        {
            Size = size;
            ListCards = new List<BaseCard>();
        }
        public void InitializeBoard(int value)
        {
            int i = 0;
            BaseCard b = temp[value - 1];
                while (i < Size)
                {
                    BaseCard temp = b.Init();
                    while (ListCards.Contains(temp))
                    {
                          temp = b.Init(); 
                    }
                    ListCards.Add(temp);
                    ListCards.Add(b.InitCopy(temp));
                    i += 2;
                }
                this.Mixing();
        }
        public void Mixing()
        {
            Random rand = new Random();
            ListCards = (from i in ListCards
                         orderby rand.Next(1,9)
                         select i).ToList();
        } 
        public  void PrintBoard()
        {
            ListCards.ForEach(x => Console.Write("*****  "));
            Console.WriteLine();
            ListCards.ForEach(x => x.Print());
            Console.WriteLine();
            ListCards.ForEach(x => Console.Write("*****  "));
            Console.WriteLine();
        }
        public  bool ValidIndex(int index)
        {
            return index < Size && index >= 0&& ListCards[index].Isvisible == Isvisible.Hidden;
        }
        public bool IsCardsFinished()
        {
            return ListCards.Any(x => x.Isvisible == Isvisible.Hidden || x.Isvisible == Isvisible.Overt);

        }


    }
}
