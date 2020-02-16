using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppsProject.RandomClasses
{
  public static class StringExtensions
  {
    /// <summary>Method that limits the length of text to a defined length.</summary>
        public static string LimitLength(this string source, int maxlength)
    {
      if (source.Length <= maxlength)
      {
        return source;
      }
      return source.Substring(0, maxlength);
    }
  }
}
