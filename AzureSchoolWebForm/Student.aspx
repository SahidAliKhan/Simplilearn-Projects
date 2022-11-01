<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="SchoolWebForm.Student" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Student Details</h2>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" style="align-content:center;" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" CssClass="auto-style1" Width="489px">
                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                <SortedDescendingHeaderStyle BackColor="#93451F" />
            </asp:GridView>
            <br />
            Enter Student ID: <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Enter Student Name:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Enter Class ID:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Insert Student" OnClick="Button2_Click"/>
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Update Student" OnClick="Button3_Click" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" Text="Remove Student" OnClick="Button4_Click"/>
&nbsp;&nbsp;
            <br />
            <br />
        </div>
    </form>
</body>
</html>
