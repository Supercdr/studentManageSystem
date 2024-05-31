<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlayOnline.aspx.cs" Inherits="studentManage.admin.PlayOnline" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>在线视频播放</title>
    <link rel="stylesheet" type="text/css" href="//releases.flowplayer.org/5.5.2/skin/minimalist.css" />
    <style>
        body {
            font-size: 12px;
            text-align: center;
            padding-top: 1%;
            color: cornflowerblue;
            background-color: white;
        }
        .flowplayer {
            width: 80%;
            background-color: aquamarine;
            background-size: cover;
            max-width: 800px;
        }
        .flowplayer.fp-controls {
            background-color: rgba(0, 0, 0, 0.4);
        }
        .flowplayer.fp-timeline {
            background-color: rgba(0, 0, 0, 0.5);
        }
        .flowplayer.fp-progress {
            background-color: rgba(219, 0, 0, 1);
        }
        .flowplayer.fp-buffer {
            background-color: rgba(249, 249, 249, 1);
        }
        .flowplayer {
            background-image: url(https://farm4.staticflickr.com/3169/2972817861_73ae53c2e5_b.jpg);
        }
    </style>
    <script src="//code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="//releases.flowplayer.org/5.5.2/flowplayer.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>网上视频播放系统 <a href="javascript:history.back(-1)" class="blue">>>返回首页<<</a></p>
            <div data-swf="//releases.flowplayer.org/5.5.2/flowplayer.swf" class="flowplayer no-toggle" data-ratio="0.416">
                <video loop="loop">
                    <asp:Literal ID="LiteralSource" runat="server"></asp:Literal>
                </video>
            </div>
        </div>
    </form>
</body>
</html>
