using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppsProject.ProjectMysql;
using MySql.Data.MySqlClient;
namespace ConsoleAppsProject.RandomClasses
{
  public class SQLConnection : Mysql
  {
    public int number;
    ///<summary>Opens Connection to MySQL</summary>
    public MySqlConnection ConnectionOpen(bool statement)
    {
      Mysql mysql = new Mysql();
      string conn = ($"SERVER={dbhostname};DATABASE={database};UID={dbusername};PASSWORD={dbpassword};");
      MySqlConnection connection = new MySqlConnection(conn);

      if (statement == true)
      {
        try
        {
          connection.Open();
        }
        catch (Exception e)
        {
          Console.WriteLine(e.Message);
        }
      }
      else if (statement == false)
      {
        try
        {
          connection.Close();
        }
        catch (Exception e)
        {
          Console.WriteLine(e.Message);
        }

      }
      return connection;
    }
  }
}
