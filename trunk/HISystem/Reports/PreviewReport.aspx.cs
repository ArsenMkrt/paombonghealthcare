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
        }
        data = new DataAccess();
        ReportViewer1.Visible = true;
        SqlConnection reportConn = new SqlConnection(data.Dataconnection);

        reportConn.Open();
 
        childTable = new Report_Quarterly.ChildCareDataTable();
        dentalTable = new Report_Quarterly.DentalCareDataTable();
        fpTable = new Report_Quarterly.FamilyPlanningDataTable();
        leprosyTable = new Report_Quarterly.Report_LeprosyDataTable();
        malariaTable = new Report_Quarterly.Report_MalariaDataTable();
        maternalTable = new Report_Quarterly.MaternalCareDataTable();
 
        Report_QuarterlyTableAdapters.ChildCareTableAdapter child = new Report_QuarterlyTableAdapters.ChildCareTableAdapter();
        child.Fill(childTable, month1, month2, 2010);
        //child.GetData(month1, month2, 2010);
        Report_QuarterlyTableAdapters.DentalCareTableAdapter dental = new Report_QuarterlyTableAdapters.DentalCareTableAdapter();
        dental.Fill(dentalTable, month1, month2, 2010);
        Report_QuarterlyTableAdapters.FamilyPlanningTableAdapter fp = new Report_QuarterlyTableAdapters.FamilyPlanningTableAdapter();
        fp.Fill(fpTable, month1, month2, 2010);
        Report_QuarterlyTableAdapters.Report_LeprosyTableAdapter leprosy = new Report_QuarterlyTableAdapters.Report_LeprosyTableAdapter();
        leprosy.Fill(leprosyTable, month1, month2, 2010);
        Report_QuarterlyTableAdapters.Report_MalariaTableAdapter malaria = new Report_QuarterlyTableAdapters.Report_MalariaTableAdapter();
        malaria.Fill(malariaTable, month1, month2, 2010);
        Report_QuarterlyTableAdapters.MaternalCareTableAdapter maternal = new Report_QuarterlyTableAdapters.MaternalCareTableAdapter();
        //maternal.Fill(maternalTable, month1, month2, 2010);
        //maternal.GetData(month1, month2, 2010);
        ReportViewer1.LocalReport.Refresh();
        reportConn.Close();
    }
}