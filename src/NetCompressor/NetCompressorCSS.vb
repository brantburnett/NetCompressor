Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports Microsoft.Win32

Imports Microsoft.VisualStudio.TextTemplating.VSHost

<Guid("E5D686A7-BDA1-4c76-848D-553DAC4B579D")> _
<ComVisible(True)> _
Public Class NetCompressorCSS
    Implements IVsSingleFileGenerator

    Public Sub Generate(ByVal inputFilePath As String, ByVal inputFileContents As String, ByVal defaultNamespace As String, ByRef outputFileContents As System.IntPtr, ByRef output As Integer, ByVal generateProgress As Microsoft.VisualStudio.TextTemplating.VSHost.IVsGeneratorProgress) Implements Microsoft.VisualStudio.TextTemplating.VSHost.IVsSingleFileGenerator.Generate
        Dim outputArray() As Byte = CompressYUI(inputFilePath)

        If outputArray Is Nothing Then
            outputArray = Encoding.UTF8.GetBytes(inputFileContents)
        End If

        output = outputArray.Length
        outputFileContents = Marshal.AllocCoTaskMem(output)
        Marshal.Copy(outputArray, 0, outputFileContents, output)
    End Sub

    Private Function CompressYUI(ByVal inputFilePath As String) As Byte()
        Try
            Dim jar As String = Path.Combine(Path.GetDirectoryName(Me.GetType().Assembly.Location), "yuicompressor-2.4.2.jar")

            Dim psi As New ProcessStartInfo(Helper.GetJavaPath(), _
                                            String.Format("-jar ""{0}"" --charset utf8 -v ""{1}""", jar, inputFilePath))
            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.RedirectStandardError = True
            psi.CreateNoWindow = True

            Using proc As Process = Process.Start(psi)
                Dim stdError As New OutputThread(proc.StandardError)
                Dim stdOut As New OutputThread(proc.StandardOutput)

                If Not proc.WaitForExit(30000) Then
                    proc.Kill()
                    Throw New ApplicationException("Timeout Exceeded")
                    Return Nothing
                End If

                If proc.ExitCode <> 0 Then
                    Throw New ApplicationException(stdError.Result)
                End If

                Return Encoding.UTF8.GetBytes(Helper.NormalizeLines(stdOut.Result))
            End Using
        Catch ex As Exception
            Throw New ApplicationException("Error Performing YUI Compression: " & ex.Message, ex)
        End Try
    End Function

    Public Function GetDefaultExtension() As String Implements IVsSingleFileGenerator.GetDefaultExtension
        Return ".min.css"
    End Function

End Class
