using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonEight
{
    internal enum CalcAction
    {
        Sum,
        Substruct,
        Multiply,
        Divide
    }
    internal class CalcActionLog
    {
        public CalcActionLog(CalcAction calcActions, int calcArgument)
        {
            CalcAction = calcActions;
            ClacArgument = calcArgument;
        }
        public CalcActionLog(CalcAction calcActions, double calcArgument)
        {
            CalcAction = calcActions;
            DoubleClacArgument = calcArgument;
        }
        public CalcAction CalcAction {get; private set;}
        public int ClacArgument { get; private set;}
        public double DoubleClacArgument { get; private set; }


    }
}
