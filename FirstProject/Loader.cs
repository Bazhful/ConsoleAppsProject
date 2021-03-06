﻿using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppsProject.ProjectCalculator;
using System.Threading;
using ConsoleAppsProject.ProjectMysql;
using System.Threading.Tasks;
using ConsoleAppsProject.RandomClasses;

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
      Console.WriteLine("Project App Launcher!");
      Console.WriteLine("--------------------------------------------------------");
      Console.WriteLine("Select the Project! (Type the number of the project)");
      Console.WriteLine("1: Calculator App");
      Console.WriteLine("2: MySQL Controller");
      Console.WriteLine("3: Project3\n");
     // SetInterval(() => Console.WriteLine("------------------------"), TimeSpan.FromSeconds(5));
     //SetInterval(() => Console.WriteLine("Hello World"), TimeSpan.FromSeconds(15));


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

      Console.Write("Select: "); string input = Console.ReadLine();
      while (int.TryParse(input, out int n) == false)
            {
             Console.WriteLine("Try again, u need to use numbers");
             break;
            }
        int app = Int32.Parse(input);

            switch (app)
            {
        case 1:
          Calc calc = new Calc();        
          calc.NewCalculation();
          break;
        case 2:
          Mysql mysql = new Mysql();
          mysql.MainSQL();
          break;
        case 3:
          Project3();
          break;
        default:
          Launcher();
          break;
            }
        }
   
    public void Project3()     
    {
      Display display = new Display();
      display.SendDetails();
    }
    public static async Task SetInterval(Action action, TimeSpan timeout)
    {
      await Task.Delay(timeout).ConfigureAwait(false);

      action();

      //Action is what its going to do and the timeout is how long its supposed to wait before performing that action again.
     await SetInterval(action, timeout);
    }

  }



       
}
