using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_AddReport : System.Web.UI.Page
{
    private Barangay bar;
    private Reports rep;
    private MonthConverter mc;

    //protected void Page_Init(object Sender, EventArgs e)
    //{
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
    //    Response.Cache.SetNoStore();
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlMonth.Enabled = true;
        ddlBarangay.Enabled = true;
 
        for (int year = 2010; year <= 2100; year++)
            ddlYear.Items.Add(year.ToString());
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        rep = new Reports();
        bar = new Barangay();
        mc = new MonthConverter();
        bool inserted = false;

        if (txtPopulation.Text != "")
        {
            if (Int32.Parse(txtPopulation.Text) > 0)
            {
                if (rep.HasDataForTheYear(Int32.Parse(ddlYear.Text), ddlMonth.Text,bar.GetBarangayID(ddlBarangay.Text)))
                {
                    Response.Write("<script> window.alert('Barangay: "+ddlBarangay.Text+" of the Year: "+
                        ddlYear.Text+" has data in the database. Please Try Other Year for the Barangay')</script>");
                }
                else
                {
                    inserted = rep.InsertPopulation(bar.GetBarangayID(ddlBarangay.Text), Int32.Parse(txtPopulation.Text),
                        Int32.Parse("0"), mc.MonthNameToIndex(ddlMonth.Text), Int32.Parse(ddlYear.Text));

                    if (inserted)
                    {
                        Response.Redirect("~/Reports/Templates/xAllProgram.aspx?&month=" + Server.UrlEncode(ddlMonth.Text) +
                            "&year=" + Server.UrlEncode(ddlYear.Text) +
                            "&barangay=" + Server.UrlEncode(ddlBarangay.Text) +
                            "&population=" + Server.UrlEncode(txtPopulation.Text));
                    }
                    else
                    {
                        Response.Write("<script> window.alert('Population Insertion has failed, Please try Again.')</script>");
                    }
                }

            }
            else
                Response.Write("<script> window.alert('Population should be greater than zero.')</script>");
        }
        else
            Response.Write("<script> window.alert('Please Fill the Population Field.')</script>");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("mReport.aspx");
    }
    protected void Program_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}