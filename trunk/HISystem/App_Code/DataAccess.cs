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

/* Log Positive
 *      1. Add Patient Finished - Lakhi 10/5/2010
 *      2. Update Patient Finished - Lakhi 10/5/2010
 *      3. Get Values Finished - Lakhi 10/5/2010
 *      4. Add Medicine Finished - Lakhi 10/10/2010
 *      5. Get Medicine Finished - Lakhi 10/10/2010
 *      6. Delete Medicine Finished - Lakhi 10/10/2010
 *      7. Grid View Finished - Lakhi 10/10/2010
 *      8. BarangayId Fixed Finished - Lakhi 10/10/2010
 *      9. Search By Medicine Name Fixed and Finished - Lakhi 10/12/2010
 *      10.Add to List Finished - Lakhi 10/12/2010
 *      11.Update Medicine Finished - Lakhi 10/13/2010
 *      12.Sorting Medicine Inventory Finished - Lakhi 10/13/2010
 *      13.Inventory Module Finished - Lakhi 10/13/2010
 * 
 * 
 * 
 * 
 */

/* Log Negative
 *      1. BarangayId Not yet Fixed in Update and Get Values - Lakhi 10/5/2010
 *      2. Inventory Not yet Finished - Lakhi 10/10/2010
 *      3. Search By Medicine Name Not yet Finished - Lakhi 10/12/2010
 *      4. 
 */

public class DataAccess
{
    private string dataConnection = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Lakhi\Desktop\Paombong\App_Data\paombongdb.mdf;Integrated Security=True;User Instance=True";

    public DataAccess()
    {

    }

    /*Add Patient Finished - Lakhi 10/5/2010*/

