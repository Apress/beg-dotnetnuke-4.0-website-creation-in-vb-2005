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

Imports System
Imports System.Configuration
Imports System.Data
Imports System.XML
Imports System.Web
Imports System.Collections.Generic
Imports DotNetNuke
Imports DotNetNuke.Common.Utilities.XmlUtils

Namespace YourCompany.Modules.TimePunch


  Public Class WeekPunches
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
    Private Function CalculateHours(ByVal Start As DateTime, ByVal TimeEnd As DateTime) As Double

      'Check to see if end comes after start
      If DateTime.Compare(Start, TimeEnd) < 0 Then
        Dim diff As TimeSpan = TimeEnd.Subtract(Start)
        Return (diff.TotalHours)
      End If
      Return 0.0
    End Function

    Public ReadOnly Property TodaysHours() As Double
      Get
        Select Case (DateTime.Now.DayOfWeek)
          Case DayOfWeek.Sunday
            Return CalculateHours(SundayStart, SundayEnd)
          Case DayOfWeek.Monday
            Return CalculateHours(MondayStart, MondayEnd)
          Case DayOfWeek.Tuesday
            Return CalculateHours(TuesdayStart, TuesdayEnd)
          Case DayOfWeek.Wednesday
            Return CalculateHours(WednesdayStart, WednesdayEnd)
          Case DayOfWeek.Thursday
            Return CalculateHours(ThursdayStart, ThursdayEnd)
          Case DayOfWeek.Friday
            Return CalculateHours(FridayStart, FridayEnd)
          Case DayOfWeek.Saturday
            Return CalculateHours(SaturdayStart, SaturdayEnd)
            Return 0.0
        End Select
      End Get
    End Property




  End Class


  Public Class TimePunchController

    Private Shared MyPunches As ArrayList = New ArrayList()
    Private Enum PunchType
      PUNCH_IN
      PUNCH_OUT
    End Enum

