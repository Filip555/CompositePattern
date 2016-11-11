using System;

namespace CompositePattern
{
    class Program
    {
        // Component - Common interface for nodes and leafs
        public interface IOperation
        {
            // Calculate the value of expresseion
            double Calculate();

            // display expression
            string Show();
        }
        //leaf
        public class Number : IOperation
        {
            public double a { get; set; }
            public Number(double _a)
            {
                a = _a;
            }
            public double Calculate()
            {
                return a;
            }

            public string Show()
            {
                return a.ToString();
            }
        }
        //composite
        public class Div : IOperation
        {
            public IOperation b1 { get; set; }
            public IOperation b2 { get; set; }

            public Div(IOperation a1, IOperation a2)
            {
                b1 = a1;
                b2 = a2;
            }
            public double Calculate()
            {
                return b1.Calculate() / b2.Calculate();
            }

            public string Show()
            {
                return "(" + b1.Show() + "/" + b2.Show() + ")";
            }
        }
        //composite
        public class Add : IOperation
        {
            public IOperation b1 { get; set; }
            public IOperation b2 { get; set; }

            public Add(IOperation a1, IOperation a2)
            {
                b1 = a1;
                b2 = a2;
            }
            public double Calculate()
            {
                return b1.Calculate() + b2.Calculate();
            }

            public string Show()
            {
                return "(" + b1.Show() + "+" + b2.Show() + ")";
            }
        }
        //composite
        public class Multi : IOperation
        {
            public IOperation b1 { get; set; }
            public IOperation b2 { get; set; }

            public Multi(IOperation a1, IOperation a2)
            {
                b1 = a1;
                b2 = a2;
            }
            public double Calculate()
            {
                return b1.Calculate() * b2.Calculate();
            }

            public string Show()
            {
                return "(" + b1.Show() + "*" + b2.Show() + ")";
            }
        }
        //composite
        public class Sub : IOperation
        {
            public IOperation b1 { get; set; }
            public IOperation b2 { get; set; }

            public Sub(IOperation a1, IOperation a2)
            {
                b1 = a1;
                b2 = a2;
            }
            public double Calculate()
            {
                return b1.Calculate() - b2.Calculate();
            }

            public string Show()
            {
                return "(" + b1.Show() + "-" + b2.Show() + ")";
            }
        }
        //client
        static void Main(string[] args)
        {
            // build the following expression ((((2+5)-1)*4)/3)
            Number a = new Number(2);
            Number b = new Number(5);
            Add addition = new Add(a, b);

            Number c = new Number(1);
            Sub subtraction = new Sub(addition, c);

            Number d = new Number(4);
            Multi multiplication = new Multi(subtraction, d);

            Number e = new Number(3);
            Div division = new Div(multiplication, e);

            Console.WriteLine("\nResult of: {0} is: {1}\n", division.Show(), division.Calculate());
            Console.WriteLine("Result of: {0} is: {1}", multiplication.Show(), multiplication.Calculate());

            Console.ReadKey();
        }
    }
}

