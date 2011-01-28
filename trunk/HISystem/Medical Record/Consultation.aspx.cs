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
    private int patientId;

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
            btnReset.Enabled = true;
            checkbox_DiseaseList.Enabled = true;
            checkbox_DiseaseList.DataBind();
            if (Request.QueryString.Count > 0)
            {
                patientId = Int32.Parse(Request.QueryString["id"]);
                if (Request.QueryString["enc"] != null)
                {
                    encId = Request.QueryString["enc"];
                    LoadDataFromEncounter();
                    btnReset.Enabled = false;
                    checkbox_DiseaseList.Enabled = false;
                }
                if (Request.QueryString["id"] != null)
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
        //patientId = Int32.Parse(grdvw_Users.Rows[grdvw_Users.SelectedIndex].Cells[1].Text);

        data = new DataAccess();

        patientData = data.GetValuesConsultation(patientId.ToString());
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
        if (txtlname.Text != "")
        {
            try
            {
                //To save data on db
                ddlBarangay.Enabled = true;

                if (txtHt_feet.Text == "" && txtHt_inch.Text == "")
                {
                    txtHt_feet.Text = "0";
                    txtHt_inch.Text = "0";
                }
                else if (txtHt_feet.Text == "")
                {
                    txtHt_feet.Text = "0";
                }
                else if (txtHt_inch.Text == "")
                {
                    txtHt_inch.Text = "0";
                }
                
                height = txtHt_feet.Text + "-" + txtHt_inch.Text + "";
                /**
                 * Added by Lakhi Save 1/5/2011
                 * This Saves patient daily Medical record
                 */
                data = new DataAccess();

                if (txtDiagnosis.Text.Length > 0 || Request.QueryString["id"] != null)
                {
                    timeSave = DateTime.Now;
                    
                    if (Request.QueryString["id"] != null)
                    {
                        data.SavePatientDailyMedicalRecord
                            (
                                Convert.ToInt32(Request.QueryString["id"]),
                                Convert.ToInt32(txtAge.Text),
                                txtPulseRate.Text,
                                Convert.ToDecimal(txtTemp.Text),
                                Convert.ToDecimal(txtWt.Text),
                                (height),
                                (txtBpressure.Text + "/" + txtBpressure0.Text),

                                txtDiagnosis.Text,
                                txtRecomendation.Text,
                                (string)Page.User.Identity.Name
                            );
                        foreach (ListItem li in checkbox_DiseaseList.Items)
                        {
                            if (li.Selected)
                            {
                                data.SavePatientDisease(Request.QueryString["id"].ToString(), li.Text, timeSave);
                            }
                        }
                        txtAge.Text = string.Empty;
                        Response.Write("<script> window.alert('Saved Consultation Successfully.')</script>");
                    }
                    else
                    {
                        data.SavePatientDailyMedicalRecord
                            (
                                Convert.ToInt32(Session["ptId"]),
                                Convert.ToInt32(txtAge.Text),
                                txtPulseRate.Text,
                                Convert.ToDecimal(txtTemp.Text),
                                Convert.ToDecimal(txtWt.Text),
                                (height),
                                (txtBpressure.Text + "/" + txtBpressure0.Text),

                                txtDiagnosis.Text,
                                txtRecomendation.Text,
                                (string)Page.User.Identity.Name
                            );
                        foreach (ListItem li in checkbox_DiseaseList.Items)
                        {
                            if (li.Selected)
                            {
                                data.SavePatientDisease(Convert.ToString(Session["ptId"]), li.Text, timeSave);
                            }
                        }
                        txtAge.Text = string.Empty;
                        Response.Write("<script> window.alert('Saved Consultation Successfully.')</script>");
                    }
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

                    txtAge.Text = string.Empty;
                    txtTemp.Text = string.Empty;
                    txtWt.Text = string.Empty;
                    txtHt_feet.Text = string.Empty;
                    txtHt_inch.Text = string.Empty;
                    txtBpressure.Text = string.Empty;
                    txtBpressure0.Text = string.Empty;
                    txtDiagnosis.Text = string.Empty;
                    txtRecomendation.Text = string.Empty;
                    txtPulseRate.Text = string.Empty;
                    checkbox_DiseaseList.ClearSelection();
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
        else
            Response.Write("<script> window.alert('Please select Patient first before saving.')</script>");
    }

    private void showErrorSave(string err)
    {
        Response.Write("<script> window.alert('Did not save successfully please check all fields:"+err.ToString()+"')</script>");
    }
    protected void ButtonProceed_Click(object sender, EventArgs e)
    {
        string Patient_id= patientId.ToString();

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
        btnReset.Enabled = true;

        //Consultation Page
        if (Request.QueryString["id"] == null && Request.QueryString["enc"] == null)
            Response.Redirect("~/Medical%20Record/Consultation.aspx");
        //Comes from Patient Inquiry or Manage Patient
        else if (Request.QueryString["enc"] == null)
            Response.Redirect("~/Medical%20Record/Consultation.aspx?id="+Request.QueryString["id"]);
        //Comes from Medical History
        else if (Request.QueryString["id"] != null && Request.QueryString["enc"] != null)
        {
            Response.Redirect("~/Medical%20Record/Consultation.aspx?&id=" + Request.QueryString["id"] + "&enc=" + Request.QueryString["enc"]);
            btnReset.Enabled = false;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GridSearchName.DataSourceID = "PatientSearchName";
        PatientSearchName.SelectParameters["PatientLastName"].DefaultValue = txtSearchPatient.Text;
    }

    protected void LoadDataFromEncounter()
    {
        data = new DataAccess();
        List<string> patientDisease = new List<string>();

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
        patientDisease =  data.GetPatientsDisease(patientId.ToString(), encId);
        checkbox_DiseaseList.DataBind();
        foreach (string pd in patientDisease)
        {
            foreach (ListItem li in checkbox_DiseaseList.Items)
            {
                if (pd.ToString() == li.Text)
                    li.Selected = true;
            }
        }
    }
    
    protected void GridSearchName_SelectedIndexChanged(object sender, EventArgs e)
    {
        patientId = Int32.Parse(GridSearchName.Rows[GridSearchName.SelectedIndex].Cells[1].Text);
        Session["ptId"] = patientId;
        Response.Write("<script> window.alert('"+ Session["ptId"].ToString() +"') </script>");
        data = new DataAccess();


        patientData = data.GetValuesConsultation(patientId.ToString());
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
                txtAge.Text = (Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(ddlYear.Text)).ToString();
                txtAge.ReadOnly = true;
            }
        }

    }
    protected void txtSearchPatient_TextChanged(object sender, EventArgs e)
    {

    }
}