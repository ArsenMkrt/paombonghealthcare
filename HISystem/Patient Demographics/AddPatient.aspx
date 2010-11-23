<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.master" AutoEventWireup="true" CodeFile="AddPatient.aspx.cs" Inherits="Patient_Demographics_AddEditPatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:DropDownList ID="ddlBarangay" runat="server" DataSourceID="Barangay" 
            DataTextField="BarangayName" DataValueField="BarangayName" 
            style="top: 58px; left: 458px; position: absolute; height: 22px; width: 77px">
        </asp:DropDownList>
        <asp:SqlDataSource ID="Barangay" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            
            SelectCommand="SELECT DISTINCT [BarangayName] FROM [Barangays] ORDER BY [BarangayName]">
        </asp:SqlDataSource>
</p>
<p>
    <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 99px; left: 20px; position: absolute; height: 19px; width: 185px" 
        Text="Name (LN,FN,MN,Suffix)"></asp:Label>
    <asp:TextBox ID="txtSuffix" runat="server" 
        style="top: 99px; left: 641px; position: absolute; height: 22px; width: 75px"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 139px; left: 20px; position: absolute; height: 19px; width: 110px" 
        Text="Contact Number"></asp:Label>
    <asp:Label ID="Label14" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 177px; left: 366px; position: absolute; height: 19px; width: 109px" 
        Text="Civil Status"></asp:Label>
    <asp:RadioButton ID="radiobutton_Female" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 179px; left: 222px; position: absolute; height: 21px; width: 75px" 
        Text="Female" oncheckedchanged="radiobutton_Female_CheckedChanged" />
    <asp:RadioButton ID="radiobutton_Male" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 180px; left: 120px; position: absolute; height: 21px; width: 75px" 
        Text="Male" oncheckedchanged="radiobutton_Male_CheckedChanged" />
    <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 213px; left: 22px; position: absolute; height: 19px; width: 97px" 
        Text="Email Address"></asp:Label>
    <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 250px; left: 21px; position: absolute; height: 19px; width: 63px" 
        Text="Birthdate"></asp:Label>
    <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 288px; left: 22px; position: absolute; height: 19px; width: 55px" 
        Text="Address"></asp:Label>
    <asp:Label ID="Label8" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 138px; left: 379px; position: absolute; height: 19px; width: 92px" 
        Text="Fax Number"></asp:Label>
    <asp:Label ID="Label10" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 346px; left: 22px; position: absolute; height: 19px; width: 75px" 
        Text="Company"></asp:Label>
    <asp:Label ID="Label11" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 387px; left: 23px; position: absolute; height: 19px; width: 74px" 
        Text="Nationality"></asp:Label>
    <asp:Label ID="Label12" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 212px; left: 390px; position: absolute; height: 19px; width: 25px" 
        Text="City"></asp:Label>
    <asp:Label ID="Label13" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 175px; left: 25px; position: absolute; height: 21px; width: 23px" 
        Text="Sex"></asp:Label>
    <asp:Label ID="Label9" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 386px; left: 370px; position: absolute; height: 18px; width: 43px" 
        Text="Doctor"></asp:Label>
    <asp:Label ID="Label20" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 60px; left: 357px; position: absolute; height: 19px; width: 34px" 
        Text="Barangay"></asp:Label>
    <asp:TextBox ID="txtFName" runat="server" 
        style="top: 97px; left: 363px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
</p>
<p>
    <asp:TextBox ID="txtLName" runat="server" 
        
        
        style="top: 98px; left: 219px; position: absolute; height: 22px; width: 133px"></asp:TextBox>
    <asp:TextBox ID="txtMName" runat="server" 
        style="top: 99px; left: 502px; position: absolute; height: 22px; width: 128px"></asp:TextBox>
</p>
<p>
</p>
<p>
    <asp:TextBox ID="txtFaxNum" runat="server" 
        
        style="top: 137px; left: 480px; position: absolute; height: 22px; width: 182px"></asp:TextBox>
    <asp:DropDownList ID="ddlCivilStatus" runat="server" 
        
        style="top: 173px; left: 482px; position: absolute; height: 22px; width: 178px">
        <asp:ListItem>Single</asp:ListItem>
        <asp:ListItem>Divorced</asp:ListItem>
        <asp:ListItem>Married</asp:ListItem>
    </asp:DropDownList>
</p>
<p>
    <asp:TextBox ID="txtEmailAdd" runat="server" 
        
        style="top: 213px; left: 165px; position: absolute; height: 22px; width: 175px"></asp:TextBox>
    <asp:TextBox ID="txtCity" runat="server" 
        
        style="top: 213px; left: 481px; position: absolute; height: 22px; width: 177px"></asp:TextBox>
