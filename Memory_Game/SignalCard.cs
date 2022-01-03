using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    class SignalCard: BaseCard
    {
        public char Signal { get; set; }
        public SignalCard()
        {

        }
        public SignalCard(char signal,Isvisible isvisible,FirstOrsecond firstOrsecond):base(isvisible,firstOrsecond)
        {
             Signal = signal;
        }
        protected override void PrintCard()
        {
            Console.Write("* {0} *  ", this.Signal);
        }
        public override bool IsSame(BaseCard b)
        {
            return  this.Signal == ((SignalCard)b).Signal;
        }
        public override BaseCard Init()
        {
            Random rand = new Random();
            char signal = (char)rand.Next(65, 123);
            return new SignalCard(signal,Isvisible.Hidden,FirstOrsecond.First);
        }
        public override BaseCard InitCopy(BaseCard b)
        {
            return new SignalCard(((SignalCard)b).Signal,Isvisible.Hidden,FirstOrsecond.Second);
        }
    }

}
