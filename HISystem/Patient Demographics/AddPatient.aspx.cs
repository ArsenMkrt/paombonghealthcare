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
    protected void button_AddEdit_Click(object sender, EventArgs e)
    {
        string Gender = "Female";

        if (radiobutton_Male.Checked)
           Gender = "Male";
        if (radiobutton_Female.Checked)
           Gender = "Female";

        data = new DataAccess();
 
        //Add Patient
        data.AddPatient(txtFName.Text.Trim(),txtMName.Text.Trim(),txtLName.Text.Trim(), txtContactNum.Text.Trim(), txtEmailAdd.Text.Trim(),
             txtSuffix.Text.Trim(), ddlDay.Text.Trim() + "/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim(), txtBirthplace.Text.Trim(), txtAddress.Text.Trim(),
             txtFaxNum.Text.Trim(), txtDoctor.Text.Trim(), txtNationality.Text.Trim(), txtCity.Text.Trim(),
             Gender, ddlCivilStatus.Text.Trim(), txtSpouseName.Text.Trim(), txtCompany.Text.Trim(), DateTime.Now.ToString("d"),ddlBarangay.Text.Trim());
        
        Response.Redirect("AddPatient.aspx");
    }
    protected void button_Clear_Click(object sender, EventArgs e)
    {

    }
}