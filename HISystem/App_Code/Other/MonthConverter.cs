using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MonthConverter
/// </summary>
public class MonthConverter
{
	public MonthConverter()
	{
		
	}
    public int MonthNameToIndex(string MonthName)
    {
        switch (MonthName.Trim())
        {
            case "January": return 1; 
            case "February": return 2; 
            case "March": return 3; 
            case "April": return 4; 
            case "May": return 5; 
            case "June": return 6; 
            case "July": return 7; 
            case "August": return 8; 
            case "September": return 9; 
            case "October": return 10; 
            case "November": return 11; 
            case "December": return 12; 
        }
        return 0;
    }

    public int DetermineQuarter(string Month)
    {
        switch (Month.Trim())
        {
            case "1": return 1;
            case "2": return 1;
            case "3": return 1;
            case "4": return 2;
            case "5": return 2;
            case "6": return 2;
            case "7": return 3;
            case "8": return 3;
            case "9": return 3;
            case "10": return 4;
            case "11": return 4;
            case "12": return 4;
        }
        return 0;
    }
}