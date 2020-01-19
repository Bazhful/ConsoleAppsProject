using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppsProject.ProjectCalculator;
using System.Threading;

namespace ConsoleAppsProject
{
    class Loader
    {
    public static void ClearCurrentConsoleLine()
    {
      int currentLineCursor = Console.CursorTop;
      Console.SetCursorPosition(0, Console.CursorTop);
      Console.Write(new string(' ', Console.WindowWidth));
      Console.SetCursorPosition(0, currentLineCursor);
    }

    public void Launcher()
        {
      
      Console.Clear();
      Console.WriteLine("Project aApp Launcher!");
      Console.WriteLine("--------------------------------------------------------");
      Console.WriteLine("Select the Project! (Type the number of the project)");
      Console.WriteLine("1: Calculator App");
      Console.WriteLine("2: Project2");
      Console.WriteLine("3: Project3\n");
      Console.WriteLine("------------------------");


      do {
        for (int p = 0; p < 2; p++)
        {
          while (Console.CapsLock == true)
          {
            ClearCurrentConsoleLine();
            Console.Write("Caps activated! PLEASE DEACTIVATE IT!");
            Console.SetCursorPosition(0, 8);
            break;
          }
      
          Thread.Sleep(100);
        }
      } while (Console.CapsLock == true);

      ClearCurrentConsoleLine();
      string input = Console.ReadLine();
      while (int.TryParse(input, out int n) == false)
            {
             Console.WriteLine("Try again, u need to use numbers");
             break;
            }
        int app = Int32.Parse(input);

            switch (app)
            {
        case 1:
          Calculator();
          break;
        case 2:
          Project2();
          break;
        case 3:
          Project3();
          break;
        default:
          Launcher();
          break;
            }


        }

       
        public void Calculator()
        {
            Calc calc = new Calc();
            calc.NewCalculation();
        }

        public void Project2()
        {


        }
        public void Project3()
        {


        }

    }

       
}
