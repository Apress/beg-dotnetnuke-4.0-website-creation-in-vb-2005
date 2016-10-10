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
Imports DotNetNuke

Namespace YourCompany.Modules.TimePunch

  ''' -----------------------------------------------------------------------------
  ''' <summary>
  ''' An abstract class for the data access layer
  ''' </summary>
  ''' <remarks>
  ''' </remarks>
  ''' <history>
  ''' </history>
  ''' -----------------------------------------------------------------------------
  Public MustInherit Class DataProvider

#Region "Shared/Static Methods"

    ' singleton reference to the instantiated object 
    Private Shared objProvider As DataProvider = Nothing

    ' constructor
    Shared Sub New()
      CreateProvider()
    End Sub

    ' dynamically create provider
    Private Shared Sub CreateProvider()
      objProvider = CType(Framework.Reflection.CreateObject("data", "YourCompany.Modules.TimePunch", ""), DataProvider)
    End Sub

    ' return the provider
    Public Shared Shadows Function Instance() As DataProvider
      Return objProvider
    End Function

#End Region

#Region "Abstract methods"

    Public MustOverride Function GetTimePunchs(ByVal ModuleId As Integer, _
                                               ByVal PunchUserID As Integer) _
                                                              As IDataReader
    Public MustOverride Function GetTimePunch(ByVal ModuleId As Integer, _
                                              ByVal ItemId As Integer) _
                                                              As IDataReader
    Public MustOverride Sub AddTimePunch(ByVal ModuleId As Integer, _
                                         ByVal PunchType As Integer, _
                                         ByVal PunchUserID As Integer)
    Public MustOverride Sub UpdateTimePunch(ByVal ModuleId As Integer, _
                                            ByVal ItemId As Integer, _
                                            ByVal PunchUser As Integer, _
                                            ByVal PunchType As Integer, _
                                            ByVal PunchDate As DateTime)
    Public MustOverride Sub DeleteTimePunch(ByVal ModuleId As Integer, _
                                            ByVal ItemId As Integer)

#End Region

  End Class

End Namespace