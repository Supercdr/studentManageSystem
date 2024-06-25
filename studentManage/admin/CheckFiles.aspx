<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckFiles.aspx.cs" Inherits="studentManage.admin.CheckFiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
    body {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; 
        background-color: #f0f4f8; 
        color: #333; 
        margin: 0;
        padding: 15px; 
        text-align: center; 
    }

    #form1 {
        background-color: white; 
        width: 80%; 
        margin: 0 auto;
        padding: 20px; 
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);  
        border-radius: 8px;  
    }

    p {
        font-size: 16px;  
        color: black; 
        line-height: 1.6;  
    }

    a {
        color: darkblue;  
        text-decoration: none; 
    }

    a:hover {
        text-decoration: underline;  
    }

    .blue {
        color: darkblue;  
    }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>友情提醒</p>
            <p>
                <asp:Label ID="PlayOnline" runat="server"></asp:Label><br />
                <asp:Label ID="Download" runat="server" Text="Label"></asp:Label><br />
                <a href="javascript:history.back(-1)" target="mainFrame">返回</a>
            </p>
        </div>
    </form>
</body>
</html>
