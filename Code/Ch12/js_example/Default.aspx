<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>JavaScript Example</title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      &nbsp;<table style="width: 782px; height: 692px">
        <tr>
          <td align="center" height="33%" valign="middle" width="33%">
            <asp:Label ID="Label1" runat="server" Text="Server Text Box"></asp:Label><br />
            <asp:TextBox ID="txtText" runat="server"></asp:TextBox><br />
            <asp:Button ID="cmdEnter" runat="server" Text="Enter" /></td>
          <td align="center" height="33%" valign="middle" width="33%">
            <asp:Label ID="Label2" runat="server" Text="Server Button"></asp:Label>
            <br />
            <asp:Button ID="cmdChange" runat="server" Text="This Text" /></td>
          <td align="center" height="33%" valign="middle" width="34%">
            <asp:Label ID="Label3" runat="server" Text="Server List and Button"></asp:Label><br />
            <asp:RadioButton ID="rb1" runat="server" AutoPostBack="True" GroupName="rb" Text="Choose List 1" /><br />
            <asp:RadioButton ID="rb2" runat="server" AutoPostBack="True" GroupName="rb" Text="Choose List 2" /><br />
            <asp:DropDownList ID="lstList" runat="server" Width="100px">
            </asp:DropDownList></td>
        </tr>
        <tr>
          <td align="center" height="33%" valign="middle" width="33%">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Turkey1.JPG" Width="250px" /></td>
          <td align="center" height="33%" valign="middle" width="33%">
          </td>
          <td align="center" height="33%" valign="middle" width="34%">
          </td>
        </tr>
        <tr>
          <td align="center" height="34%" valign="middle" width="33%">
            <asp:Label ID="Label4" runat="server" Text="Server Text Box">
            </asp:Label>
            <asp:TextBox ID="txtClientText" runat="server"></asp:TextBox><br />
            <asp:Button ID="cmdEnterClient" runat="server" Text="Enter" OnClientClick="return ValidateClientText()" /></td>
          <td align="center" height="34%" valign="middle" width="33%">
            <asp:Label ID="Label5" runat="server" Text="JavaScript Highlighted Button">
            </asp:Label><br />
            <img id="cmdImgButton" src="btn_normal.GIF" style="cursor: pointer" onmousedown="cmdImgButon_Down()"
              onmouseup="cmdImgButon_Up()" onmouseover="cmdImgButon_Hover()" onmouseout="this.src='btn_normal.GIF'" /></td>
          <td align="center" height="34%" valign="middle" width="34%">
          </td>
        </tr>
      </table>
    </div>
    <div id="popup" style="width: 400px; height: 200px; background-color: LightGreen;
      position: absolute; left: 200px; top: 200px; border: solid 2px red; visibility: hidden"
      align="center">
      <br />
      <br />
      <asp:Label ID="Label6" runat="server" Text="This is a friendlier popup than the normal 'Alert' statement that windows gives you.">
      </asp:Label>
      <br />
      <asp:Label ID="Label7" runat="server" Text="Be aware though that this popup is not modal!">
      </asp:Label>
      <br />
      <br />
      <asp:Button ID="Button1" runat="server" Text="OK" OnClientClick="document.getElementById('popup').style.visibility='hidden'" />
    </div>
  </form>
</body>
</html>

<script language="javascript">

function ValidateClientText()
{
  // http://www.w3schools.com/css/default.asp
  //I can raise an alert in here
  //I can also set the background color and the font color
  //css: background-color
  //css: color
  //Must get element first

  var txt = document.getElementById("txtClientText");
  txt.style.backgroundColor = "Red";
  txt.style.color = "White";
  
  //return false to prevent postback
  return false;
}

function cmdImgButon_Hover()
{
  var img = document.getElementById("cmdImgButton");
  img.src="btn_hover.GIF";
}

function cmdImgButon_Down()
{
  var img = document.getElementById("cmdImgButton");
  img.src="btn_down.GIF";
}

function cmdImgButon_Up()
{
  var img = document.getElementById("cmdImgButton");
  img.src="btn_normal.GIF";
  
  document.getElementById("popup").style.visibility="visible";
}

</script>

