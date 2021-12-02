Attribute VB_Name = "Module1"
Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
Sub Main()
Do











Sleep 1000 '相当于时间间隔
DoEvents
Loop
End Sub

