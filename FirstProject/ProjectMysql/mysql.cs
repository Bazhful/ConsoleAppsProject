using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Threading;
using System.Configuration;
using ConsoleAppsProject.RandomClasses;

namespace ConsoleAppsProject.ProjectMysql
{
  public class Mysql
  {

    protected string dbhostname = "";
    protected string database = "";
    protected string dbusername = "";
    protected string dbpassword = "";
    private SQLConnection connection = new SQLConnection();

    public void MainSQL() 
    {     
      Console.Clear();
      Console.WriteLine("MySQL Controller!\n");
      Console.WriteLine("Here you can search, insert, update, etc your own " +
                "database");
      Console.WriteLine("------------------------------------------------------");
      Console.WriteLine("First of all. We will need some information regarding your MySQL Database!");
      Console.WriteLine("Please Enter your MySQL Hostname ");
      Console.Write("Select: "); dbhostname = Console.ReadLine();
      Console.WriteLine("\nPlease Enter your MySQL Username");
      Console.Write("Select: "); dbusername = Console.ReadLine();
      Console.WriteLine("\nPlease Enter what Database you want to use!");
      Console.Write("Select: "); database = Console.ReadLine();
      Console.WriteLine("\nPlease Enter your MySQL Password");
      Console.Write("Select: "); dbpassword = Console.ReadLine();
      Console.WriteLine("\nThis is what you have selected is it correct [Password is hidden]");
      Console.WriteLine($"SERVER = {dbhostname} \nDATABASE = {database} \nUID = {dbusername}");
      Console.WriteLine("Is this Information correct, type 'Yes' if you want to change something type 'No'");
      Console.Write("Select: ");  string check_correct = Console.ReadLine();
      check_correct = check_correct.ToLower();

      if (check_correct == "yes")
      {
        SecondarySQL();
      }

      else
      {
        MainSQLNo();
      }
    }
    public void SecondarySQL()
    {
      Console.Clear();
      Console.WriteLine("This is the actual controlpanel, here you will be able to edit your MySQL database. Everything from searching to adding to modifying.");
      Console.WriteLine("Please Select one of the Options Below!");
      Console.WriteLine("1: List All Tables");
      Console.WriteLine("2: List/Search Table Content");
      Console.WriteLine("3: Update");
      Console.WriteLine("4: Exit");
      Console.WriteLine("5: Insert");
      Console.WriteLine("6: Exit");
      Console.WriteLine("------------------------------------------------------");
      Console.Write("Select: ");  string input = Console.ReadLine();
      while (int.TryParse(input, out int n) == false)
      {
        Console.WriteLine("Try again, u need to use numbers!");
        Console.ReadKey();
        SecondarySQL();
      }
      //This is number 1, for selecting error. 
      int number1 = Int32.Parse(input);

      switch (number1)
      {
        case 1:
          SQLList();
          break;
        case 2:
            SQLTableList();
          break;
        case 3:
          SQLTableList();
          break;
        case 4:
          SQLUpdate();
          break;
        case 5:
          SQLInsert();
          break;
        case 6:
          Environment.Exit(0);
          break;
        default:
          Console.WriteLine("You did not pick a number between 1-4");
          SecondarySQL();
          break;

      }
    }

    public void MainSQLNo()
    {
      Console.Clear();
      Console.WriteLine("Which one wasnt correct?");
      Console.WriteLine($"1: Hostname, The current hostname is = {dbhostname}");
      Console.WriteLine($"2: Database, The current database is = {database}");
      Console.WriteLine($"3: Username, The current username is = {dbusername}");
      Console.WriteLine($"4: Password, if none of the above is incorrect your password might be.");
      Console.WriteLine("\n5: Everything is Correct, LETS MOVE ON!");
      Console.WriteLine("------------------------------------------------------");
      Console.WriteLine("Which one would u like to change!");
      Console.Write("Select: ");  string input = Console.ReadLine();
      while (int.TryParse(input, out int n) == false)
      {
        Console.WriteLine("Try again, u need to use numbers!");
        MainSQLNo();
      }
      //This is number 1, for selecting error. 
      int number1 = Int32.Parse(input);

      switch (number1)
      {
        case 1:
          Console.WriteLine("Please Enter your MySQL Hostname ");
          Console.Write("Select: "); dbhostname = Console.ReadLine();
          MainSQLNo();
          break;
        case 2:
          Console.WriteLine("\nPlease Enter your MySQL Username");
          Console.Write("Select: "); dbusername = Console.ReadLine();
          MainSQLNo();
          break;
        case 3:
          Console.WriteLine("\nPlease Enter what Database you want to use!");
          Console.Write("Select: "); database = Console.ReadLine();
          MainSQLNo();
          break;
        case 4:
          Console.WriteLine("\nPlease Enter your MySQL Password");
          Console.Write("Select: "); dbpassword = Console.ReadLine();
          MainSQLNo();
          break;
        case 5:
          SecondarySQL();
          break;
        default:
          Console.WriteLine("You did not pick a number between 1-5");
          MainSQLNo();
          break;
         
      }
     
    }
 
