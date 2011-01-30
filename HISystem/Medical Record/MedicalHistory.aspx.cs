using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Medical_Record_MedicalHistory : System.Web.UI.Page
{
    private MedicalRecord mr;
    private DataTable patientData;
    private string height;
    private string patientId;

    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        patientId = GridSearchName.Rows[GridSearchName.SelectedIndex].Cells[1].Text;
        BindPatientId();
        PopulateNameandBrgy();
    }

    protected void GridSearchName_Load(object sender, EventArgs e)
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
        GridSearchName.DataSourceID = "PatientSearchName";
        PatientSearchName.SelectParameters["PatientLastName"].DefaultValue = txtSearchPatient.Text;
        GridSearchName.DataBind();
    }

    protected void GridSearchName_SelectedIndexChanged(object sender, EventArgs e)
    {
        patientId = GridSearchName.Rows[GridSearchName.SelectedIndex].Cells[1].Text;
        Session["patientId"] = patientId;
        BindPatientId();
        PopulateNameandBrgy();
    }
    protected void BindPatientId()
    {
        SqlDataSource1.SelectParameters["PatientID"].DefaultValue = Convert.ToString(Session["patientId"]);
        GridView1.DataBind();
    }


    protected void PopulateNameandBrgy()
    {
        mr = new MedicalRecord();

        patientData = mr.GetNameForMedHistory(Convert.ToString(Session["patientId"]));

        if (patientData.Rows.Count > 0)
        {
            foreach (DataRow dr in patientData.Rows)
            {

                lbl_PatientName.Text = dr["PatientLName"].ToString().Trim() + ", " + dr["PatientFName"].ToString().Trim() + " " + dr["PatientMName"].ToString().Trim();
                lbl_PatientBarangay.Text = dr["PatientBarangay"].ToString().Trim();
            }
        }
    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string encId = "";
        encId = GridView1.Rows[GridView1.SelectedIndex].Cells[1].Text;

        Response.Redirect("~/Medical%20Record/Consultation.aspx?&id=" + Convert.ToString(Session["patientId"]) + "&enc=" + encId);
    }
}