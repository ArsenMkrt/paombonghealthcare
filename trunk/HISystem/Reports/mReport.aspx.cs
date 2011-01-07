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
        ddlMonth.Enabled = true;
        ddlBarangay.Enabled = true;
 
        for (int year = 2011; year <= 2100; year++)
            ddlYear.Items.Add(year.ToString());
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        data = new DataAccess();

        if (txtPopulation.Text != "")
        {
            switch (ddlProgram.Text)
            {
                case "Maternal Care": 
                    {
                        string Program = "MaternalCare";
                        Response.Redirect("~/Reports/Templates/xMaternalCare.aspx?&p=" + Server.UrlEncode("Maternal Care") + "&program=" + Server.UrlEncode(Program) +
                            "&month=" + Server.UrlEncode(ddlMonth.Text) + "&year=" + Server.UrlEncode(ddlYear.Text) + "&barangay=" + Server.UrlEncode(ddlBarangay.Text) +
                            "&population=" + Server.UrlEncode(txtPopulation.Text)); 
                        break; 
                    }
                case "Family Planning": 
                    {
                        string Program = "FamilyPlanning";
                        Response.Redirect("~/Reports/Templates/xFPlanning.aspx?&p=" + Server.UrlEncode("Family Planning") + "&program=" + Server.UrlEncode(Program) +
                            "&month=" + Server.UrlEncode(ddlMonth.Text) + "&year=" + Server.UrlEncode(ddlYear.Text) + "&barangay=" + Server.UrlEncode(ddlBarangay.Text) +
                            "&population=" + Server.UrlEncode(txtPopulation.Text)); 
                        break; 
                    }
                case "Child Care A": 
                    {
                        string Program = "ChildCare";
                        Response.Redirect("~/Reports/Templates/xChildCare.aspx?&p=" + Server.UrlEncode("Child Care A") + "&program=" + Server.UrlEncode(Program) +
                            "&month=" + Server.UrlEncode(ddlMonth.Text) + "&year=" + Server.UrlEncode(ddlYear.Text) + "&barangay=" + Server.UrlEncode(ddlBarangay.Text) +
                            "&population=" + Server.UrlEncode(txtPopulation.Text)); 
                        break; 
                    }
                case "Child Care B": 
                    {
                        string Program = "ChildCare";
                        Response.Redirect("~/Reports/Templates/xChildCare.aspx?&p=" + Server.UrlEncode("Child Care B") + "&program=" + Server.UrlEncode(Program) +
                            "&month=" + Server.UrlEncode(ddlMonth.Text) + "&year=" + Server.UrlEncode(ddlYear.Text) + "&barangay=" + Server.UrlEncode(ddlBarangay.Text) +
                            "&population=" + Server.UrlEncode(txtPopulation.Text)); 
                        break; 
                    }
                case "Dental Care": 
                    {
                        string Program = "DentalCare";
                        Response.Redirect("~/Reports/Templates/xDentalCare.aspx?&p=" + Server.UrlEncode("Dental Care") + "&program=" + Server.UrlEncode(Program) +
                            "&month=" + Server.UrlEncode(ddlMonth.Text) + "&year=" + Server.UrlEncode(ddlYear.Text) + "&barangay=" + Server.UrlEncode(ddlBarangay.Text) +
                            "&population=" + Server.UrlEncode(txtPopulation.Text)); 
                        break; 
                    }
                case "Malaria": 
                    {
                        Response.Redirect("~/Reports/Templates/xMalaria.aspx?&p=" + Server.UrlEncode("Malaria") + "&program=" + Server.UrlEncode(ddlProgram.Text) +
                            "&month=" + Server.UrlEncode(ddlMonth.Text) + "&year=" + Server.UrlEncode(ddlYear.Text) + "&barangay=" + Server.UrlEncode(ddlBarangay.Text) +
                            "&population=" + Server.UrlEncode(txtPopulation.Text)); 
                        break; 
                    }
                case "Schistosomiasis": 
                    {
                        string Program = "Schisto";
                        Response.Redirect("~/Reports/Templates/xSchistomiasis.aspx?&p=" + Server.UrlEncode("Schistosomiasis") + "&program=" + Server.UrlEncode(Program) +
                            "&month=" + Server.UrlEncode(ddlMonth.Text) + "&year=" + Server.UrlEncode(ddlYear.Text) + "&barangay=" + Server.UrlEncode(ddlBarangay.Text) +
                            "&population=" + Server.UrlEncode(txtPopulation.Text)); 
                        break; 
                    }
                case "Filariasis": 
                    {
                        Response.Redirect("~/Reports/Templates/xFilariasis.aspx?&p=" + Server.UrlEncode("Filariasis") + "&program=" + Server.UrlEncode(ddlProgram.Text) +
                            "&month=" + Server.UrlEncode(ddlMonth.Text) + "&year=" + Server.UrlEncode(ddlYear.Text) + "&barangay=" + Server.UrlEncode(ddlBarangay.Text) +
                            "&population=" + Server.UrlEncode(txtPopulation.Text)); 
                        break; 
                    }
                case "Tuberculosis": 
                    {
                        Response.Redirect("~/Reports/Templates/xTuberculosis.aspx?&p=" + Server.UrlEncode("Tuberculosis") + "&program=" + Server.UrlEncode(ddlProgram.Text) +
                            "&month=" + Server.UrlEncode(ddlMonth.Text) + "&year=" + Server.UrlEncode(ddlYear.Text) + "&barangay=" + Server.UrlEncode(ddlBarangay.Text) +
                            "&population=" + Server.UrlEncode(txtPopulation.Text)); 
                        break; 
                    }
                case "Leprosy": 
                    {
                        Response.Redirect("~/Reports/Templates/xLeprosy.aspx?&p=" + Server.UrlEncode("Leprosy") + "&program=" + Server.UrlEncode(ddlProgram.Text) +
                            "&month=" + Server.UrlEncode(ddlMonth.Text) + "&year=" + Server.UrlEncode(ddlYear.Text) + "&barangay=" + Server.UrlEncode(ddlBarangay.Text) +
                            "&population=" + Server.UrlEncode(txtPopulation.Text)); 
                        break; 
                    }
            }

        }
        else
            Response.Write("<script> window.alert('Please Fill the Population Field.')</script>");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("mReport.aspx");
    }
}