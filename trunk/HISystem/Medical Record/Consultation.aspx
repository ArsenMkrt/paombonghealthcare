<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="Consultation.aspx.cs" Inherits="Medical_Record_Consultation" %>



<%@ Register src="DailyPatientRecord.ascx" tagname="DailyPatientRecord" tagprefix="uc1" %>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


    <uc1:DailyPatientRecord ID="DailyPatientRecord1" runat="server" />
    </asp:Content>

