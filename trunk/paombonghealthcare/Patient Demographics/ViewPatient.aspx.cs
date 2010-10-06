using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Patient_Demographics_ViewPatient : System.Web.UI.Page
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

        patientData = data.GetValues(txtPatientId.Text.Trim());
        Session["PatientData"] = patientData;

        if (patientData.Rows.Count > 0)
        {
            foreach (DataRow dr in patientData.Rows)
            {
                txtName.Text = dr["PatientName"].ToString().Trim();
                txtContactNum.Text = dr["PatientContactNumber"].ToString().Trim();
                txtFaxNum.Text = dr["PatientFaxNumber"].ToString().Trim();

                if (dr["PatientSex"].ToString() == "Male")
                {
                    radiobutton_Male.Checked = true;
                    radiobutton_Female.Checked = false;
                }
                else
                {
                    radiobutton_Male.Checked = true;
                    radiobutton_Female.Checked = false;
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
                //ddlBarangay.Text = dr["PatientBarangay"].ToString().Trim();
            }
        }
    }
    protected void button_Back_Click(object sender, EventArgs e)
    {

    }
}