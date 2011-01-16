using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;

public partial class Patient_Demographics_AddEditPatient : System.Web.UI.Page
{
    private DataAccess data;
    DataTable patientData;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void button_AddEdit_Click(object sender, EventArgs e)
    {
        data = new DataAccess();

        bool checker = data.HasPatient(txtFName.Text, txtMName.Text, txtLName.Text, txtAddress.Text);

        if (checker == true)
            Response.Write("<script> window.alert('Patient Exists.')</script>");
        else
        {
            if (Int32.Parse(ddlYear.Text) <= Int32.Parse(DateTime.Now.ToString("yyyy")))
            {
                if (radiobutton_Female.Checked || radiobutton_Male.Checked)
                {
                    string Gender = "Female";

                    if (radiobutton_Male.Checked)
                        Gender = "Male";
                    if (radiobutton_Female.Checked)
                        Gender = "Female";

                    //Add Patient

                    bool statusAdd = data.AddPatient(txtFName.Text.Trim(), txtMName.Text.Trim(), txtLName.Text.Trim(), txtContactNum.Text.Trim(), txtEmailAdd.Text.Trim(),
                        txtSuffix.Text.Trim(), ddlDay.Text.Trim() + "/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim(), txtBirthplace.Text.Trim(), txtAddress.Text.Trim(),
                        txtFaxNum.Text.Trim(), txtDoctor.Text.Trim(), txtNationality.Text.Trim(), txtCity.Text.Trim(),
                        Gender, ddlCivilStatus.Text.Trim(), txtSpouseName.Text.Trim(), txtCompany.Text.Trim(), DateTime.Now.ToString("d"), ddlBarangay.Text.Trim());

                    if (statusAdd)
                    {
                        Response.Write("<script> window.alert('Added Patient Successfully.')</script>");
                    }
                    else
                        Response.Write("<script> window.alert('Added Patient Failed.')</script>");
                }
                else
                    Response.Write("<script> window.alert('Please select gender')</script>");
            }
            else
                Response.Write("<script> window.alert('Please provide a birthdate that is lower than the current year.')</script>");
        }
    }
    protected void button_Clear_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddPatient.aspx");
    }
    protected void radiobutton_Male_CheckedChanged(object sender, EventArgs e)
    {
        if (radiobutton_Female.Checked)
            radiobutton_Female.Checked = false;
    }
    protected void radiobutton_Female_CheckedChanged(object sender, EventArgs e)
    {
        if (radiobutton_Male.Checked)
            radiobutton_Male.Checked = false;
    }
    protected void button_ProceedConsultation_Click(object sender, EventArgs e)
    {
        //Proceed to consultation 
        Response.Redirect("~/Medical%20Record/Consultation.aspx");
    }
}