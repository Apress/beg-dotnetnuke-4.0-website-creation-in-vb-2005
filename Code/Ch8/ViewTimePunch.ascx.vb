'
' DotNetNuke® - http://www.dotnetnuke.com
' Copyright (c) 2002-2005
' by Perpetual Motion Interactive Systems Inc. ( http://www.perpetualmotion.ca )
'
' Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
' documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
' the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
' to permit persons to whom the Software is furnished to do so, subject to the following conditions:
'
' The above copyright notice and this permission notice shall be included in all copies or substantial portions 
' of the Software.
'
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
' DEALINGS IN THE SOFTWARE.
'
Imports DotNetNuke
Imports System.Web.UI
Imports System.Collections.Generic
Imports System.Reflection

Namespace YourCompany.Modules.TimePunch

  Partial Class ViewTimePunch
    Inherits Entities.Modules.PortalModuleBase
    Implements Entities.Modules.IActionable

#Region "Private variables"

    Private Const P_IN As Boolean = False
    Private Const P_OUT As Boolean = True
    Private mPunchState As Boolean = P_IN

    Private Shared TimePunchs As TimePunchController = Nothing

#End Region

    Private Sub DisplayWeek(ByVal wk As Integer)
      TimePunchs.FillData(ModuleId, Me.UserId)
      Dim Week As WeekPunches = CType(TimePunchs.PunchArray(wk), WeekPunches)

      txtSun.Text = ""
      txtMon.Text = ""
      txtTue.Text = ""
      txtWed.Text = ""
      txtThu.Text = ""
      txtFri.Text = ""
      txtSat.Text = ""

      'Show the hours worked today in the text box
      txtHoursToday.Text = Week.TodaysHours.ToString("F2")

      txtSun.Text = Week.SundayHours.ToString("F2")
      txtMon.Text = Week.MondayHours.ToString("F2")
      txtTue.Text = Week.TuesdayHours.ToString("F2")
      txtWed.Text = Week.WednesdayHours.ToString("F2")
      txtThu.Text = Week.ThursdayHours.ToString("F2")
      txtFri.Text = Week.FridayHours.ToString("F2")
      txtSat.Text = Week.SundayHours.ToString("F2")
    End Sub


#Region "Event Handlers"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Page_Load runs when the control is loaded
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub Page_Load(ByVal sender As System.Object, _
                          ByVal e As System.EventArgs) Handles MyBase.Load
      If (Me.Session("WeekIndex") = Nothing Or cmbWeek.Items.Count = 0) Then
        'Get the business layer going
        TimePunchs = New TimePunchController()

        'cmdPunch and cmbWeek have the attributes "runat=server"  Because of 
        'this we can access these controls here and fill in the data.
        cmbWeek.Items.Clear()
        cmbWeek.Items.Add("Last Week")
        cmbWeek.Items.Add("This Week")
        cmbWeek.SelectedIndex = 0

        'Add this function call because in the Web changing the
        'selected index does not fire the selectedindexchanged event.
        DisplayWeek(cmbWeek.SelectedIndex)

        'Get the punch state from the database and save it in the session 
        'state for fast retrieval. The punch state is whatever the last punch 
        'was for the day for this person
        If (TimePunchs.GetPunchState(ModuleId, Me.UserId) = 0) Then
          'Person is currently punched in
          cmdPunch.Text = "Punch Out"
          mPunchState = P_OUT
        Else
          'Person is currently punched out
          cmdPunch.Text = "Punch In"
          mPunchState = P_IN
        End If
        'Save the mPuchState variable for use next time through
        Me.Session("mPunchState") = mPunchState

        'If no one is logged in, then disable the button and drop-down
        If (Me.UserId = -1) Then
          cmdPunch.Text = "Disabled.  No log in"
          cmdPunch.Enabled = False
          cmbWeek.Enabled = False
        End If
      End If
      Me.Session("WeekIndex") = Server.HtmlEncode(cmbWeek.SelectedIndex. _
                                                               ToString())
    End Sub

    Protected Sub cmdPunch_Click(ByVal sender As Object, _
                                 ByVal e As EventArgs) Handles cmdPunch.Click
      'If the session variable is available then
      'refill the mPunchState with the saved value
      If (Not Me.Session("mPunchState") = Nothing) Then
        mPunchState = CBool(Me.Session("mPunchState"))
      End If
      If (mPunchState = P_OUT) Then
        mPunchState = P_IN
        cmdPunch.Text = "Punch In"

        'Save the out punch time
        Dim tpi As TimePunchInfo = New TimePunchInfo()
        tpi.ModuleId = ModuleId
        tpi.Punch_User = Me.UserId
        tpi.Punch_Type = 1
        TimePunchs.AddTimePunch(tpi)

        DisplayWeek(cmbWeek.SelectedIndex)
      Else
        mPunchState = P_OUT
        cmdPunch.Text = "Punch Out"

        'Save the in punch time
        Dim tpi As TimePunchInfo = New TimePunchInfo()
        tpi.ModuleId = ModuleId
        tpi.Punch_User = Me.UserId
        tpi.Punch_Type = 0
        TimePunchs.AddTimePunch(tpi)
      End If
      'Save the mPuchState variable for use next time through
      Me.Session("mPunchState") = mPunchState

    End Sub

    Protected Sub cmbWeek_SelectedIndexChanged(ByVal sender As Object, _
                                        ByVal e As EventArgs) _
                                        Handles cmbWeek.SelectedIndexChanged
      DisplayWeek(cmbWeek.SelectedIndex)
    End Sub


#End Region

#Region "Optional Interfaces"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Registers the module actions required for interfacing with the portal framework
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property ModuleActions() As Entities.Modules.Actions.ModuleActionCollection Implements Entities.Modules.IActionable.ModuleActions
      Get
        Dim Actions As New Entities.Modules.Actions.ModuleActionCollection
        Actions.Add(GetNextActionID, Localization.GetString(Entities.Modules.Actions.ModuleActionType.AddContent, LocalResourceFile), Entities.Modules.Actions.ModuleActionType.AddContent, "", "", EditUrl(), False, Security.SecurityAccessLevel.Edit, True, False)
        Return Actions
      End Get
    End Property

#End Region

  End Class

End Namespace