</p>
<p>
    <asp:DropDownList ID="ddlDay" runat="server" 
        
        style="top: 251px; left: 131px; position: absolute; height: 21px; width: 42px">
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem>2</asp:ListItem>
        <asp:ListItem>3</asp:ListItem>
        <asp:ListItem>4</asp:ListItem>
        <asp:ListItem>5</asp:ListItem>
        <asp:ListItem>6</asp:ListItem>
        <asp:ListItem>7</asp:ListItem>
        <asp:ListItem>8</asp:ListItem>
        <asp:ListItem>9</asp:ListItem>
        <asp:ListItem>10</asp:ListItem>
        <asp:ListItem>11</asp:ListItem>
        <asp:ListItem>12</asp:ListItem>
        <asp:ListItem>13</asp:ListItem>
        <asp:ListItem>14</asp:ListItem>
        <asp:ListItem>15</asp:ListItem>
        <asp:ListItem>16</asp:ListItem>
        <asp:ListItem>17</asp:ListItem>
        <asp:ListItem>18</asp:ListItem>
        <asp:ListItem>19</asp:ListItem>
        <asp:ListItem>20</asp:ListItem>
        <asp:ListItem>21</asp:ListItem>
        <asp:ListItem>22</asp:ListItem>
        <asp:ListItem>23</asp:ListItem>
        <asp:ListItem>24</asp:ListItem>
        <asp:ListItem>25</asp:ListItem>
        <asp:ListItem>26</asp:ListItem>
        <asp:ListItem>27</asp:ListItem>
        <asp:ListItem>28</asp:ListItem>
        <asp:ListItem>29</asp:ListItem>
        <asp:ListItem>30</asp:ListItem>
        <asp:ListItem>31</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlMonth" runat="server" 
        
        style="top: 250px; left: 196px; position: absolute; height: 21px; width: 63px">
        <asp:ListItem>Jan</asp:ListItem>
        <asp:ListItem>Feb</asp:ListItem>
        <asp:ListItem>Mar</asp:ListItem>
        <asp:ListItem>Apr</asp:ListItem>
        <asp:ListItem>May</asp:ListItem>
        <asp:ListItem>Jun</asp:ListItem>
        <asp:ListItem>Jul</asp:ListItem>
        <asp:ListItem>Aug</asp:ListItem>
        <asp:ListItem>Sept</asp:ListItem>
        <asp:ListItem>Oct</asp:ListItem>
        <asp:ListItem>Nov</asp:ListItem>
        <asp:ListItem>Dec</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList ID="ddlYear" runat="server" 
        
        style="top: 250px; left: 283px; position: absolute; height: 21px; width: 56px">
        <asp:ListItem>1989</asp:ListItem>
        <asp:ListItem>1990</asp:ListItem>
        <asp:ListItem>1991</asp:ListItem>
        <asp:ListItem>1992</asp:ListItem>
        <asp:ListItem>1993</asp:ListItem>
        <asp:ListItem>1994</asp:ListItem>
        <asp:ListItem>1995</asp:ListItem>
        <asp:ListItem>1996</asp:ListItem>
        <asp:ListItem>1997</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="txtBirthplace" runat="server" 
        style="top: 250px; left: 482px; position: absolute; height: 22px; width: 177px"></asp:TextBox>
</p>
<p>
    <asp:TextBox ID="txtAddress" runat="server" 
        
        style="top: 289px; left: 130px; position: absolute; height: 44px; width: 612px"></asp:TextBox>
    <asp:Label ID="Label18" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="z-index: 1; left: 381px; top: 251px; position: absolute; height: 19px; width: 69px;" 
        Text="Birthplace"></asp:Label>
</p>
<p>
</p>
<p>
    <asp:TextBox ID="txtCompany" runat="server" 
        
        style="top: 347px; left: 132px; position: absolute; height: 22px; width: 201px"></asp:TextBox>
    <asp:Label ID="Label19" runat="server" Font-Bold="True" ForeColor="#006666" 
        style="top: 348px; left: 368px; position: absolute; height: 19px; width: 111px" 
        Text="Spouse Name"></asp:Label>
    <asp:TextBox ID="txtSpouseName" runat="server" 
        style="top: 347px; left: 483px; position: absolute; height: 22px; width: 172px"></asp:TextBox>
</p>
<p>
    <asp:TextBox ID="txtNationality" runat="server" 
        
        style="top: 387px; left: 132px; position: absolute; height: 22px; width: 201px"></asp:TextBox>
</p>
<p>
</p>
<p>
    <asp:TextBox ID="txtContactNum" runat="server" 
        
        style="top: 137px; left: 165px; position: absolute; height: 22px; width: 179px"></asp:TextBox>
    <asp:TextBox ID="txtDoctor" runat="server" 
        
        style="top: 386px; left: 484px; position: absolute; height: 23px; width: 171px"></asp:TextBox>
        </p>
<p>
        <asp:Button ID="button_AddEdit0" runat="server" 
            style="top: 441px; left: 231px; position: absolute; height: 26px; width: 132px" 
            Text="Save Patient Details" onclick="button_AddEdit_Click" />
        <asp:Button ID="button_Clear" runat="server" 
        style="top: 441px; left: 420px; position: absolute; height: 26px; width: 117px" 
        Text="Clear Details" onclick="button_Clear_Click" />
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

