using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_ViewEditReport : System.Web.UI.Page
{
    private DataAccess data;
    protected void Page_Load(object sender, EventArgs e)
    {
        ddlQuarter.Enabled = false;
        ddlYear.Enabled = false;

        for (int year = 2010; year <= 2100; year++)
            ddlYear.Items.Add(year.ToString());
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        data = new DataAccess();

        if (ddlProgram.Text != "" && ddlProgram.Text != "" && ddlQuarter.Text != "")
        {
            switch (ddlProgram.Text)
            {
                case "Maternal Care":
                    {
                        Response.Redirect("/Paombong/Reports/Templates/ccMaternalCare.aspx?program="
                            + Server.UrlEncode(ddlProgram.Text.ToString()) +
                            "&year=" + Server.UrlEncode(ddlYear.Text)
                            + "&Quarter=" + Server.UrlEncode(ddlQuarter.Items[ddlQuarter.SelectedIndex].Value));
                        break;
                    }
                case "Family Planning":
                    {
                        Response.Redirect("/Paombong/Reports/Templates/ccFPlanning.aspx?program="
                            + Server.UrlEncode(ddlProgram.Text.ToString())
                            + "&year=" + Server.UrlEncode(ddlYear.Text)
                            + "&Quarter=" + Server.UrlEncode(ddlQuarter.Items[ddlQuarter.SelectedIndex].Value));
                        break;
                    }
                case "Child Care A":
                    {
                        Response.Redirect("/Paombong/Reports/Templates/ccChildCare.aspx?program="
                            + Server.UrlEncode(ddlProgram.Text.ToString())
                            + "&year=" + Server.UrlEncode(ddlYear.Text)
                            + "&Quarter=" + Server.UrlEncode(ddlQuarter.Items[ddlQuarter.SelectedIndex].Value));
                        break;
                    }
                case "Child Care B":
                    {
                        Response.Redirect("/Paombong/Reports/Templates/ccChildCare.aspx?program="
                            + Server.UrlEncode(ddlProgram.Text.ToString())
                            + "&year=" + Server.UrlEncode(ddlYear.Text)
                            + "&Quarter=" + Server.UrlEncode(ddlQuarter.Items[ddlQuarter.SelectedIndex].Value));
                        break;
                    }
                case "Dental Care":
                    {
                        Response.Redirect("/Paombong/Reports/Templates/ccDentalCare.aspx?program="
                            + Server.UrlEncode(ddlProgram.Text.ToString())
                            + "&year=" + Server.UrlEncode(ddlYear.Text)
                            + "&Quarter=" + Server.UrlEncode(ddlQuarter.Items[ddlQuarter.SelectedIndex].Value));
                        break;
                    }
                case "Malaria":
                    {
                        Response.Redirect("/Paombong/Reports/Templates/ccMalaria.aspx?program="
                            + Server.UrlEncode(ddlProgram.Text.ToString())
                            + "&year=" + Server.UrlEncode(ddlYear.Text)
                            + "&Quarter=" + Server.UrlEncode(ddlQuarter.Items[ddlQuarter.SelectedIndex].Value));
                        break;
                    }
                case "Schistosomiasis":
                    {
                        Response.Redirect("/Paombong/Reports/Templates/ccSchistomiasis.aspx?program="
                            + Server.UrlEncode(ddlProgram.Text.ToString())
                            + "&year=" + Server.UrlEncode(ddlYear.Text)
                            + "&Quarter=" + Server.UrlEncode(ddlQuarter.Items[ddlQuarter.SelectedIndex].Value));
                        break;
                    }
                case "Filariasis":
                    {
                        Response.Redirect("/Paombong/Reports/Templates/ccFilariasis.aspx?program="
                            + Server.UrlEncode(ddlProgram.Text.ToString())
                            + "&year=" + Server.UrlEncode(ddlYear.Text)
                            + "&Quarter=" + Server.UrlEncode(ddlQuarter.Items[ddlQuarter.SelectedIndex].Value));
                        break;
                    }
                case "Tuberculosis":
                    {
                        Response.Redirect("/Paombong/Reports/Templates/ccTuberculosis.aspx?program="
                            + Server.UrlEncode(ddlProgram.Text.ToString())
                            + "&year=" + Server.UrlEncode(ddlYear.Text)
                            + "&Quarter=" + Server.UrlEncode(ddlQuarter.Items[ddlQuarter.SelectedIndex].Value));
                        break;
                    }
                case "Leprosy":
                    {
                        Response.Redirect("/Paombong/Reports/Templates/ccLeprosy.aspx?program="
                            + Server.UrlEncode(ddlProgram.Text.ToString())
                            + "&year=" + Server.UrlEncode(ddlYear.Text)
                            + "&Quarter=" + Server.UrlEncode(ddlQuarter.Items[ddlQuarter.SelectedIndex].Value));
                        break;
                    }
            }

        }
    }
    protected void ddlProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlQuarter.Enabled = true;
        ddlYear.Enabled = true;
    }
}