    public void SQLList()
    {
        Console.Clear();   
        MySqlCommand cmd = new MySqlCommand("show tables", connection.ConnectionOpen(true));
        MySqlDataReader reader = cmd.ExecuteReader();
        int count = 0;
      //This loops for all rows in the database
      while (reader.Read())
      {        
        //This count the amount of columns in the current row.
        for (int i = 0; i < reader.FieldCount; i++)
        {
          //This Gets the value of the colum in the current row, and displays it in console form.
          Console.WriteLine($"Table[{count}]:{reader.GetValue(i)}");
          count++;
        }
      }
      connection.ConnectionOpen(false);
      Console.WriteLine("Press any key to continue!");
      Console.ReadKey();
      SecondarySQL();
    }
    public void SQLTableList()
    {
      Console.Clear();
      Console.WriteLine("Please enter what column u want to search, or use '*' for all columns, if u have multiple columns use , after every column like this -> (id, movie)");
      Console.Write("Select: "); string row = Console.ReadLine();
      Console.WriteLine("-------------------------");
      Console.WriteLine("Please Enter the Table Name that you want to search in, or type '*' if u wanna search in all tables.");
      Console.Write("Select: "); string table = Console.ReadLine();
      Console.WriteLine("-------------------------");
      Console.WriteLine("Please Enter What you want to search for!");
      Console.WriteLine("Leave empty if u dont want to search for anything specific and you just wanna list all  the content from your table and column that you have selected");
      Console.WriteLine("Exampel. If u wanna find all occurences where idUser = 2, type 'idUser=2'");
      Console.Write("Select: "); string search = Console.ReadLine();
      if (String.IsNullOrEmpty(search))
      {
        CommandList(row, table);
      }
      if (!String.IsNullOrEmpty(search))
      {
        CommandSearch(row, table, search);
      }
    }
    public void SQLUpdate()
    {
      Console.Clear();

    }

    public void SQLInsert()
    {
      Console.Clear();
    }
    ///<summary>Opens/Closes Connection to MySQL, Insert bool value with either false to close or true to open the MYSQL connection </summary>

/// <summary>
/// Method, for running MYSQL command with WHERE, "SELECT row FROM table WHERE x=x"
/// </summary>
/// <param name="row"></param>
/// <param name="table"></param>
/// <param name="search"></param>
/// <returns></returns>
    public MySqlCommand CommandSearch(string row, string table, string search)
    {
      MySqlCommand cmd = new MySqlCommand($"SELECT {row} FROM {table} WHERE {search}", connection.ConnectionOpen(true)); //Make this into a function

      MySqlDataReader reader = cmd.ExecuteReader();
      //This loops for all rows in the database
      Console.Clear();
      for (int i = 0; i < reader.FieldCount; i++)
      {
        Console.Write($"{reader.GetName(i),-15}");
      }
      Console.WriteLine("\n---------------------");
      while (reader.Read())
      {
        //This count the amount of columns in the current row.
        for (int i = 0; i < reader.FieldCount; i++)
        {
          //This Gets the value of the colum in the current row, and displays it in console form.
          var x = reader.GetString(i);
          //var p = 15.Adddition(5); Trying some stupid stuff out.
          string lol = $"{x}".LimitLength(15);
          Console.Write($"{lol,-15}");
          /*if (x.Length <= 5) 
          {
            Console.WriteLine(x);
          }
          else 
          {
            Console.WriteLine(x.Substring(0, 5));
          }  This is a way to convert the amount of characters in a string */
          //Console.WriteLine($"{reader.(i)}");
          // Console.Write($"{reader.GetValue(i), -15}");
        }
        Console.WriteLine("\n---------------------");
      }
      connection.ConnectionOpen(true);
      Console.WriteLine("Press any key to continue!");
      Console.ReadKey();
      SecondarySQL();
      return cmd;
    }
/// <summary>
/// Method, for running MYSQL Command that only takes in row and table from SELECT  "SELECT row FROM TABLE"
/// </summary>
/// <param name="row"></param>
/// <param name="table"></param>
/// <returns></returns>
    public MySqlCommand CommandList(string row, string table)
    {
      MySqlCommand cmd = new MySqlCommand($"SELECT {row} FROM {table}", connection.ConnectionOpen(true)); //Make this into a function
      MySqlDataReader reader = cmd.ExecuteReader();
      //This loops for all rows in the database
      Console.Clear();
      for (int i = 0; i < reader.FieldCount; i++)
      {
        Console.Write($"{reader.GetName(i),-15}");

      }
      Console.WriteLine("\n---------------------");
      while (reader.Read())
      {
        //This count the amount of columns in the current row.
        for (int i = 0; i < reader.FieldCount; i++)
        {
          //This Gets the value of the colum in the current row, and displays it in console form.
          var x = reader.GetString(i);
          string lol = $"{x}".LimitLength(15);
          Console.Write($"{lol,-15}");
          /*if (x.Length <= 5) 
          {
            Console.WriteLine(x);
          }
          else 
          {
            Console.WriteLine(x.Substring(0, 5));
          }  This is a way to convert the amount of characters in a string */
          //Console.WriteLine($"{reader.(i)}");
          // Console.Write($"{reader.GetValue(i), -15}");
        }
        Console.WriteLine("\n---------------------");
      }
      connection.ConnectionOpen(true);
      Console.WriteLine("Press any key to continue!");
      Console.ReadKey();
      SecondarySQL();
      return cmd;
    }
  }
} 

