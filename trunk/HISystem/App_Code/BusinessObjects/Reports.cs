using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

/// <Paombong Healthcare Information System>
/// For Municipality of Paombong
/// Developers
///     ~Lakhi Lester Calantoc
///     ~Gerald Aldana Magno
/// Business Analyst
///     ~Kendrick Bacani
/// <This is an open source Healthcare Information System>
/// </Paombong Healthcare Information System>
/// 
/// <Here are the FHSIS Report Methods>
///
public class Reports
{
    private MonthConverter mc;
    private DataAccess data;

	public Reports()
	{

	}

    /*This checks whether the certain report is present in the database.
     * It only Checks for Maternal Care because in the form of Inputting a report
     * in the database it only gives the user to input all data for all the 
     * succeeding program thats why the maternal care is only the one to be checked 
     * in the database. 
     */

    public bool HasDataForTheYear(int Year, string Month, int BarangayID)
    {
        int count = 0;
        mc = new MonthConverter();
        data = new DataAccess();
        data.ConnectToDatabase();
        SqlCommand cmdTxt = new SqlCommand("SELECT COUNT(*) FROM MaternalCare WHERE Year = " +
            "@year AND BarangayID = @barangayID AND Month = @month",data.Connection);
        cmdTxt.Parameters.Add("@year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@month", SqlDbType.Int).Value = mc.MonthNameToIndex(Month);
        cmdTxt.Parameters.Add("@barangayID", SqlDbType.Int).Value = BarangayID;
        count = (int)cmdTxt.ExecuteScalar();
        data.CloseDatabase();
        if (count > 0)
            return true;
        else
            return false;
    }

    public bool HasPopulationData(int Year, string Month, int BarangayID)
    {
        int count = 0;
        mc = new MonthConverter();
        data = new DataAccess();
        data.ConnectToDatabase();
        SqlCommand cmdTxt = new SqlCommand("SELECT COUNT(*) FROM Population WHERE Year = " +
            "@year AND BarangayID = @barangayID AND Month = @month", data.Connection);
        cmdTxt.Parameters.Add("@year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@month", SqlDbType.Int).Value = mc.MonthNameToIndex(Month);
        cmdTxt.Parameters.Add("@barangayID", SqlDbType.Int).Value = BarangayID;
        count = (int)cmdTxt.ExecuteScalar();
        data.CloseDatabase();
        if (count > 0)
            return true;
        else
            return false;
    }

    public bool DeleteRecord(string Month,int Year, int BarangayID)
    {
        bool isDeleted = false;

        data = new DataAccess();
        data.ConnectToDatabase();
        SqlCommand cmdTxt = new SqlCommand("DELETE FROM Population WHERE BarangayID = @barangayId AND Year = @year AND Month = @month",data.Connection);
        cmdTxt.Parameters.Add("@barangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@month", SqlDbType.VarChar).Value = Month;
        int rowsAffected = cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
        if (rowsAffected > 0)
            isDeleted = true;
        else
            isDeleted = false;
        return isDeleted;
    }

    public bool DeleteReportsRecord(string Month, int Year, int BarangayID)
    {
        bool isDeleted = true;
        string[] reports = new string[] { "Maternal Care", "Family Planning", "Child Care", "Dental Care", "Malaria", 
            "Schistomiasis", "Filariasis", "Tuberculosis", "Leprosy" };
        data = new DataAccess();
        data.ConnectToDatabase();
        for (int i = 0; i < reports.Length; i++)
        {
            SqlCommand cmdTxt = new SqlCommand("DELETE FROM " + reports[i] + " WHERE BarangayID = @barangayId AND Year = @year AND Month = @month", data.Connection);
            cmdTxt.Parameters.Add("@barangayID", SqlDbType.Int).Value = BarangayID;
            cmdTxt.Parameters.Add("@year", SqlDbType.Int).Value = Year;
            cmdTxt.Parameters.Add("@month", SqlDbType.VarChar).Value = Month;
            int rowsAffected = cmdTxt.ExecuteNonQuery();
            if (rowsAffected > 0)
                isDeleted = true && isDeleted;
            else
                isDeleted = false && isDeleted;
        }
        data.CloseDatabase();
        return isDeleted;
    }

