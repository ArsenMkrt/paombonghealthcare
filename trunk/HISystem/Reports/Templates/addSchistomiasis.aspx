<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="addSchistomiasis.aspx.cs" Inherits="Reports_Templates_addSchistomiasis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
     <asp:SqlDataSource ID="childCare" runat="server" 
        ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
        SelectCommand="SELECT * FROM [ChildCare] WHERE ChildData = @childData"></asp:SqlDataSource>
    <asp:Label ID="Label3" runat="server" 
        style="top: 59px; left: 649px; position: absolute; height: 19px; width: 34px" 
        Text="Month"></asp:Label>
    <asp:Label ID="Label4" runat="server" 
        style="top: 59px; left: 901px; position: absolute; height: 19px; width: 34px" 
        Text="Year"></asp:Label>
    <asp:DropDownList ID="ddlYear" runat="server" 
        
        style="top: 56px; left: 956px; position: absolute; height: 20px; width: 130px" 
        AutoPostBack="True" onselectedindexchanged="ddlYear_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:DropDownList ID="ddlIndicator" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddlIndicator_SelectedIndexChanged" 
        style="top: 60px; left: 54px; position: absolute; height: 20px; width: 542px">
    </asp:DropDownList>
    <br />
    <asp:DropDownList ID="ddlMonth" runat="server" 
        
        style="top: 57px; left: 716px; position: absolute; height: 20px; width: 149px" 
        AutoPostBack="True" onselectedindexchanged="ddlMonth_SelectedIndexChanged">
    </asp:DropDownList>
        <br />
    </p>
    <p>
    </p>
    <asp:Panel ID="pnl_listview" runat="server" ScrollBars="Both" 
        style="top: 110px; left: 50px; position: absolute; height: 502px; width: 1164px">
        <asp:ListView ID="listviewSchisto" runat="server" 
            InsertItemPosition="LastItem" 
            oniteminserting="listviewSchisto_ItemInserting" 
            onitemdeleting="listviewSchisto_ItemDeleting">
            <AlternatingItemTemplate>
                <tr style="background-color: #FFFFFF;color: #284775;">
                    <td>
                        <asp:Label ID="SchistoEntryNumberLabelID1" runat="server" 
                            Text='<%# Eval("ChildEntryNumber") %>' Visible="false" />
                    </td>
                    <td>
                        <asp:Label ID="SchistoDataLabel" runat="server" Text='<%# Eval("SchistoData") %>' />
                    </td>
                    <td>
                         <asp:Label ID="Population1" runat="server" Text='<%# Eval("Population") %>' />
                    </td>
                    
                    <td>
                        <asp:Label ID="MaleLabel" runat="server" Text='<%# Eval("Male") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FemaleLabel" runat="server" Text='<%# Eval("Female") %>' />
                    </td>
                    <td>
                        <asp:Label ID="InputDateLabel" runat="server" Text='<%# Eval("InputDate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BarangayNameLabel" runat="server" 
                            Text='<%# Eval("BarangayName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AccomplishmentLabel" runat="server" 
                            Text='<%# Eval("Accomplishment") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MonthLabel" runat="server" Text='<%# Eval("Month") %>' />
                    </td>
                    <td>
                        <asp:Label ID="YearLabel" runat="server" Text='<%# Eval("Year") %>' />
                    </td>
        <%--            <td>
                        <asp:Label ID="QuarterLabel" runat="server" Text='<%# Eval("Quarter") %>' />
                    </td>--%>
                     <td>
                        <asp:Label ID="Target1" runat="server" Text='<%# Eval("Target") %>' />
                    </td>
                      <td>
                        <asp:LinkButton ID = "lnkDel" runat="server" Text="Delete" CommandName="Delete"
                         OnClientClick="return confirm('Delete this entry?')" />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color: #999999;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                            Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                            Text="Cancel" />
                    </td>
                  <%--  <td>
                        <asp:Label ID="ChildEntryNumberLabel1" runat="server" 
                            Text='<%# Eval("ChildEntryNumber") %>' />
                    </td>--%>
                    <td>
                        <asp:TextBox ID="SchistoDataTextBox" runat="server" 
                            Text='<%# Bind("SchistoData") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="MaleTextBox" runat="server" Text='<%# Bind("Male") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="FemaleTextBox" runat="server" Text='<%# Bind("Female") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="InputDateTextBox" runat="server" 
                            Text='<%# Bind("InputDate") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="BarangayNameTextBox" runat="server" 
                            Text='<%# Bind("BarangayName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AccomplishmentTextBox" runat="server" 
                            Text='<%# Bind("Accomplishment") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MonthLabel1" runat="server" Text='<%# Eval("Month") %>' />
                    </td>
                    <td>
                        <asp:Label ID="YearLabel1" runat="server" Text='<%# Eval("Year") %>' />
                    </td>
             <%--       <td>
                        <asp:TextBox ID="QuarterTextBox" runat="server" Text='<%# Bind("Quarter") %>' />
                    </td>--%>
                    <td>
                        <asp:TextBox ID="TargetTextBox" runat="server" Text='<%# Bind("Target") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table id="Table1" runat="server" 
                    style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>
                            No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                            Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                            Text="Clear" />
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text="---------" />
                    </td>
                    <td>
                        <asp:TextBox ID="MaleTextBox" runat="server" Text='<%# Bind("Male") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="FemaleTextBox" runat="server" Text='<%# Bind("Female") %>' />
                    </td>
                    <td>
                        <asp:Label ID="InputDateTextBox" runat="server" 
                            Text="---------" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBarangay" runat="server">
                            <asp:ListItem Value="101">Binakod</asp:ListItem>
                            <asp:ListItem Value="102">San Roque</asp:ListItem>
                            <asp:ListItem Value="103">Sto. Nino</asp:ListItem>
                            <asp:ListItem Value="104">Malumot</asp:ListItem> 
                            <asp:ListItem Value="105">Poblacion</asp:ListItem>
                            <asp:ListItem Value="106">Masukol</asp:ListItem> 
                            <asp:ListItem Value="107">San Jose</asp:ListItem>
                            <asp:ListItem Value="108">Sto. Rosario</asp:ListItem> 
                            <asp:ListItem Value="109">San Vicente</asp:ListItem>
                            <asp:ListItem Value="110">San Isidro I</asp:ListItem>     
                            <asp:ListItem Value="111">San Isidro II</asp:ListItem>
                            <asp:ListItem Value="112">Pinalagdan</asp:ListItem> 
                            <asp:ListItem Value="113">Kapitangan</asp:ListItem>
                            <asp:ListItem Value="114">Sta. Cruz</asp:ListItem> 
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="AccomplishmentTextBox" runat="server" 
                            Text='<%# Bind("Accomplishment") %>' />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMonth" runat="server">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem> 
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem> 
                            <asp:ListItem Value="7">7</asp:ListItem>
                            <asp:ListItem Value="8">8</asp:ListItem> 
                            <asp:ListItem Value="9">9</asp:ListItem>
                            <asp:ListItem Value="10">10</asp:ListItem>     
                            <asp:ListItem Value="11">11</asp:ListItem>
                            <asp:ListItem Value="12">12</asp:ListItem> 
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:TextBox ID="YearTextBox" runat="server" Text='<%# Bind("Year") %>' />
                    </td>
                    <td>
                        <asp:Label ID="TargetLabel" runat="server" Text="---------" />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color: #E0FFFF;color: #333333;">
                    <td>
                        <asp:Label ID="SchistoEntryNumberLabelID1" runat="server" 
                            Text='<%# Eval("SchistoEntryNumber") %>' Visible="false" />
                    </td> 
                    <td>
                        <asp:Label ID="SchistoDataLabel" runat="server" Text='<%# Eval("SchistoData") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MaleLabel" runat="server" Text='<%# Eval("Male") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FemaleLabel" runat="server" Text='<%# Eval("Female") %>' />
                    </td>
                    <td>
                        <asp:Label ID="InputDateLabel" runat="server" Text='<%# Eval("InputDate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BarangayNameLabel" runat="server" 
                            Text='<%# Eval("BarangayName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AccomplishmentLabel" runat="server" 
                            Text='<%# Eval("Accomplishment") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MonthLabel" runat="server" Text='<%# Eval("Month") %>' />
                    </td>
                    <td>
                        <asp:Label ID="YearLabel" runat="server" Text='<%# Eval("Year") %>' />
                    </td>
      <%--              <td>
                        <asp:Label ID="QuarterLabel" runat="server" Text='<%# Eval("Quarter") %>' />
                    </td>--%>
                    <td>
                        <asp:Label ID="TargetLabel" runat="server" Text='<%# Eval("Target") %>' />
                    </td>
                    <td>
                        <asp:LinkButton ID = "lnkDel" runat="server" Text="Delete" CommandName="Delete"
                         OnClientClick="return confirm('Delete this entry?')" />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table id="Table2" runat="server">
                    <tr id="Tr1" runat="server">
                        <td id="Td1" runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr id="Tr2" runat="server" style="background-color: #E0FFFF;color: #333333;">
                                    <th runat="server">
                                        </th>
                                    <th id="Th1" runat="server">
                                        SchistoData</th>
                                    <th id="Th2" runat="server">
                                        Population</th>
                                    <th id="Th3" runat="server">
                                        Male</th>
                                    <th id="Th4" runat="server">
                                        Female</th>
                                    <th id="Th5" runat="server">
                                        InputDate</th>
                                    <th id="Th6" runat="server">
                                        BarangayName</th>
                                    <th id="Th7" runat="server">
                                        Accomplishment</th>
                                    <th id="Th8" runat="server">
                                        Month</th>
                                    <th id="Th9" runat="server">
                                        Year</th>
                         <%--           <th runat="server">
                                        Quarter</th>--%>
                                    <th id="Th10" runat="server">
                                        Target</th>
                                        <th id="Th11" runat="server">
                                        Command</th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="Tr3" runat="server">
                        <td id="Td2" runat="server" 
                            style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color: #E2DED6;font-weight: bold;color: #333333;">
                  <%--  <td>
                        <asp:Label ID="ChildEntryNumberLabel" runat="server" 
                            Text='<%# Eval("ChildEntryNumber") %>' />
                    </td>--%>
                    <td>
                        <asp:Label ID="SchistoDataLabel" runat="server" Text='<%# Eval("SchistoData") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MaleLabel" runat="server" Text='<%# Eval("Male") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FemaleLabel" runat="server" Text='<%# Eval("Female") %>' />
                    </td>
                    <td>
                        <asp:Label ID="InputDateLabel" runat="server" Text='<%# Eval("InputDate") %>' />
                    </td>
                    <td>
                        <asp:Label ID="BarangayNameLabel" runat="server" 
                            Text='<%# Eval("BarangayName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AccomplishmentLabel" runat="server" 
                            Text='<%# Eval("Accomplishment") %>' />
                    </td>
                    <td>
                        <asp:Label ID="MonthLabel" runat="server" Text='<%# Eval("Month") %>' />
                    </td>
                    <td>
                        <asp:Label ID="YearLabel" runat="server" Text='<%# Eval("Year") %>' />
                    </td>
              <%--      <td>
                        <asp:Label ID="QuarterLabel" runat="server" Text='<%# Eval("Quarter") %>' />
                    </td>--%>
                     <td>
                        <asp:Label ID="TargetLabel" runat="server" Text='<%# Eval("Target") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
    </asp:Panel>
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

