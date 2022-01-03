using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    class ColorCard:BaseCard
    {
        public ConsoleColor Color { get; set; }
        public ColorCard()
        {

        }
        public ColorCard(ConsoleColor color,Isvisible isvisible, FirstOrsecond firstOrsecond) : base(isvisible, firstOrsecond)
        {
              Color = color;
        }
        protected override void PrintCard()
        {
            Console.BackgroundColor = this.Color;
            Console.Write("     ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("  ");
        }
        public override bool IsSame(BaseCard b)
        {
            return  this.Color == ((ColorCard)b).Color;
        }
        public override BaseCard Init()
        {
            Random rand = new Random();
            ConsoleColor color = (ConsoleColor)rand.Next(6, 16);
            return new ColorCard(color, Isvisible.Hidden, FirstOrsecond.First);
        }
        public override BaseCard InitCopy(BaseCard b)
        {
            return new ColorCard(((ColorCard)b).Color, Isvisible.Hidden,FirstOrsecond.Second);
        }
    }
}
