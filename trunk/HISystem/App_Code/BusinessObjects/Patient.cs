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

/// <summary>
/// Summary description for Patient
/// </summary>
public class Patient
{
    //Variables
    private DataAccess data;

    //Constructor
	public Patient()
	{

	}

    //Methods
    public bool AddPatient(string PatientFirstName, string PatientMiddleName, string PatientLastName,
        string PatientContactNumber, string PatientEmailAddress, string PatientSuffix, DateTime PatientBirthdate, string PatientBirthplace, string PatientAddress,
        string PatientFaxNumber, string PatientDoctor, string PatientNationality, string PatientCity,
        string PatientSex, string PatientMaritalStatus, string PatientSpouseName, string PatientCompany, string DateRegistered, string PatientBarangay)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        SqlCommand cmdTxt = new SqlCommand("AddPatient",data.Connection);
        
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
        cmdTxt.Parameters.Add("@DateYear", SqlDbType.Char).Value = DateTime.Now.Year.ToString();

        int checker = cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
        if (checker > 0)
            return true;
        else
            return false;
    }

    public DataTable GetValues(string Patient_Id)
    {
        data = new DataAccess();

        SqlDataReader dtrPatient;
        DataTable patientData = new DataTable();
        patientData.Columns.Add("PatientID");
        patientData.Columns.Add("PatientLName");
        patientData.Columns.Add("PatientFName");
        patientData.Columns.Add("PatientMName");
        patientData.Columns.Add("PatientSuffix");
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

        data.ConnectToDatabase();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("GetPatientData",data.Connection);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@Patient_Id", SqlDbType.Char).Value = Patient_Id;
            dtrPatient = cmdTxt.ExecuteReader();
            dtrPatient.Read();

            patientData.Rows.Add(dtrPatient["PatientID"].ToString(),
                dtrPatient["PtLname"].ToString().Trim(), dtrPatient["PtFname"].ToString().Trim(),
                dtrPatient["PtMname"].ToString().Trim(), dtrPatient["PtSuffix"].ToString().Trim(),
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
        catch (Exception)
        {

        }
        finally
        {
            data.CloseDatabase();
        }
        return patientData;
    }

    public bool UpdateRecord(string Patient_Id, string PatientFirstName, string PatientMiddleName, string PatientLastName,
        string PatientContactNumber, string PatientEmailAddress, string PatientSuffix, string PatientBirthdate, string PatientBirthplace, string PatientAddress,
        string PatientFaxNumber, string PatientDoctor, string PatientNationality, string PatientCity,
        string PatientSex, string PatientMaritalStatus, string PatientSpouseName, string PatientCompany, string DateRegistered, string PatientBarangay)
    {
        data = new DataAccess();
        int check;
        data.ConnectToDatabase();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("UpdatePatient",data.Connection);
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
            check = cmdTxt.ExecuteNonQuery();
            data.CloseDatabase();
            if (check > 0)
                return true;
            else
                return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    //Check Birthdate Also
    public bool HasPatient(string firstName, string middleName, string lastname, string address)
    {
        data = new DataAccess();
        data.ConnectToDatabase();;
        SqlCommand cmdTxt = new SqlCommand("SELECT COUNT(*) FROM Patients WHERE PtFname = @firstname AND PtMname = @middlename" +
            " AND PtLname = @lastname AND PtAddress = @address",data.Connection);
        cmdTxt.Parameters.Add("@firstname", SqlDbType.VarChar).Value = firstName;
        cmdTxt.Parameters.Add("@middlename", SqlDbType.VarChar).Value = middleName;
        cmdTxt.Parameters.Add("@lastname", SqlDbType.VarChar).Value = lastname;
        cmdTxt.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
        int check = (int)cmdTxt.ExecuteScalar();
        data.CloseDatabase();
        if (check > 0)
            return true;
        else
            return false;
    }
}