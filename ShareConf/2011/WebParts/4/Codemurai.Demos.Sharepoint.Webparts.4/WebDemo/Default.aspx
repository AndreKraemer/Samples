<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebDemo._Default" %>
<%@ Register TagPrefix="cm" Namespace="Codemurai.Demos.Sharepoint.Webparts._4.Control.View" 
             Assembly="Codemurai.Demos.Sharepoint.Webparts.4.Control, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f18a3aa89e64bfca" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:WebPartManager ID="WebPartManager1" runat="server">
    </asp:WebPartManager>
    <div>
        <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
            <cm:Announcement4 ID="AnnouncementControl" runat="server" />
        </ZoneTemplate>
        </asp:WebPartZone>
    </div>
    </form>
</body>
</html>