    public bool InsertPopulation(int BarangayID, int Population, int Target, int Month, int Year)
    {
        data = new DataAccess();
        mc = new MonthConverter();
        data.ConnectToDatabase();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Population (BarangayID,Population,Target,Month,Year)"
            + "VALUES (@BarangayID,@Population,@Target,@Month,@Year)",data.Connection);
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Population", SqlDbType.Int).Value = Population;
        cmdTxt.Parameters.Add("@Target", SqlDbType.Int).Value = Target;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        int checker = cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
        if (checker > 0)
            return true;
        else
            return false;
    }

    public void InsertMalariaReport(string MalariaData, int Pregnant, int Male, int Female, int BarangayID,
        int Month, int Year)
    {
        data = new DataAccess();
        mc = new MonthConverter();

        data.ConnectToDatabase();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Malaria (MalariaData,Pregnant,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@MalariaData,@Pregnant,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)",data.Connection);
        cmdTxt.Parameters.Add("@MalariaData", SqlDbType.VarChar).Value = MalariaData;
        cmdTxt.Parameters.Add("@Pregnant", SqlDbType.Int).Value = Pregnant;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now;
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
    }

    public void InsertChildReport(string ChildData, int Male, int Female, int BarangayID,
        int Month, int Year)
    {
        data = new DataAccess();
        mc = new MonthConverter();
        data.ConnectToDatabase();

        SqlCommand cmdTxt = new SqlCommand("INSERT INTO ChildCare (ChildData,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@ChildData,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)",data.Connection);
        cmdTxt.Parameters.Add("@ChildData", SqlDbType.VarChar).Value = ChildData;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now;
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
    }

    public void InsertTbReport(string TuberculosisData, int Male, int Female, int BarangayID,
        int Month, int Year)
    {
        data = new DataAccess();
        mc = new MonthConverter();
        data.ConnectToDatabase();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Tuberculosis (TuberculosisData,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@TbData,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)",data.Connection);
        cmdTxt.Parameters.Add("@TbData", SqlDbType.VarChar).Value = TuberculosisData;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now;
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
    }

    public void InsertSchisReport(string SchisData, int Male, int Female, int BarangayID,
       int Month, int Year)
    {
        data = new DataAccess();
        mc = new MonthConverter();
        data.ConnectToDatabase();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Schisto (SchistoData,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@SchisData,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)",data.Connection);
        cmdTxt.Parameters.Add("@SchisData", SqlDbType.VarChar).Value = SchisData;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now;
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
    }

    public void InsertFilariasisReport(string FilariasisData, int Male, int Female, int BarangayID,
       int Month, int Year)
    {
        data = new DataAccess();
        mc = new MonthConverter();
        data.ConnectToDatabase();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Filariasis (FilariasisData,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@FilariasisData,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)",data.Connection);
        cmdTxt.Parameters.Add("@FilariasisData", SqlDbType.VarChar).Value = FilariasisData;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now;
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
    }
    public void InsertFPReport(string FPData, int SU, int New, int Others, int DO,
       int EU, int BarangayID, int Month, int Year)
    {
        data = new DataAccess();
        mc = new MonthConverter();
        data.ConnectToDatabase();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO FamilyPlanning (FPData,StartUser,New,Others,DropOut,EndUser,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@FPData,@SU,@New,@Others,@DO,@EU,@InputDate,@BarangayID,@Month,@Year,@Quarter)",data.Connection);
        cmdTxt.Parameters.Add("@FPData", SqlDbType.VarChar).Value = FPData;
        cmdTxt.Parameters.Add("@SU", SqlDbType.Int).Value = SU;
        cmdTxt.Parameters.Add("@New", SqlDbType.Int).Value = New;
        cmdTxt.Parameters.Add("@Others", SqlDbType.Int).Value = Others;
        cmdTxt.Parameters.Add("@DO", SqlDbType.Int).Value = DO;
        cmdTxt.Parameters.Add("@EU", SqlDbType.Int).Value = EU;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now;
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
    }

    public void InsertDentalCareReport(string DentalData, int Male, int Female, int BarangayID,
        int Month, int Year)
    {
        data = new DataAccess();
        mc = new MonthConverter();
        data.ConnectToDatabase();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO DentalCare (DentalData,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@DentalData,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)",data.Connection);
        cmdTxt.Parameters.Add("@DentalData", SqlDbType.VarChar).Value = DentalData;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now;
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
    }

    public void InsertLeprosyReport(string LeprosyData, int Male, int Female, int BarangayID,
        int Month, int Year)
    {
        data = new DataAccess();
        mc = new MonthConverter();
        data.ConnectToDatabase();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Leprosy (LeprosyData,Male,Female,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@LeprosyData,@Male,@Female,@InputDate,@BarangayID,@Month,@Year,@Quarter)",data.Connection);
        cmdTxt.Parameters.Add("@LeprosyData", SqlDbType.VarChar).Value = LeprosyData;
        cmdTxt.Parameters.Add("@Male", SqlDbType.Int).Value = Male;
        cmdTxt.Parameters.Add("@Female", SqlDbType.Int).Value = Female;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now;
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
    }

    public bool InsertMaternalCareReport(string MaternalData, int NumberOfPatients, int BarangayID,
        int Month, int Year)
    {
        data = new DataAccess();
        mc = new MonthConverter();
        data.ConnectToDatabase();
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO MaternalCare (MaternalData,NumberOfPatients,InputDate,BarangayID,Month,Year,Quarter)"
            + "VALUES (@MaternalData,@NumberOfPatients,@InputDate,@BarangayID,@Month,@Year,@Quarter)",data.Connection);
        cmdTxt.Parameters.Add("@MaternalData", SqlDbType.VarChar).Value = MaternalData;
        cmdTxt.Parameters.Add("@NumberOfPatients", SqlDbType.Int).Value = NumberOfPatients;
        cmdTxt.Parameters.Add("@InputDate", SqlDbType.DateTime).Value = DateTime.Now;
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.Int).Value = BarangayID;
        cmdTxt.Parameters.Add("@Month", SqlDbType.Int).Value = Month;
        cmdTxt.Parameters.Add("@Year", SqlDbType.Int).Value = Year;
        //cmdTxt.Parameters.Add("@Accomplishment", SqlDbType.VarChar).Value = Accomplishment;
        //cmdTxt.Parameters.Add("@Percent", SqlDbType.Decimal).Value = percent;
        cmdTxt.Parameters.Add("@Quarter", SqlDbType.Int).Value = mc.DetermineQuarter(Month.ToString());
        int checker = cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
        if (checker > 0)
            return true;
        else 
            return false;
    }

}