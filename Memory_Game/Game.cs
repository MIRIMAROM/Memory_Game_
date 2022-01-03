using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Memory_Game
{

    enum TypePlayer {ComputerPlayer=1,UserPlayer}
    enum TypeCard { IconCard, SignalCard, ExerciseCard }

    class Game
    {
        private  BasePlayer[] temp = { new ComputerPlayer(),new UserPlayer()};
        public List<BasePlayer> Players { get; set; } = new List<BasePlayer>();
        public int Index { get; set; }
        //public Dictionary<TypeCard, List<TypeCard>> CardsInTheGame { get; set; }
        public List<List<int>> CardComputerPlayer { get; set; }
        public TypePlayer TypePlayer { get; set; }
        public void InitializePlayer(TypePlayer value)
        {
            BasePlayer u =temp[(int)value-1];
            if (value == TypePlayer.ComputerPlayer)
            {
                CardComputerPlayer = new List<List<int>>();
                TypePlayer = TypePlayer.ComputerPlayer;
                Players.Add(u.InitializeUserName());
                UserPlayer p = new UserPlayer();
                Players.Add(p.InitializeUserName());
            }
            else
                if (value==TypePlayer.UserPlayer)
            {
                TypePlayer = TypePlayer.UserPlayer;
                Console.WriteLine("enter how many player do you want");
                int num;
                while (!int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("invalid please enter again :enter how many player do you want");
                } 
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine("player " + (i + 1) + ":");
                    Players.Add(u .InitializeUserName());
                }
            }
        }
        public void FindCouple(BaseCard b1,BaseCard b2)
        {
            if(b1.IsSame(b2))
            {
                Console.WriteLine(" you find Couple!!");
                b1.Isvisible = Isvisible.Available;
                b2.Isvisible = Isvisible.Available;
                Players[Index].Cards.Add(b1);
                Players[Index].Cards.Add(b2);
                Players[Index].Points++;
            }
            else
            {
                b1.Isvisible = Isvisible.Hidden;
                b2.Isvisible = Isvisible.Hidden;
                Console.WriteLine("try again later you not find Couple!!");
            }
        }
        public List<BasePlayer> TheWinner()
        {
          return Players.FindAll(p=>p.Points==Players.Max(x => x.Points));
        }
        public int ChooseCard(BasePlayer item, Board BG)
        {
            int card = item.CardSelection(BG.Size);
            while (!BG.ValidIndex(card - 1))
            {
                card = item.CardSelection(BG.Size);
            }
            BG.ListCards[card - 1].Isvisible = Isvisible.Overt;
            return card;
        }
        public void ProgressGame()
        {
            int value; 
            Console.WriteLine(" -----------MEMORY GAME-----------");
            Console.WriteLine("enter 1-ComputerPlayer 2-UserPlayer");
            Game G = new Game();
            while (!int.TryParse(Console.ReadLine(), out value)||value > temp.Length ||value < 1)
            {
                Console.WriteLine("invalid please enter again :enter 1-ComputerPlayer 2-UserPlayer");
            }
            G.InitializePlayer((TypePlayer)value);
            Console.WriteLine("enter how many cards do you want(even num)");
            while (!int.TryParse(Console.ReadLine(), out value) || value%2 != 0)
            {
                Console.WriteLine("invalid please enter again :enter how many cards do you want(even num)");
            }
            Board BG = new Board(value);
            Console.WriteLine("enter 1-ICON 2-COLOR 3-SIGNAL 4-EXERCISE");
            while (!int.TryParse(Console.ReadLine(), out value) || value < 0 || value > 4)
            {
                Console.WriteLine("invalid please enter again :1-ICON 2-COLOR 3-SIGNAL 4-EXERCISE");
            }
            BG.InitializeBoard(value);
            BG.PrintBoard();
            while (!BG.IsCardsFinished())
            {
                G.Index = 0;
                foreach (var item in G.Players)
                {
                    Console.WriteLine("------------player "+item.GetName() + ": ---------------");
                    int card1,card2;
                    if (G.TypePlayer == TypePlayer.ComputerPlayer&&item.GetName()=="computer")
                    {
                        card1 = ChooseCard(item, BG);
                        card2 = ChooseCard(item, BG);
                        //מחשב חכם
                        while (G.CardComputerPlayer.Any(x => x.All(y => y == card1 || y == card2)))
                        {
                            BG.ListCards[card1 - 1].Isvisible = Isvisible.Hidden;
                            BG.ListCards[card2 - 1].Isvisible = Isvisible.Hidden;
                            card1 = ChooseCard(item, BG);
                            card2 = ChooseCard(item, BG);
                        }
                    }
                    else
                    {
                        card1 = ChooseCard(item, BG);
                        BG.PrintBoard();
                        card2 = ChooseCard(item, BG);
                    }
                    G.CardComputerPlayer.Add(new List<int> { card1, card2 });
                    BG.PrintBoard();
                    G.FindCouple(BG.ListCards[card1-1], BG.ListCards[card2-1]);
                    G.Index++;
                    if (BG.IsCardsFinished())
                    {
                        Console.WriteLine("------Well done!!----");
                        Console.WriteLine("The Winner:");
                        G.TheWinner().ForEach(x => x.Details()) ;
                        break;
                    }
                    Thread.Sleep(1100);
                    Console.Clear();
                    BG.PrintBoard();
                }
                   
            }
        } 
    }



}

