using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data; 

public partial class Medical_Record_Consultation : System.Web.UI.Page
{
    private DataAccess data;
    private DataTable patientData;
   

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
            }
        }

    }
    protected void dropMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlBarangay_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    
    protected void btnSave_Click(object sender, EventArgs e)
    {   
        /**
         * Added by Lakhi Save 1/5/2011
         * This Saves patient daily Medical record
         */
        int totalHeight = 0;
        if (txtHt_inch.MaxLength == 1 && txtHt_feet.MaxLength == 1)
            totalHeight = Convert.ToInt32(txtHt_feet.Text + "0" + txtHt_inch.Text);
        else if (txtHt_feet.MaxLength == 1 && txtHt_inch.MaxLength == 0)
            totalHeight = Convert.ToInt32(txtHt_feet.Text + "00");

        data = new DataAccess();
        if (txtDiagnosis.Text.Trim() != null)
        {
            data.SavePatientDailyMedicalRecord(Convert.ToInt32(txtbx_PatientID.Text), Convert.ToInt32(txtAge.Text), Convert.ToInt32(txtTemp.Text)
                , Convert.ToInt32(txtWt.Text),totalHeight
                , Convert.ToInt32(txtBpressure.Text), txtDiagnosis.Text, txtRecomendation.Text);
        }
        else
            Response.Write("<script> window.alert('Please fillup required fields.')</script>");
    }
    protected void grdvw_Users_Load(object sender, EventArgs e)
    {

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
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
}