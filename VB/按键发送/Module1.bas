Attribute VB_Name = "Module1"
Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)



Sub Main()


For i = 1 To 10
Do
Dim myKey As Object
    Set myKey = CreateObject("WScript.Shell")
    myKey.SendKeys "{scrolllock}"
    Sleep 100
    myKey.SendKeys "{capslock}"
    Sleep 100
    myKey.SendKeys "{NumLock}"
    Sleep 100
    DoEvents
    Loop
Next i
    
End Sub
