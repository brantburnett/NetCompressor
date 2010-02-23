Imports System.IO
Imports System.Text.RegularExpressions

Public NotInheritable Class Helper

    Private Sub New()
        Throw New NotImplementedException()
    End Sub

    Private Shared _javaPath As String

    Public Shared Function GetJavaPath() As String
        If _javaPath IsNot Nothing Then
            Return _javaPath
        End If

        Dim windows As String = System.Environment.GetFolderPath(Environment.SpecialFolder.System)
        Dim java As String = Path.Combine(windows, "java.exe")

        If File.Exists(java) Then
            _javaPath = java
            Return java
        End If

        java = Path.Combine(windows, "..\SysWOW64\java.exe")
        If File.Exists(java) Then
            _javaPath = java
            Return java
        End If

        Throw New ApplicationException("Cannot Find Java.exe In Windows System Folders")
    End Function

    Private Shared _normalizeRegex As New Regex("\r?\n")
    Public Shared Function NormalizeLines(ByVal str As String) As String
        Return _normalizeRegex.Replace(str, vbCrLf)
    End Function

End Class
