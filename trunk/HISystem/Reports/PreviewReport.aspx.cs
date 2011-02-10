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
    private ReportPrintDocument rpd;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadYearAndAgeInDropDown(DropDownList1, ddlAge);
        }
    }

    private void LoadYearAndAgeInDropDown(DropDownList dropdownYear,DropDownList dropdownAge)
    {
        dropdownAge.Items.Clear();
        dropdownYear.Items.Clear();


        //Populate Year Dropdown
        for (int i = 2010; i < 2100; i++)
        {
            dropdownYear.Items.Add(i.ToString());
        }
        //Populate Age Dropdown
        for (int x = 1; x < 125; x++)
        {
            dropdownAge.Items.Add(x.ToString());
        }
    }
    protected void btn_runReport_Click(object sender, EventArgs e)
    {
        if (rdbtn_Reports.Checked)
        {
            switch (ddlQuarter.Text)
            {
                case "1st Quarter":
                    {
                        month1 = 1;
                        month2 = 3;
                    } break;
                case "2nd Quarter":
                    {
                        month1 = 4;
                        month2 = 6;
                    } break;
                case "3rd Quarter":
                    {
                        month1 = 7;
                        month2 = 9;
                    } break;
                case "4th Quarter":
                    {
                        month1 = 10;
                        month2 = 12;
                    } break;
            }

            data = new DataAccess();
            ReportPaombong.Visible = true;

            /*Leprosy*/
            _Leprosy.SelectParameters["month1"].DefaultValue = month1.ToString();
            _Leprosy.SelectParameters["month"].DefaultValue = month2.ToString();
            _Leprosy.SelectParameters["year"].DefaultValue = DropDownList1.Text;
            /*MaternalCare*/
            _MaternalCare.SelectParameters["month1"].DefaultValue = month1.ToString();
            _MaternalCare.SelectParameters["month"].DefaultValue = month2.ToString();
            _MaternalCare.SelectParameters["year"].DefaultValue = DropDownList1.Text;
            /*Malaria*/
            _Malaria.SelectParameters["month1"].DefaultValue = month1.ToString();
            _Malaria.SelectParameters["month"].DefaultValue = month2.ToString();
            _Malaria.SelectParameters["year"].DefaultValue = DropDownList1.Text;
            /*ChildCare*/
            _ChildCare.SelectParameters["month1"].DefaultValue = month1.ToString();
            _ChildCare.SelectParameters["month"].DefaultValue = month2.ToString();
            _ChildCare.SelectParameters["year"].DefaultValue = DropDownList1.Text;
            /*_DentalCare*/
            _DentalCare.SelectParameters["month1"].DefaultValue = month1.ToString();
            _DentalCare.SelectParameters["month"].DefaultValue = month2.ToString();
            _DentalCare.SelectParameters["year"].DefaultValue = DropDownList1.Text;
            /*FamilyPlanning*/
            _FamilyPlanning.SelectParameters["month1"].DefaultValue = month1.ToString();
            _FamilyPlanning.SelectParameters["month"].DefaultValue = month2.ToString();
            _FamilyPlanning.SelectParameters["year"].DefaultValue = DropDownList1.Text;
            /*Tuberculosis*/
            _Tuberculosis.SelectParameters["month1"].DefaultValue = month1.ToString();
            _Tuberculosis.SelectParameters["month"].DefaultValue = month2.ToString();
            _Tuberculosis.SelectParameters["year"].DefaultValue = DropDownList1.Text;
            /*Schistomiasis*/
            _Schisto.SelectParameters["month1"].DefaultValue = month1.ToString();
            _Schisto.SelectParameters["month"].DefaultValue = month2.ToString();
            _Schisto.SelectParameters["year"].DefaultValue = DropDownList1.Text;
            ReportPaombong.LocalReport.Refresh();
        }
        else if (rdbtn_Inventory.Checked)
        {
            ReportPaombong.Visible = true;
            _MedicineLog_.SelectParameters["logtype"].DefaultValue = ddlLogType.Text.ToString();
            ReportPaombong.LocalReport.Refresh();
        }
        else if (rdbtn_Consultation.Checked)
        {
            ReportPaombong.Visible = true;
            if (rdbtn_Barangay.Checked)
            {
                _Barangay.SelectParameters["barangayName"].DefaultValue = DropDownList2.Text.ToString();
                _Barangay.SelectParameters["month"].DefaultValue = DropDownList3.Text.ToString();
                ReportPaombong.LocalReport.Refresh();
            }
            else if (rdbtn_Disease.Checked)
            {
                _SearchByDiseaseName.SelectParameters["diseaseName"].DefaultValue = ddlDisease.Text.ToString();
                _SearchByDiseaseName.SelectParameters["month"].DefaultValue = DropDownList4.Text.ToString();
                ReportPaombong.LocalReport.Refresh();
            }
            else if (rdbtn_Age.Checked)
            {
                _AgeBracket.SelectParameters["ageParam"].DefaultValue = ddlAge.Text.ToString();
                _AgeBracket.SelectParameters["month"].DefaultValue = DropDownList5.Text.ToString();
                ReportPaombong.LocalReport.Refresh();
            }
            else if (rdbtn_Month.Checked)
            {
                _MonthConsult.SelectParameters["monthParam"].DefaultValue = ddlMonth.Text.ToString();
                ReportPaombong.LocalReport.Refresh();
            }
            else if (rdbtn_Year.Checked)
            {
                _YearConsult.SelectParameters["yearParam"].DefaultValue = ddlYear.Text.ToString();
                ReportPaombong.LocalReport.Refresh();
            }
        }
        ReportPaombong.Visible = true;
    }
    protected void rdbtn_Reports_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbtn_Reports.Checked)
        {
            MultiView2.SetActiveView(PaombongReportView);
            #region Instantiate Report Source
            ReportDataSource rds_Maternal = new ReportDataSource();
            rds_Maternal.DataSourceId = "_MaternalCare";
            rds_Maternal.Name = "MaternalCare";
            ReportDataSource rds_FamilyPlanning = new ReportDataSource();
            rds_FamilyPlanning.DataSourceId = "_FamilyPlanning";
            rds_FamilyPlanning.Name = "FamilyPlanning";
            ReportDataSource rds_ChildCare = new ReportDataSource();
            rds_ChildCare.DataSourceId = "_ChildCare";
            rds_ChildCare.Name = "ChildCare";
            ReportDataSource rds_DentalCare = new ReportDataSource();
            rds_DentalCare.DataSourceId = "_DentalCare";
            rds_DentalCare.Name = "DentalCare";
            ReportDataSource rds_Tuberculosis = new ReportDataSource();
            rds_Tuberculosis.DataSourceId = "_Tuberculosis";
            rds_Tuberculosis.Name = "Tuberculosis";
            ReportDataSource rds_Malaria = new ReportDataSource();
            rds_Malaria.DataSourceId = "_Malaria";
            rds_Malaria.Name = "Malaria";
            ReportDataSource rds_Schisto = new ReportDataSource();
            rds_Schisto.DataSourceId = "_Schisto";
            rds_Schisto.Name = "Schisto";
            ReportDataSource rds_Leprosy = new ReportDataSource();
            rds_Leprosy.DataSourceId = "_Leprosy";
            rds_Leprosy.Name = "Leprosy";
            ReportDataSource rds_Filariasis = new ReportDataSource();
            rds_Filariasis.DataSourceId = "_Filariasis";
            rds_Filariasis.Name = "Filariasis";
            ReportPaombong.LocalReport.ReportPath = Server.MapPath("Report.rdlc");
            ReportPaombong.LocalReport.DisplayName = "PaombongQuarterlyReport";
            ReportPaombong.LocalReport.DataSources.Add(rds_Maternal);
            ReportPaombong.LocalReport.DataSources.Add(rds_FamilyPlanning);
            ReportPaombong.LocalReport.DataSources.Add(rds_ChildCare);
            ReportPaombong.LocalReport.DataSources.Add(rds_DentalCare);
            ReportPaombong.LocalReport.DataSources.Add(rds_Tuberculosis);
            ReportPaombong.LocalReport.DataSources.Add(rds_Malaria);
            ReportPaombong.LocalReport.DataSources.Add(rds_Schisto);
            ReportPaombong.LocalReport.DataSources.Add(rds_Leprosy);
            ReportPaombong.LocalReport.DataSources.Add(rds_Filariasis);
            #endregion
            ReportPaombong.Visible = true;
            ReportPaombong.LocalReport.Refresh();

            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            DropDownList1.Visible = true;
            ddlQuarter.Visible = true;
            //Consultation
            Label6.Visible = false;
            rdbtn_Age.Visible = false;
            rdbtn_Barangay.Visible = false;
            rdbtn_Disease.Visible = false;
            rdbtn_Month.Visible = false;
            rdbtn_Year.Visible = false;
            Label7.Visible = false;
            DropDownList2.Visible = false;
            Label8.Visible = false;
            ddlDisease.Visible = false;
            Label9.Visible = false;
            ddlAge.Visible = false;
            Label10.Visible = false;
            ddlMonth.Visible = false;
            Label11.Visible = false;
            ddlYear.Visible = false;
            //Inventory
            Label4.Visible = false;
            Label5.Visible = false;
            ddlLogType.Visible = false;
        }
    }

    //protected void Page_Init(object Sender, EventArgs e)
    //{
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
    //    Response.Cache.SetNoStore();
    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        LocalReport lr = new LocalReport();
        lr.ReportPath = "Report.rdlc";
        rpd = new ReportPrintDocument(lr);
        rpd.Print();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        CreatePDF(DateTime.Now.ToString("yyyymm") + "_QuarterReport");
    }
    private void CreatePDF(string fileName)
    {
        // Variables  
        Warning[] warnings;
        string[] streamIds;
        string mimeType = string.Empty;
        string encoding = string.Empty;
        string extension = string.Empty;

        // Setup the report viewer object and get the array of bytes  
        ReportViewer viewer = new ReportViewer();
        viewer.ProcessingMode = ProcessingMode.Local;
        viewer.LocalReport.ReportPath = "Report.rdlc";

        byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

        // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.  
        Response.Buffer = true;
        Response.Clear();
        Response.ContentType = mimeType;
        Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
        Response.BinaryWrite(bytes); // create the file  
        Response.Flush(); // send it to the client to download  
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        ReportDataSource rds = new ReportDataSource();
        rds.DataSourceId = "_SearchByDiseaseName";
        rds.Name = "SearchByDiseaseName";

        ObjectDataSource _SearchByDiseaseName = new ObjectDataSource("PaombongDataSetTableAdapters.SearchByDiseaseNameTableAdapter", "GetData");
        rds.Value = _SearchByDiseaseName;
        ReportPaombong.LocalReport.ReportPath = Server.MapPath("Report_SearchByDiseaseName.rdlc");
        ReportPaombong.LocalReport.DisplayName = "PaombongPatientsConsultation";
        ReportPaombong.LocalReport.DataSources.Clear();
        ReportPaombong.LocalReport.DataSources.Add(rds);
        
        ReportPaombong.LocalReport.Refresh();
    }
    protected void rdbtn_Inventory_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbtn_Inventory.Checked)
        {
            MultiView2.Visible = true;
            MultiView2.SetActiveView(InventoryView);
            ReportDataSource rds_Inventory = new ReportDataSource();
            rds_Inventory.DataSourceId = "_MedicineLog_";
            rds_Inventory.Name = "MedicineLog";
            ObjectDataSource _MedicineLog_ = new ObjectDataSource("PaombongDataSetTableAdapters.MedicineLogTableAdapter", "GetData");
            rds_Inventory.Value = _MedicineLog_;
            ReportPaombong.LocalReport.ReportPath = Server.MapPath("Report_MedicineLog.rdlc");
            ReportPaombong.LocalReport.DisplayName = "PaombongMedicineLog";
            ReportPaombong.LocalReport.DataSources.Clear();
            ReportPaombong.LocalReport.DataSources.Add(rds_Inventory);

            ReportPaombong.LocalReport.Refresh();
            ReportPaombong.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            ddlLogType.Visible = true;

            //From Other Type Of Reports
            //Reports
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            DropDownList1.Visible = false;
            ddlQuarter.Visible = false;
            //Consultation
            Label6.Visible = false;
            rdbtn_Age.Visible = false;
            rdbtn_Barangay.Visible = false;
            rdbtn_Disease.Visible = false;
            rdbtn_Month.Visible = false;
            rdbtn_Year.Visible = false;
            Label7.Visible = false;
            DropDownList2.Visible = false;
            Label8.Visible = false;
            ddlDisease.Visible = false;
            Label9.Visible = false;
            ddlAge.Visible = false;
            Label10.Visible = false;
            ddlMonth.Visible = false;
            Label11.Visible = false;
            ddlYear.Visible = false;
        }
    }
    protected void rdbtn_Consultation_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbtn_Consultation.Checked)
        {
            MultiView3.Visible = true;
            MultiView3.SetActiveView(ConsultFilterView);
            Label6.Visible = true;
            rdbtn_Age.Visible = true;
            rdbtn_Barangay.Visible = true;
            rdbtn_Disease.Visible = true;
            rdbtn_Month.Visible = true;
            rdbtn_Year.Visible = true;
            //From Other Type Of Reports
            //Reports
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            DropDownList1.Visible = false;
            ddlQuarter.Visible = false;
            //Inventory
            Label4.Visible = false;
            Label5.Visible = false;
            ddlLogType.Visible = false;
        }
    }
    protected void rdbtn_Barangay_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbtn_Barangay.Checked)
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(BrgyView);
            txtFilterby.Text = "Barangay";
            ReportDataSource rds_cBarangay = new ReportDataSource();
            rds_cBarangay.DataSourceId = "_Barangay";
            rds_cBarangay.Name = "SearchByBarangay";
            ObjectDataSource _Barangay = new ObjectDataSource("PaombongDataSetTableAdapters.SearchByBarangayNameTableAdapter", "GetData");
            rds_cBarangay.Value = _Barangay;
            ReportPaombong.LocalReport.ReportPath = Server.MapPath("Report_SearchByBarangay.rdlc");
            ReportPaombong.LocalReport.DisplayName = "PaombongPatientsConsultation_BarangaySearch";
            ReportPaombong.LocalReport.DataSources.Clear();
            ReportPaombong.LocalReport.DataSources.Add(rds_cBarangay);
            ReportPaombong.LocalReport.Refresh();
            ReportPaombong.Visible = true;
            Label7.Visible = true;
            Label12.Visible = true;
            DropDownList3.Visible = true;
            DropDownList2.Visible = true;
            //Disease
            Label8.Visible = false;
            Label13.Visible = false;
            DropDownList4.Visible = false;
            ddlDisease.Visible = false;
            //Age
            Label9.Visible = false;
            ddlAge.Visible = false;
            Label14.Visible = false;
            DropDownList5.Visible = false;
            //Month
            Label10.Visible = false;
            ddlMonth.Visible = false;
            //Year
            Label11.Visible = false;
            ddlYear.Visible = false;
        }
    }
    protected void rdbtn_Disease_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbtn_Disease.Checked)
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(DiseaseView);
            txtFilterby.Text = "Disease";
            ReportDataSource rds = new ReportDataSource();
            rds.DataSourceId = "_SearchByDiseaseName";
            rds.Name = "SearchByDiseaseName";
            ObjectDataSource _SearchByDiseaseName = new ObjectDataSource("PaombongDataSetTableAdapters.SearchByDiseaseNameTableAdapter", "GetData");
            rds.Value = _SearchByDiseaseName;
            ReportPaombong.LocalReport.ReportPath = Server.MapPath("Report_SearchByDiseaseName.rdlc");
            ReportPaombong.LocalReport.DisplayName = "PaombongPatientsConsultation";
            ReportPaombong.LocalReport.DataSources.Clear();
            ReportPaombong.LocalReport.DataSources.Add(rds);
            ReportPaombong.LocalReport.Refresh();
            ReportPaombong.Visible = true;
            Label8.Visible = true;
            ddlDisease.Visible = true;
            DropDownList4.Visible = true;
            Label13.Visible = true;
            //Barangay
            Label7.Visible = false;
            Label12.Visible = false;
            DropDownList3.Visible = false;
            DropDownList2.Visible = false;
            //Age
            Label9.Visible = false;
            Label14.Visible = false;
            DropDownList5.Visible = false;
            ddlAge.Visible = false;
            //Month
            Label10.Visible = false;
            ddlMonth.Visible = false;
            //Year
            Label11.Visible = false;
            ddlYear.Visible = false;
        }
    }
    protected void rdbtn_Age_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbtn_Age.Checked)
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(AgeView);
            txtFilterby.Text = "Age Bracket";
            ReportDataSource rds_AgeBracket = new ReportDataSource();
            rds_AgeBracket.DataSourceId = "_AgeBracket";
            rds_AgeBracket.Name = "SearchByAgeBracket";
            ObjectDataSource _AgeBracket = new ObjectDataSource("PaombongDataSetTableAdapters.SearchByAgeBracketTableAdapter", "GetData");
            rds_AgeBracket.Value = _AgeBracket;
            ReportPaombong.LocalReport.ReportPath = Server.MapPath("Report_SearchByAgeBracket.rdlc");
            ReportPaombong.LocalReport.DisplayName = "PaombongPatientsConsultation_AgeBracketSearch";
            ReportPaombong.LocalReport.DataSources.Clear();
            ReportPaombong.LocalReport.DataSources.Add(rds_AgeBracket);

            ReportPaombong.LocalReport.Refresh();
            ReportPaombong.Visible = true;
            Label9.Visible = true;
            Label14.Visible = true;
            DropDownList5.Visible = true;
            ddlAge.Visible = true;
            //Barangay
            Label7.Visible = false;
            Label12.Visible = false;
            DropDownList3.Visible = false;
            DropDownList2.Visible = false;
            //Disease
            Label8.Visible = false;
            Label13.Visible = false;
            DropDownList4.Visible = false;
            ddlDisease.Visible = false;
            //Month
            Label10.Visible = false;
            ddlMonth.Visible = false;
            //Year
            Label11.Visible = false;
            ddlYear.Visible = false;
        }
    }
    protected void rdbtn_Month_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbtn_Month.Checked)
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(MonthView);
            txtFilterby.Text = "Month";
            ReportDataSource rds_Month = new ReportDataSource();
            rds_Month.DataSourceId = "_MonthConsult";
            rds_Month.Name = "SearchByMonth";
            ObjectDataSource _MonthConsult = new ObjectDataSource("PaombongDataSetTableAdapters.SearchByMonthTableAdapter", "GetData");
            rds_Month.Value = _MonthConsult;
            ReportPaombong.LocalReport.ReportPath = Server.MapPath("Report_SearchByMonth.rdlc");
            ReportPaombong.LocalReport.DisplayName = "PaombongPatientsConsultation_MonthSearch";
            ReportPaombong.LocalReport.DataSources.Clear();
            ReportPaombong.LocalReport.DataSources.Add(rds_Month);
            ReportPaombong.LocalReport.Refresh();
            ReportPaombong.Visible = true;
            Label10.Visible = true;
            ddlMonth.Visible = true;
            //Barangay
            Label7.Visible = false;
            Label12.Visible = false;
            DropDownList3.Visible = false;
            DropDownList2.Visible = false;
            //Disease
            Label8.Visible = false;
            Label13.Visible = false;
            DropDownList4.Visible = false;
            ddlDisease.Visible = false;
            //Year
            Label11.Visible = false;
            ddlYear.Visible = false;
            //Age
            Label9.Visible = false;
            Label14.Visible = false;
            DropDownList5.Visible = false;
            ddlAge.Visible = false;
        }
    }
    protected void rdbtn_Year_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbtn_Year.Checked)
        {
            MultiView1.Visible = true;
            MultiView1.SetActiveView(YearView);
            txtFilterby.Text = "Year";
            ReportDataSource rds_Year = new ReportDataSource();
            rds_Year.DataSourceId = "_YearConsult";
            rds_Year.Name = "SearchByYear";
            ObjectDataSource _YearConsult = new ObjectDataSource("PaombongDataSetTableAdapters.SearchByYearTableAdapter", "GetData");
            rds_Year.Value = _YearConsult;
            ReportPaombong.LocalReport.ReportPath = Server.MapPath("Report_SearchByYear.rdlc");
            ReportPaombong.LocalReport.DisplayName = "PaombongPatientsConsultation_YearSearch";
            ReportPaombong.LocalReport.DataSources.Clear();
            ReportPaombong.LocalReport.DataSources.Add(rds_Year);
            ReportPaombong.LocalReport.Refresh();
            ReportPaombong.Visible = true;
            Label11.Visible = true;
            ddlYear.Visible = true;
            //Age
            Label9.Visible = false;
            ddlAge.Visible = false;
            Label14.Visible = false;
            DropDownList5.Visible = false;
            //Barangay
            Label7.Visible = false;
            Label12.Visible = false;
            DropDownList3.Visible = false;
            DropDownList2.Visible = false;
            //Disease
            Label8.Visible = false;
            Label13.Visible = false;
            DropDownList4.Visible = false;
            ddlDisease.Visible = false;
            //Month
            Label10.Visible = false;
            ddlMonth.Visible = false;
        }
    }
}