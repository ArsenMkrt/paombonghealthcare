<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="ccChildCare.aspx.cs" Inherits="Reports_Templates_ChildCareTemp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
        <asp:Label ID="Label3" runat="server" 
            style="top: 18px; left: 28px; position: absolute; height: 19px; width: 93px" 
            Text="Child Care" Font-Bold="True"></asp:Label>
        <asp:Label ID="lblYear" runat="server" 
            style="top: 56px; left: 590px; position: absolute; height: 19px; width: 72px" 
            Text="Label" ForeColor="#CC3300"></asp:Label>
        <asp:Label ID="lblQuarter" runat="server" 
            style="top: 58px; left: 804px; position: absolute; height: 19px; width: 106px" 
            Text="Label" ForeColor="#CC3300"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label6" runat="server" 
            style="top: 59px; left: 736px; position: absolute; height: 19px; width: 48px; right: 453px" 
            Text="Quarter:"></asp:Label>
        <asp:DropDownList ID="ddlIndicator" runat="server" 
            
            
            style="top: 57px; left: 33px; position: absolute; height: 20px; width: 444px" 
            AutoPostBack="True" onselectedindexchanged="ddlIndicator_SelectedIndexChanged">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label5" runat="server" 
            style="top: 57px; left: 539px; position: absolute; height: 19px; width: 34px" 
            Text="Year:"></asp:Label>
    </p>
    <asp:Panel ID="panelGridview" runat="server" ScrollBars="Both" 
        
        style="top: 103px; left: 15px; position: absolute; height: 470px; width: 1215px">
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="2px" 
            CellPadding="3" Height="177px" 
            DataKeyNames="BarangayID" HorizontalAlign="Center" 
            style="top: 5px; left: 4px; position: absolute; width: 1191px" 
            ForeColor="Black" 
            onrowdatabound="GridView1_RowDataBound">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:BoundField DataField="BarangayID" Visible="false"/>  
                            <asp:TemplateField>  
                               <ItemTemplate>  
                                    <asp:Label ID="lblBarangayID" runat="server" Text='<%#Eval("BarangayID") %>' Visible="false"></asp:Label>  
                                </ItemTemplate>  
                            </asp:TemplateField> 
                <asp:TemplateField ControlStyle-Width="100" HeaderText="Barangay">
                    <ItemTemplate>
                        <asp:Label ID="lblBarangayName" runat="server" Text='<%#Eval("BarangayName")%>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Population">
                    <ItemTemplate>
                        <asp:Label ID="lblPopulation" runat="server" Text='<%#Eval("Population")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPopulation" runat="server" BackColor="Aqua" Text='<%#Eval("Population")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Target">
                    <ItemTemplate>
                        <asp:Label ID="lblTarget" runat="server" Text='<%#Eval("Target")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtTarget" BackColor="Aqua" runat="server" Text='<%#Eval("Target")%>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100" ControlStyle-Width="100">
                    <ItemTemplate>
                    <center>
                            Male<asp:Label ID="lblMale1" Text='<%#Eval("Male1")%>' runat="server" Width="100" />
                            Female<asp:Label ID="lblFemale1" Text='<%#Eval("Female1")%>'  runat="server" Width="100" />
                            Total<asp:Label ID="lblTotal1" Text="x" runat="server" Width="100" />
                    </center>
                    </ItemTemplate>
                    <EditItemTemplate>
                     <center>
                            Male<asp:TextBox ID="txtMale1" Text='<%#Eval("Male1")%>' BackColor="Aqua" runat="server" Wrap="true" Width="100" />
                            Female<asp:TextBox ID="txtFemale1" Text='<%#Eval("Female1")%>' BackColor="Aqua" runat="server" Wrap="true" Width="100" />
                            Total<asp:TextBox ID="TxtTotal1" Text="x" BackColor="Aqua" ReadOnly="true" runat="server" Wrap="true" Width="100" />
                    </center>
                    </EditItemTemplate>
                    <ControlStyle Width="100px" />
                    <HeaderStyle Width="100px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100" ControlStyle-Width="100">
                    <ItemTemplate>
                    <center>
                            Male<asp:Label ID="lblMale2" Text='<%#Eval("Male2")%>' runat="server" Width="100" />
                            Female<asp:Label ID="lblFemale2" Text='<%#Eval("Female2")%>'  runat="server" Width="100" />
                            Total<asp:Label ID="lblTotal2" Text="x" runat="server"  Width="100" />
                    </center>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <center>
                            Male<asp:TextBox ID="txtMale2" Text='<%#Eval("Male2")%>' BackColor="Aqua" Wrap="true" runat="server" Width="100" />
                            Female<asp:TextBox ID="txtFemale2" Text='<%#Eval("Female2")%>' BackColor="Aqua" Wrap="true" runat="server" Width="100" />
                            Total<asp:TextBox ID="TxtTotal2" Text="x"  BackColor="Aqua" ReadOnly="true" runat="server" Wrap="true" Width="100" />
                    </center>
                    </EditItemTemplate>
                    <ControlStyle Width="100px" />
                    <HeaderStyle Width="100px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="100" ControlStyle-Width="100">
                    <ItemTemplate>
                    <center>
                            Male<asp:Label ID="lblMale3" Text='<%#Eval("Male3")%>' runat="server" Width="100" />
                            Female<asp:Label ID="lblFemale3" Text='<%#Eval("Female3")%>' runat="server" Width="100" />
                            Total<asp:Label ID="lblTotal3" Text="x" runat="server" Width="100" />
                    </center>
                    </ItemTemplate>
                    <EditItemTemplate>
                    <center>
                            Male<asp:TextBox ID="txtMale3" Text='<%#Eval("Male3")%>' BackColor="Aqua" Wrap="true" runat="server" Width="100" />
                            Female<asp:TextBox ID="txtFemale3" Text='<%#Eval("Female3")%>' BackColor="Aqua" Wrap="true" runat="server" Width="100" />
                            Total<asp:TextBox ID="TxtTotal3" Text="x"  BackColor="Aqua" ReadOnly="true" runat="server" Wrap="true" Width="100" />
                    </center>
                    </EditItemTemplate>
                    <ControlStyle Width="100px" />
                    <HeaderStyle Width="100px" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
                </asp:TemplateField>
                        <asp:TemplateField ControlStyle-Height="200" ControlStyle-Width="200" 
                            HeaderText="Quarter Accomplishment">
                            <ItemTemplate>
                                <asp:Label ID="lblQA" Text='<%#Eval("Accomplishment")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtQA" Text='<%#Eval("Accomplishment")%>' BackColor="Aqua" runat="server" 
                                     TextMode="MultiLine"></asp:TextBox>
                            </EditItemTemplate>
                            <ControlStyle Height="120px" Width="120px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Percent">
                            <ItemTemplate>
                                <asp:Label ID="lblPercent" Text='<%#Eval("Percent")%>' runat="server"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtPercent" Text='<%#Eval("Percent")%>' BackColor="Aqua" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BorderStyle="Dashed" HorizontalAlign="Center" 
                        VerticalAlign="Middle" />
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
            <RowStyle HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
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
        <asp:Button ID="Save" runat="server" onclick="Save_Click" 
            style="top: 590px; left: 469px; position: absolute; width: 89px" 
            Text="Save" />
    </p>
    <p>
    </p>
</asp:Content>

