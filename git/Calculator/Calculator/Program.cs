using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{

    class Calculator
    {
        double n1 = 0;
        string operation = null;
        double n2;
        public Calculator()
        {
            Console.WriteLine(n1);
        }
        double doOperation()
        {
            switch (operation)
            {
                case "+":
                    return n1 + n2;
                case "*":
                    return n1 * n2;
                case "-":
                    return n1 - n2;
                case "/":
                    return n1 / n2;
                default: return 0;
            }

        }
        public void Enter()
        {
            string str = Console.ReadLine().Replace('.', ',').Replace(" ","");
            try
            {
                if (str.Length == 1 && "+-/*".Contains(str))
                {
                    operation = str;
                }
                else if (operation is null)
                {
                    n1 = Double.Parse(str);
                    Console.Clear();
                    Console.WriteLine("new value intered: " + n1);
                    Console.WriteLine(n1);
                }
                else
                {
                    Console.Clear();
                    n2 = Double.Parse(str);
                    if (n2 == 0 && operation == "/")
                    {
                        Console.WriteLine("Divide by 0!");
                        Console.WriteLine(n1 = 0);
                    }else
                        Console.WriteLine("{0} {1} {2} = {3}\n{4}", n1, operation, n2, n1 = doOperation(),n1);
                    operation = null;
                }
            }
            catch (Exception)
            {
                Console.Clear();
                operation = null;
                Console.WriteLine("\"{0}\" isn't number or avaliable operation", str);
                Console.WriteLine(n1);
            }
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Calculator";
            Calculator calc = new Calculator();
            while (true)
            {
                calc.Enter();
            }
        }
    }
}
