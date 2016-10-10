Imports System.drawing

Partial Class _Default
  Inherits System.Web.UI.Page

  Protected Sub cmdEnter_Click(ByVal sender As Object, _
                          ByVal e As System.EventArgs) Handles cmdEnter.Click
    txtText.BackColor = Color.Red
    txtText.ForeColor = Color.White

  End Sub

  Protected Sub cmdChange_Click(ByVal sender As Object, _
                          ByVal e As System.EventArgs) Handles cmdChange.Click
    If cmdChange.Text = "This Text" Then
      cmdChange.Text = "The Other Text"
    Else
      cmdChange.Text = "This Text"
    End If


  End Sub

  Protected Sub rb1_CheckedChanged(ByVal sender As Object, _
                          ByVal e As System.EventArgs) Handles rb1.CheckedChanged
    'Clear the list then add item according to this radio button
    lstList.Items.Clear()
    lstList.Items.Add("First 1 rb")
    lstList.Items.Add("First 2 rb")
    lstList.Items.Add("First 3 rb")
    lstList.Items.Add("First 4 rb")
    lstList.Items.Add("First 5 rb")

  End Sub

  Protected Sub rb2_CheckedChanged(ByVal sender As Object, _
                           ByVal e As System.EventArgs) Handles rb2.CheckedChanged
    'Clear the list then add item according to this radio button
    lstList.Items.Clear()
    lstList.Items.Add("Second 1 rb")
    lstList.Items.Add("Second 2 rb")
    lstList.Items.Add("Second 3 rb")
    lstList.Items.Add("Second 4 rb")
    lstList.Items.Add("Second 5 rb")

  End Sub

End Class
