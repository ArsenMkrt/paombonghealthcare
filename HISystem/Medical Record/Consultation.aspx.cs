using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Web.Security; 

public partial class Medical_Record_Consultation : System.Web.UI.Page
{
    private DataAccess data;
    private DataTable patientData;
    private string height;
    private string err;

    protected void Page_Load(object sender, EventArgs e)
    {
            
       
        if (!this.IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                txtbx_PatientID.Text = Request.QueryString["id"];


                if (txtbx_PatientID.Text.Trim() != null)
                {
                    ButtonProceed_Click(sender, e);
                }
            }
        }
        //to load current day as label
        lbl_dateToday.Text = DateTime.Now.ToShortDateString();
        
        
      
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtbx_PatientID.Text = grdvw_Users.Rows[grdvw_Users.SelectedIndex].Cells[1].Text;

        data = new DataAccess();

        patientData = data.GetValuesConsultation(txtbx_PatientID.Text);
        Session["PatientData"] = patientData;

        if (patientData.Rows.Count > 0)
        {
            foreach (DataRow dr in patientData.Rows)
            {
                //txtlname.Text = dr["PatientLName"].ToString().Trim();
                txtlname.Text = dr["PatientLName"].ToString().Trim();

                txtfname.Text = dr["PatientFName"].ToString().Trim();
                txtmname.Text = dr["PatientMName"].ToString().Trim();


                txtPhilhealthNum.Text = dr["PatientFaxNumber"].ToString().Trim();


                string[] bDate = dr["PatientBirthdate"].ToString().Trim().Split('/');
                ddlDay.Text = bDate[0].Trim();
                ddlMonth.Text = bDate[1].Trim();
                ddlYear.Text = bDate[2].Trim();
                txtAddress.Text = dr["PatientAddress"].ToString().Trim();
                ddlBarangay.Text = dr["PatientBarangay"].ToString().Trim();
                txtAddress.ReadOnly = true;
                txtlname.ReadOnly = true;
                txtfname.ReadOnly = true;
                txtmname.ReadOnly = true;
                txtPhilhealthNum.ReadOnly = true;
                ddlDay.Enabled = false;
                ddlMonth.Enabled = false;
                ddlYear.Enabled = false;
                ddlBarangay.Enabled = false;
                txtAge.Text = (Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(ddlYear.Text)).ToString();
                txtAge.ReadOnly = true;
                
            }
        }

    }
    
    
    
    protected void btnSave_Click(object sender, EventArgs e)
    {



        try
        {

            //To save data on db
            ddlBarangay.Enabled = true;

            if (txtHt_inch.Text.Length == 1)
            {
                height = txtHt_feet.Text + "0" + txtHt_inch.Text;
            }
            else if (txtHt_inch.Text.Length == 0 || txtHt_inch.Text.Trim() == null)
            {
                height = txtHt_feet.Text + "00";
            }
            else
                height = txtHt_feet.Text + txtHt_inch.Text;
            /**
             * Added by Lakhi Save 1/5/2011
             * This Saves patient daily Medical record
             */
            data = new DataAccess();
            if (txtbx_PatientID.Text.Trim() == null)
            {
                Response.Write("<script> window.alert('Please select Patient.')</script>");
            }

            else if (txtDiagnosis.Text.Length > 0 || txtbx_PatientID.Text.Trim() != null || txtDiagnosis.Text.Trim() != "")
            {

                data.SavePatientDailyMedicalRecord
                    (

                        Convert.ToInt32(txtbx_PatientID.Text),
                        Convert.ToInt32(txtAge.Text),
                        Convert.ToDecimal(txtTemp.Text),
                        Convert.ToDecimal(txtWt.Text),
                        Convert.ToInt32(height),
                        Convert.ToInt32(txtBpressure.Text),
                        Convert.ToInt32(txtBpressure0.Text),
                        txtDiagnosis.Text,
                        txtRecomendation.Text,
                        (string)Page.User.Identity.Name

                    );






                txtAge.Text = string.Empty;
                Response.Write("<script> window.alert('Saved Consultation Successfully.')</script>");
            }
            else
            {
                Response.Write("<script> window.alert('Please fillup required fields.')</script>");
            }
        }
        
        catch (Exception ex)
        {
            err = ex.ToString();
            showErrorSave(sender, e);
            
        }
        finally
        {
            if (err == null)
            {
                //reset upon save
                txtbx_PatientID.Text = string.Empty;
                txtAge.Text = string.Empty;
                txtTemp.Text = string.Empty;
                txtWt.Text = string.Empty;
                txtHt_feet.Text = string.Empty;
                txtHt_inch.Text = string.Empty;
                txtBpressure.Text = string.Empty;
                txtBpressure0.Text = string.Empty;
                txtDiagnosis.Text = string.Empty;
                txtRecomendation.Text = string.Empty;




                //clear patient loaded info upon save
                txtlname.Text = string.Empty;
                txtfname.Text = string.Empty;
                txtmname.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtPhilhealthNum.Text = string.Empty;                
                ddlBarangay.SelectedIndex = 1;
                ddlDay.SelectedIndex = 1;
                ddlMonth.SelectedIndex = 1;
                ddlYear.SelectedIndex = 1;
                txtAddress.Text = string.Empty;

                ddlBarangay.Enabled = false;

            }
        }

    }
    protected void grdvw_Users_Load(object sender, EventArgs e)
    {

    }
    private void showErrorSave(object sender, EventArgs e)
    {
      
        Response.Write("<script> window.alert('Did not save successfully please check all fields!')</script>");
    }
    protected void ButtonProceed_Click(object sender, EventArgs e)
    {
        string Patient_id= txtbx_PatientID.Text.Trim();

        data = new DataAccess();

        patientData = data.GetValuesConsultation(Patient_id);
        Session["PatientData"] = patientData;

        if (patientData.Rows.Count > 0)
        {
            foreach (DataRow dr in patientData.Rows)
            {
                //txtlname.Text = dr["PatientLName"].ToString().Trim();
                txtlname.Text = dr["PatientLName"].ToString().Trim();
               
                txtfname.Text = dr["PatientFName"].ToString().Trim();
                txtmname.Text = dr["PatientMName"].ToString().Trim();


                txtPhilhealthNum.Text = dr["PatientFaxNumber"].ToString().Trim();

              
                string[] bDate = dr["PatientBirthdate"].ToString().Trim().Split('/');
                ddlDay.Text = bDate[0].Trim();
                ddlMonth.Text = bDate[1].Trim();
                ddlYear.Text = bDate[2].Trim();
                txtAddress.Text = dr["PatientAddress"].ToString().Trim();
                ddlBarangay.Text = dr["PatientBarangay"].ToString().Trim();
                txtAddress.ReadOnly = true;
                txtlname.ReadOnly = true;
                txtfname.ReadOnly = true;
                txtmname.ReadOnly = true;
                txtPhilhealthNum.ReadOnly = true;
                ddlDay.Enabled = false;
                ddlMonth.Enabled = false;
                ddlYear.Enabled = false;
                txtAge.Text = (Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(ddlYear.Text)).ToString();
                txtAge.ReadOnly = true;
            }
        }
       
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Medical%20Record/Consultation.aspx");
    }
    protected void txtSearchPatient_TextChanged(object sender, EventArgs e)
    {
        GridSearchName.DataSourceID = "PatientSearchName";
        PatientSearchName.SelectParameters["PatientLastName"].DefaultValue = txtSearchPatient.Text;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        PatientSearchName.SelectParameters["PatientLastName"].DefaultValue = txtSearchPatient.Text;
    }

    
    protected void GridSearchName_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtbx_PatientID.Text = GridSearchName.Rows[GridSearchName.SelectedIndex].Cells[1].Text;

        data = new DataAccess();


        patientData = data.GetValuesConsultation(txtbx_PatientID.Text);
        Session["PatientData"] = patientData;

        if (patientData.Rows.Count > 0)
        {
            foreach (DataRow dr in patientData.Rows)
            {
                //txtlname.Text = dr["PatientLName"].ToString().Trim();
                txtlname.Text = dr["PatientLName"].ToString().Trim();

                txtfname.Text = dr["PatientFName"].ToString().Trim();
                txtmname.Text = dr["PatientMName"].ToString().Trim();


                txtPhilhealthNum.Text = dr["PatientFaxNumber"].ToString().Trim();


                string[] bDate = dr["PatientBirthdate"].ToString().Trim().Split('/');
                ddlDay.Text = bDate[0].Trim();
                ddlMonth.Text = bDate[1].Trim();
                ddlYear.Text = bDate[2].Trim();
                txtAddress.Text = dr["PatientAddress"].ToString().Trim();
                ddlBarangay.Text = dr["PatientBarangay"].ToString().Trim();
                txtAddress.ReadOnly = true;
                txtlname.ReadOnly = true;
                txtfname.ReadOnly = true;
                txtmname.ReadOnly = true;
                txtPhilhealthNum.ReadOnly = true;
                ddlDay.Enabled = false;
                ddlMonth.Enabled = false;
                ddlYear.Enabled = false;
                txtAge.Text = (Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(ddlYear.Text)).ToString();
                txtAge.ReadOnly = true;
            }
        }

    }
}