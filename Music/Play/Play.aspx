<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Play.aspx.cs" Inherits="Play_Play" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <object id="Player" type="audio/x-pn/realaudio" 
standby="Loading.... Microsoft Windows Media Player"
classid="CLSID:22d6f312-b0f6-11d0-94ab-0080c74c7e95">
<param name="filename"  value=<%=Mlm() %> />
<param name="autoStart" value="true" />
<param name="playCount" value="2" />
</object>
    </div>
    </form>
</body>
</html>
