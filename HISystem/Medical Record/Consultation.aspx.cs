using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Web.Security;
using bll;
public partial class Medical_Record_Consultation : System.Web.UI.Page
{
    private MedicalRecord mr;
    private Disease dis;
    private DataTable patientData;
    private DataTable ptData;
    private string height;
    private string err;
    private string encId;
    private int patientId;
    
    //protected void Page_Init(object Sender, EventArgs e)
    //{
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
    //    Response.Cache.SetNoStore();
    //    Response.Cache.SetValidUntilExpires(false);
    //    Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
    //    Response.Expires = -1500;
    //    Response.AppendHeader("Pragma", "no-cache");
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            btnReset.Enabled = true;
            btnSave.Enabled = true;
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
        mr = new MedicalRecord();

        patientData = mr.GetValuesConsultation(patientId.ToString());
        Session["PatientData"] = patientData;

        if (patientData.Rows.Count > 0)
        {
            foreach (DataRow dr in patientData.Rows)
            {
                
                txtlname.Text = dr["PatientLName"].ToString().Trim();
                txtfname.Text = dr["PatientFName"].ToString().Trim();
                txtmname.Text = dr["PatientMName"].ToString().Trim();
                txtPhilhealthNum.Text = dr["PatientFaxNumber"].ToString().Trim();

                txtDatepick.Text = dr["PatientBirthdate"].ToString().Trim();
                
                txtAddress.Text = dr["PatientAddress"].ToString().Trim();
                ddlBarangay.Text = dr["PatientBarangay"].ToString().Trim();
                txtAddress.ReadOnly = true;
                txtlname.ReadOnly = true;
                txtfname.ReadOnly = true;
                txtmname.ReadOnly = true;
                txtPhilhealthNum.ReadOnly = true;
                
                ddlBarangay.Enabled = false;


                DateTime bdate = DateTime.Parse(dr["PatientBirthdate"].ToString().Trim());
                calcAge a = new calcAge();
                txtAge.Text = a.GetAge(bdate);
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
                mr = new MedicalRecord();
                dis = new Disease();
                if (txtDiagnosis.Text.Length > 0 || Request.QueryString["id"] != null)
                {
                    timeSave = DateTime.Now;
                    
                    if (Request.QueryString["id"] != null)
                    {
                        mr.SavePatientDailyMedicalRecord
                            (
                                Convert.ToInt32(Request.QueryString["id"]),
                                txtAge.Text,
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
                                dis.SavePatientDisease(Request.QueryString["id"].ToString(), li.Text, timeSave);
                            }
                        }
                        txtAge.Text = string.Empty;
                        txtHt_feet.Text = string.Empty;
                        txtHt_inch.Text = string.Empty;
                        Response.Write("<script> window.alert('Saved Consultation Successfully.')</script>");
                    }
                    else
                    {
                        mr.SavePatientDailyMedicalRecord
                            (
                                Convert.ToInt32(Session["ptId"]),
                                txtAge.Text,
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
                                dis.SavePatientDisease(Convert.ToString(Session["ptId"]), li.Text, timeSave);
                            }
                        }
                        txtAge.Text = string.Empty;
                        txtHt_feet.Text = string.Empty;
                        txtHt_inch.Text = string.Empty;
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
                    txtDatepick.Text = string.Empty;
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
        string Patient_id = patientId.ToString();

        mr = new MedicalRecord();

        patientData = mr.GetValuesConsultation(Patient_id);
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


                txtDatepick.Text = dr["PatientBirthdate"].ToString().Trim();
                txtAddress.Text = dr["PatientAddress"].ToString().Trim();
                ddlBarangay.Text = dr["PatientBarangay"].ToString().Trim();
                txtAddress.ReadOnly = true;
                txtlname.ReadOnly = true;
                txtfname.ReadOnly = true;
                txtmname.ReadOnly = true;
                txtPhilhealthNum.ReadOnly = true;




                DateTime bdate = DateTime.Parse(dr["PatientBirthdate"].ToString().Trim());
                calcAge a = new calcAge();
                txtAge.Text = a.GetAge(bdate);
              //  txtAge.Text = (Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(ddlYear.Text)).ToString();
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
        mr = new MedicalRecord();
        dis = new Disease();
        List<string> patientDisease = new List<string>();

        ptData = mr.GetEncounterData(encId);
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
            txtPulseRate.Text = dr["PulseRate"].ToString().Trim();
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
        patientDisease =  dis.GetPatientsDisease(patientId.ToString(), encId);
        checkbox_DiseaseList.DataBind();
        foreach (string pd in patientDisease)
        {
            foreach (ListItem li in checkbox_DiseaseList.Items)
            {
                if (pd.ToString() == li.Text)
                    li.Selected = true;
            }
        }
        btnSave.Enabled = false;
        btnSearch.Enabled = false;
    }
    
    protected void GridSearchName_SelectedIndexChanged(object sender, EventArgs e)
    {
        patientId = Int32.Parse(GridSearchName.Rows[GridSearchName.SelectedIndex].Cells[1].Text);
        Session["ptId"] = patientId;
        mr = new MedicalRecord();

        patientData = mr.GetValuesConsultation(patientId.ToString());
        Session["PatientData"] = patientData;

        if (patientData.Rows.Count > 0)
        {
            foreach (DataRow dr in patientData.Rows)
            {
                txtlname.Text = dr["PatientLName"].ToString().Trim();
                txtfname.Text = dr["PatientFName"].ToString().Trim();
                txtmname.Text = dr["PatientMName"].ToString().Trim();
                txtPhilhealthNum.Text = dr["PatientFaxNumber"].ToString().Trim();
                
                txtDatepick.Text = dr["PatientBirthdate"].ToString().Trim();
                txtAddress.Text = dr["PatientAddress"].ToString().Trim();
                ddlBarangay.Text = dr["PatientBarangay"].ToString().Trim();
                txtAddress.ReadOnly = true;
                txtlname.ReadOnly = true;
                txtfname.ReadOnly = true;
                txtmname.ReadOnly = true;
                txtPhilhealthNum.ReadOnly = true;



                DateTime bdate = DateTime.Parse(dr["PatientBirthdate"].ToString().Trim());
                calcAge a = new calcAge();
                txtAge.Text = a.GetAge(bdate);
            //    txtAge.Text = (Int32.Parse(DateTime.Now.ToString("yyyy")) - Int32.Parse(ddlYear.Text)).ToString();
                txtAge.ReadOnly = true;
            }
        }

    }
    protected void txtSearchPatient_TextChanged(object sender, EventArgs e)
    {

    }
}