    public void AddPatient(string PatientFirstName, string PatientMiddleName, string PatientLastName,
        string PatientContactNumber, string PatientEmailAddress, string PatientSuffix, string PatientBirthdate, string PatientBirthplace, string PatientAddress,
        string PatientFaxNumber, string PatientDoctor, string PatientNationality, string PatientCity,
        string PatientSex, string PatientMaritalStatus, string PatientSpouseName, string PatientCompany, string DateRegistered, string PatientBarangay)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);
        try
        {
            connPatient.Open();
            SqlCommand cmdTxt = new SqlCommand("AddPatient", connPatient);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@PatientFirstName", SqlDbType.Char).Value = PatientFirstName;
            cmdTxt.Parameters.Add("@PatientMiddleName", SqlDbType.Char).Value = PatientMiddleName;
            cmdTxt.Parameters.Add("@PatientLastName", SqlDbType.Char).Value = PatientLastName;
            cmdTxt.Parameters.Add("@PatientContactNumber", SqlDbType.Char).Value = PatientContactNumber;
            cmdTxt.Parameters.Add("@PatientEmailAddress", SqlDbType.Char).Value = PatientEmailAddress;
            cmdTxt.Parameters.Add("@PatientNationality", SqlDbType.Char).Value = PatientNationality;
            cmdTxt.Parameters.Add("@PatientCity", SqlDbType.Char).Value = PatientCity;
            cmdTxt.Parameters.Add("@PatientBirthdate", SqlDbType.Char).Value = PatientBirthdate;
            cmdTxt.Parameters.Add("@PatientBirthPlace", SqlDbType.Char).Value = PatientBirthplace;
            cmdTxt.Parameters.Add("@PatientAddress", SqlDbType.Char).Value = PatientAddress;
            cmdTxt.Parameters.Add("@PatientFaxNumber", SqlDbType.Char).Value = PatientFaxNumber;
            cmdTxt.Parameters.Add("@PatientDoctor", SqlDbType.Char).Value = PatientDoctor;
            cmdTxt.Parameters.Add("@PatientSex", SqlDbType.Char).Value = PatientSex;
            cmdTxt.Parameters.Add("@PatientCompany", SqlDbType.Char).Value = PatientCompany;
            cmdTxt.Parameters.Add("@PatientMaritalStatus", SqlDbType.Char).Value = PatientMaritalStatus;
            cmdTxt.Parameters.Add("@PatientSpouseName", SqlDbType.Char).Value = PatientSpouseName;
            cmdTxt.Parameters.Add("@DateRegistered", SqlDbType.Char).Value = DateRegistered;
            cmdTxt.Parameters.Add("@PatientSuffix", SqlDbType.Char).Value = PatientSuffix;
            cmdTxt.Parameters.Add("@PatientBarangay", SqlDbType.Char).Value = PatientBarangay;

            int checker = cmdTxt.ExecuteNonQuery();
            if (checker > 0)
                MessageBox.Show("Patient Saved!");
            else
                MessageBox.Show("Patient Not Saved! Please Try Again");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    public DataTable GetValues(string Patient_Id)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);
        SqlDataReader dtrPatient;
        DataTable patientData = new DataTable();
        patientData.Columns.Add("PatientID");
        patientData.Columns.Add("PatientName");
        patientData.Columns.Add("PatientSex");
        patientData.Columns.Add("PatientCompany");
        patientData.Columns.Add("PatientCity");
        patientData.Columns.Add("PatientBirthdate");
        patientData.Columns.Add("PatientBirthplace");
        patientData.Columns.Add("PatientCivilStatus");
        patientData.Columns.Add("SpouseName");
        patientData.Columns.Add("PatientNationality");
        patientData.Columns.Add("PatientAddress");
        patientData.Columns.Add("PatientContactNumber");
        patientData.Columns.Add("PatientEmailAddress");
        patientData.Columns.Add("PatientFaxNumber");
        patientData.Columns.Add("PatientDoctor");
        patientData.Columns.Add("DateRegistered");
        patientData.Columns.Add("PatientBarangay");

        connPatient.Open();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("GetPatientData", connPatient);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@Patient_Id", SqlDbType.Char).Value = Patient_Id;
            dtrPatient = cmdTxt.ExecuteReader();
            dtrPatient.Read();

            patientData.Rows.Add(dtrPatient["PatientID"].ToString(),
                dtrPatient["PtLname"].ToString().Trim() + "," + dtrPatient["PtFname"].ToString().Trim() + ","
                + dtrPatient["PtMname"].ToString().Trim() + "," + dtrPatient["PtSuffix"].ToString().Trim(),
                dtrPatient["PtGender"].ToString().Trim(),
                dtrPatient["PtCompany"].ToString().Trim(),
                dtrPatient["PtBusinessCty"].ToString().Trim(),
                dtrPatient["PtBdate"].ToString().Trim(),
                dtrPatient["PtBplace"].ToString().Trim(),
                dtrPatient["CivilStatus"].ToString().Trim(),
                dtrPatient["SpouseName"].ToString().Trim(),
                dtrPatient["Nationality"].ToString().Trim(),
                dtrPatient["PtAddress"].ToString().Trim(),
                dtrPatient["PtContact"].ToString().Trim(),
                dtrPatient["PtEmail"].ToString().Trim(),
                dtrPatient["PtFaxNumber"].ToString().Trim(),
                dtrPatient["PtDoctor"].ToString().Trim(),
                dtrPatient["DateRegistered"].ToString().Trim(),
                dtrPatient["BarangayName"].ToString().Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
        return patientData;
    }

    /*Update Record Finished - Lakhi 10/5/2010*/

    public void UpdateRecord(string Patient_Id, string PatientFirstName, string PatientMiddleName, string PatientLastName,
        string PatientContactNumber, string PatientEmailAddress, string PatientSuffix, string PatientBirthdate, string PatientBirthplace, string PatientAddress,
        string PatientFaxNumber, string PatientDoctor, string PatientNationality, string PatientCity,
        string PatientSex, string PatientMaritalStatus, string PatientSpouseName, string PatientCompany, string DateRegistered, string PatientBarangay)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);
        connPatient.Open();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("UpdatePatient", connPatient);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@Patient_Id", SqlDbType.Int).Value = Patient_Id;
            cmdTxt.Parameters.Add("@PatientFirstName", SqlDbType.Char).Value = PatientFirstName;
            cmdTxt.Parameters.Add("@PatientMiddleName", SqlDbType.Char).Value = PatientMiddleName;
            cmdTxt.Parameters.Add("@PatientLastName", SqlDbType.Char).Value = PatientLastName;
            cmdTxt.Parameters.Add("@PatientContactNumber", SqlDbType.Char).Value = PatientContactNumber;
            cmdTxt.Parameters.Add("@PatientEmailAddress", SqlDbType.Char).Value = PatientEmailAddress;
            cmdTxt.Parameters.Add("@PatientNationality", SqlDbType.Char).Value = PatientNationality;
            cmdTxt.Parameters.Add("@PatientCity", SqlDbType.Char).Value = PatientCity;
            cmdTxt.Parameters.Add("@PatientBirthdate", SqlDbType.Char).Value = PatientBirthdate;
            cmdTxt.Parameters.Add("@PatientBirthPlace", SqlDbType.Char).Value = PatientBirthplace;
            cmdTxt.Parameters.Add("@PatientAddress", SqlDbType.Char).Value = PatientAddress;
            cmdTxt.Parameters.Add("@PatientFaxNumber", SqlDbType.Char).Value = PatientFaxNumber;
            cmdTxt.Parameters.Add("@PatientDoctor", SqlDbType.Char).Value = PatientDoctor;
            cmdTxt.Parameters.Add("@PatientSex", SqlDbType.Char).Value = PatientSex;
            cmdTxt.Parameters.Add("@PatientCompany", SqlDbType.Char).Value = PatientCompany;
            cmdTxt.Parameters.Add("@PatientMaritalStatus", SqlDbType.Char).Value = PatientMaritalStatus;
            cmdTxt.Parameters.Add("@PatientSpouseName", SqlDbType.Char).Value = PatientSpouseName;
            cmdTxt.Parameters.Add("@DateRegistered", SqlDbType.Char).Value = DateRegistered;
            cmdTxt.Parameters.Add("@PatientSuffix", SqlDbType.Char).Value = PatientSuffix;
            cmdTxt.Parameters.Add("@PatientBarangay", SqlDbType.Char).Value = PatientBarangay;
            int check = cmdTxt.ExecuteNonQuery();
            if (check > 0)
                MessageBox.Show("Updated Patient Information Successfully!");
            else
                MessageBox.Show("Unsuccesfull!! Updating Patient Information Please Try Again!");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    public int GetMedicineId(string MedicineName)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);

        connPatient.Open();
        SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId FROM Medicine WHERE MedicineName = @aa", connPatient);
        cmdTxt.Parameters.Add("@aa", SqlDbType.Char).Value = MedicineName;
        SqlDataReader id = cmdTxt.ExecuteReader();
        id.Read();
        int retId = id.GetInt32(0);
        id.Close();
        connPatient.Close();
        return retId;
    }

    /*AddMedicine Finished - Lakhi 10/10/2010*/

    public void AddMedicine(string MedicineName, string CategoryName, int Quantity)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);
        try
        {
            connPatient.Open();
            SqlCommand cmdTxt = new SqlCommand("AddMedicine", connPatient);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@MedicineName", SqlDbType.Char).Value = MedicineName;
            cmdTxt.Parameters.Add("@Quantity", SqlDbType.Int).Value = Quantity;
            cmdTxt.Parameters.Add("@CategoryName", SqlDbType.Char).Value = CategoryName;
            int checker = cmdTxt.ExecuteNonQuery();
            if (checker > 0)
                MessageBox.Show("Successfully Added Medicine");
            else
                MessageBox.Show("Please Try Again!!");

        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    /*GetMedicine Finished - Lakhi 10/10/2010*/

    public DataTable GetMedicine(string MedicineId)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);
        SqlDataReader dtrMedicine;
        DataTable medicineData = new DataTable();
        medicineData.Columns.Add("MedicineName");
        medicineData.Columns.Add("Quantity");
        medicineData.Columns.Add("CategoryName");

        connPatient.Open();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("GetMedicineData", connPatient);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@MedicineId", SqlDbType.Char).Value = MedicineId;
            dtrMedicine = cmdTxt.ExecuteReader();
            dtrMedicine.Read();

            medicineData.Rows.Add(dtrMedicine["MedicineName"].ToString().Trim()
                ,dtrMedicine["Quantity"].ToString().Trim()
                ,dtrMedicine["CategoryName"].ToString().Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
        return medicineData;
    }

    public void DeleteMedicine(string MedicineId)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);
   
        connPatient.Open();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("Delete From Medicine Where MedicineId = @aa", connPatient);
            cmdTxt.Parameters.Add("@aa", SqlDbType.Int).Value = MedicineId;
            int check = cmdTxt.ExecuteNonQuery();
            if (check > 0)
                MessageBox.Show("Successfully Deleted Medicine");
            else
                MessageBox.Show("Please Try Again!!");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    public void RefreshGridviewMedicine(GridView gridView)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);

        connPatient.Open();
        try
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Medicine",connPatient);
            DataSet ds = new DataSet();
            da.Fill(ds,"Medicine");

            if (ds.Tables.Count > 0)
            {
                gridView.DataSource = ds;
                gridView.DataBind();
            }
            ds.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    public void RefreshGridviewMedicineByCategory(GridView gridView,string CategoryName)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);

        connPatient.Open();
        try
        {

            SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine "+
                "WHERE CategoryId = (SELECT CategoryId FROM Category WHERE CategoryName = @aa)", connPatient);
            cmdTxt.Parameters.Add("@aa",SqlDbType.VarChar).Value = CategoryName;
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
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }

    }


    public void RefreshGridviewMedicineByName(GridView gridView, string MedicineName)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);
        SqlDataAdapter da;

        connPatient.Open();
        try
        {
            if (MedicineName != "" || MedicineName != null)
            {
                SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine WHERE MedicineName Like '" +MedicineName.Trim()+"%'", connPatient);
                
                da = new SqlDataAdapter(cmdTxt);
            }
            else
            {
                SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine", connPatient);
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
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }

    }

    public void RefreshGridviewByQuantityLow(GridView gridView)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);

        connPatient.Open();
        try
        {

            SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine " +
                "WHERE Quantity <= 25", connPatient);
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
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }

    }
    public void RefreshGridviewByQuantityLowConfig(GridView gridView,int Quantity)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);

        connPatient.Open();
        try
        {

            SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine " +
                "WHERE Quantity <= @aa", connPatient);
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
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }

    }

    public void RefreshGridviewByCategoryAndQuantityLow(GridView gridView, string CategoryName, int Quantity)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);

        connPatient.Open();
        try
        {

            SqlCommand cmdTxt = new SqlCommand("SELECT MedicineId,MedicineName,Quantity FROM Medicine " +
                "WHERE CategoryId = (SELECT CategoryId FROM Category WHERE CategoryName = @aa) AND Quantity <= @ab", connPatient);
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
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }

    }


    public void UpdateStock(int MedicineId,int Quantity)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);

        connPatient.Open();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("SELECT Quantity FROM Medicine " +
                "WHERE MedicineId = @aa", connPatient);
            cmdTxt.Parameters.Add("@aa", SqlDbType.Int).Value = MedicineId;
            SqlDataReader dr = cmdTxt.ExecuteReader();
            dr.Read();
            SqlCommand cmdTxt2 = new SqlCommand("Update Medicine Set Quantity = @aa WHERE MedicineId = @ab",connPatient);
            int newQuantity = (int)dr.GetInt64(0) - Quantity;
            cmdTxt2.Parameters.Add("@aa", SqlDbType.BigInt).Value = newQuantity;
            cmdTxt2.Parameters.Add("@ab", SqlDbType.Int).Value = MedicineId;
            dr.Close();
            cmdTxt2.ExecuteNonQuery();
            
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }

    }
    
    public void UpdateMedicine(int MedicineId,string MedicineName, string CategoryName, int Quantity)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);
        try
        {
            connPatient.Open();
            SqlCommand cmdTxt = new SqlCommand("Update Medicine SET MedicineName = @MedicineName,"+
                "CategoryId = (SELECT CategoryId FROM Category WHERE CategoryName = @CategoryName),"+
                "Quantity = @Quantity WHERE MedicineId ="+MedicineId, connPatient);
            cmdTxt.Parameters.Add("@MedicineName", SqlDbType.Char).Value = MedicineName;
            cmdTxt.Parameters.Add("@Quantity", SqlDbType.BigInt).Value = Quantity;
            cmdTxt.Parameters.Add("@CategoryName", SqlDbType.Char).Value = CategoryName;
            int checker = cmdTxt.ExecuteNonQuery();
            if (checker > 0)
                MessageBox.Show("Successfully Updated Medicine");
            else
                MessageBox.Show("Please Try Again!!");

        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    public List<string> GetDiseaseCategory()
    {
        List<string> category;
        SqlConnection connPatient = new SqlConnection(dataConnection);

        connPatient.Open();
        category = new List<string>();
        SqlCommand cmdTxt = new SqlCommand("Select DiseaseCategoryName From DiseaseCategory", connPatient);
        SqlDataReader dr = cmdTxt.ExecuteReader();
        while (dr.Read())
        {
            category.Add(dr.GetString(0).ToString().Trim());
        }
        dr.Close();
        connPatient.Close();
        return category;            
    }

    public void LoadCheckBoxList(CheckBoxList checkBoxDisease,string DiseaseCategory)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);

        try
        {
            connPatient.Open();
            SqlCommand cmdTxt = new SqlCommand("Select DiseaseName From Diseases Where DiseaseCategoryName = @DiseaseCategory", connPatient);
            cmdTxt.Parameters.Add("@DiseaseCategory", SqlDbType.Char).Value = DiseaseCategory;

            SqlDataReader dr = cmdTxt.ExecuteReader();
            while (dr.Read())
            {
                checkBoxDisease.Items.Add(dr.GetString(0).ToString().Trim());
            }
            dr.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

    /*Not Yet Finished for PopUp Window*/

    public void LoadPatientGrid(GridView gridview)
    {
        SqlConnection connPatient = new SqlConnection(dataConnection);
        SqlCommand cmdTxt;
        DataTable dt;
        DataSet ds;
        SqlDataReader dr;
        try
        {
            connPatient.Open();
            
            cmdTxt = new SqlCommand("SELECT a.PatientID as PatientId,a.PtLname + ',' + a.PtFname + ' ' + a.PtMname as Name,c.BarangayID,c.BarangayName as Barangay FROM Patients a,"
            + "PatientsLocation b,Barangays c WHERE a.PatientID = b.PatientID AND c.BarangayID = b.BarangayID", connPatient);

            dr = cmdTxt.ExecuteReader();
            dt = new DataTable();
            dt.Columns.Add("PatientId");
            dt.Columns.Add("Name");
            dt.Columns.Add("Barangay");
            while (dr.Read())
            {
                dt.Rows.Add(dr["PatientId"].ToString(), dr["Name"].ToString(), dr["Barangay"].ToString());
            }
            dr.Close();
            
            ds = new DataSet();
            ds.Tables.Add(dt);
            MessageBox.Show("" + ds.Tables.Count.ToString());
            gridview.DataSource = null;
            gridview.DataBind();
            gridview.Dispose();
            gridview.DataSource = ds;
            gridview.DataBind();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error : " + ex.Message);
        }
        finally
        {
            connPatient.Close();
        }
    }

}