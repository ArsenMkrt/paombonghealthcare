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
    private Report_Quarterly.ChildCareDataTable childTable;
    private Report_Quarterly.DentalCareDataTable dentalTable;
    private Report_Quarterly.FamilyPlanningDataTable fpTable;
    private Report_Quarterly.Report_LeprosyDataTable leprosyTable;
    private Report_Quarterly.Report_MalariaDataTable malariaTable;
    private Report_Quarterly.MaternalCareDataTable maternalTable;

    public SqlParameter[] month = new SqlParameter[2];

    protected void Page_Load(object sender, EventArgs e)
    {
        data = new DataAccess();
        ReportViewer1.Visible = true;
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
        
        //SqlConnection reportConn = new SqlConnection(data.Dataconnection);

        //reportConn.Open();

        //childTable = new Report_Quarterly.ChildCareDataTable();
        //dentalTable = new Report_Quarterly.DentalCareDataTable();
        //fpTable = new Report_Quarterly.FamilyPlanningDataTable();
        //leprosyTable = new Report_Quarterly.Report_LeprosyDataTable();
        //malariaTable = new Report_Quarterly.Report_MalariaDataTable();
        //maternalTable = new Report_Quarterly.MaternalCareDataTable();

        ////ReportDataSource datasource = new ReportDataSource("ChildData",ds.Tables[0]);
        //ReportViewer1.LocalReport.ReportPath = "ReportTemplate.rdlc";

        //ReportParameter[] parameters = new ReportParameter[3];
        //parameters[0] = new ReportParameter("month1", month1.ToString());
        //parameters[1] = new ReportParameter("month", month2.ToString());
        //parameters[2] = new ReportParameter("year", DropDownList1.Text);
        //ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //ReportViewer1.LocalReport.SetParameters(parameters);
        ////ReportViewer1.LocalReport.DataSources.Add(datasource);
        //ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"ReportTemplate.rdlc");
        //ReportViewer1.LocalReport.Refresh();

        /*Leprosy*/
        LeprosyObject2.SelectParameters["month1"].DefaultValue = month1.ToString();
        LeprosyObject2.SelectParameters["month"].DefaultValue = month2.ToString();
        LeprosyObject2.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*Malaria*/
        MalariaObject2.SelectParameters["month1"].DefaultValue = month1.ToString();
        MalariaObject2.SelectParameters["month"].DefaultValue = month2.ToString();
        MalariaObject2.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*MaternalCare*/
        MaternalCareObject2.SelectParameters["month1"].DefaultValue = month1.ToString();
        MaternalCareObject2.SelectParameters["month"].DefaultValue = month2.ToString();
        MaternalCareObject2.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*ChildCare*/
        ChildCareObject2.SelectParameters["month1"].DefaultValue = month1.ToString();
        ChildCareObject2.SelectParameters["month"].DefaultValue = month2.ToString();
        ChildCareObject2.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*DentalObject*/
        DentalObject.SelectParameters["month1"].DefaultValue = month1.ToString();
        DentalObject.SelectParameters["month"].DefaultValue = month2.ToString();
        DentalObject.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*FamilyPlanning*/
        FamilyPlanObject.SelectParameters["month1"].DefaultValue = month1.ToString();
        FamilyPlanObject.SelectParameters["month"].DefaultValue = month2.ToString();
        FamilyPlanObject.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*Tuberculosis*/
        TuberObject.SelectParameters["month1"].DefaultValue = month1.ToString();
        TuberObject.SelectParameters["month"].DefaultValue = month2.ToString();
        TuberObject.SelectParameters["year"].DefaultValue = DropDownList1.Text;
        /*Schistomiasis*/
        SchistoObject.SelectParameters["month1"].DefaultValue = month1.ToString();
        SchistoObject.SelectParameters["month"].DefaultValue = month2.ToString();
        SchistoObject.SelectParameters["year"].DefaultValue = DropDownList1.Text;

        //Report_QuarterlyTableAdapters.ChildCareTableAdapter child = new Report_QuarterlyTableAdapters.ChildCareTableAdapter();
        //child.Dispose();
        //child.Fill(childTable, month1, month2, Int32.Parse(DropDownList1.Text));
        //child.GetData(month1, month2, Int32.Parse(DropDownList1.Text));

        //Report_QuarterlyTableAdapters.DentalCareTableAdapter dental = new Report_QuarterlyTableAdapters.DentalCareTableAdapter();
        //dental.GetData(month1, month2, Int32.Parse(DropDownList1.Text));
        //Report_QuarterlyTableAdapters.FamilyPlanningTableAdapter fp = new Report_QuarterlyTableAdapters.FamilyPlanningTableAdapter();
        //fp.GetData(month1, month2, Int32.Parse(DropDownList1.Text));
        //Report_QuarterlyTableAdapters.Report_LeprosyTableAdapter leprosy = new Report_QuarterlyTableAdapters.Report_LeprosyTableAdapter();
        //leprosy.GetData(month1, month2, Int32.Parse(DropDownList1.Text));
        //Report_QuarterlyTableAdapters.Report_MalariaTableAdapter malaria = new Report_QuarterlyTableAdapters.Report_MalariaTableAdapter();
        //malaria.GetData(month1, month2, Int32.Parse(DropDownList1.Text));
        
        //Report_QuarterlyTableAdapters.MaternalCareTableAdapter maternal = new Report_QuarterlyTableAdapters.MaternalCareTableAdapter();
        //maternal.Dispose();
        //maternal.Fill(maternalTable, month1, month2, Int32.Parse(DropDownList1.Text));
        //maternal.GetData(month1, month2, Int32.Parse(DropDownList1.Text));
        ReportViewer1.LocalReport.Refresh();
        
        //reportConn.Close();
    }
}