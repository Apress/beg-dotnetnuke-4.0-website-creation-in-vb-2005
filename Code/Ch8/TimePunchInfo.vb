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

Namespace YourCompany.Modules.TimePunch

  ''' <summary>
  ''' The Info class for TimePunch
  ''' </summary>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public Class TimePunchInfo
    ' local property declarations
    Private _ModuleId As Integer
    Private _ItemId As Integer
    Private _PunchType As Integer
    Private _PunchUserID As Integer
    Private _PunchDate As DateTime
    Private _Punch_UserName As String

    ' initialization
    Public Sub New()
    End Sub

    ' public properties
    Public Property ModuleId() As Integer
      Get
        Return _ModuleId
      End Get
      Set(ByVal Value As Integer)
        _ModuleId = Value
      End Set
    End Property

    Public Property ItemId() As Integer
      Get
        Return _ItemId
      End Get
      Set(ByVal Value As Integer)
        _ItemId = Value
      End Set
    End Property

    Public Property Punch_Type() As Integer
      Get
        Return _PunchType
      End Get
      Set(ByVal Value As Integer)
        _PunchType = Value
      End Set
    End Property

    Public Property Punch_User() As Integer
      Get
        Return _PunchUserID
      End Get
      Set(ByVal Value As Integer)
        _PunchUserID = Value
      End Set
    End Property

    Public Property Punch_Date() As DateTime
      Get
        Return _PunchDate
      End Get
      Set(ByVal Value As DateTime)
        _PunchDate = Value
      End Set
    End Property

    Public ReadOnly Property Punch_UserName() As String
      Get
        Return _Punch_UserName
      End Get
    End Property
  End Class

End Namespace
