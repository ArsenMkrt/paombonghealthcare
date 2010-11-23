using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_Templates_ChildCareTemp : System.Web.UI.Page
{
    private DataAccess data;
    private MonthConverter month;
    private int year;
    private string quarter;
    private string indicator = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            data = new DataAccess();
            month = new MonthConverter();

            year = Convert.ToInt32(Request["year"]);
            lblYear.Text = year.ToString();
            quarter = (string)Request["Quarter"];
            lblQuarter.Text = quarter;
            
            if (Session["Indicator"] == null)
            {
                ddlIndicator.Items.Clear();
                data.LoadIndicator(Convert.ToString(Request["program"]).Trim(), ddlIndicator);
            }
            else
            {
                indicator = (string)Session["Indicator"];
                ddlIndicator.Text = indicator;        
            }

            switch (quarter)
            {
                case "1":
                    {
                        this.GridView1.Columns[5].HeaderText = "January";
                        this.GridView1.Columns[6].HeaderText = "February";
                        this.GridView1.Columns[7].HeaderText = "March";
                        break;
                    }
                case "2":
                    {
                        this.GridView1.Columns[5].HeaderText = "April";
                        this.GridView1.Columns[6].HeaderText = "May";
                        this.GridView1.Columns[7].HeaderText = "June";
                        break;
                    }
                case "3":
                    {
                        this.GridView1.Columns[5].HeaderText = "July";
                        this.GridView1.Columns[6].HeaderText = "August";
                        this.GridView1.Columns[7].HeaderText = "September";
                        break;
                    }
                case "4":
                    {
                        this.GridView1.Columns[5].HeaderText = "October";
                        this.GridView1.Columns[6].HeaderText = "November";
                        this.GridView1.Columns[7].HeaderText = "December";
                        break;
                    }
                default:
                    {
                        Response.Write("<script>window.alert('Try Again')</script>");
                        Response.Redirect("/Reports/ViewEditReport.aspx");
                        break;
                    }
            }

            if (Session["Indicator"] == null)
            {
                Response.Write("<script type='text/javascript'>" + "alert(\"A: " + ddlIndicator.Text + "\");</script>");
                data.LoadGridChildCare(GridView1, ddlIndicator.Text.Trim(), lblQuarter.Text, lblYear.Text);
            }
            else
            {
                Response.Write("<script type='text/javascript'>" + "alert(\"B: " + Convert.ToString(Session["Indicator"]).Trim() + "\");</script>");
                data.LoadGridChildCare(GridView1, Convert.ToString(Session["Indicator"]).Trim(), lblQuarter.Text,lblYear.Text);
            }
        }

    }
    protected void Save_Click(object sender, EventArgs e)
    {
        //ContentPlaceHolder cph = (ContentPlaceHolder)Page.Master.FindControl("ContentPlaceHolder1");
        //Panel panel = (Panel)cph.FindControl("PanelGridview");                              
        //GridView gridview = (GridView)panel.FindControl("GridView1");
        //foreach (GridViewRow row in gridview.Rows)
        //{
        //    string label = ((Label)row.FindControl("lblBarangay")).Text; //Correct
        //    string label3 = ((TextBox)row.Controls[1].FindControl("txtPopulation")).Text;
        //    string label4 = ((TextBox)row.Cells[1].Controls[1].FindControl("txtPopulation")).Text;
        //    TextBox pop = (TextBox)Extender.FindControlR(row,"txtPopulation");
        //    Response.Write("<script type='text/javascript'>" + "alert(\"l1:" + label + " ,l3:" + label3 +" ,pop: "+pop.Text+ " ,l4:"+ label4 + "\");</script>");
        //}
        //TextBox tPop = ((TextBox)gridview.Rows[1].Cells[1].FindControl("txtPopulation"));
        //TextBox tPop2 = ((TextBox)gridview.Rows[1].Cells[2].Controls[0].FindControl("txtPopulation"));
        //Response.Write("<script type='text/javascript'>" + "alert(\"l1:" + ddlIndicator.Text.Trim() + "\");</script>");
        //}
        //SaveReport();
    }

    public void SaveReport()
    {
        month = new MonthConverter();

            GridViewRow row = (GridViewRow)GridView1.Rows[1];
            Label barangay = (Label)row.FindControl("lblBarangay");

            TextBox population = (TextBox)row.FindControl("txtPopulation");
            string target = ((TextBox)row.FindControl("txtTarget")).Text;

            TextBox M1 = (TextBox)row.FindControl("txtMale1");
            TextBox F1 = (TextBox)row.FindControl("txtFemale1");
            TextBox M2 = (TextBox)row.FindControl("txtMale2");
            TextBox F2 = (TextBox)row.FindControl("txtFemale2");
            TextBox M3 = (TextBox)row.FindControl("txtMale3");
            TextBox F3 = (TextBox)row.FindControl("txtFemale3");
            TextBox qa = (TextBox)row.FindControl("txtQA");
            TextBox percent = (TextBox)row.FindControl("txtPercent");


        //}
            ///*For 1st Month*/
            //data.InsertChildReport(Label4.Text, Convert.ToInt32(M1.Text.Trim()), Convert.ToInt32(F1.Text.Trim()), data.GetBarangayID(barangay.Text),
            //    Convert.ToString(month.MonthNameToIndex(this.GridView1.Columns[3].HeaderText)), qa.Text, Convert.ToDecimal(percent.Text.Trim()), Convert.ToInt32(population.Text.Trim()));
            ///*For 2nd Month*/
            //data.InsertChildReport(Label4.Text, Convert.ToInt32(M2.Text.Trim()), Convert.ToInt32(F2.Text.Trim()), data.GetBarangayID(barangay.Text),
            //   Convert.ToString(month.MonthNameToIndex(this.GridView1.Columns[3].HeaderText)), qa.Text, Convert.ToDecimal(percent.Text.Trim()), Convert.ToInt32(population.Text.Trim()));
            ///*For 3rd Month*/
            //data.InsertChildReport(Label4.Text, Convert.ToInt32(M3.Text.Trim()), Convert.ToInt32(F3.Text.Trim()), data.GetBarangayID(barangay.Text),
            //   Convert.ToString(month.MonthNameToIndex(this.GridView1.Columns[3].HeaderText)) + "-" + year.Text, qa.Text, Convert.ToDecimal(percent.Text.Trim()), Convert.ToInt32(population.Text.Trim()));
        //}
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }
    protected void ddlIndicator_SelectedIndexChanged(object sender, EventArgs e)
    {
        data = new DataAccess();
        Session["Indicator"] = ddlIndicator.SelectedValue.ToString().Trim();
        data.LoadGridChildCare(GridView1, Convert.ToString(Session["Indicator"]).Trim(), lblQuarter.Text, lblYear.Text);
    }
}