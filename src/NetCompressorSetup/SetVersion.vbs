Const ForReading = 1
Const ForWriting = 2

versionStr = wscript.Arguments(0)

Set objFSO = CreateObject("Scripting.FileSystemObject")

' Update Version.wxi

Set objFile = objFSO.OpenTextFile("Version.wxi", ForReading)
strText = objFile.ReadAll
objFile.Close

Set regEx = New RegExp
regEx.IgnoreCase = true
regEx.Multiline = true
regEx.Global = true
regEx.Pattern = "<\?define Version=.*?>"
strText = regEx.Replace(strText, "<?define Version=" + versionStr + "?>")

Set objFile = objFSO.OpenTextFile("Version.wxi", ForWriting)
objFile.Write strText
objFile.Close

