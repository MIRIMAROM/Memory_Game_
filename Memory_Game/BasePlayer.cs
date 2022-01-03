using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    abstract class BasePlayer
    {
        public int Points { get; set; }
        public List<BaseCard> Cards { get; set; }
        protected string Name;

        public BasePlayer()
        {

        }
        public BasePlayer(string name,int points, List<BaseCard> cards)
        {
            Name = name ;
            Points = points;
            Cards = cards;
        }
        public string GetName()
        {
            return Name;
        }
        public abstract  BasePlayer InitializeUserName();
        public abstract int CardSelection(int num);
        public void DisplaysThePlayerCard()
        {
            Cards.ForEach(i => i.Print());
        }
        public void Details()
        { 
            Console.WriteLine( "Name= " + this.Name + " Points= " + this.Points+" Cards= ");
            this.DisplaysThePlayerCard();
        }
    }
}
