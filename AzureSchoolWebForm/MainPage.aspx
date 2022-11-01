<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="SchoolWebForm.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">     <h1>Welcome to Rainbow School Page!!!</h1>
        <div>
        </div>
        <p>
            &nbsp;</p>
        <h2>Do you want to visit Class page:<asp:Button ID="Button1" runat="server" Height="34px" Text="Click" Width="108px" OnClick="Button1_Click" />
        </h2>
    <p>
        &nbsp;</p>
    <h2>Do you want to visit Student page:<asp:Button ID="Button2" runat="server" Height="36px" Text="Click" Width="108px" OnClick="Button2_Click" />
        </h2>
    <p>
        &nbsp;</p>
    <h2>Do you want to visit Subject page:<asp:Button ID="Button3" runat="server" Height="38px" style="margin-top: 0px" Text="Click" Width="117px" OnClick="Button3_Click" />
        </h2>
    </form>
        </body>
</html>
