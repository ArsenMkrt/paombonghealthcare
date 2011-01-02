using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Patient_Demographics_ViewEditPatient : System.Web.UI.Page
{
    private DataAccess data;
    private DataTable patientData;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        data = new DataAccess();

        txtPatientId.ReadOnly = true;
        txtPatientId.Enabled = true;

        patientData = data.GetValues(txtPatientId.Text.Trim());
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
                }
                else
                {
                    radiobutton_Female.Checked = true;
                }

                ddlCivilStatus.Text = dr["PatientCivilStatus"].ToString().Trim();
                txtEmailAdd.Text = dr["PatientEmailAddress"].ToString().Trim();

                string[] bDate = dr["PatientBirthdate"].ToString().Trim().Split('/');
                ddlDay.Text = bDate[0].Trim();
                ddlMonth.Text = bDate[1].Trim();
                ddlYear.Text = bDate[2].Trim();
                txtBirthplace.Text = dr["PatientBirthplace"].ToString().Trim();
                txtCompany.Text = dr["PatientCompany"].ToString().Trim();
                txtCity.Text = dr["PatientCity"].ToString().Trim();
                txtAddress.Text = dr["PatientAddress"].ToString().Trim();
                txtSpouseName.Text = dr["SpouseName"].ToString().Trim();
                txtNationality.Text = dr["PatientNationality"].ToString().Trim();
                txtDoctor.Text = dr["PatientDoctor"].ToString().Trim();
                ddlBarangay.Text = dr["PatientBarangay"].ToString().Trim();
            }
        }
    }
    
    
    protected void radiobutton_Male_CheckedChanged(object sender, EventArgs e)
    {
        radiobutton_Male.Checked = false;
        radiobutton_Female.Checked = true;
    }
    protected void radiobutton_Female_CheckedChanged(object sender, EventArgs e)
    {
        radiobutton_Female.Checked = false;
        radiobutton_Male.Checked = true;
    }
    protected void button_AddEdit_Click(object sender, EventArgs e)
    {
        string Gender = "Female";

        if (radiobutton_Male.Checked)
            Gender = "Male";
        if (radiobutton_Female.Checked)
            Gender = "Female";

        //string toSplit = txtLName.Text.ToString();
        //string[] Name = toSplit.Split(',');
        data = new DataAccess();

        data.UpdateRecord(txtPatientId.Text.Trim(), txtFName.Text, txtMName.Text, txtLName.Text, txtContactNum.Text.Trim(), txtEmailAdd.Text.Trim(),
            txtSuffix.Text, ddlDay.Text.Trim() + "/" + ddlMonth.Text.Trim() + "/" + ddlYear.Text.Trim(), txtBirthplace.Text.Trim(), txtAddress.Text.Trim(),
            txtFaxNum.Text.Trim(), txtDoctor.Text.Trim(), txtNationality.Text.Trim(), txtCity.Text.Trim(),
            Gender, ddlCivilStatus.Text.Trim(), txtSpouseName.Text.Trim(), txtCompany.Text.Trim(), DateTime.Now.ToString("d"), ddlBarangay.Text.Trim());
        Response.Redirect("ViewEditPatient.aspx");
    }
    protected void button_Clear_Click(object sender, EventArgs e)
    {

    }
}