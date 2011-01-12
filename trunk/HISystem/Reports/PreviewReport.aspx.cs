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
    //private Report_Quarterly.ChildCareDataTable childTable;
    //private Report_Quarterly.DentalCareDataTable dentalTable;
    //private Report_Quarterly.FamilyPlanningDataTable fpTable;
    //private Report_Quarterly.Report_LeprosyDataTable leprosyTable;
    //private Report_Quarterly.Report_MalariaDataTable malariaTable;
    //private Report_Quarterly.MaternalCareDataTable maternalTable;

    protected void Page_Load(object sender, EventArgs e)
    {
        data = new DataAccess();
        //ReportViewer1.Visible = false;
        for (int i = 2010; i < 2100; i++)
            DropDownList1.Items.Add(i.ToString());
    }
    protected void btn_runReport_Click(object sender, EventArgs e)
    {
        switch (ddlQuarter.Text)
        {
            case "1st Quarter": { month1 = 1; month2 = 3; } break;
            case "2nd Quarter": { month1 = 4; month2 = 6; } break;
            case "3rd Quarter": { month1 = 7; month2 = 9; } break;
            case "4th Quarter": { month1 = 10; month2 = 12; } break;
            case "All": { month1 = 1; month2 = 12; } break;
        }
        data = new DataAccess();
        ReportViewer1.Visible = true;

        /*Leprosy*/
        leBusinessObject.SelectParameters["month1"].DefaultValue = month1.ToString();
        leBusinessObject.SelectParameters["month"].DefaultValue = month2.ToString();
        leBusinessObject.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*Malaria*/
        maBusinessObject.SelectParameters["month1"].DefaultValue = month1.ToString();
        maBusinessObject.SelectParameters["month"].DefaultValue = month2.ToString();
        maBusinessObject.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*MaternalCare*/
        mcBusinessObject.SelectParameters["month1"].DefaultValue = month1.ToString();
        mcBusinessObject.SelectParameters["month"].DefaultValue = month2.ToString();
        mcBusinessObject.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*ChildCare*/
        ccBusinessObject.SelectParameters["month1"].DefaultValue = month1.ToString();
        ccBusinessObject.SelectParameters["month"].DefaultValue = month2.ToString();
        ccBusinessObject.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*dcBusinessObject*/
        dcBusinessObject.SelectParameters["month1"].DefaultValue = month1.ToString();
        dcBusinessObject.SelectParameters["month"].DefaultValue = month2.ToString();
        dcBusinessObject.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*FamilyPlanning*/
        fpBusinessObject.SelectParameters["month1"].DefaultValue = month1.ToString();
        fpBusinessObject.SelectParameters["month"].DefaultValue = month2.ToString();
        fpBusinessObject.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*Tuberculosis*/
        TuberObject.SelectParameters["month1"].DefaultValue = month1.ToString();
        TuberObject.SelectParameters["month"].DefaultValue = month2.ToString();
        TuberObject.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*Schistomiasis*/
        scBusinessObject.SelectParameters["month1"].DefaultValue = month1.ToString();
        scBusinessObject.SelectParameters["month"].DefaultValue = month2.ToString();
        scBusinessObject.SelectParameters["year"].DefaultValue = DropDownList1.Text;

        ReportViewer1.LocalReport.Refresh();
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
        //if (RadioButton3.Checked)
        //{
        //    DropDownList2.Visible = true;
        //}
        //else
        //{
        //    DropDownList2.Visible = false;
        //}
    }
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        //if (RadioButton4.Checked)
        //{
        //    ddlQuarter.Visible = true;
        //}
        //else
        //{
        //    ddlQuarter.Visible = false;
        //}
    }
    protected void RadioButton5_CheckedChanged(object sender, EventArgs e)
    {
        //if (RadioButton5.Checked)
        //{
        //    DropDownList1.Visible = true;
        //}
        //else
        //{
        //    DropDownList1.Visible = false;
        //}
    }
}