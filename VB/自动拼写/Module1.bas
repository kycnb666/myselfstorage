Attribute VB_Name = "Module1"
Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)





Sub Main()
Dim wd As Object
Set wd = CreateObject("wscript.shell")
Sleep 1000
Shell "cmd /c" & "start notepad.exe", vbHide

Sleep 1000
wd.SendKeys "{F}"
Sleep 500
wd.SendKeys "{U}"
Sleep 500
wd.SendKeys "{C}"
Sleep 500
wd.SendKeys "{K}"
Sleep 500
wd.SendKeys "{enter}"
Sleep 500
wd.SendKeys "{c}"
Sleep 500
wd.SendKeys "{a}"
Sleep 500
wd.SendKeys "{o}"
Sleep 500
wd.SendKeys "{n}"
Sleep 500
wd.SendKeys "{i}"
Sleep 500
wd.SendKeys "{m}"
Sleep 500
wd.SendKeys "{a}"
Sleep 500
wd.SendKeys "{1}"
Sleep 1000
wd.SendKeys "%{f4}"
Sleep 1000
wd.SendKeys "{s}"
Sleep 2000





wd.SendKeys "{h}"
Sleep 500
wd.SendKeys "{tab}"
Sleep 500
wd.SendKeys "{down}"
Sleep 500
wd.SendKeys "{enter}"
Sleep 500
wd.SendKeys "{enter}"
Sleep 500













End Sub
