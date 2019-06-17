<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebDav.aspx.cs" Inherits="Лаба_8.WebDav" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button runat="server" ID ="createDirectory" Text="createDirectory" OnClick="createDirectory_Click" />
            <asp:Button runat="server" ID ="delDir" Text="deleteDir" OnClick="deleteDirectory_Click" />
            <asp:Button runat="server" ID ="Button1" Text="deleteFile" OnClick="deleteFile_Click" />
            <asp:Button runat="server" ID ="Button2" Text="download" OnClick="downloadFile_Click" />
            <asp:Button runat="server" ID ="Button3" Text="copy" OnClick="CopyFile_Click" />
            <asp:Button runat="server" ID ="Button4" Text="upload" OnClick="uploadFile_Click" />

        </div>
    </form>
</body>
</html>
