using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    class ComputerPlayer:BasePlayer
    {
        public ComputerPlayer()
        {

        }
        public ComputerPlayer(string name, int points, List<BaseCard> cards):base(name,points,cards)
        {

        }
        public override int CardSelection(int num)
        {
            Random card = new Random();
            return card.Next(1, num + 1);
        }
        public  override BasePlayer InitializeUserName()
        {
            return new ComputerPlayer("computer", 0, new List<BaseCard>());
        }

    }
}
