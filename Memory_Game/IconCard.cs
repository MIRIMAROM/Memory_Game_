using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    class IconCard:SignalCard 
    {
        public ConsoleColor Color{ get; set;}
        public IconCard()
        {

        }
        public IconCard(char tav, ConsoleColor color,Isvisible isvisible,FirstOrsecond firstOrsecond):base(tav,isvisible,firstOrsecond)
        {
            Color = color;
        }
        protected override void PrintCard()
        {
            Console.BackgroundColor = this.Color;
            base.PrintCard();
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public override bool IsSame(BaseCard b)
        {
                return base.IsSame(b) && this.Color == ((IconCard)b).Color;
        }
        public override BaseCard Init()
        {
            Random rand1 = new Random();
            char tav = (char)rand1.Next(32, 48);
            Random rand2 = new Random();
            ConsoleColor color = (ConsoleColor)rand2.Next(6, 16);
            return new IconCard(tav,color, Isvisible.Hidden,FirstOrsecond.First);
        }
        public override BaseCard InitCopy(BaseCard b)
        {
            return new IconCard(((IconCard)b).Signal, ((IconCard)b).Color,Isvisible.Hidden,FirstOrsecond.Second);
        }
    }
}
