using System;
using System.Dynamic;
using System.Net.NetworkInformation;

namespace MathApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            char choice = ' ';
            int lhs = 0;
            int rhs = 0;
            int result = 0;


            do   // Allows user to continue doing equations until an "x" is or gibberish entered, which stops program.
            {
                choice = OperatorInput();

                switch (choice)
                {
                    case '+':   // All code within a switch statement MUST be inside a case statement.
                        (lhs, rhs) = GetNumbers(choice);
                        result = DoAdd(lhs, rhs);
                        break;

                    case '-':
                        (lhs, rhs) = GetNumbers(choice);
                        result = DoSubtract(lhs, rhs);
                        break;

                    case '*':
                        (lhs, rhs) = GetNumbers(choice);
                        result = DoMultiply(lhs, rhs);
                        break;

                    case '/':
                        (lhs, rhs) = GetNumbers(choice);
                        result = DoDivide(lhs, rhs);
                        break;

                    case '%':
                        (lhs, rhs) = GetNumbers(choice);
                        result = DoModulus(lhs, rhs);
                        break;

                    case 'x':
                        Console.WriteLine("Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Thanks for stopping by!");
                        return;

                }
                Console.WriteLine($"{lhs} {choice} {rhs} = {result}");
                Console.WriteLine("");

            } while (choice == '+' || choice == '-' || choice == '*' || choice == '/' || choice == '%');   // Allows user to continue doing equations until an "x" or gibberish is entered, which stops program.

        } // End Main

        static char OperatorInput()
        {
            string input;
            Console.Write("Please enter mathematical operator " +
                "(+, -, *, /, %, or 'x' to exit): ");
            input = Console.ReadLine();
            return input[0];
        }

        static (int, int) GetNumbers(char oper)
        {
            try
            {
                int lhs = 0;
                int rhs = 0;

                Console.Write("What is your first number: ");
                lhs = Convert.ToInt32(Console.ReadLine());
                do
                {
                    Console.Write("What is your second number: ");
                    rhs = Convert.ToInt32(Console.ReadLine());
                    if (rhs == 0 && oper == '/')
                    {
                        Console.WriteLine("You cannot divide by zero!");
                    }
                } while (rhs == 0 && oper == '/');
                if (lhs % 1 != 0 || rhs % 1 != 0)
                {
                    Console.WriteLine("You must use integers for both numbers.  Please try again.");
                }
                return (lhs, rhs);
            }
            catch (FormatException)
            {
                Console.WriteLine("You must use integers for both numbers.");
                return (0, 0);
            }
        }

        static int DoAdd(int lhs, int rhs)
        {
            return lhs + rhs;
        }

        static int DoSubtract(int lhs, int rhs)
        {
            return lhs - rhs;
        }

        static int DoMultiply(int lhs, int rhs)
        {
            return lhs * rhs;
        }

        static int DoDivide(int lhs, int rhs)
        {
            return lhs / rhs;
        }

        static int DoModulus(int lhs, int rhs)
        {
            return lhs % rhs;
        }

    }
}