#Region "Public Methods"


    Public Function GetPunchState(ByVal ModuleId As Integer, _
                                  ByVal PunchUserID As Integer) As Integer
      Dim retval As Integer = 1  'punch OUT state
      Dim LastPunch As DateTime = DateTime.MinValue

      'Set up a collection of TimePunchInfo objects
      Dim colTimePunchs As List(Of TimePunchInfo)

      'Get the content from the TimePunch table
      colTimePunchs = GetTimePunchs(ModuleId, PunchUserID)
      For Each tpi As TimePunchInfo In colTimePunchs
        If (DateTime.Today.ToShortDateString() = tpi.Punch_Date.ToShortDateString()) Then
          If (tpi.Punch_Date >= LastPunch) Then
            LastPunch = tpi.Punch_Date
            retval = tpi.Punch_Type
          End If
        End If
      Next
      Return retval
    End Function

    Public Sub FillData(ByVal ModuleId As Integer, ByVal PunchUserID As Integer)
      'Set up a collection of TimePunchInfo objects
      Dim colTimePunchs As List(Of TimePunchInfo)

      'Get the content from the TimePunch table
      colTimePunchs = GetTimePunchs(ModuleId, PunchUserID)

      'Reset the MyPunches array list
      MyPunches.Clear()

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

      'We now have a list of punches for this person forever.
      ' (This is where a list of punches for a time span would be handy)
      ' (Also most programs like this would archive data so there would 
      ' only be about 1 yr worth in here anyway.)
      LastWeek.SundayStart = GetPunch(PunchType.PUNCH_IN, _
                                         LastSunday, colTimePunchs)
      LastWeek.SundayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                         LastSunday, colTimePunchs)
      LastWeek.MondayStart = GetPunch(PunchType.PUNCH_IN, _
                                         LastSunday.AddDays(1), colTimePunchs)
      LastWeek.MondayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                         LastSunday.AddDays(1), colTimePunchs)
      LastWeek.TuesdayStart = GetPunch(PunchType.PUNCH_IN, _
                                         LastSunday.AddDays(2), colTimePunchs)
      LastWeek.TuesdayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                         LastSunday.AddDays(2), colTimePunchs)
      LastWeek.WednesdayStart = GetPunch(PunchType.PUNCH_IN, _
                                         LastSunday.AddDays(3), colTimePunchs)
      LastWeek.WednesdayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                         LastSunday.AddDays(3), colTimePunchs)
      LastWeek.ThursdayStart = GetPunch(PunchType.PUNCH_IN, _
                                         LastSunday.AddDays(4), colTimePunchs)
      LastWeek.ThursdayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                         LastSunday.AddDays(4), colTimePunchs)
      LastWeek.FridayStart = GetPunch(PunchType.PUNCH_IN, _
                                         LastSunday.AddDays(5), colTimePunchs)
      LastWeek.FridayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                         LastSunday.AddDays(5), colTimePunchs)
      LastWeek.SaturdayStart = GetPunch(PunchType.PUNCH_IN, _
                                         LastSunday.AddDays(6), colTimePunchs)
      LastWeek.SaturdayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                         LastSunday.AddDays(6), colTimePunchs)

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
      ThisWeek.SundayStart = GetPunch(PunchType.PUNCH_IN, _
                                        ThisSunday, colTimePunchs)
      ThisWeek.SundayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                        ThisSunday, colTimePunchs)
      ThisWeek.MondayStart = GetPunch(PunchType.PUNCH_IN, _
                                        ThisSunday.AddDays(1), colTimePunchs)
      ThisWeek.MondayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                        ThisSunday.AddDays(1), colTimePunchs)
      ThisWeek.TuesdayStart = GetPunch(PunchType.PUNCH_IN, _
                                        ThisSunday.AddDays(2), colTimePunchs)
      ThisWeek.TuesdayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                        ThisSunday.AddDays(2), colTimePunchs)
      ThisWeek.WednesdayStart = GetPunch(PunchType.PUNCH_IN, _
                                        ThisSunday.AddDays(3), colTimePunchs)
      ThisWeek.WednesdayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                        ThisSunday.AddDays(3), colTimePunchs)
      ThisWeek.ThursdayStart = GetPunch(PunchType.PUNCH_IN, _
                                        ThisSunday.AddDays(4), colTimePunchs)
      ThisWeek.ThursdayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                        ThisSunday.AddDays(4), colTimePunchs)
      ThisWeek.FridayStart = GetPunch(PunchType.PUNCH_IN, _
                                        ThisSunday.AddDays(5), colTimePunchs)
      ThisWeek.FridayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                        ThisSunday.AddDays(5), colTimePunchs)
      ThisWeek.SaturdayStart = GetPunch(PunchType.PUNCH_IN, _
                                        ThisSunday.AddDays(6), colTimePunchs)
      ThisWeek.SaturdayEnd = GetPunch(PunchType.PUNCH_OUT, _
                                        ThisSunday.AddDays(6), colTimePunchs)

      MyPunches.Add(ThisWeek)
    End Sub


    'This method will troll the collection looking for the earliest punch 
    'of the day if the punch type is punch_in. It will look for the latest 
    'punch of the day if the punch type is punch_out.
    Private Function GetPunch(ByVal pt As PunchType, ByVal dt As DateTime, _
                              ByVal TimePunchs As List(Of TimePunchInfo)) _
                                                                As DateTime
      Dim BaseTime As DateTime = DateTime.MaxValue
      Dim found As Boolean = False

      'Set to min or max if punch in or out
      If (pt = PunchType.PUNCH_IN) Then
        BaseTime = DateTime.MaxValue
      Else
        BaseTime = DateTime.MinValue
      End If

      For Each tpi As TimePunchInfo In TimePunchs
        If (CType(tpi.Punch_Type, PunchType) = pt) Then
          If (dt.ToShortDateString() = tpi.Punch_Date.ToShortDateString()) Then
            found = True
            If (pt = PunchType.PUNCH_IN And tpi.Punch_Date <= BaseTime) Then
              BaseTime = tpi.Punch_Date
            End If

            If (pt = PunchType.PUNCH_OUT And tpi.Punch_Date >= BaseTime) Then
              BaseTime = tpi.Punch_Date
            End If
          End If
        End If
      Next

      If (found) Then
        Return BaseTime
      Else
        Return DateTime.MinValue
      End If
    End Function

    Public ReadOnly Property PunchArray() As ArrayList
      Get
        Return MyPunches
      End Get
    End Property


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' gets an object from the database
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <param name="moduleId">The Id of the module</param>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetTimePunchs(ByVal ModuleId As Integer, _
                                  ByVal PunchUserID As Integer) _
                                              As List(Of TimePunchInfo)

      Return CBO.FillCollection(Of TimePunchInfo)(DataProvider.Instance(). _
                                                  GetTimePunchs(ModuleId, _
                                                  PunchUserID))

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' gets an object from the database
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <param name="ModuleId">The Id of the module</param>
    ''' <param name="ItemId">The Id of the item</param>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetTimePunch(ByVal ModuleId As Integer, _
                                 ByVal ItemId As Integer) _
                                                   As TimePunchInfo

      Return CType(CBO.FillObject(DataProvider.Instance(). _
                                  GetTimePunch(ModuleId, _
                                  ItemId), _
                                  GetType(TimePunchInfo)), TimePunchInfo)

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' adds an object to the database
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <param name="objTimePunch">The TimePunchInfo object</param>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub AddTimePunch(ByVal objTimePunch As TimePunchInfo)

      DataProvider.Instance().AddTimePunch(objTimePunch.ModuleId, _
                                             objTimePunch.Punch_Type, _
                                             objTimePunch.Punch_User)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' saves an object to the database
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <param name="objTimePunch">The TimePunchInfo object</param>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub UpdateTimePunch(ByVal objTimePunch As TimePunchInfo)

      DataProvider.Instance().UpdateTimePunch(objTimePunch.ModuleId, _
                                              objTimePunch.ItemId, _
                                              objTimePunch.Punch_User, _
                                              objTimePunch.Punch_Type, _
                                              objTimePunch.Punch_Date)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' deletes an object from the database
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <param name="ModuleId">The Id of the module</param>
    ''' <param name="ItemId">The Id of the item</param>
    ''' <history>
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub DeleteTimePunch(ByVal ModuleId As Integer, _
                               ByVal ItemId As Integer)

      DataProvider.Instance().DeleteTimePunch(ModuleId, ItemId)

    End Sub

#End Region

  End Class
End Namespace
