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

public class Program
{
    private DataAccess data;

	public Program()
	{

	}


    public void LoadIndicator(string Program, DropDownList dropdownIndicator)
    {
        data = new DataAccess();
        data.ConnectToDatabase();;

        try
        {
            SqlCommand cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE ProgramCategoryID ="+
                "(SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @Program)",data.Connection);
            cmdTxt.Parameters.Add("@Program", SqlDbType.Char).Value = Program;

            SqlDataReader dr = cmdTxt.ExecuteReader();
            while (dr.Read())
            {
                dropdownIndicator.Items.Add(dr.GetString(0).Trim());
            }
            dr.Close();

        }
        catch (Exception)
        {
        }
        finally
        {
            data.CloseDatabase();
        }
    }

    public int CountIndicatorPerProgram(string Program)
    {
        int count = 0;
        data = new DataAccess();
        data.ConnectToDatabase();;

        SqlCommand cmdTxt = new SqlCommand("SELECT COUNT(*) FROM Indicator WHERE ProgramCategoryID = " +
            "(SELECT ProgramCategoryID FROM ProgramCategory WHERE ProgramData = @data)",data.Connection);
        cmdTxt.Parameters.Add("@data", SqlDbType.VarChar).Value = Program;
        count = (int)cmdTxt.ExecuteScalar();
        data.CloseDatabase();
        return count;
    }

    public int GetIndicatorId(string IndicatorData)
    {
        data = new DataAccess();
        data.ConnectToDatabase();;
        SqlCommand cmdTxt = new SqlCommand("SELECT IndicatorID FROM Indicator WHERE IndicatorData = @IndicatorData",data.Connection);
        cmdTxt.Parameters.Add("@IndicatorData", SqlDbType.Char).Value = IndicatorData.Trim();

        SqlDataReader dr = cmdTxt.ExecuteReader();
        dr.Read();
        int id = dr.GetInt32(0);
        dr.Close();
        data.CloseDatabase();
        return id;
    }

    public string GetIndicatorName(int IndicatorId)
    {
        data = new DataAccess();
        data.ConnectToDatabase();;
        SqlCommand cmdTxt = new SqlCommand("SELECT IndicatorData FROM Indicator WHERE IndicatorID = @IndicatorId",data.Connection);
        cmdTxt.Parameters.Add("@IndicatorId", SqlDbType.Int).Value = IndicatorId;

        SqlDataReader dr = cmdTxt.ExecuteReader();
        dr.Read();
        string indicatorData = dr.GetString(0);
        dr.Close();
        data.CloseDatabase();
        return indicatorData;
    }

}