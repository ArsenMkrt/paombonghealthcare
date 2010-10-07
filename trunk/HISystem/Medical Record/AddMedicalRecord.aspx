<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="AddMedicalRecord.aspx.cs" Inherits="Medical_Record_MedicalRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    <br />
</p>
<p>
    <asp:Label ID="Label3" runat="server" 
        style="top: 54px; left: 51px; position: absolute; height: 19px; width: 59px" 
        Text="Patient Id"></asp:Label>
    <asp:Button ID="Button1" runat="server" 
        style="top: 54px; left: 284px; position: absolute; height: 26px; width: 56px" 
        Text="Search" />
</p>
<p>
    <asp:TextBox ID="txtPatient" runat="server" 
        style="top: 55px; left: 134px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
    <asp:Label ID="Label5" runat="server" 
        style="top: 109px; left: 54px; position: absolute; height: 19px; width: 34px" 
        Text="Disease"></asp:Label>
</p>
<p>
</p>
<p>
    <asp:CheckBoxList ID="checkbox_Disease" runat="server" 
        style="top: 140px; left: 175px; position: absolute; height: 27px; width: 82px">
    </asp:CheckBoxList>
</p>
<p>
</p>
<p>
    <asp:Label ID="Label4" runat="server" 
        style="top: 303px; left: 63px; position: absolute; height: 19px; width: 34px" 
        Text="Notes"></asp:Label>
</p>
<p>
    <asp:TextBox ID="TextBox1" runat="server" 
        
        style="top: 317px; left: 133px; position: absolute; height: 147px; width: 555px"></asp:TextBox>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
<p>
</p>
</asp:Content>

