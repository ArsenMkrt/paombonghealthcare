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

public class Barangay
{
    private DataAccess data;

	public Barangay()
	{
	}


    public int GetBarangayID(string BarangayName)
    {
        data = new DataAccess();
        data.ConnectToDatabase();;
        SqlCommand cmdTxt = new SqlCommand("SELECT BarangayID FROM Barangays WHERE BarangayName = @BarangayName",data.Connection);
        cmdTxt.Parameters.Add("@BarangayName", SqlDbType.VarChar).Value = BarangayName;
        SqlDataReader dr = cmdTxt.ExecuteReader();
        dr.Read();
        int id = dr.GetInt32(0);
        dr.Close();
        data.CloseDatabase();
        return id;
    }

    public string GetBarangayName(int BarangayID)
    {
        data = new DataAccess();
        data.ConnectToDatabase();;
        SqlCommand cmdTxt = new SqlCommand("SELECT BarangayName FROM Barangays WHERE BarangayID = @BarangayID",data.Connection);
        cmdTxt.Parameters.Add("@BarangayID", SqlDbType.VarChar).Value = BarangayID;
        SqlDataReader dr = cmdTxt.ExecuteReader();
        dr.Read();
        string BarangayName = dr.GetString(0);
        dr.Close();
        data.CloseDatabase();
        return BarangayName;
    }

    //public void LoadBarangays(GridView gridview)
    //{
    //    data = new DataAccess();
    //    gridview.Dispose();

    //    DataTable dtGrid = new DataTable();
    //    dtGrid.Columns.Add("Barangay");
    //    dtGrid.Columns.Add("Population");
    //    dtGrid.Columns.Add("Target");
    //    dtGrid.Columns.Add("month1");
    //    dtGrid.Columns.Add("month2");
    //    dtGrid.Columns.Add("month3");
    //    dtGrid.Columns.Add("Quarter Accomplishment");
    //    dtGrid.Columns.Add("Percent");
    //    data.ConnectToDatabase();;
    //    SqlCommand cmdTxt = new SqlCommand("SELECT BarangayName FROM Barangays",data.Connection);
    //    SqlDataReader dr = cmdTxt.ExecuteReader();

    //    while (dr.Read())
    //    {
    //        dtGrid.Rows.Add(dr.GetString(0).Trim(), "", "", "", "", "", "", "");
    //    }

    //    dr.Close();

    //    gridview.DataSource = dtGrid;
    //    gridview.DataBind();
    //    data.CloseDatabase();
    //}

    
}