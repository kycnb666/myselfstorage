Attribute VB_Name = "Module1"
Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)


Sub main()
Do
If CheckExeIsRun("taskmgr.exe") Then
    Dim myKey As Object
    Set myKey = CreateObject("WScript.Shell")
    myKey.SendKeys "^+{esc}"
    Sleep 100
    myKey.SendKeys "%{f4}"

End If
Sleep 1000
DoEvents
Loop
End Sub
'�������Ƿ����У�exeName ������Ҫ���Ľ��� exe ���֣����� VB6.EXE
Private Function CheckExeIsRun(exeName As String) As Boolean
    On Error GoTo Err
    Dim WMI
    Dim Obj
    Dim Objs
    CheckExeIsRun = False
    Set WMI = GetObject("WinMgmts:")
    Set Objs = WMI.InstancesOf("Win32_Process")
    For Each Obj In Objs
      If (InStr(UCase(exeName), UCase(Obj.Description)) <> 0) Then
            CheckExeIsRun = True
            If Not Objs Is Nothing Then Set Objs = Nothing
            If Not WMI Is Nothing Then Set WMI = Nothing
            Exit Function
      End If
    Next
    If Not Objs Is Nothing Then Set Objs = Nothing
    If Not WMI Is Nothing Then Set WMI = Nothing
    Exit Function
Err:
    If Not Objs Is Nothing Then Set Objs = Nothing
    If Not WMI Is Nothing Then Set WMI = Nothing
End Function

