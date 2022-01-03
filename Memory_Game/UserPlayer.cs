using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    class UserPlayer :BasePlayer
    {

        public UserPlayer()
        {

        }
        public UserPlayer(string name, int points, List<BaseCard> cards) : base(name,points, cards)
        {

        }
        public override BasePlayer InitializeUserName()
        {
            Console.WriteLine("enter your name:");
            return new UserPlayer(Console.ReadLine(),0,new List<BaseCard>()); 
        }
        public override int CardSelection(int num)
        {
            int card;
            Console.WriteLine("choose card(enter the index!!)1-"+num);
            while (!int.TryParse((Console.ReadLine()), out card))
            {
                Console.WriteLine("invalid index choose card(enter the index!!)1-" + num);
            }
            return card;
        }
      
    }
}
