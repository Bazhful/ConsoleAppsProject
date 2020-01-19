using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppsProject;

namespace ConsoleAppsProject.ProjectCalculator
{
    public class Calc
    {
        //main function, Call this to run calc app.
        public void NewCalculation()
        {
            Console.Clear();
            Console.WriteLine("Calculator");
            Console.WriteLine("--------------------");
            Console.WriteLine("Please Pick one of the Options!");
            Console.WriteLine("1: Addition");
            Console.WriteLine("2: Subtraction");
            Console.WriteLine("3: Division");
            Console.WriteLine("4: Mulitplication");
            Console.WriteLine("5: Power of X");
            string input = Console.ReadLine();
            
            while(int.TryParse(input, out int n) == false)
            {
                Console.WriteLine("Try again, u need to use numbers");
            }

            int oper = Int32.Parse(input);


            Console.WriteLine("\n Please pick your First Number!");
            input = Console.ReadLine();
            while(int.TryParse(input, out int n) == false)
            {
                Console.WriteLine("Try again, u need to use numbers!");
            }
            int number1 = Int32.Parse(input);
            Console.WriteLine("\n Please pick your Secound Number!");
            input = Console.ReadLine();
            while (int.TryParse(input, out int n) == false)
            {
                Console.WriteLine("Try again, u need to use numbers!");
            }
            int number2 = Int32.Parse(input);

            switch(oper){
                case 1:
                    Add(number1, number2);
                    break;
                case 2:
                    Sub(number1, number2);
                    break;
                case 3:
                    Divider(number1, number2);
                    break;
                case 4:
                    Multi(number1, number2);
                    break;
                case 5:
                    Power(number1, number2);
                    break;
                default:
                    Console.WriteLine("You did not pick a number between 1-5");
                    break;
            }
            
            Console.WriteLine("Type 'Yes' if u wanna restart the calculator");
            string restart_check = Console.ReadLine();
            restart_check = restart_check.ToLower();

            while (restart_check == "yes") 
            {
                NewCalculation();
            }
        }

        public int Add(int x, int y)
        {
            int number = x + y;
            Show(number);
            return number;
            
        }

        public int Sub(int x, int y)
        {
            int number = x - y;
            Show(number);
            return number;
        }

        public int Divider(int x, int y)
        {
            int number = x / y;
            Show(number);
            return number;
        }

        public int Multi(int x, int y)
        {
            int number = x * y;
            Show(number);
            return number;

        }

        public int Power(int x, int y)
        {
            int number = 1;
            for (int count = 0; count < y; count++)
            {
                number *= x;
            }
            Show(number);
            return number;
        }

        public int Show(int x)
        {

            int number = x;
            Console.WriteLine("\n According to my calculations, your number should be = " + number);
            Console.WriteLine("Type 'Yes' if u wanna restart the calculator, Type 'No' if u wish to terminate the program!, Type 'Back' if u wanna go back to the launcher!");
            string restart_check = Console.ReadLine();
            restart_check = restart_check.ToLower();
            switch(restart_check)
            {
                case "yes":
                    NewCalculation();
                    break;
                case "no":
                    Environment.Exit(0);
                    break;
                case "back":
                    Loader loader = new Loader();
                    loader.Launcher();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
            return number;
        }

    }
}
