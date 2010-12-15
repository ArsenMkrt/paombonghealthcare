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

        ReportViewer1.Visible = true;
        SqlConnection reportConn = new SqlConnection(data.Dataconnection);
        System.Data.DataSet thisDataSet = new System.Data.DataSet();
        
        string[] report = new string[6]{"Report_ChildData","Report_DentalCare","Report_FamilyPlanning","Report_Leprosy","Report_Malaria",
            "Report_Maternal"};
        
        SqlCommand reportCmd = new SqlCommand(report[0]);
        reportCmd.CommandType = CommandType.StoredProcedure;
        reportCmd.Parameters.Add("@month",SqlDbType.Int).Value = month1;
        reportCmd.Parameters.Add("@month1",SqlDbType.Int).Value = month2;
        reportCmd.Parameters.Add("@year",SqlDbType.Int).Value = ddlYear.Text;
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = reportCmd;
        adapter.Fill(thisDataSet);

        ReportDataSource dataSource = new ReportDataSource("DataSet_Program", thisDataSet.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(dataSource);
        if(thisDataSet.Tables[0].Rows.Count == 0)
        {
            //lblMessage.Text = "Sorry, no products under this category!";
        }

        ReportViewer1.LocalReport.Refresh();
    }
}