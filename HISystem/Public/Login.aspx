<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Public_Login" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">




    <h2 style="background-color: #d3e7c5">
        Log In
    </h2>
    <p>
        <span style="font-size: small">Please enter your username and password.
        </span>
        <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="False" 
            ForeColor="#3366CC" Font-Underline="True" style="font-size: small">Register</asp:HyperLink> 
        <span style="font-size: small">&nbsp;if you don't have an account.
    </span>
    </p>
    

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    
    <asp:Panel ID="PnlLogin" runat="server" Width="341px" Height="178px" 
        BackColor="#D3E7C5">
    <asp:Login ID="LoginUser" runat="server" EnableViewState="False" 
     
     Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" 
        Font-Bold="True" Width="294px" DestinationPageUrl="~/Default.aspx" 
        Height="56px" style="font-size: small">
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <LayoutTemplate>
            <span class="failureNotification">
                <asp:Literal ID="FailureText" runat="server"></asp:Literal>
            </span>
            <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                 ValidationGroup="LoginUserValidationGroup" Font-Size="Small" 
                style="font-size: small" DisplayMode="List" Width="294px"/>
            
            <div class="accountInfo" >
               
                <fieldset class="login">
                    <legend style="color: #333333">Account Information</legend>
                    <br />
                    <table>
                    <tr>
                    <td style="width: 116px"> <asp:Label ID="UserNameLabel" runat="server" 
                            AssociatedControlID="UserName" Font-Size="Small" ForeColor="#333333">Username:</asp:Label>
                   </td>
                    <td style="width: 176px">
                      <asp:TextBox ID="UserName" runat="server" 
                            AutoCompleteType="Disabled" autocomplete="off" Width="128px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameRequired" Display="Dynamic" 
                            runat="server" ControlToValidate="UserName" 
                             CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                             ValidationGroup="LoginUserValidationGroup" Font-Size="Small">*</asp:RequiredFieldValidator>
                    </td>
                   
                    </tr>
                      
                    
                    <tr>
                    <td style="width: 116px">
                     <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" 
                            Font-Size="Small" ForeColor="#333333">Password:</asp:Label>
                    </td>
                       <td style="width: 176px">
                        <asp:TextBox ID="Password" runat="server" 
                               TextMode="Password" AutoCompleteType="Disabled" autocomplete="off" Width="128px">Doctor1</asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordRequired" Display="Dynamic" 
                            runat="server" ControlToValidate="Password" 
                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                             ValidationGroup="LoginUserValidationGroup" Font-Size="Small">*</asp:RequiredFieldValidator>
                       </td>
                       
                    </tr>
                    <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                            ValidationGroup="LoginUserValidationGroup" Width="64px" />
                        &nbsp;<input id="Reset1" type="reset" value="Clear" /></td>
                    </tr>
                    </table>
                </fieldset>
                
                
            </div>
        </LayoutTemplate>
        <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" 
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
        <TextBoxStyle Font-Size="0.8em" />
        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="0.9em" 
            ForeColor="White" />
    </asp:Login>
    
    </asp:Panel>
    <asp:RoundedCornersExtender ID="PnlLogin_RoundedCornersExtender" runat="server" 
        Enabled="True" Radius="10" TargetControlID="PnlLogin" Color="#D3E7C5">
    </asp:RoundedCornersExtender>
    <asp:DropShadowExtender ID="PnlLogin_DropShadowExtender" 
                runat="server" TargetControlID="PnlLogin" Radius="9" Opacity=".25" 
        Rounded="True">
            </asp:DropShadowExtender>


    <br />






</asp:Content>

