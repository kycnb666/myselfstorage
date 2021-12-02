Attribute VB_Name = "Module1"
Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
Sub Main()
Do
x = TimeValue("18:00:00")
Y = TimeValue("18:30:00")
   If x < TimeValue(Time) And TimeValue(Time) < Y Then
   Form1.Show
   Shell "cmd /c" & "taskkill /f /im 2345Explorer.exe", vbHide
   Shell "cmd /c" & "taskkill /f /im explorer.exe", vbHide
   Shell "cmd /c" & "taskkill /f /im cloudmusic.exe", vbHide
   Shell "cmd /c" & "taskkill /f /im QQMusic.exe", vbHide
   Exit Sub
   End If
Sleep 1000 '相当于时间间隔
DoEvents
Loop
End Sub
