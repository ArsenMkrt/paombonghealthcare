using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Medical_Record_MedicalHistory : System.Web.UI.Page
{
    private DataAccess data;
    private DataTable patientData;
    private string height;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtbx_PatientID.Text = grdvw_Users.Rows[grdvw_Users.SelectedIndex].Cells[1].Text;
        BindPatientId();
        PopulateNameandBrgy();

    }

    protected void grdvw_Users_Load(object sender, EventArgs e)
    {

    }

   
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void txtSearchPatient_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        PatientSearchName.SelectParameters["PatientLastName"].DefaultValue = txtSearchPatient.Text;
    }

    protected void GridSearchName_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtbx_PatientID.Text = GridSearchName.Rows[GridSearchName.SelectedIndex].Cells[1].Text;
        BindPatientId();

        PopulateNameandBrgy();



    }
    protected void BindPatientId()
    {
        SqlDataSource1.SelectParameters["PatientID"].DefaultValue = txtbx_PatientID.Text;
        GridView1.DataBind();
    }


    protected void PopulateNameandBrgy()
    {
        data = new DataAccess();

        patientData = data.GetNameForMedHistory(txtbx_PatientID.Text.Trim());

        if (patientData.Rows.Count > 0)
        {
            foreach (DataRow dr in patientData.Rows)
            {

                lbl_PatientName.Text = dr["PatientLName"].ToString().Trim() + ", " + dr["PatientFName"].ToString().Trim() + " " + dr["PatientMName"].ToString().Trim();
                lbl_PatientBarangay.Text = dr["PatientBarangay"].ToString().Trim();
            }
        }
    }
}