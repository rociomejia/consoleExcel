using System;
using System.Collections.Generic;
using System.Text;
namespace CSSD.IS.ProfLearn.Util

{
    public class Utility
    {
        public static string GetCurrentYearCode()
        {
            string currentYearCode = "";
            if (DateTime.Today.Month >= 8 && DateTime.Today.Day >= 1)
            {
                currentYearCode = DateTime.Today.Year.ToString().Substring(2) + (DateTime.Today.Year + 1).ToString().Substring(2);
            }
            else
            {
                currentYearCode = (DateTime.Today.Year - 1).ToString().Substring(2) + DateTime.Today.Year.ToString().Substring(2);
            }
            return currentYearCode;
        }
    }
}
