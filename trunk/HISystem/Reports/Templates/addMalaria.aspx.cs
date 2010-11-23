using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Reports_Templates_addMalaria : System.Web.UI.Page
{
    private DataAccess data;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string program = Request["program"].ToString().Trim();
            string pIndicator = Request["p"].ToString().Trim();
            data = new DataAccess();

            data.LoadIndicator(pIndicator, ddlIndicator);
            data.LoadAvailableYearAndMonth(program, ddlYear, ddlMonth);
            LoadListView(listviewMalaria);
        }
    }
    protected void ddlIndicator_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadListView(listviewMalaria);
    }

    private void LoadListView(ListView listviewMalaria)
    {
        data = new DataAccess();
        SqlConnection conn = new SqlConnection(data.Dataconnection);
        SqlDataReader dr;
        conn.Open();

        SqlCommand cmdTxt = new SqlCommand("SELECT a.MalariaEntryNumber,a.MalariaData,a.Male,a.Female," +
            "a.Pregnant,a.InputDate,a.BarangayID,a.Accomplishment,a.Month,a.Year,b.BarangayName,b.BarangayID,c.Population,c.Target,c.BarangayID" +
            " FROM Malaria a,Barangays b,Population c WHERE MalariaData = @indicatorData AND a.BarangayID = b.BarangayID AND c.BarangayID = a.BarangayID AND a.Year = c.Year", conn);
        cmdTxt.Parameters.Add("@indicatorData", SqlDbType.VarChar).Value = ddlIndicator.Text;

        dr = cmdTxt.ExecuteReader();

        listviewMalaria.DataSource = dr;
        listviewMalaria.DataBind();

        dr.Dispose();
        conn.Close();
    }

    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void listviewMalaria_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        data = new DataAccess();
        string Male = "", Population = "", Female = "",Pregnant = "", BarangayID = "", Accomplishment = "", Month = "",
            Year = "", Target = "";

        TextBox txt = (e.Item.FindControl("PopulationLabel")) as TextBox;
        if (txt != null)
            Population = txt.Text;
        txt = (e.Item.FindControl("MaleTextBox")) as TextBox;
        if (txt != null)
            Male = txt.Text;
        txt = (e.Item.FindControl("FemaleTextBox")) as TextBox;
        if (txt != null)
            Female = txt.Text;
        DropDownList ddl = (e.Item.FindControl("ddlBarangay")) as DropDownList;
        if (ddl != null)
            BarangayID = ddl.Text;
        txt = (e.Item.FindControl("AccomplishmentTextBox")) as TextBox;
        if (txt != null)
            Accomplishment = txt.Text;
        ddl = (e.Item.FindControl("ddlMonth")) as DropDownList;
        if (ddl != null)
            Month = ddl.Text;
        txt = (e.Item.FindControl("YearTextBox")) as TextBox;
        if (txt != null)
            Year = txt.Text;
        txt = (e.Item.FindControl("PregnantTextBox")) as TextBox;
        if (txt != null)
            Pregnant = txt.Text;
        txt = (e.Item.FindControl("TargetTextBox")) as TextBox;
        if (txt != null)
            Target = txt.Text;

        //Response.Write("<script type='text/javascript'>" + "alert(\"Population: " + Population + "\");</script>");
        //Response.Write("<script type='text/javascript'>" + "alert(\"Male: " + Male + "\");</script>");
        //Response.Write("<script type='text/javascript'>" + "alert(\"Female: " + Female + "\");</script>");
        //Response.Write("<script type='text/javascript'>" + "alert(\"BarangayID: " + BarangayID + "\");</script>");
        //Response.Write("<script type='text/javascript'>" + "alert(\"Accomplishment: " + Accomplishment + "\");</script>");
        //Response.Write("<script type='text/javascript'>" + "alert(\"Month: " + Month + "\");</script>");
        //Response.Write("<script type='text/javascript'>" + "alert(\"Year: " + Year + "\");</script>");
        //Response.Write("<script type='text/javascript'>" + "alert(\"Percent: " + Percent + "\");</script>");
        //Response.Write("<script type='text/javascript'>" + "alert(\"Target: " + Target + "\");</script>");
        data.InsertMalariaReport(ddlIndicator.Text.Trim(),
                            Convert.ToInt32(Male.Trim()),
                            Convert.ToInt32(Female.Trim()),
                            Convert.ToInt32(Pregnant.Trim()),
                            Convert.ToInt32(BarangayID.Trim()),
                            Convert.ToInt32(Month.Trim()),
                            Convert.ToInt32(Year.Trim()),
                            Accomplishment.Trim());
        LoadListView(listviewMalaria);
    }
    protected void listviewMalaria_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        int IndexItemSelected = e.ItemIndex;
        Label entryNumber = (Label)listviewMalaria.Items[IndexItemSelected].FindControl("MalariaEntryNumberLabelID1");
        DeleteItem(entryNumber.Text);
        LoadListView(listviewMalaria);
    }
    private void DeleteItem(string EntryNumber)
    {
        data = new DataAccess();
        SqlConnection conn = new SqlConnection(data.Dataconnection);

        conn.Open();

        SqlCommand cmdTxt = new SqlCommand("Delete From Malaria Where MalariaEntryNumber = @entryNum", conn);
        cmdTxt.Parameters.Add("@entryNum", SqlDbType.Int).Value = Int32.Parse(EntryNumber);
        cmdTxt.ExecuteNonQuery();
        conn.Close();
    }
}