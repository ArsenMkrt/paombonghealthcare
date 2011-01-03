using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Medical_Record_LifestyleCheck : System.Web.UI.UserControl
{
    int year, month;
    private bool CheckLeap(int year)
    {
        if ((year % 4 == 0) && (year % 100 != 0) || (year % 400 == 0))
            return true;
        else
            return false;
    }

    private void BindDays(int year, int month)
    {
        int i;
        ArrayList AlDay = new ArrayList();

        switch (month)
        {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                for (i = 1; i <= 31; i++)
                    AlDay.Add(i);
                break;
            case 2:
                if (CheckLeap(year))
                {
                    for (i = 1; i <= 29; i++)
                        AlDay.Add(i);
                }
                else
                {
                    for (i = 1; i <= 28; i++)
                        AlDay.Add(i);
                }
                break;
            case 4:
            case 6:
            case 9:
            case 11:
                for (i = 1; i <= 30; i++)
                    AlDay.Add(i);
                break;
        }
        dropDay.DataSource = AlDay;
        dropDay.DataBind();
        
    } 

    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_dateToday.Text = DateTime.Now.ToShortDateString();
        DateTime tnow = DateTime.Now;
        ArrayList AlYear = new ArrayList();
        int i;
        for (i = 1970; i <= 2010; i++)
            AlYear.Add(i);
        ArrayList AlMonth = new ArrayList();
        for (i = 1; i <= 12; i++)
            AlMonth.Add(i);
        if (!this.IsPostBack)
        {
            dropYear.DataSource = AlYear;
            dropYear.DataBind();
            dropYear.SelectedValue = tnow.Year.ToString();
            dropMonth.DataSource = AlMonth;
            dropMonth.DataBind();
            dropMonth.SelectedValue = tnow.Month.ToString();
            year = Int32.Parse(dropYear.SelectedValue);
            month = Int32.Parse(dropMonth.SelectedValue);
            BindDays(year, month);
            dropDay.SelectedValue = tnow.Day.ToString();
        }
        //Label1.Text = "You select date:" + dropYear.SelectedValue + "year" + dropMonth.SelectedValue + "month" + dropDay.SelectedValue;
    }
    protected void dropYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        

        year = Int32.Parse(dropYear.SelectedValue);
        month = Int32.Parse(dropMonth.SelectedValue);
        BindDays(year, month);
    }
    protected void dropDay_SelectedIndexChanged(object sender, EventArgs e)
    {
        

        year = Int32.Parse(dropYear.SelectedValue);
        month = Int32.Parse(dropMonth.SelectedValue);
        BindDays(year, month);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
}