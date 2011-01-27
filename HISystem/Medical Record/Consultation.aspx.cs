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
    private DataTable ptData;
    private string height;
    private string err;
    private string encId;

    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                txtbx_PatientID.Text = Request.QueryString["id"];
                if (Request.QueryString["enc"] != null)
                {
                    encId = Request.QueryString["enc"];
                    LoadDataFromEncounter();
                }
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
        DateTime timeSave;

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
                height = txtHt_feet.Text + "-" + txtHt_inch.Text+"";
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
                timeSave = DateTime.Now;
                data.SavePatientDailyMedicalRecord
                    (
                        Convert.ToInt32(txtbx_PatientID.Text),
                        Convert.ToInt32(txtAge.Text),
                        Convert.ToDecimal(txtTemp.Text),
                        Convert.ToDecimal(txtWt.Text),
                        (height),
                        (txtBpressure.Text +"/"+ txtBpressure0.Text),
                        
                        txtDiagnosis.Text,
                        txtRecomendation.Text,
                        (string)Page.User.Identity.Name
                    );


                foreach (ListItem li in checkbox_DiseaseList.Items)
                {
                    if (li.Selected)
                    {
                        data.SavePatientDisease(txtbx_PatientID.Text, li.Text, timeSave);
                    }
                }
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
            showErrorSave(err);
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
    private void showErrorSave(string err)
    {
      
        Response.Write("<script> window.alert('Did not save successfully please check all fields: "+err+"')</script>");
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

    protected void LoadDataFromEncounter()
    {
        data = new DataAccess();
        ptData = data.GetEncounterData(encId);
        foreach (DataRow dr in ptData.Rows)
        {
            txtTemp.Text = dr["Temp"].ToString().Trim();
            txtTemp.ReadOnly = true;
            txtAge.Text = dr["Age"].ToString().Trim();
            txtAge.ReadOnly = true;


            string bp = dr["Bloodpressure"].ToString().Trim();
            string[] bpressure = bp.Split('/');

            txtBpressure.Text = bpressure[0];
            txtBpressure.ReadOnly = true;
            txtBpressure0.Text = bpressure[1];
            txtBpressure0.ReadOnly = true;
            
            txtDiagnosis.Text = dr["Diagnosis"].ToString().Trim();
            txtDiagnosis.ReadOnly = true;
            string Height = dr["Height"].ToString().Trim();
            string[] heightDetails = Height.Split('-');
            txtHt_feet.Text = heightDetails[0];
            txtHt_feet.ReadOnly = true;
            txtHt_inch.Text = heightDetails[1];
            txtHt_inch.ReadOnly = true;
            txtWt.Text = dr["Weight"].ToString().Trim();
            txtWt.ReadOnly = true;
            txtRecomendation.Text = dr["Treatment"].ToString().Trim();
            txtRecomendation.ReadOnly = true;
        }
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