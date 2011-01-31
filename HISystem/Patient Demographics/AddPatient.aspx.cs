using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Windows.Forms;
using System.Web.Security;

public partial class Patient_Demographics_AddEditPatient : System.Web.UI.Page
{
    private Patient pt;



    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        // Popup result is the selected date
        PopupControlExtender1.Commit(Calendar1.SelectedDate.ToShortDateString());
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Roles.IsUserInRole(HttpContext.Current.User.Identity.Name, "Midwife"))
        {
            //disable button if role is midwife since midwife cant consult
            button_ProceedConsultation.Visible = false;
            button_ProceedConsultation.ToolTip = "Consultation is disabled for midwife account" + 
                "/n Please use doctor or nurse account for consultation.";
        }
        else
            button_ProceedConsultation.Visible = true;
    }
    protected void Page_Init(object Sender, EventArgs e)
    {
        //Session Expires which focuses on removing the cache
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void button_AddEdit_Click(object sender, EventArgs e)
    {
        pt = new Patient();

        //Checks whether the Patient is present in the database
        bool checker = pt.HasPatient(txtFName.Text, txtMName.Text, txtLName.Text, txtAddress.Text);

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
                    bool statusAdd = pt.AddPatient(txtFName.Text.Trim(), txtMName.Text.Trim(), txtLName.Text.Trim(), txtContactNum.Text.Trim(), txtEmailAdd.Text.Trim(),
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
        //Clear but redirects to page to clear values - Lakhi
        Response.Redirect("AddPatient.aspx");
    }
    protected void button_ProceedConsultation_Click(object sender, EventArgs e)
    {
        //Proceed to consultation 
        Response.Redirect("~/Medical%20Record/Consultation.aspx");
    }
}