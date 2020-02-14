using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Threading;

namespace ConsoleAppsProject.ProjectMysql
{
  public class Mysql
  {

    private string dbhostname = "";
    private string database = "";
    private string dbusername = "";
    private string dbpassword = "";
   

    public void MainSQL() 
    {     
      Console.Clear();
      Console.WriteLine("MySQL Controller!\n");
      Console.WriteLine("Here you can search, insert, update, etc your own " +
                "database");
      Console.WriteLine("------------------------------------------------------");
      Console.WriteLine("First of all. We will need some information regarding your MySQL Database!");
      Console.WriteLine("Please Enter your MySQL Hostname ");
      dbhostname = Console.ReadLine();
      Console.WriteLine("\nPlease Enter your MySQL Username");
      dbusername = Console.ReadLine();
      Console.WriteLine("\nPlease Enter what Database you want to use!");
      database = Console.ReadLine();
      Console.WriteLine("\nPlease Enter your MySQL Password");
      dbpassword = Console.ReadLine();
      Console.WriteLine("\nThis is what you have selected is it correct [Password is hidden]");
      Console.WriteLine($"SERVER = {dbhostname} \nDATABASE = {database} \nUID = {dbusername}");
      Console.WriteLine("Is this Information correct, type 'Yes' if you want to change something type 'No'");
      string check_correct = Console.ReadLine();
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
      Console.WriteLine("2: Search");
      Console.WriteLine("3: Update");
      Console.WriteLine("4: Insert");
      Console.WriteLine("------------------------------------------------------");
      string input = Console.ReadLine();
      while (int.TryParse(input, out int n) == false)
      {
        Console.WriteLine("Try again, u need to use numbers!");
      }
      //This is number 1, for selecting error. 
      int number1 = Int32.Parse(input);

      switch (number1)
      {
        case 1:
          SQLList();
          break;
        case 2:
          SQLSearch();
          break;
        case 3:
          SQLUpdate();
          break;
        case 4:
          SQLInsert();
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
      string input = Console.ReadLine();
      while (int.TryParse(input, out int n) == false)
      {
        Console.WriteLine("Try again, u need to use numbers!");
      }
      //This is number 1, for selecting error. 
      int number1 = Int32.Parse(input);

      switch (number1)
      {
        case 1:
          Console.WriteLine("Please Enter your MySQL Hostname ");
          dbhostname = Console.ReadLine();
          MainSQLNo();
          break;
        case 2:
          Console.WriteLine("\nPlease Enter your MySQL Username");
          dbusername = Console.ReadLine();
          MainSQLNo();
          break;
        case 3:
          Console.WriteLine("\nPlease Enter what Database you want to use!");
          database = Console.ReadLine();
          MainSQLNo();
          break;
        case 4:
          Console.WriteLine("\nPlease Enter your MySQL Password");
          dbpassword = Console.ReadLine();
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
      string conn = ($"SERVER={dbhostname};DATABASE={database};UID={dbusername};PASSWORD={dbpassword};");
        Console.Clear();   
        MySqlConnection connection = new MySqlConnection(conn);
        connection.Open();
        MySqlCommand cmd = new MySqlCommand("show tables", connection);
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
      connection.Close();
    }


    public void SQLSearch()
    {
      string conn = ($"SERVER={dbhostname};DATABASE={database};UID={dbusername};PASSWORD={dbpassword};");
      Console.Clear();
    }

    public void SQLUpdate()
    {
      string conn = ($"SERVER={dbhostname};DATABASE={database};UID={dbusername};PASSWORD={dbpassword};");
      Console.Clear();
    }

    public void SQLInsert()
    {
      string conn = ($"SERVER={dbhostname};DATABASE={database};UID={dbusername};PASSWORD={dbpassword};");
      Console.Clear();
    }
  }
}
