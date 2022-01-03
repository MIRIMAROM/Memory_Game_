using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    class ExerciseCard : BaseCard  
    {
        private DataTable dt = new DataTable();
        private char[] operators = {'+','-','/','*'}; 
        public string Exercise { get; set; }
        public int Result { get; set; }
        public ExerciseCard()
        {

        }
        public ExerciseCard(string exercise, int result,Isvisible isvisible, FirstOrsecond firstOrsecond):base(isvisible,firstOrsecond)
        {
            Exercise = exercise;
            Result = result;
        }
        protected override void PrintCard()
        {
            if(this.FirstOrsecond==FirstOrsecond.Second)
                Console.Write("  {0}   ", this.Result);
            else
                Console.Write("*{0}*  ", this.Exercise);
        }
        public override bool IsSame(BaseCard b)
        {
            return int.Parse(dt.Compute(Exercise, "").ToString()) == ((ExerciseCard)b).Result;
        }
        public override BaseCard Init()
        {
            Random rand = new Random();
            int num1 = rand.Next(1, 10);
            int num2 = rand.Next(1, 10);
            char oper = operators[rand.Next(0, 4)];
            string exercise = num1.ToString() + oper + num2.ToString();
            return new ExerciseCard(exercise, int.Parse(dt.Compute(exercise, "").ToString()), Isvisible.Hidden, FirstOrsecond.First);
        }
        public override BaseCard InitCopy(BaseCard b)
        {
            return new ExerciseCard(((ExerciseCard) b).Exercise, ((ExerciseCard)b).Result, Isvisible.Hidden, FirstOrsecond.Second);
        }
    }
}
