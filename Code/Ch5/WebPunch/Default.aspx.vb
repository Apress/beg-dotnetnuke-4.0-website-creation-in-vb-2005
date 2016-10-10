Imports System
Imports System.Data

Imports System.Collections
Imports System.Collections.Generic

Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Partial Class _Default
  Inherits System.Web.UI.Page

#Region "Private variables"

  Private Const P_IN As Boolean = False
  Private Const P_OUT As Boolean = True
  Private mPunchState As Boolean = P_IN

  Private mStartPunch As DateTime
  Private mEndPunch As DateTime

  Private Shared MyPunches As ArrayList = New ArrayList()

  Private Class WeekPunches
#Region "Class local variables"

    Private mMondayStart As DateTime
    Private mMondayEnd As DateTime
    Private mTuesdayStart As DateTime
    Private mTuesdayEnd As DateTime
    Private mWednesdayStart As DateTime
    Private mWednesdayEnd As DateTime
    Private mThursdayStart As DateTime
    Private mThursdayEnd As DateTime
    Private mFridayStart As DateTime
    Private mFridayEnd As DateTime
    Private mSaturdayStart As DateTime
    Private mSaturdayEnd As DateTime
    Private mSundayStart As DateTime
    Private mSundayEnd As DateTime

#End Region

#Region "Accessor Get / Set Methods"

    Public Property MondayStart() As DateTime
      Get
        Return mMondayStart
      End Get
      Set(ByVal value As DateTime)
        mMondayStart = value
      End Set
    End Property
    Public Property MondayEnd() As DateTime
      Get
        Return mMondayEnd
      End Get
      Set(ByVal value As DateTime)
        mMondayEnd = value
      End Set
    End Property
    Public ReadOnly Property MondayHours() As Double
      Get
        Return CalculateHours(mMondayStart, mMondayEnd)
      End Get
    End Property

    Public Property TuesdayStart() As DateTime
      Get
        Return mTuesdayStart
      End Get
      Set(ByVal value As DateTime)
        mTuesdayStart = value
      End Set
    End Property
    Public Property TuesdayEnd() As DateTime
      Get
        Return mTuesdayEnd
      End Get
      Set(ByVal value As DateTime)
        mTuesdayEnd = value
      End Set
    End Property
    Public ReadOnly Property TuesdayHours() As Double
      Get
        Return CalculateHours(mTuesdayStart, mTuesdayEnd)
      End Get
    End Property

    Public Property WednesdayStart() As DateTime
      Get
        Return mWednesdayStart
      End Get
      Set(ByVal value As DateTime)
        mWednesdayStart = value
      End Set
    End Property
    Public Property WednesdayEnd() As DateTime
      Get
        Return mWednesdayEnd
      End Get
      Set(ByVal value As DateTime)
        mWednesdayEnd = value
      End Set
    End Property
    Public ReadOnly Property WednesdayHours() As Double
      Get
        Return CalculateHours(mWednesdayStart, mWednesdayEnd)
      End Get
    End Property

    Public Property ThursdayStart() As DateTime
      Get
        Return mThursdayStart
      End Get
      Set(ByVal value As DateTime)
        mThursdayStart = value
      End Set
    End Property
    Public Property ThursdayEnd() As DateTime
      Get
        Return mThursdayEnd
      End Get
      Set(ByVal value As DateTime)
        mThursdayEnd = value
      End Set
    End Property
    Public ReadOnly Property ThursdayHours() As Double
      Get
        Return CalculateHours(mThursdayStart, mThursdayEnd)
      End Get
    End Property

    Public Property FridayStart() As DateTime
      Get
        Return mFridayStart
      End Get
      Set(ByVal value As DateTime)
        mFridayStart = value
      End Set
    End Property
    Public Property FridayEnd() As DateTime
      Get
        Return mFridayEnd
      End Get
      Set(ByVal value As DateTime)
        mFridayEnd = value
      End Set
    End Property
    Public ReadOnly Property FridayHours() As Double
      Get
        Return CalculateHours(mFridayStart, mFridayEnd)
      End Get
    End Property

    Public Property SaturdayStart() As DateTime
      Get
        Return mSaturdayStart
      End Get
      Set(ByVal value As DateTime)
        mSaturdayStart = value
      End Set
    End Property
    Public Property SaturdayEnd() As DateTime
      Get
        Return mSaturdayEnd
      End Get
      Set(ByVal value As DateTime)
        mSaturdayEnd = value
      End Set
    End Property
    Public ReadOnly Property SaturdayHours() As Double
      Get
        Return CalculateHours(mSaturdayStart, mSaturdayEnd)
      End Get
    End Property

    Public Property SundayStart() As DateTime
      Get
        Return mSundayStart
      End Get
      Set(ByVal value As DateTime)
        mSundayStart = value
      End Set
    End Property
    Public Property SundayEnd() As DateTime
      Get
        Return mSundayEnd
      End Get
      Set(ByVal value As DateTime)
        mSundayEnd = value
      End Set
    End Property
    Public ReadOnly Property SundayHours() As Double
      Get
        Return CalculateHours(mSundayStart, mSundayEnd)
      End Get
    End Property

