using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Interpreter
{
    public class Context
    {
        public Context(String input)
        {
            this.Input = input;
        }

        public String Input { get; set; }
        public int Output { get; set; }
    }


    #region Expression & subclass
    public abstract class AbstractExpression
    {
        public abstract void interpret(Context context);
    }

    public class PlusExpression : AbstractExpression
    {
        public override void interpret(Context context)
        {
            System.Diagnostics.Debug.WriteLine("PlusExpression ++");
            String input = context.Input;
            int parsedResult = int.Parse(input);
            parsedResult++;
            context.Input = parsedResult.ToString();
            context.Output = parsedResult;
        }
    }

    public class MinusExpression : AbstractExpression
    {
        public override void interpret(Context context)
        {
            System.Diagnostics.Debug.WriteLine("PlusExpression --");
            String input = context.Input;
            int parsedResult = int.Parse(input);
            parsedResult--;
            context.Input = parsedResult.ToString();
            context.Output = parsedResult;
        }
    }
    #endregion
}
