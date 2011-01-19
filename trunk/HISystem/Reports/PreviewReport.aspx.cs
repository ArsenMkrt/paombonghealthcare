using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Reporting.WebForms;

public partial class Reports_PreviewReport : System.Web.UI.Page
{
    private DataAccess data;
    private int month1;
    private int month2;
    private ReportPrintDocument rpd;

    protected void Page_Load(object sender, EventArgs e)
    {

        data = new DataAccess();
        for (int i = 2010; i < 2100; i++)
        {
            DropDownList1.Items.Add(i.ToString());
        }
    }
    protected void btn_runReport_Click(object sender, EventArgs e)
    {
        
        switch (ddlQuarter.Text)
        {
            case "1st Quarter": 
                { 
                    month1 = 1;
                    month2 = 3;
                  } break;
            case "2nd Quarter": 
                {
                    month1 = 4;
                    month2 = 6;
                } break;
            case "3rd Quarter": 
                {
                    month1 = 7;
                    month2 = 9;
                } break;
            case "4th Quarter": 
                {
                    month1 = 10;
                    month2 = 12;
                } break;
            case "All": 
                {
                    month1 = 1;
                    month2 = 12;
                } break;
        }
        data = new DataAccess();
        ReportPaombong.Visible = true;
        
        /*Leprosy*/
        _Leprosy.SelectParameters["month1"].DefaultValue = month1.ToString();
        _Leprosy.SelectParameters["month"].DefaultValue = month2.ToString();
        _Leprosy.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*MaternalCare*/
        _MaternalCare.SelectParameters["month1"].DefaultValue = month1.ToString();
        _MaternalCare.SelectParameters["month"].DefaultValue = month2.ToString();
        _MaternalCare.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*Malaria*/
        _Malaria.SelectParameters["month1"].DefaultValue = month1.ToString();
        _Malaria.SelectParameters["month"].DefaultValue = month2.ToString();
        _Malaria.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*ChildCare*/
        _ChildCare.SelectParameters["month1"].DefaultValue = month1.ToString();
        _ChildCare.SelectParameters["month"].DefaultValue = month2.ToString();
        _ChildCare.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*_DentalCare*/
        _DentalCare.SelectParameters["month1"].DefaultValue = month1.ToString();
        _DentalCare.SelectParameters["month"].DefaultValue = month2.ToString();
        _DentalCare.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*FamilyPlanning*/
        _FamilyPlanning.SelectParameters["month1"].DefaultValue = month1.ToString();
        _FamilyPlanning.SelectParameters["month"].DefaultValue = month2.ToString();
        _FamilyPlanning.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*Tuberculosis*/
        _Tuberculosis.SelectParameters["month1"].DefaultValue = month1.ToString();
        _Tuberculosis.SelectParameters["month"].DefaultValue = month2.ToString();
        _Tuberculosis.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*Schistomiasis*/
        _Schisto.SelectParameters["month1"].DefaultValue = month1.ToString();
        _Schisto.SelectParameters["month"].DefaultValue = month2.ToString();
        _Schisto.SelectParameters["year"].DefaultValue = DropDownList1.Text;

        ReportPaombong.LocalReport.Refresh();
    }
    protected void rdbtn_Reports_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbtn_Reports.Checked)
        {
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            DropDownList1.Visible = true;
            ddlQuarter.Visible = true;
        }
        else
        {
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            DropDownList1.Visible = false;
            ddlQuarter.Visible = false;
        }
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
        Response.Cache.SetNoStore();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        LocalReport lr = new LocalReport();
        lr.ReportPath = "Report.rdlc";
        rpd = new ReportPrintDocument(lr);  
    }
}