<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <div>
            <asp:Label ID="Label1" runat="server" Text="IBS-param"></asp:Label>
     <br/>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Click" OnClick="Button1_Click" />
            </div>
    </form>
    <form id ="form2" method ="get" action="./">
        <div>
            <br />
            <input type="submit" id ="button2"/>
            </div>
    </form>
</body>
</html>
