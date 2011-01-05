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

    }

    protected void grdvw_Users_Load(object sender, EventArgs e)
    {

    }

   
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void txtSearchPatient_TextChanged(object sender, EventArgs e)
    {
        //Response.Write("<script type='text/javascript'>" + "alert(\"Hello: " + txtSearchPatient.Text + "\");</script>");
        //PatientSearchName.SelectParameters["PatientLastName"].DefaultValue = txtSearchPatient.Text;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        PatientSearchName.SelectParameters["PatientLastName"].DefaultValue = txtSearchPatient.Text;
    }


    protected void ButtonProceed_Click(object sender, EventArgs e)
    {
        string Patient_id = txtbx_PatientID.Text.Trim();



        
    }

    protected void GridSearchName_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtbx_PatientID.Text = GridSearchName.Rows[GridSearchName.SelectedIndex].Cells[1].Text;
        GridView1_SelectedIndexChanged1(sender, e);
        //data = new DataAccess();



        //patientData = data.GetValuesConsultation(txtbx_PatientID.Text);
        //Session["PatientData"] = patientData;

        //if (patientData.Rows.Count > 0)
        //{
        //    foreach (DataRow dr in patientData.Rows)
        //    {
        //        //txtlname.Text = dr["PatientLName"].ToString().Trim();
        //        txtlname.Text = dr["PatientLName"].ToString().Trim();

        //        txtfname.Text = dr["PatientFName"].ToString().Trim();
        //        txtmname.Text = dr["PatientMName"].ToString().Trim();


        //        txtPhilhealthNum.Text = dr["PatientFaxNumber"].ToString().Trim();


        //        string[] bDate = dr["PatientBirthdate"].ToString().Trim().Split('/');
        //        ddlDay.Text = bDate[0].Trim();
        //        ddlMonth.Text = bDate[1].Trim();
        //        ddlYear.Text = bDate[2].Trim();
        //        txtAddress.Text = dr["PatientAddress"].ToString().Trim();
        //        ddlBarangay.Text = dr["PatientBarangay"].ToString().Trim();
        //    }
        //}

    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        SqlDataSource1.SelectParameters["PatientID"].DefaultValue = txtbx_PatientID.Text;
    }
}