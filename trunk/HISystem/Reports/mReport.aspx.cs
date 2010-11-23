using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_AddReport : System.Web.UI.Page
{
    private DataAccess data;

    protected void Page_Load(object sender, EventArgs e)
    {
        //ddlMonth.Enabled = false;
        //ddlBarangays.Enabled = false;

        //for (int year = 2010; year <= 2100; year++)
        //    ddlBarangays.Items.Add(year.ToString());
    }
    protected void ddlProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ddlMonth.Enabled = true;
        //ddlBarangays.Enabled = true;
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        data = new DataAccess();

        if (ddlProgram.Text != "")
        {
            switch (ddlProgram.Text)
            {
                case "Maternal Care": 
                    {
                        string Program = "MaternalCare";
                        Response.Redirect("/Paombong/Reports/Templates/addMaternalCare.aspx?&p=" + Server.UrlEncode("Maternal Care") + "&program=" + Server.UrlEncode(Program)); 
                        break; 
                    }
                case "Family Planning": 
                    {
                        string Program = "FamilyPlanning";
                        Response.Redirect("/Paombong/Reports/Templates/addFPlanning.aspx?&p=" + Server.UrlEncode("Family Planning") + "&program=" + Server.UrlEncode(Program)); 
                        break; 
                    }
                case "Child Care A": 
                    {
                        string Program = "ChildCare";
                        Response.Redirect("/Paombong/Reports/Templates/addChildCare.aspx?&p=" + Server.UrlEncode("Child Care A") + "&program=" + Server.UrlEncode(Program)); 
                        break; 
                    }
                case "Child Care B": 
                    {
                        string Program = "ChildCare";
                        Response.Redirect("/Paombong/Reports/Templates/addChildCare.aspx?&p=" + Server.UrlEncode("Child Care B") + "&program=" + Server.UrlEncode(Program)); 
                        break; 
                    }
                case "Dental Care": 
                    {
                        string Program = "DentalCare";
                        Response.Redirect("/Paombong/Reports/Templates/addDentalCare.aspx?&p=" + Server.UrlEncode("Dental Care") + "&program=" + Server.UrlEncode(Program)); 
                        break; 
                    }
                case "Malaria": 
                    {
                        Response.Redirect("/Paombong/Reports/Templates/addMalaria.aspx?&p=" + Server.UrlEncode("Malaria") + "&program=" + Server.UrlEncode(ddlProgram.Text)); 
                        break; 
                    }
                case "Schistosomiasis": 
                    {
                        string Program = "Schisto";
                        Response.Redirect("/Paombong/Reports/Templates/addSchistomiasis.aspx?&p=" + Server.UrlEncode("Schistosomiasis") + "&program=" + Server.UrlEncode(Program)); 
                        break; 
                    }
                case "Filariasis": 
                    {
                        Response.Redirect("/Paombong/Reports/Templates/addFilariasis.aspx?&p=" + Server.UrlEncode("Filariasis") + "&program=" + Server.UrlEncode(ddlProgram.Text)); 
                        break; 
                    }
                case "Tuberculosis": 
                    {
                        Response.Redirect("/Paombong/Reports/Templates/addTuberculosis.aspx?&p=" + Server.UrlEncode("Tuberculosis") + "&program=" + Server.UrlEncode(ddlProgram.Text)); 
                        break; 
                    }
                case "Leprosy": 
                    {
                        Response.Redirect("/Paombong/Reports/Templates/addLeprosy.aspx?&p=" + Server.UrlEncode("Leprosy") + "&program=" + Server.UrlEncode(ddlProgram.Text));
                        break; 
                    }
            }

        }
    }
}