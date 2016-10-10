<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Untitled Page</title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      &nbsp;&nbsp;
      <asp:Button ID="cmdPunch" runat="server" Style="z-index: 100; left: 80px; position: absolute;
        top: 240px" Text="Punch In" Height="64px" Width="176px"
        Font-Bold="True" Font-Size="X-Large" />
      <asp:DropDownList ID="cmbWeek" runat="server" Style="z-index: 101; left: 24px; position: absolute;
        top: 64px" Width="168px" AutoPostBack="True">
      </asp:DropDownList>
      <asp:Label ID="Label1" runat="server" BorderStyle="None" Style="z-index: 102; left: 24px;
        position: absolute; top: 112px" Text="Sunday" Width="80px"></asp:Label>
      <asp:Label ID="Label2" runat="server" BorderStyle="None" Style="z-index: 103; left: 552px;
        position: absolute; top: 112px" Text="Saturday" Width="80px"></asp:Label>
      <asp:Label ID="Label3" runat="server" BorderStyle="None" Style="z-index: 104; left: 464px;
        position: absolute; top: 112px" Text="Friday" Width="80px"></asp:Label>
      <asp:Label ID="Label4" runat="server" BorderStyle="None" Style="z-index: 105; left: 376px;
        position: absolute; top: 112px" Text="Thursday" Width="80px"></asp:Label>
      <asp:Label ID="Label5" runat="server" BorderStyle="None" Style="z-index: 106; left: 288px;
        position: absolute; top: 112px" Text="Wednesday" Width="80px"></asp:Label>
      <asp:Label ID="Label6" runat="server" BorderStyle="None" Style="z-index: 107; left: 112px;
        position: absolute; top: 112px" Text="Monday" Width="80px"></asp:Label>
      <asp:Label ID="Label7" runat="server" BorderStyle="None" Style="z-index: 108; left: 200px;
        position: absolute; top: 112px" Text="Tuesday" Width="80px"></asp:Label>
      <asp:Label ID="txtSun" runat="server" BackColor="#E0E0E0" BorderStyle="Inset" Style="z-index: 109;
        left: 24px; position: absolute; top: 144px" Width="70px" Height="15px"></asp:Label>
      <asp:Label ID="txtThu" runat="server" BackColor="#E0E0E0" BorderStyle="Inset" Style="z-index: 110;
        left: 376px; position: absolute; top: 144px" Width="70px" Height="15px"></asp:Label>
      <asp:Label ID="txtWed" runat="server" BackColor="#E0E0E0" BorderStyle="Inset" Style="z-index: 111;
        left: 288px; position: absolute; top: 144px" Width="70px" Height="15px"></asp:Label>
      <asp:Label ID="txtTue" runat="server" BackColor="#E0E0E0" BorderStyle="Inset" Style="z-index: 112;
        left: 200px; position: absolute; top: 144px" Width="70px" Height="15px"></asp:Label>
      <asp:Label ID="txtMon" runat="server" BackColor="#E0E0E0" BorderStyle="Inset" Style="z-index: 113;
        left: 112px; position: absolute; top: 144px" Width="70px" Height="15px"></asp:Label>
      <asp:Label ID="txtSat" runat="server" BackColor="#E0E0E0" BorderStyle="Inset" Style="z-index: 114;
        left: 552px; position: absolute; top: 144px" Width="70px" Height="15px"></asp:Label>
      <asp:Label ID="txtFri" runat="server" BackColor="#E0E0E0" BorderStyle="Inset" Style="z-index: 115;
        left: 464px; position: absolute; top: 144px" Width="70px" Height="15px"></asp:Label>
      <asp:Label ID="Label8" runat="server" BorderStyle="None" Style="z-index: 116; left: 80px;
        position: absolute; top: 352px" Text="Hours Worked Today"></asp:Label>
      <asp:Label ID="txtHoursToday" runat="server" BackColor="#E0E0E0" BorderStyle="Inset"
        Style="z-index: 117; left: 80px; position: absolute; top: 376px" Width="128px"
        Height="15px"></asp:Label>
    </div>
  </form>
</body>
</html>

