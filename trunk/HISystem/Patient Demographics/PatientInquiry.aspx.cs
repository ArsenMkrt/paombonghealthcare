using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

public partial class Patient_Demographics_PatientInquiry : System.Web.UI.Page
{
    private Patient pt;
    private DataTable patientData;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Midwife"))
        {
            //disable button if role is midwife since midwife cant consult
            button_ProceedConsultation.Visible = false;
            button_ProceedConsultation.ToolTip = "Consultation is disabled for midwife account" + "/n Please use doctor or nurse account for consultation.";
        }
        else
            button_ProceedConsultation.Visible = true;
    }
    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        try
        {
            pt = new Patient();

            txtPatientId.ReadOnly = true;
            txtPatientId.Enabled = true;

            patientData = pt.GetValues(txtPatientId.Text.Trim());
            Session["PatientData"] = patientData;

            if (patientData.Rows.Count > 0)
            {
                foreach (DataRow dr in patientData.Rows)
                {
                    txtLName.Text = dr["PatientLName"].ToString().Trim();
                    txtFName.Text = dr["PatientFName"].ToString().Trim();
                    txtMName.Text = dr["PatientMName"].ToString().Trim();
                    txtSuffix.Text = dr["PatientSuffix"].ToString().Trim();
                    txtContactNum.Text = dr["PatientContactNumber"].ToString().Trim();
                    txtFaxNum.Text = dr["PatientFaxNumber"].ToString().Trim();

                    if (dr["PatientSex"].ToString() == "Male")
                    {
                        radiobutton_Male.Checked = true;
                        radiobutton_Female.Checked = false;
                    }
                    else
                    {
                        radiobutton_Male.Checked = false;
                        radiobutton_Female.Checked = true;
                    }

                    ddlCivilStatus.Text = dr["PatientCivilStatus"].ToString().Trim();
                    txtEmailAdd.Text = dr["PatientEmailAddress"].ToString().Trim();

                    string date = dr["PatientBirthdate"].ToString().Trim();
                    DateTime dob = Convert.ToDateTime(date);
                    txtDate.Text = dob.ToString("MM/dd/yyyy");


                    txtBirthplace.Text = dr["PatientBirthplace"].ToString().Trim();
                    txtCompany.Text = dr["PatientCompany"].ToString().Trim();
                    txtCity.Text = dr["PatientCity"].ToString().Trim();
                    txtAddress.Text = dr["PatientAddress"].ToString().Trim();
                    txtSpouseName.Text = dr["SpouseName"].ToString().Trim();
                    txtNationality.Text = dr["PatientNationality"].ToString().Trim();
                    txtDoctor.Text = dr["PatientDoctor"].ToString().Trim();
                    ddlBarangay.Text = dr["PatientBarangay"].ToString().Trim();

                    txtLName.ReadOnly = true;
                    txtFName.ReadOnly = true;
                    
                    txtDate.ReadOnly = true;
                    txtMName.ReadOnly = true;
                    txtContactNum.ReadOnly = true;
                    txtFaxNum.ReadOnly = true;
                    ddlBarangay.Enabled = false;
                    radiobutton_Female.Enabled = false;
                    radiobutton_Male.Enabled = false;
                    ddlCivilStatus.Enabled = false;
                    txtEmailAdd.ReadOnly = true;
                    txtCity.ReadOnly = true;
                    txtBirthplace.ReadOnly = true;
                   
                    txtAddress.ReadOnly = true;
                    txtCompany.ReadOnly = true;
                    txtNationality.ReadOnly = true;
                    txtSpouseName.ReadOnly = true;
                    txtDoctor.ReadOnly = true;
                }
            }
        }
        catch (Exception)
        {
            //display error
        }
    }

    protected void button_ProceedConsultation_Click(object sender, EventArgs e)
    {
        if (txtPatientId.Text.Trim() != "" && txtPatientId.Text.Length > 0)
        {
            //Proceed to consultation 
            Response.Redirect("~/Medical%20Record/Consultation.aspx?id=" + txtPatientId.Text);
        }
        else
            Response.Redirect("~/Medical%20Record/Consultation.aspx");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtPatientId.Text = GridSearchName.Rows[GridSearchName.SelectedIndex].Cells[1].Text;
        ButtonSearch_Click(sender, e);
    }
    protected void GridSearchName_Load(object sender, EventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GridSearchName.DataSourceID = "PatientSearchName";
        PatientSearchName.SelectParameters["PatientLastName"].DefaultValue = txtSearchPatient.Text;
    }

    protected void GridSearchName_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtPatientId.Text = GridSearchName.Rows[GridSearchName.SelectedIndex].Cells[1].Text;
        txtPatientId.ReadOnly = true;

        ButtonSearch_Click(sender, e);
    }
}