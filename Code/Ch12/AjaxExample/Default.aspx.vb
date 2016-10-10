
Partial Class _Default
  Inherits System.Web.UI.Page
  Implements ICallbackEventHandler

  Public CallbackStr As String
  Public CallBackReturnVal As String

  Protected Sub Page_Load(ByVal sender As Object, _
                              ByVal e As System.EventArgs) Handles Me.Load
    'This bit o' code gets translated and loaded into the client script
    CallbackStr = ClientScript.GetCallbackEventReference(Me, _
                                                     "arg", _
                                                     "CallbackResult", _
                                                     "OnBeforeCallback", _
                                                     "onError", _
                                                     False)

  End Sub

#Region "callback functions"

  'This function is required to handle the callback from the web page
  'It is invoked when the browser makes an Ajax request to the server
  Public Sub RaiseCallbackEvent(ByVal eventArgument As String) Implements _
            System.Web.UI.ICallbackEventHandler.RaiseCallbackEvent
    For k As Integer = 0 To 20
      CallBackReturnVal += "option" + k.ToString() + "|"
    Next
  End Sub

  'This function actually gives back the answer
  Public Function GetCallbackResult() As String Implements _
            System.Web.UI.ICallbackEventHandler.GetCallbackResult
    Return CallBackReturnVal
  End Function

#End Region

End Class