#End Region

    'This is where you would incorporate some rules such as 
    'lunch breaks 
    Private Function CalculateHours(ByVal Start As DateTime, _
                                    ByVal TimeEnd As DateTime) As Double

      'Check to see if end comes after start
      If DateTime.Compare(Start, TimeEnd) < 0 Then
        Dim diff As TimeSpan = TimeEnd.Subtract(Start)
        Return (diff.TotalHours)
      End If
      Return 0.0
    End Function

  End Class

#End Region

  Protected Sub Page_Load(ByVal sender As Object, _
                          ByVal e As System.EventArgs) _
                          Handles Me.Load

    If (Session("WeekIndex") Is Nothing Or cmbWeek.Items.Count = 0) Then
      FillData()

      'cmdPunch and cmbWeek have the attributes "runat=server"  Because of this
      'we can access these controls here and fill in the data.
      cmdPunch.Text = "Punch In"
      cmbWeek.Items.Clear()
      cmbWeek.Items.Add("Last Week")
      cmbWeek.Items.Add("This Week")
      cmbWeek.SelectedIndex = 0

      'Add this function call because in the Web changing the
      'selected index does not fire the selectedindexchanged event.
      DisplayWeek(cmbWeek.SelectedIndex)

    End If

    Session("WeekIndex") = Server.HtmlEncode(cmbWeek.SelectedIndex.ToString())

  End Sub

  Private Sub DisplayWeek(ByVal wk As Integer)

    txtSun.Text = ""
    txtMon.Text = ""
    txtTue.Text = ""
    txtWed.Text = ""
    txtThu.Text = ""
    txtFri.Text = ""
    txtSat.Text = ""

    Dim Week As WeekPunches = CType(MyPunches(wk), WeekPunches)
    txtSun.Text = Week.SundayHours.ToString("F2")
    txtMon.Text = Week.MondayHours.ToString("F2")
    txtTue.Text = Week.TuesdayHours.ToString("F2")
    txtWed.Text = Week.WednesdayHours.ToString("F2")
    txtThu.Text = Week.ThursdayHours.ToString("F2")
    txtFri.Text = Week.FridayHours.ToString("F2")
    txtSat.Text = Week.SundayHours.ToString("F2")

  End Sub

  Private Sub FillData()
    'This takes the place of getting data from a database.
    'We will hard code last weeks data and some of this weeks.

    'Create last week
    Dim LastSunday As DateTime = DateTime.Now
    Dim Days2Subtract As Integer = 7 + CInt(DateTime.Now.DayOfWeek)
    LastSunday = LastSunday.Subtract(New TimeSpan( _
                                    Days2Subtract, _
                                    LastSunday.Hour, _
                                    LastSunday.Minute, _
                                    LastSunday.Second, _
                                    LastSunday.Millisecond))

    Dim LastWeek As WeekPunches = New WeekPunches()
    LastWeek.SundayStart = LastSunday
    LastWeek.SundayEnd = LastSunday
    LastWeek.MondayStart = LastSunday.Add(New TimeSpan(1, 8, 0, 0, 0))
    LastWeek.MondayEnd = LastSunday.Add(New TimeSpan(1, 15, 0, 0, 0))
    LastWeek.TuesdayStart = LastSunday.Add(New TimeSpan(2, 8, 0, 0, 0))
    LastWeek.TuesdayEnd = LastSunday.Add(New TimeSpan(2, 14, 0, 0, 0))
    LastWeek.WednesdayStart = LastSunday.Add(New TimeSpan(3, 8, 0, 0, 0))
    LastWeek.WednesdayEnd = LastSunday.Add(New TimeSpan(3, 13, 0, 0, 0))
    LastWeek.ThursdayStart = LastSunday.Add(New TimeSpan(4, 8, 0, 0, 0))
    LastWeek.ThursdayEnd = LastSunday.Add(New TimeSpan(4, 14, 20, 0, 0))
    LastWeek.FridayStart = LastSunday.Add(New TimeSpan(5, 8, 0, 0, 0))
    LastWeek.FridayEnd = LastSunday.Add(New TimeSpan(5, 15, 30, 0, 0))
    LastWeek.SaturdayStart = LastSunday.Add(New TimeSpan(6, 0, 0, 0, 0))
    LastWeek.SaturdayEnd = LastSunday.Add(New TimeSpan(6, 0, 0, 0, 0))

    MyPunches.Add(LastWeek)

    'Create this week
    Dim ThisSunday As DateTime = DateTime.Now
    Days2Subtract = CInt(DateTime.Now.DayOfWeek)
    ThisSunday = ThisSunday.Subtract(New TimeSpan( _
                                    Days2Subtract, _
                                    ThisSunday.Hour, _
                                    ThisSunday.Minute, _
                                    ThisSunday.Second, _
                                    ThisSunday.Millisecond))
    Dim ThisWeek As WeekPunches = New WeekPunches()
    If (DateTime.Now.DayOfWeek > DayOfWeek.Sunday) Then
      ThisWeek.SundayStart = ThisSunday
      ThisWeek.SundayEnd = ThisSunday
    End If
    If (DateTime.Now.DayOfWeek > DayOfWeek.Monday) Then
      ThisWeek.MondayStart = ThisSunday.Add(New TimeSpan(1, 7, 30, 0, 0))
      ThisWeek.MondayEnd = ThisSunday.Add(New TimeSpan(1, 16, 40, 0, 0))
    End If
    If (DateTime.Now.DayOfWeek > DayOfWeek.Tuesday) Then
      ThisWeek.TuesdayStart = ThisSunday.Add(New TimeSpan(2, 8, 20, 0, 0))
      ThisWeek.TuesdayEnd = ThisSunday.Add(New TimeSpan(2, 14, 50, 0, 0))
    End If
    If (DateTime.Now.DayOfWeek > DayOfWeek.Wednesday) Then
      ThisWeek.WednesdayStart = ThisSunday.Add(New TimeSpan(3, 0, 0, 0, 0))
      ThisWeek.WednesdayEnd = ThisSunday.Add(New TimeSpan(3, 0, 0, 0, 0))
    End If
    If (DateTime.Now.DayOfWeek > DayOfWeek.Thursday) Then
      ThisWeek.ThursdayStart = ThisSunday.Add(New TimeSpan(4, 0, 0, 0, 0))
      ThisWeek.ThursdayEnd = ThisSunday.Add(New TimeSpan(4, 0, 0, 0, 0))
    End If
    If (DateTime.Now.DayOfWeek > DayOfWeek.Friday) Then
      ThisWeek.FridayStart = ThisSunday.Add(New TimeSpan(5, 0, 0, 0, 0))
      ThisWeek.FridayEnd = ThisSunday.Add(New TimeSpan(5, 0, 0, 0, 0))
    End If
    MyPunches.Add(ThisWeek)

  End Sub

  Private Function CalculateHours(ByVal Start As DateTime, _
                                  ByVal TimeEnd As DateTime) As Double

    'Check to see if end comes after start
    If DateTime.Compare(Start, TimeEnd) < 0 Then
      Dim diff As TimeSpan = TimeEnd.Subtract(Start)
      Return (diff.TotalHours)
    End If
    Return 0.0

  End Function

  Protected Sub cmdPunch_Click(ByVal sender As Object, _
                               ByVal e As System.EventArgs) _
                               Handles cmdPunch.Click

    'If the session variable is available then
    'refill the mPunchState with the saved value
    If (Not Session("mPunchState") Is Nothing) Then
      mPunchState = CBool(Session("mPunchState"))
    End If

    'If the session variable is available then
    'refill the mPunchState with the saved value
    If (Not Session("mStartPunch") Is Nothing) Then
      mStartPunch = CType(Session("mStartPunch"), DateTime)
    End If

    'If the session variable is available then
    'refill the mPunchState with the saved value
    If (Not Session("mEndPunch") Is Nothing) Then
      mEndPunch = CType(Session("mEndPunch"), DateTime)
    End If

    If (mPunchState = P_OUT) Then
      mPunchState = P_IN
      cmdPunch.Text = "Punch In"
      mEndPunch = DateTime.Today
      mEndPunch = mEndPunch.Add(New TimeSpan(2, 5, 0))
      txtHoursToday.Text = CalculateHours(mStartPunch, mEndPunch).ToString("F2")

      Dim Week As WeekPunches = CType(MyPunches(1), WeekPunches)
      Select Case (DateTime.Now.DayOfWeek)
        Case DayOfWeek.Sunday
          Week.SundayStart = mStartPunch
          Week.SundayEnd = mEndPunch
        Case DayOfWeek.Monday
          Week.MondayStart = mStartPunch
          Week.MondayEnd = mEndPunch
        Case DayOfWeek.Tuesday
          Week.TuesdayStart = mStartPunch
          Week.TuesdayEnd = mEndPunch
        Case DayOfWeek.Wednesday
          Week.WednesdayStart = mStartPunch
          Week.WednesdayEnd = mEndPunch
        Case DayOfWeek.Thursday
          Week.ThursdayStart = mStartPunch
          Week.ThursdayEnd = mEndPunch
        Case DayOfWeek.Friday
          Week.FridayStart = mStartPunch
          Week.FridayEnd = mEndPunch
        Case DayOfWeek.Saturday
          Week.SaturdayStart = mStartPunch
          Week.SaturdayEnd = mEndPunch
      End Select
      DisplayWeek(cmbWeek.SelectedIndex)
    Else
      mPunchState = P_OUT
      cmdPunch.Text = "Punch Out"
      mStartPunch = DateTime.Today
    End If

    'Save the mPuchState variable for use next time through
    Session("mPunchState") = mPunchState
    Session("mStartPunch") = mStartPunch
    Session("mEndPunch") = mEndPunch

  End Sub

  'You can either put the Handles suffix on this method signature to tie this event handler to the control
  'or you can leave it off like it is done here and instead define the OnSelectedIndexChanged attribute as calling
  'this funciton within the aspx page itself.
  'If you do both you will get a double hit on this evetn handler.
  Protected Sub cmbWeek_SelectedIndexChanged(ByVal sender As Object, _
                                        ByVal e As System.EventArgs) _
                                        Handles cmbWeek.SelectedIndexChanged

    DisplayWeek(cmbWeek.SelectedIndex)
  End Sub

End Class
