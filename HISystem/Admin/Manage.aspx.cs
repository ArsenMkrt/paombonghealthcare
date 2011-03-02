using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Manage : System.Web.UI.Page
{
    private Reports report;
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int year = 2010; year <= 2100; year++)
        {
            ddlYear.Items.Add(year.ToString());
            ddlYear0.Items.Add(year.ToString());
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

    }
    
    protected void btnEdit_Click(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        report = new Reports();
        bool isDeleted;
        bool hasDataReport;
        bool hasDataPopulation;
        hasDataReport = report.HasDataForTheYear(Convert.ToInt32(ddlYear0.Text), ddlMonth0.Text, Convert.ToInt32(ddlBarangay0.Text));
        hasDataPopulation = report.HasPopulationData(Convert.ToInt32(ddlYear0.Text), ddlMonth0.Text, Convert.ToInt32(ddlBarangay0.Text));
        if (hasDataReport)
        {
            isDeleted = report.DeleteRecord(ddlMonth0.Text, Convert.ToInt32(ddlYear.Text), Convert.ToInt32(ddlBarangay0.Text));
            if (isDeleted)
                Response.Write("<script> window.alert('Deleted Record Successfully.')</script>");
            else
                Response.Write("<script> window.alert('Deleted Record Failed! Please Try Again!')</script>");
        }
        else
        {
            if (hasDataPopulation)
            {
                isDeleted = report.DeleteRecord(ddlMonth0.Text, Convert.ToInt32(ddlYear.Text), Convert.ToInt32(ddlBarangay0.Text));
                if (isDeleted)
                    Response.Write("<script> window.alert('Deleted Record Successfully.')</script>");
                else
                    Response.Write("<script> window.alert('Deleted Record Failed! Please Try Again!')</script>");
            }
            else
                Response.Write("<script> window.alert('There is no data or report to delete!')</script>");
        }
    }
}