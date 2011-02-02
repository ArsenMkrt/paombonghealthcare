using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for calcAge
/// </summary>
/// 
namespace bll
{
    public class calcAge
    {
        public string GetAge(DateTime DOB)
        {
            int Years = 0;
            int Month = 0;
            int Days = 0;
            string StrAge = null;
            if (DOB < DateTime.Now)
            {
                TimeSpan dateDiff = DateTime.Now - DOB;
                DateTime age = new DateTime(dateDiff.Ticks);
                Years = age.Year - 1;
                Month = age.Month - 1;
                Days = age.Day - 1;
                //StrAge = Years.ToString() + "Yrs, " + Month.ToString() + "Months old" + Days.ToString();

                if(Years>1)
                StrAge = Years.ToString() + "Yrs, " + Month.ToString() + "mo.";

                else if(Years==1)
                    StrAge = Years.ToString() + "Yr, " + Month.ToString() + "mo.";
                else if(Years==0)
                    StrAge = Month.ToString() + "mo.";
            }
            else
            {
                StrAge = "Birthdate should not be a future date.";
            }
            return StrAge;
        }

        
    }
}