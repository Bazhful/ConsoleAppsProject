using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppsProject.ProjectMysql;

namespace ConsoleAppsProject.RandomClasses
{
  public static class StringExtensions
  {
    /// <summary>Method that limits the length of text to a defined length.</summary>
        public static string LimitLength(this string source, int maxlength)
    {
      if (source.Length <= maxlength)
        //This is git test
      {
        return source;
      }
      return source.Substring(0, maxlength);
    }
  }
}
