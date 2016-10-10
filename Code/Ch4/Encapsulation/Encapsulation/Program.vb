Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace Encapsulation

  Module Program

    Class DataHiding
      Private mPrivate_integer As Integer
      Private mPrivate_string As String

      Public mPublic_integer As Integer
      Public mPublic_string As String

      'This is a constructor.  It is used to initialize the object
      ' that is created from this class
      Public Sub New()
        mPrivate_integer = 1
        mPrivate_string = "one"
        mPublic_integer = 2
        mPublic_string = "two"
      End Sub

      'Accessor method to get and set the private integer
      Public Property Private_integer() As Integer
        Get
          Return mPrivate_integer
        End Get
        Set(ByVal value As Integer)
          mPrivate_integer = value
        End Set
      End Property

      Public Property Private_string() As String
        Get
          Return mPrivate_string
        End Get
        Set(ByVal value As String)
          mPrivate_string = value
        End Set
      End Property

    End Class


    Sub Main()
      'Create the new object fom the class
      Dim dh As DataHiding = New DataHiding()

      'get the public values
      Console.WriteLine(dh.mPublic_integer)
      Console.WriteLine(dh.mPublic_string)

      'get the private values via accessor methods
      Console.WriteLine(dh.Private_integer)
      Console.WriteLine(dh.Private_string)

    End Sub

  End Module

End Namespace

