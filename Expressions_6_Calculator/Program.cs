using Expression = NCalc.Expression;

namespace Expressions_6_Calculator
{
    public class Calculator
    {
        public string InputText { get; set; }
        public string CalculatedResult { get; set; }
        private bool isSciOpWaiting = false;

        public Calculator()
        {
            InputText = "";
            CalculatedResult = "0";
        }

        public void Reset()
        {
            CalculatedResult = "0";
            InputText = "";
            isSciOpWaiting = false;
        }

        public void Calculate()
        {
            if (InputText.Length == 0)
                return;

            if (isSciOpWaiting)
            {
                InputText += ")";
                isSciOpWaiting = false;
            }

            try
            {
                var inputString = NormalizeInputString();
                Expression expression = new Expression(inputString);
                var result = expression.Evaluate();
                CalculatedResult = result.ToString();
            }
            catch (Exception)
            {
                CalculatedResult = "NaN";
            }
        }

        private string NormalizeInputString()
        {
            Dictionary<string, string> _opMapper = new()
            {
                {"×", "*"},
                {"÷", "/"},
                {"SIN", "Sin"},
                {"COS", "Cos"},
                {"TAN", "Tan"},
                {"ASIN", "Asin"},
                {"ACOS", "Acos"},
                {"ATAN", "Atan"},
                {"LOG", "Log"},
                {"EXP", "Exp"},
                {"LOG10", "Log10"},
                {"POW", "Pow"},
                {"SQRT", "Sqrt"},
                {"ABS", "Abs"},
            };

            var retString = InputText;

            foreach (var key in _opMapper.Keys)
            {
                retString = retString.Replace(key, _opMapper[key]);
            }

            return retString;
        }

        public void StartConsoleApp()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Kalkulyator (Chiqish uchun 'exit' deb yozing)");
                Console.WriteLine("Joriy ifoda: " + InputText);
                Console.WriteLine("Natija: " + CalculatedResult);
                Console.WriteLine("Hisoblashni amalga oshirish uchun formulani kiriting:");

                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "exit")
                    break;

                InputText = userInput;
                Calculate();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            calculator.StartConsoleApp();
        }
    }
}
