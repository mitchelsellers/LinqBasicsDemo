<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LINQWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:CheckBoxList ID="cblItems" runat="server">
            <asp:ListItem Text="Item 1" Value="1"/>
            <asp:ListItem Text="Item 2" Value="2"/>
            <asp:ListItem Text="Item 3" Value="3"/>
            <asp:ListItem Text="Item 4" Value="4"/>
            <asp:ListItem Text="Item 5" Value="5"/>
            <asp:ListItem Text="Item 6" Value="6"/>
            <asp:ListItem Text="Item 7" Value="7"/>
        </asp:CheckBoxList>
        <p>
            <asp:Button runat="server" ID="FindSelectedButton" Text="Find Selected" OnClick="FindSelectedButton_Click" />
        </p>
        <p style="background-color: #eee;">
            Selected Items:<asp:Literal runat="server" ID="litResults" />
        </p>
    </div>
    </form>
</body>
</html>
