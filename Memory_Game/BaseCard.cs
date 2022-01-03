using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    enum Isvisible {Overt,Hidden,Available, AvailablePlayer };
    enum FirstOrsecond {First,Second}
    abstract class BaseCard
    {
        public Isvisible Isvisible { get; set; }
        public FirstOrsecond FirstOrsecond{ get; set; }
        public BaseCard()
        {

        }
        public BaseCard(Isvisible isVisible, FirstOrsecond firstOrSecond)
        {
            Isvisible = isVisible;
            FirstOrsecond = firstOrSecond;
        }
        public  override bool Equals(object obj)
        {
            BaseCard card = obj as BaseCard;
            return card ==null?false: this.IsSame(card);
        }
        public abstract bool IsSame(BaseCard b);
        protected abstract void PrintCard();
        public abstract BaseCard Init();
        public abstract BaseCard InitCopy(BaseCard b);
        public void Print()
        {
            if (this.Isvisible == Isvisible.Available)
                Console.Write("* ! *  ");
            else
                  if (this.Isvisible == Isvisible.Hidden)
            {
                Console.Write("* ? *  ");
            }
            else
                PrintCard();
        }
    }
}
