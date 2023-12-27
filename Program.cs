namespace LessonEight
{
    internal class Program
    {
        static void Calculator_GotResult(object sender, EventArgs eventArgs) 
        {
            Console.WriteLine($"result = {((Calc)sender).IntResult}");
        }
        static void Executive(Action<int> action, int value = 0)
        {
            try
            {
                action.Invoke(value);
            }
            catch (CalculatorDivideByZeroException ex)
            {
                Console.WriteLine(ex);
            }
            catch(CalculateOperationCauseOverflowException ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void Main(string[] args)
        {
            ICalc calc = new Calc();
            calc.GotResult += Calculator_GotResult;

            Executive(calc.Sum, int.MaxValue);
            Executive(calc.Sum, int.MaxValue);
            Executive(calc.Divide);
            Executive(calc.Multiply, 10);





        }
    }
}
