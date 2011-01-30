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

public class Disease
{
    private DataAccess data;

	public Disease()
	{
	
	}
    public List<string> GetDiseaseCategory()
    {
        List<string> category;
        data = new DataAccess();
        data.ConnectToDatabase();
        category = new List<string>();
        SqlCommand cmdTxt = new SqlCommand("Select DiseaseCategoryName From DiseaseCategory",data.Connection);
        SqlDataReader dr = cmdTxt.ExecuteReader();
        while (dr.Read())
        {
            category.Add(dr.GetString(0).ToString().Trim());
        }
        dr.Close();
        data.CloseDatabase();
        return category;
    }

    public void LoadCheckBoxList(CheckBoxList checkBoxDisease, string DiseaseCategory)
    {
        data = new DataAccess();
        data.ConnectToDatabase();
        try
        {
            SqlCommand cmdTxt = new SqlCommand("Select DiseaseName From Diseases Where DiseaseCategoryName = @DiseaseCategory",data.Connection);
            cmdTxt.Parameters.Add("@DiseaseCategory", SqlDbType.Char).Value = DiseaseCategory;

            SqlDataReader dr = cmdTxt.ExecuteReader();
            while (dr.Read())
            {
                checkBoxDisease.Items.Add(dr.GetString(0).ToString().Trim());
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

    public bool SavePatientDisease(string PatientID, string DiseaseName, DateTime encTimeSaved)
    {
        data = new DataAccess();
        data.ConnectToDatabase();;
        SqlCommand cmdTxt = new SqlCommand("SaveDiseases",data.Connection);
        cmdTxt.CommandType = CommandType.StoredProcedure;
        cmdTxt.Parameters.Add("@encDateTime", SqlDbType.DateTime).Value = encTimeSaved;
        cmdTxt.Parameters.Add("@DiseaseName", SqlDbType.VarChar).Value = DiseaseName;
        cmdTxt.Parameters.Add("@PatientID", SqlDbType.VarChar).Value = PatientID;
        int checker = cmdTxt.ExecuteNonQuery();
        data.CloseDatabase();
        if (checker > 0)
            return true;
        else
            return false;
    }

    public List<string> GetPatientsDisease(string PatientID, string encID)
    {
        List<string> patientDisease = new List<string>();
        data = new DataAccess();
        data.ConnectToDatabase();;
        SqlCommand cmdTxt = new SqlCommand("SELECT d.DiseaseName FROM PatientsDiseases AS pd INNER JOIN " +
                         "Diseases AS d ON pd.DiseaseID = d.DiseaseID WHERE (pd.PatientID = @PatientID) " +
                         "AND (pd.EncounterID = @encID)",data.Connection);
        cmdTxt.Parameters.Add("@encID", SqlDbType.Int).Value = Int32.Parse(encID);
        cmdTxt.Parameters.Add("@PatientID", SqlDbType.Int).Value = Int32.Parse(PatientID);
        SqlDataReader dr = cmdTxt.ExecuteReader();
        while (dr.Read())
        {
            patientDisease.Add(dr.GetString(0));
        }
        dr.Close();
        data.CloseDatabase();
        return patientDisease;
    }


}