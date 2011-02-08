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

public class Inventory
{
    //Variables
    private DataAccess data;

    //Constructor
	public Inventory()
	{

	}

    public int GetMedicineId(string MedicineName)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        
        SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId FROM Medicine WHERE MedicineName = @aa",data.Connection);
        cmdTxt.Parameters.Add("@aa", SqlDbType.Char).Value = MedicineName;
        SqlDataReader id = cmdTxt.ExecuteReader();
        id.Read();
        int retId = id.GetInt32(0);
        id.Close();
        data.CloseDatabase();
        return retId;
    }

    public int GetMedicineQuantity(int MedicineId)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        
        SqlCommand cmdTxt = new SqlCommand("SELECT Quantity FROM Medicine WHERE MedicineId = @aa",data.Connection);
        cmdTxt.Parameters.Add("@aa", SqlDbType.Int).Value = MedicineId;
        SqlDataReader id = cmdTxt.ExecuteReader();
        id.Read();
        int quantity = Int32.Parse(id["Quantity"].ToString());
        id.Close();
        data.CloseDatabase();
        return quantity;
    }


    /*Add Medicine Finished - Lakhi 10/10/2010*/

    public bool AddMedicine(string MedicineName, string CategoryName, int Quantity)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        
        SqlCommand cmdTxt = new SqlCommand("AddMedicine",data.Connection);
        
        cmdTxt.CommandType = CommandType.StoredProcedure;
        cmdTxt.Parameters.Add("@MedicineName", SqlDbType.Char).Value = MedicineName;
        cmdTxt.Parameters.Add("@Quantity", SqlDbType.Int).Value = Quantity;
        cmdTxt.Parameters.Add("@CategoryName", SqlDbType.Char).Value = CategoryName;
        
        int checker = cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
        if (checker > 0)
            return true;
        else
            return false;
    }

    /*Get Medicine Finished - Lakhi 10/10/2010*/

    public DataTable GetMedicine(string MedicineId)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        SqlDataReader dtrMedicine;
        DataTable medicineData = new DataTable();
        medicineData.Columns.Add("MedicineName");
        medicineData.Columns.Add("Quantity");
        medicineData.Columns.Add("CategoryName");
        
        try
        {
            SqlCommand cmdTxt = new SqlCommand("GetMedicineData",data.Connection);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@MedicineId", SqlDbType.Char).Value = MedicineId;
            dtrMedicine = cmdTxt.ExecuteReader();
            dtrMedicine.Read();

            medicineData.Rows.Add(dtrMedicine["MedicineName"].ToString().Trim()
                , dtrMedicine["Quantity"].ToString().Trim()
                , dtrMedicine["CategoryName"].ToString().Trim());
        }
        catch (Exception)
        {
        }
        data.CloseDatabase();
        return medicineData;
    }

    public void DeleteMedicine(string MedicineId)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("Delete From Medicine Where MedicineId = @aa",data.Connection);
            cmdTxt.Parameters.Add("@aa", SqlDbType.Int).Value = MedicineId;
            int check = cmdTxt.ExecuteNonQuery();
        }
        catch (Exception)
        {
        }
        data.CloseDatabase();
    }

    public void RefreshGridviewMedicine(GridView gridView)
    {
        data = new DataAccess();
        data.ConnectToDatabase();

        try
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Medicine",data.Connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "Medicine");

            if (ds.Tables.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            ds.Dispose();
        }
        catch (Exception)
        {
        }
        finally
        {
            data.CloseDatabase();
        }
    }

    public void RefreshGridviewMedicineByCategory(GridView gridView, string CategoryName)
    {
        data = new DataAccess();
        data.ConnectToDatabase();

        try
        {
            
            SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine " +
                "WHERE CategoryId = (SELECT CategoryId FROM Category WHERE CategoryName = @aa)",data.Connection);
            cmdTxt.Parameters.Add("@aa", SqlDbType.VarChar).Value = CategoryName;
            SqlDataAdapter da = new SqlDataAdapter(cmdTxt);
            gridView.DataSource = null;
            gridView.DataBind();

            DataSet ds = new DataSet();
            da.Fill(ds, "Medicine");

            if (ds.Tables.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            ds.Dispose();
        }
        catch (Exception)
        {
        }
        finally
        {
            data.CloseDatabase();
        }

    }
    
    public void RefreshGridviewMedicineByName(GridView gridView, string MedicineName)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        SqlDataAdapter da;
        try
        {
         
            if (MedicineName != "" || MedicineName != null)
            {
                SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine WHERE MedicineName Like '" + MedicineName.Trim() + "%'",data.Connection);

                da = new SqlDataAdapter(cmdTxt);
            }
            else
            {
                SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine",data.Connection);
                da = new SqlDataAdapter(cmdTxt);
            }

            gridView.DataSource = null;
            gridView.DataBind();

            DataSet ds = new DataSet();
            da.Fill(ds, "Medicine");

            if (ds.Tables.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            ds.Dispose();
        }
        catch (Exception)
        {
        }
        finally
        {
            data.CloseDatabase();
        }

    }

    public void RefreshGridviewByQuantityLow(GridView gridView)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        try
        {
            
            SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine " +
                "WHERE Quantity <= 25",data.Connection);
            SqlDataAdapter da = new SqlDataAdapter(cmdTxt);
            gridView.DataSource = null;
            gridView.DataBind();

            DataSet ds = new DataSet();
            da.Fill(ds, "Medicine");

            if (ds.Tables.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            ds.Dispose();
        }
        catch (Exception)
        {
        }
        finally
        {
            data.CloseDatabase();
        }

    }
    public void RefreshGridviewByQuantityLowConfig(GridView gridView, int Quantity)
    {
        data = new DataAccess();
        data.ConnectToDatabase();;
        try
        {

            SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine " +
                "WHERE Quantity <= @aa",data.Connection);
            cmdTxt.Parameters.Add("@aa", SqlDbType.Int).Value = Quantity;
            SqlDataAdapter da = new SqlDataAdapter(cmdTxt);
            gridView.DataSource = null;
            gridView.DataBind();

            DataSet ds = new DataSet();
            da.Fill(ds, "Medicine");

            if (ds.Tables.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            ds.Dispose();
        }
        catch (Exception)
        {
        }
        finally
        {
            data.CloseDatabase();
        }

    }

    public void RefreshGridviewByCategoryAndQuantityLow(GridView gridView, string CategoryName, int Quantity)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        try
        {
            
            SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine " +
                "WHERE CategoryId = (SELECT CategoryId FROM Category WHERE CategoryName = @aa) AND Quantity <= @ab",data.Connection);
            cmdTxt.Parameters.Add("@aa", SqlDbType.VarChar).Value = CategoryName;
            cmdTxt.Parameters.Add("@ab", SqlDbType.Int).Value = Quantity;
            SqlDataAdapter da = new SqlDataAdapter(cmdTxt);
            gridView.DataSource = null;
            gridView.DataBind();

            DataSet ds = new DataSet();
            da.Fill(ds, "Medicine");

            if (ds.Tables.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            ds.Dispose();
        }
        catch (Exception)
        {
        }
        finally
        {
            data.CloseDatabase();
        }

    }

    public void UpdateStock(int MedicineId, int Quantity)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        try
        {
            
            SqlCommand cmdTxt = new SqlCommand("SELECT Quantity FROM Medicine " +
                "WHERE MedicineId = @aa",data.Connection);
            cmdTxt.Parameters.Add("@aa", SqlDbType.Int).Value = MedicineId;
            SqlDataReader dr = cmdTxt.ExecuteReader();
            dr.Read();
            SqlCommand cmdTxt2 = new SqlCommand("Update Medicine Set Quantity = @aa WHERE MedicineId = @ab",data.Connection);
            int newQuantity = (int)dr.GetInt64(0) - Quantity;
            cmdTxt2.Parameters.Add("@aa", SqlDbType.BigInt).Value = newQuantity;
            cmdTxt2.Parameters.Add("@ab", SqlDbType.Int).Value = MedicineId;
            dr.Close();
            cmdTxt2.ExecuteNonQuery();

        }
        catch (Exception)
        {
        }
        finally
        {
            data.CloseDatabase();
        }

    }

    public bool UpdateMedicine(int MedicineId, string MedicineName, string CategoryName, int Quantity)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        
        SqlCommand cmdTxt = new SqlCommand("Update Medicine SET MedicineName = @MedicineName," +
            "CategoryId = (SELECT CategoryId FROM Category WHERE CategoryName = @CategoryName)," +
            "Quantity = @Quantity WHERE MedicineId =" + MedicineId,data.Connection);
        cmdTxt.Parameters.Add("@MedicineName", SqlDbType.Char).Value = MedicineName;
        cmdTxt.Parameters.Add("@Quantity", SqlDbType.BigInt).Value = Quantity;
        cmdTxt.Parameters.Add("@CategoryName", SqlDbType.Char).Value = CategoryName;
        int checker = cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
        if (checker > 0)
            return true;
        else
            return false;
    }

    public bool HasMedicine(int MedicineId)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        
        SqlCommand cmdTxt = new SqlCommand("SELECT COUNT(*) FROM Medicine WHERE MedicineId = @medicineId",data.Connection);
        cmdTxt.Parameters.Add("@medicineId", SqlDbType.Int).Value = MedicineId;
        int check = (int)cmdTxt.ExecuteScalar();
        if (check > 0)
            return true;
        else
            return false;
    }

    public void SaveMedicineLog(int MedicineId, string MedicineName, int Quantity, string FacilitatedBy, string TypeOfLog)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO MedicineLog (MedicineId,MedicineName,Quantity,DateOfPurchase,FacilitatedBy,LogType)" +
            " VALUES (@medId,@medName,@quantity,@dateOfPurchase,@facilitatedBy,@type)",data.Connection);
        cmdTxt.Parameters.Add("@medId", SqlDbType.Int).Value = MedicineId;
        cmdTxt.Parameters.Add("@medName", SqlDbType.VarChar).Value = MedicineName;
        cmdTxt.Parameters.Add("@quantity", SqlDbType.Int).Value = Quantity;
        cmdTxt.Parameters.Add("@dateOfPurchase", SqlDbType.DateTime).Value = DateTime.Now;
        cmdTxt.Parameters.Add("@facilitatedBy", SqlDbType.VarChar).Value = FacilitatedBy;
        cmdTxt.Parameters.Add("@type", SqlDbType.VarChar).Value = TypeOfLog;
        cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
    }

    public bool HasMedicineName(string MedicineName)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        
        SqlCommand cmdTxt = new SqlCommand("SELECT COUNT(*) FROM Medicine WHERE MedicineName = @medicineName",data.Connection);
        cmdTxt.Parameters.Add("@medicineName", SqlDbType.VarChar).Value = MedicineName;

        if ((int)cmdTxt.ExecuteScalar() > 0)
            return true;
        else
            return false;
    }

    public string GetMedicineName(int MedicineId)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        
        SqlCommand cmdTxt = new SqlCommand("SELECT MedicineName FROM Medicine WHERE MedicineId = @aa",data.Connection);
        cmdTxt.Parameters.Add("@aa", SqlDbType.Int).Value = MedicineId;
        SqlDataReader name = cmdTxt.ExecuteReader();
        name.Read();
        string medName = name["MedicineName"].ToString();
        name.Close();
        data.CloseDatabase();
        return medName;
    }

}