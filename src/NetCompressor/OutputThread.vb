Imports System.IO
Imports System.Text
Imports System.Threading

Public Class OutputThread

    Private _output As TextReader
    Private _thread As Thread

    Private _result As String
    Public ReadOnly Property Result() As String
        Get
            Return _result
        End Get
    End Property

    Public Sub New(ByVal output As TextReader)
        _output = output
        _thread = New Thread(AddressOf Execute)
        _thread.Start()
    End Sub

    Private Sub Execute()
        Try
            _result = _output.ReadToEnd()
        Catch
        End Try
    End Sub

End Class
