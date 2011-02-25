<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="Manage.aspx.cs" Inherits="Admin_Manage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="LoginContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" 
        Height="272px" Width="685px">
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Manage Population">
        
        
            <HeaderTemplate>
                Manage Population
            </HeaderTemplate>
        
        
        <ContentTemplate>
        <br />
             
            <asp:SqlDataSource ID="Barangay0" runat="server" 
                ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
                SelectCommand="SELECT DISTINCT [BarangayName] FROM [Barangays] ORDER BY [BarangayName]">
            </asp:SqlDataSource>
             
             <br />
            kapag meron na nito automatic nilo-load na niya projected population sa mreport<br /> 
            and kung hndi pa nakaset edi enable nlng for input sa mreport.<br />

            <table style="width: 100%; height: 133px;">
                <tr>
                    <td style="width: 119px">
                        Year</td>
                    <td style="width: 366px">
                        <asp:DropDownList ID="ddlYear" runat="server" Height="20px" Width="123px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 119px">
                        Barangay</td>
                    <td style="width: 366px">
                        <asp:DropDownList ID="ddlBarangay" runat="server" DataKeyNames="BarangayName" 
                            DataSourceID="Barangay0" DataTextField="BarangayName" 
                            DataValueField="BarangayName" Height="20px" Width="122px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 119px">
                        &nbsp;</td>
                    <td style="width: 366px">
                        <asp:Button ID="btnSubmit" runat="server" Height="27px" 
                            onclick="btnSubmit_Click" Text="Submit" Width="124px" />
                    </td>
                </tr>
            </table>

        </ContentTemplate>
        
        </asp:TabPanel>


        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Manage Reports">
        
        
            <ContentTemplate>
             
              
             
                <asp:SqlDataSource ID="Program" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
                    
                    SelectCommand="SELECT DISTINCT [ProgramData] FROM [ProgramCategory] ORDER BY [ProgramData]">
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="Barangay" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
                    SelectCommand="SELECT DISTINCT [BarangayName] FROM [Barangays] ORDER BY [BarangayName]">
                </asp:SqlDataSource>
                <table style="width: 100%; height: 133px;">
                    <tr>
                        <td style="width: 167px">
                            Program</td>
                        <td colspan="2" style="width: 366px">
                            <asp:DropDownList ID="ddlProgram0" runat="server" DataSourceID="Program" 
                                DataTextField="ProgramData" DataValueField="ProgramData" Height="20px" 
                                Visible="False" Width="122px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 167px">
                            Month</td>
                        <td colspan="2" style="width: 366px">
                            <asp:DropDownList ID="ddlMonth0" runat="server" Height="20px" Width="122px">
                                <asp:ListItem Value="January">January</asp:ListItem>
                                <asp:ListItem Value="February">February</asp:ListItem>
                                <asp:ListItem Value="March">March</asp:ListItem>
                                <asp:ListItem Value="April">April</asp:ListItem>
                                <asp:ListItem Value="May">May</asp:ListItem>
                                <asp:ListItem Value="June">June</asp:ListItem>
                                <asp:ListItem Value="July">July</asp:ListItem>
                                <asp:ListItem Value="August">August</asp:ListItem>
                                <asp:ListItem Value="September">September</asp:ListItem>
                                <asp:ListItem Value="October">October</asp:ListItem>
                                <asp:ListItem Value="November">November</asp:ListItem>
                                <asp:ListItem Value="December">December</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 167px">
                            Year</td>
                        <td colspan="2" style="width: 366px">
                            <asp:DropDownList ID="ddlYear0" runat="server" Height="20px" Width="123px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 167px">
                            Barangay</td>
                        <td colspan="2" style="width: 366px">
                            <asp:DropDownList ID="ddlBarangay0" runat="server" DataKeyNames="BarangayName" 
                                DataSourceID="Barangay" DataTextField="BarangayName" 
                                DataValueField="BarangayName" Height="20px" Width="122px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 167px">
                            &nbsp;</td>
                        <td style="width: 128px">
                            <asp:Button ID="btnEdit" runat="server" Height="23px" onclick="btnEdit_Click" 
                                Text="Edit" Width="118px" />
                        </td>
                        <td style="width: 366px">
                            <asp:Button ID="btnDelete" runat="server" Height="25px" 
                                Text="Delete Existing Record" Width="141px" onclick="btnDelete_Click" />
                        </td>
                    </tr>
                </table>
             
              
             
            </ContentTemplate>
        
        
        </asp:TabPanel>
    </asp:TabContainer>
    <br />
</asp:Content>

