<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate3.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Public_Register" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">



    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

<asp:Panel runat="server" ID="PnlRegUserWzrd" BackColor="#D3E7C5" Height="400px" 
        Width="500px">
<asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="False" 
        OnCreatedUser="RegisterUser_CreatedUser" BackColor="#EFF3FB" 
        BorderColor="#B5C7DE" BorderStyle="Solid" BorderWidth="1px" 
        Font-Names="Verdana" Font-Size="0.8em" style="font-size: small" 
        Height="500px" Width="250px">
       <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" 
           BorderWidth="2px" Font-Bold="True" Font-Size="0.9em" ForeColor="White" 
           HorizontalAlign="Center" />
       <LayoutTemplate>
            <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ContinueButtonStyle BackColor="White" BorderColor="#507CD1" 
           BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
           ForeColor="#284E98" />
       <CreateUserButtonStyle BackColor="White" BorderColor="#507CD1" 
           BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
           ForeColor="#284E98" />
       <TitleTextStyle Font-Bold="True" ForeColor="White" />
        <WizardSteps>
            <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                <ContentTemplate>
                    <h2>
                        Create a New Account
                    </h2>
                    <p>
                        <span style="font-size: small">Use the form below to create a new account.
                        </span>
                    </p>
                    <p>
                        <span style="font-size: small">
                        Passwords are required to be a minimum of <%= Membership.MinRequiredPasswordLength %> characters in length.
                        </span>
                    </p>
                    <span>
                        <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="RegisterUserValidationGroup"/>



                    <div class="accountInfo" style="height: 163px;  width: 310px;">
                        <fieldset class="register">
                            <legend>Account Information</legend>
                            
                            <table style="width: 100%;">
                                <tr>
                                    <td>
                                         <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                    </td>
                                    <td>
                                         <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" Display="Dynamic" runat="server" ControlToValidate="UserName" 
                                     CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                         <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                    </td>
                                    <td>
                                          <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" Display="Dynamic" ControlToValidate="Email" 
                                     CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                         <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                    </td>
                                    <td>
                                         <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" Display="Dynamic" ControlToValidate="Password" 
                                     CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                         <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                               
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                                     ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" 
                                     ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                     ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                                    </td>
                                    
                                </tr>
                                <tr>
                                <td>
                                </td>
                                <td>
                                
                                 <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Create User" 
                                 ValidationGroup="RegisterUserValidationGroup"/>
                                 
                                 </td>
                                </tr>
                            </table>
                           
                        </fieldset>
                        
                    </div>
                </ContentTemplate>
                <CustomNavigationTemplate>
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
<asp:CompleteWizardStep runat="server"></asp:CompleteWizardStep>
        </WizardSteps>
       <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" 
           BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
           ForeColor="#284E98" />
       <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" 
           ForeColor="White" />
       <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top" />
       <StepStyle Font-Size="0.8em" />
    </asp:CreateUserWizard>
    </asp:Panel>
    <asp:RoundedCornersExtender ID="RegisterUser_RoundedCornersExtender" 
        runat="server" Radius="10" TargetControlID="PnlRegUserWzrd">
    </asp:RoundedCornersExtender>
    <asp:DropShadowExtender ID="PnlLogin_DropShadowExtender" 
                runat="server" TargetControlID="PnlRegUserWzrd" Radius="9" Opacity=".25" 
        Rounded="True">
            </asp:DropShadowExtender>





</asp:Content>

