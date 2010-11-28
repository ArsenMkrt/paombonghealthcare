<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="Consultation.aspx.cs" Inherits="Medical_Record_Consultation" %>



<%@ Register src="DailyPatientRecord.ascx" tagname="DailyPatientRecord" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:DailyPatientRecord ID="DailyPatientRecord1" runat="server" />
    </asp:Content>

