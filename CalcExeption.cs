using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonEight
{
    internal class CalcExeption : Exception
    {
        public CalcExeption(string? message, Stack<CalcActionLog> actionLogs) : base(message) 
        {
            ActionLogs = actionLogs;
        }
        public CalcExeption(string? message, Exception? ex) : base(message, ex)
        {

        }
        public Stack<CalcActionLog> ActionLogs { get; private set; }

        public override string ToString()
        {
            return Message + ": " + string.Join("\n", ActionLogs.Select(x => $"Exeption: {x.CalcAction} {x.ClacArgument}"));
        }
    }
    internal class CalculatorDivideByZeroException : CalcExeption
    {
        public CalculatorDivideByZeroException(string message, Stack<CalcActionLog> actionLogs): base(message, actionLogs)
        {
            
        }
        public CalculatorDivideByZeroException(string message, Exception ex) : base(message, ex)
        {

        }
    }
    internal class CalculateOperationCauseOverflowException : CalcExeption
    {
        public CalculateOperationCauseOverflowException(string message, Stack<CalcActionLog> actionLogs) : base(message, actionLogs)
        {

        }
        public CalculateOperationCauseOverflowException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
