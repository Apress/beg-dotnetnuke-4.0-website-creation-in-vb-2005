<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Ajax Example</title>

  <script language="javascript">

  //This function gets called before the callback function happens
  function OnBeforeCallback()
  {
    //This function can be eliminated if you don't want to use it.
  }
  
  function CallServer(arg)
  {
    //This is a little bit of HTML that replaces this 
    //callbackStr variabe with its C# string variable from the server.
    <%=CallbackStr%>
  }

  //This function gets called when the server has finished crunching code
  //and sends back the answer
  function CallbackResult(txt)
  {
    var lst = document.getElementById("lstList");
    
    ClearOptions(lst);
    var info = txt.split("|");
    for(k=0; k<info.length; k++)
      AddToOptionList(lst, k, info[k]);
  }

  //This function gets called automatically if there is an error in the 
  //Ajax call.
  function onError(message, context) 
  {
    alert("Ajax Error = " + message);
  }

  //This function gets called from pressing the button
  function GetList()
  {
    CallServer("Get List");
  }

  //This function clears a select list of all its options
  function ClearOptions(OptionList)
  {
    // Always clear an option list from the last entry to the first
    for (x = OptionList.length; x >= 0; x = x - 1)
    {
      OptionList[x] = null;
    }
  }
  
  //This function adds an option to the select list
  function AddToOptionList(OptionList, OptionValue, OptionText)
  {
    var LastOption;
    
    // Add option to the bottom of the list
    LastOption = OptionList.length;
    OptionList[LastOption] = new Option(OptionText, OptionValue);
  }

  </script>

</head>
<body>
  <form id="form1" runat="server">
    <div>
      <table height="100%" width="100%">
        <tr>
          <td align="center" height="33%" valign="middle" width="33%">
          </td>
          <td align="center" height="33%" valign="middle" width="33%">
          </td>
          <td align="center" height="33%" valign="middle" width="34%">
          </td>
        </tr>
        <tr>
          <td align="center" height="33%" valign="middle" width="33%">
            <img src="Turkey1.JPG" width="250" /></td>
          <td align="center" height="33%" valign="middle" width="33%">
            <input id="cmdFill" type="button" value="Fill List" onclick="GetList()" name="cmdFill" />
            <br />
            <select id="lstList" name="lstList" size="10" style="width: 50%">
              <option selected="selected"></option>
            </select>
          </td>
          <td align="center" height="33%" valign="middle" width="34%">
            <img src="Turkey1.JPG" width="250" /></td>
        </tr>
        <tr>
          <td align="center" height="34%" valign="middle" width="33%">
            <img src="Turkey1.JPG" width="250" /></td>
          <td align="center" height="34%" valign="middle" width="33%">
            <img src="Turkey1.JPG" width="250" /></td>
          <td align="center" height="34%" valign="middle" width="34%">
            <img src="Turkey1.JPG" width="250" /></td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>
