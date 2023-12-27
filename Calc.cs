using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonEight
{
    //TaskOne
    //Доработайте реализацию калькулятора разработав собственные типы ошибок.
    //CalculatorDivideByZeroException
    //CalculateOperationCauseOverflowException

    //TaskTwo
    //В прошлой лекции мы реализовали метод CancelLast позволяющий
    //отменить любое сделанное действие.Реализуйте класс - список,
    //описывающий последовательность действий приведших исключению.
    //Очевидно что класс калькулятора должен быть доработан чтобы
    //хранить не только информацию необходимую нам для отмены но и
    //информацию о самом действии. Продумайте как лучше это реализовать.
    internal class Calc : ICalc
    {
        public event EventHandler<EventArgs>? GotResult;
        readonly Stack<int> IntResults = new();
        readonly Stack<double> DoubleResults = new();
        public int IntResult = 0;
        public double DoubleResult = 0;
        public Stack<CalcActionLog> Log = new();

        public void Divide(int value)
        {
            if (value == 0)
            {
                Log.Push(new CalcActionLog(CalcAction.Divide, value));
                throw new CalculatorDivideByZeroException("На ноль делить нельзя!", Log);
            }
            IntResults.Push(IntResult);
            IntResult /= value;
            RaiseEvent();
        }
        public void Divide(double value)
        {
            if (value == 0)
            {
                Log.Push(new CalcActionLog(CalcAction.Divide, value));
                throw new CalculatorDivideByZeroException("На ноль делить нельзя!", Log);
            }
            DoubleResults.Push(DoubleResult);
            DoubleResult /= value;
            RaiseEvent();
        }

        public void Multiply(int value)
        {
            ulong temp = (ulong)(value * IntResult);
            if (temp > int.MaxValue)
            {
                Log.Push(new CalcActionLog(CalcAction.Multiply, value));
                throw new CalculateOperationCauseOverflowException("Переполнение....", Log);
            }
            if (value == 0)
            {
                Log.Push(new CalcActionLog(CalcAction.Multiply, value));
                throw new CalculatorDivideByZeroException("На ноль делить нельзя!", Log);
            }
            IntResults.Push(IntResult);
            IntResult *= value;
            RaiseEvent();
        }
        public void Multiply(double value)
        {
            ulong temp = (ulong)(value * DoubleResult);
            if (temp > double.MaxValue)
            {
                Log.Push(new CalcActionLog(CalcAction.Multiply, value));
                throw new CalculateOperationCauseOverflowException("Переполнение....", Log);
            }
            if (value == 0)
            {
                Log.Push(new CalcActionLog(CalcAction.Multiply, value));
                throw new CalculatorDivideByZeroException("На ноль делить нельзя!", Log);
            }
            DoubleResults.Push(DoubleResult);
            DoubleResult *= value;
            RaiseEvent();
        }

        public void Substruct(int value)
        {
            long temp = IntResult - value;
            if (temp < int.MinValue || (IntResult == int.MinValue && value == int.MaxValue))
            {
                Log.Push(new CalcActionLog(CalcAction.Substruct, value));
                throw new CalculateOperationCauseOverflowException("Переполнение....", Log);
            }
            IntResults.Push(IntResult);
            IntResult -= value;
            RaiseEvent();
        }
        public void Substruct(double value)
        {
            ulong temp = (ulong)(DoubleResult - value);
            if (temp < double.MinValue || (IntResult == double.MinValue && value == double.MaxValue))
            {
                Log.Push(new CalcActionLog(CalcAction.Substruct, value));
                throw new CalculateOperationCauseOverflowException("Переполнение....", Log);
            }
            DoubleResults.Push(DoubleResult);
            DoubleResult -= value;
            RaiseEvent();
        }

        public void Sum(int value)
        {
            ulong temp = (ulong)(value + IntResult);
            if (temp > int.MaxValue)
            {
                Log.Push(new CalcActionLog(CalcAction.Sum, value));
                throw new CalculateOperationCauseOverflowException("Переполнение....", Log);
            }
            IntResults.Push(IntResult);
            IntResult += value;
            RaiseEvent();
        }
        public void Sum(double value)
        {
            ulong temp = (ulong)(value + DoubleResult);
            if (temp > double.MaxValue)
            {
                Log.Push(new CalcActionLog(CalcAction.Sum, value));
                throw new CalculateOperationCauseOverflowException("Переполнение....", Log);
            }
            DoubleResults.Push(DoubleResult);
            DoubleResult += value;
            RaiseEvent();
        }


        private void RaiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }

        public void CancelLast()
        {
            IntResult = IntResults.Pop();
            RaiseEvent();
        }
    }
}
