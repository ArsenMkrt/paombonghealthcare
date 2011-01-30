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

public class MedicalRecord
{
    private DataAccess data;

	public MedicalRecord()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetValuesConsultation(string Patient_Id)
    {
        data = new DataAccess();
        SqlDataReader dtrPatient;
        DataTable patientData = new DataTable();
        patientData.Columns.Add("PatientID");
        patientData.Columns.Add("PatientLName");
        patientData.Columns.Add("PatientFName");
        patientData.Columns.Add("PatientMName");
        patientData.Columns.Add("PatientBirthdate");
        patientData.Columns.Add("PatientAddress");
        patientData.Columns.Add("PatientFaxNumber");
        patientData.Columns.Add("PatientBarangay");
        data.ConnectToDatabase();;
        try
        {
            SqlCommand cmdTxt = new SqlCommand("GetPatientData2",data.Connection);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@Patient_Id", SqlDbType.Char).Value = Patient_Id;
            dtrPatient = cmdTxt.ExecuteReader();
            dtrPatient.Read();

            patientData.Rows.Add(dtrPatient["PatientID"].ToString(),
                dtrPatient["PtLname"].ToString().Trim(),
                dtrPatient["PtFname"].ToString().Trim(),
                dtrPatient["PtMname"].ToString().Trim(),
                dtrPatient["PtBdate"].ToString().Trim(),

                dtrPatient["PtAddress"].ToString().Trim(),

                dtrPatient["PtFaxNumber"].ToString().Trim(),
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


    public void SavePatientDailyMedicalRecord(int PatientID, int PatientAge, string PulseRate, decimal Temperature, decimal PatientWeight, string PatientHeight
       , string BloodPressure, string Diagnosis, string Treatment, string userAccount)
    {
        data = new DataAccess();
        data.ConnectToDatabase();;
        SqlCommand cmdTxt = new SqlCommand("INSERT INTO Encounters (EncounterDateTime,PatientID,Age,Temp,Weight,PulseRate,Height,Bloodpressure,Diagnosis,Treatment,Facilitatedby)"
            + "VALUES (@EncounterDateTime,@PatientID,@Age,@Temp,@Weight,@PulseRate,@Height,@Bloodpressure,@Diagnosis,@Treatment,@Facilitatedby)",data.Connection);
        cmdTxt.Parameters.Add("@EncounterDateTime", SqlDbType.DateTime).Value = DateTime.Now;
        cmdTxt.Parameters.Add("@PatientID", SqlDbType.Int).Value = PatientID;
        cmdTxt.Parameters.Add("@Age", SqlDbType.Int).Value = PatientAge;
        cmdTxt.Parameters.Add("@Temp", SqlDbType.Decimal).Value = Temperature;
        cmdTxt.Parameters.Add("@Weight", SqlDbType.Decimal).Value = PatientWeight;
        cmdTxt.Parameters.Add("@Height", SqlDbType.VarChar).Value = PatientHeight;
        cmdTxt.Parameters.Add("@Bloodpressure", SqlDbType.VarChar).Value = BloodPressure;
        cmdTxt.Parameters.Add("@PulseRate", SqlDbType.VarChar).Value = PulseRate;
        cmdTxt.Parameters.Add("@Diagnosis", SqlDbType.VarChar).Value = Diagnosis;
        cmdTxt.Parameters.Add("@Treatment", SqlDbType.VarChar).Value = Treatment;
        cmdTxt.Parameters.Add("@Facilitatedby", SqlDbType.VarChar).Value = userAccount;
        cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
    }

    public DataTable GetEncounterData(string EncounterId)
    {
        data = new DataAccess();
        DataTable ptEncounterData = new DataTable();
        SqlDataReader dtrPatient;

        ptEncounterData.Columns.Add("Age");
        ptEncounterData.Columns.Add("Temp");
        ptEncounterData.Columns.Add("Weight");
        ptEncounterData.Columns.Add("PulseRate");
        ptEncounterData.Columns.Add("Height");
        ptEncounterData.Columns.Add("Bloodpressure");
        ptEncounterData.Columns.Add("Diagnosis");
        ptEncounterData.Columns.Add("Treatment");

        data.ConnectToDatabase();;
        SqlCommand cmdTxt = new SqlCommand("SELECT Age,Temp,Weight,PulseRate,Height,Bloodpressure,Diagnosis,Treatment FROM Encounters WHERE EncounterID = @encId",data.Connection);
        cmdTxt.Parameters.Add("@encId", SqlDbType.Int).Value = Int32.Parse(EncounterId);
        dtrPatient = cmdTxt.ExecuteReader();
        dtrPatient.Read();

        ptEncounterData.Rows.Add(dtrPatient["Age"].ToString().Trim(), dtrPatient["Temp"].ToString().Trim(),
            dtrPatient["Weight"].ToString().Trim(), dtrPatient["PulseRate"].ToString().Trim(), dtrPatient["Height"].ToString().Trim()
            , dtrPatient["Bloodpressure"].ToString().Trim(), dtrPatient["Diagnosis"].ToString().Trim(), dtrPatient["Treatment"].ToString().Trim());
        return ptEncounterData;
    }

    public DataTable GetNameForMedHistory(string Patient_Id)
    {
        data = new DataAccess();
        SqlDataReader dtrPatient;
        DataTable patientData = new DataTable();


        patientData.Columns.Add("PatientLName");
        patientData.Columns.Add("PatientFName");
        patientData.Columns.Add("PatientMName");
        patientData.Columns.Add("PatientBarangay");

        data.ConnectToDatabase();;
        try
        {
            SqlCommand cmdTxt = new SqlCommand("GetPatientData",data.Connection);
            cmdTxt.CommandType = CommandType.StoredProcedure;
            cmdTxt.Parameters.Add("@Patient_Id", SqlDbType.Char).Value = Patient_Id;
            dtrPatient = cmdTxt.ExecuteReader();
            dtrPatient.Read();

            patientData.Rows.Add(dtrPatient["PtLname"].ToString().Trim(), dtrPatient["PtFname"].ToString().Trim(),
                dtrPatient["PtMname"].ToString().Trim(), dtrPatient["BarangayName"].ToString().Trim());
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
}