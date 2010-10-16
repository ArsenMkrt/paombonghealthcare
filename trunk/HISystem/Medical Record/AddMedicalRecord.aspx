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
        style="top: 54px; left: 284px; position: absolute; height: 26px; width: 71px" 
        Text="Search" onclick="Button1_Click" />
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
    
    style="top: 108px; left: 135px; position: absolute; height: 27px; width: 83px" 
        BorderWidth="2px" CellPadding="4" CellSpacing="2" TextAlign="Left">
    </asp:CheckBoxList>
</p>
<p>
</p>
<p>
    <asp:Label ID="Label4" runat="server" 
        style="top: 384px; left: 55px; position: absolute; height: 20px; width: 34px" 
        Text="Notes"></asp:Label>
</p>
<p>
    <asp:TextBox ID="TextBox1" runat="server" 
        
        
        style="top: 413px; left: 134px; position: absolute; height: 147px; width: 555px"></asp:TextBox>
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
    <asp:Button ID="Button2" runat="server" 
        style="top: 578px; left: 284px; position: absolute; height: 26px; width: 148px" 
        Text="Add Medical Record" />
    <asp:Button ID="btnAddMedicalRecord" runat="server" 
        style="top: 578px; left: 284px; position: absolute; height: 26px; width: 148px" 
        Text="Add Medical Record" />
    <asp:Button ID="btnClear" runat="server" 
        style="top: 578px; left: 492px; position: absolute; height: 26px; width: 106px" 
        Text="Clear Details" />
</p>
<p>
</p>
</asp:Content>

