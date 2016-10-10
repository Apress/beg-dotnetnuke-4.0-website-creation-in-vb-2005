<%@ Control language="vb" Inherits="YourCompany.Modules.TimePunch.ViewTimePunch"
            CodeFile="ViewTimePunch.ascx.vb" AutoEventWireup="false" 
            Explicit="True" %>
<%@ Register TagPrefix="dnn" TagName="Audit" 
             Src="~/controls/ModuleAuditControl.ascx" %>
<table id="TimeCard" border=0 width="100%" height="100%">
  <tr width="100%" valign="middle">
    <td  colspan="2">
      <asp:DropDownList ID="cmbWeek" runat="server" Width="100%" 
                        AutoPostBack="True">
      </asp:DropDownList>
      <br /><br />
    </td>
    <td colspan="5">
      &nbsp;
    </td>
  </tr>
  <tr width="100%" align="center" valign="middle">
    <td  valign="middle" width="14%">
    <%-- Sunday label --%>
      <asp:Label ID="Label1" runat="server" BorderStyle="None" 
                 Text="Sunday" Width="80%"></asp:Label>
    </td>
    <td  valign="middle" width="14%">
    <%--Monday label --%>
       <asp:Label ID="Label6" runat="server" BorderStyle="None" 
                  Text="Monday" Width="80%"></asp:Label>
   </td>
    <td  valign="middle" width="14%">
    <%--Tuesday label --%>
      <asp:Label ID="Label7" runat="server" BorderStyle="None" 
                 Text="Tuesday" Width="80%"></asp:Label>
    </td>
    <td  valign="middle" width="14%">
    <%--Wednesday label --%>
      <asp:Label ID="Label5" runat="server" BorderStyle="None"  
                 Text="Wednesday" Width="80%"></asp:Label>
    </td>
    <td  valign="middle" width="14%">
    <%--Thursday label --%>
      <asp:Label ID="Label4" runat="server" BorderStyle="None" 
                 Text="Thursday" Width="80%"></asp:Label>
    </td>
    <td  valign="middle" width="14%">
    <%--Friday label --%>
      <asp:Label ID="Label3" runat="server" BorderStyle="None" 
                 Text="Friday" Width="80%"></asp:Label>
    </td>
    <td  valign="middle" width="16%">
    <%--Saturday label --%>
      <asp:Label ID="Label2" runat="server" BorderStyle="None" 
                 Text="Saturday" Width="80%"></asp:Label>
    </td>
  </tr>
  <tr width="100%" align="center" valign="middle">
    <td  valign="middle" width="14%">
    <%-- Sunday value --%>
      <asp:TextBox ID="txtSun" runat="server" BackColor="#E0E0E0" Enabled="false"
                   BorderStyle="Inset" Width="80%"></asp:TextBox>
    </td>
    <td  valign="middle" width="14%">
    <%--Monday value --%>
      <asp:TextBox ID="txtMon" runat="server" BackColor="#E0E0E0" Enabled="false"
                   BorderStyle="Inset" Width="80%" ></asp:TextBox>
   </td>
    <td  valign="middle" width="14%">
    <%--Tuesday value --%>
      <asp:TextBox ID="txtTue" runat="server" BackColor="#E0E0E0" Enabled="false"
                   BorderStyle="Inset" Width="80%" ></asp:TextBox>
    </td>
    <td  valign="middle" width="14%">
    <%--Wednesday value --%>
      <asp:TextBox ID="txtWed" runat="server" BackColor="#E0E0E0" Enabled="false"
                   BorderStyle="Inset" Width="80%" ></asp:TextBox>
    </td>
    <td  valign="middle" width="14%">
    <%--Thursday value --%>
      <asp:TextBox ID="txtThu" runat="server" BackColor="#E0E0E0" Enabled="false"
                   BorderStyle="Inset" Width="80%" ></asp:TextBox>
    </td>
    <td  valign="middle" width="14%">
    <%--Friday value --%>
      <asp:TextBox ID="txtFri" runat="server" BackColor="#E0E0E0" Enabled="false"
                   BorderStyle="Inset" Width="80%" ></asp:TextBox>
    </td>
    <td  valign="middle" width="16%">
    <%--Saturday value --%>
      <asp:TextBox ID="txtSat" runat="server" BackColor="#E0E0E0" Enabled="false"
                   BorderStyle="Inset" Width="80%" ></asp:TextBox>
    </td>
  </tr>
  <tr height="1%">
    <%--Filler row to give vertical space --%>
    <td colspan="7">
      &nbsp;
    </td>
  </tr>
  <tr>
    <td colspan="2">
      <asp:Button ID="cmdPunch" runat="server" Text="Punch In" 
                  Height="64px" Width="100%"
                  Font-Bold="True" Font-Size="X-Large" />
    </td>
    <td colspan="5">
      &nbsp;
    </td>
  </tr>
  <tr height="1%">
   <%--Filler row to give vertical space --%>
   <td colspan="7">
      &nbsp;
    </td>
  </tr>
  <tr height="1%">
   <%--Hours worked label --%>
   <td colspan="2">
      <asp:Label ID="Label8" runat="server" BorderStyle="None" 
                 Text="Hours Worked Today">
      </asp:Label>
    </td>
    <td colspan="5">
      &nbsp;
    </td>
  </tr>
  <tr height="1%">
   <%--Hours worked --%>
   <td colspan="2">
      <asp:TextBox ID="txtHoursToday" runat="server" Enabled="false"
                   BackColor="#E0E0E0" BorderStyle="Inset" Width="80%" >
      </asp:TextBox>
    </td>
    <td colspan="5">
      &nbsp;
    </td>
  </tr>
</table>
