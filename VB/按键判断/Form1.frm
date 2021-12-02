VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   0  'None
   Caption         =   "Form1"
   ClientHeight    =   3015
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   4560
   LinkTopic       =   "Form1"
   ScaleHeight     =   3015
   ScaleWidth      =   4560
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  'ÆÁÄ»ÖÐÐÄ
   WindowState     =   2  'Maximized
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_KeyPress(KeyAscii As Integer)
If KeyAscii = 97 Then
Form1.BackColor = RGB(0, 0, 255)
ElseIf KeyAscii = 65 Then
Form1.BackColor = RGB(0, 255, 0)
ElseIf KeyAscii = 98 Then
Form1.BackColor = RGB(255, 0, 0)
ElseIf KeyAscii = 99 Then
Form1.BackColor = RGB(10, 55, 0)
ElseIf KeyAscii = 100 Then
Form1.BackColor = RGB(110, 25, 0)
ElseIf KeyAscii = 101 Then
Form1.BackColor = RGB(0, 55, 50)
ElseIf KeyAscii = 102 Then
Form1.BackColor = RGB(99, 225, 0)
ElseIf KeyAscii = 103 Then
Form1.BackColor = RGB(99, 111, 69)
ElseIf KeyAscii = 104 Then
Form1.BackColor = RGB(80, 5, 66)
ElseIf KeyAscii = 105 Then
Form1.BackColor = RGB(109, 25, 20)
ElseIf KeyAscii = 106 Then
Form1.BackColor = RGB(80, 5, 110)
ElseIf KeyAscii = 107 Then
Form1.BackColor = RGB(88, 215, 50)
ElseIf KeyAscii = 108 Then
Form1.BackColor = RGB(169, 25, 33)
ElseIf KeyAscii = 109 Then
Form1.BackColor = RGB(5, 5, 40)
ElseIf KeyAscii = 110 Then
Form1.BackColor = RGB(66, 26, 99)
ElseIf KeyAscii = 111 Then
Form1.BackColor = RGB(0, 25, 255)
ElseIf KeyAscii = 112 Then
Form1.BackColor = RGB(77, 0, 50)
ElseIf KeyAscii = 113 Then
Form1.BackColor = RGB(88, 0, 222)
ElseIf KeyAscii = 114 Then
Form1.BackColor = RGB(1, 5, 220)
ElseIf KeyAscii = 115 Then
Form1.BackColor = RGB(55, 5, 20)
ElseIf KeyAscii = 116 Then
Form1.BackColor = RGB(99, 5, 220)
ElseIf KeyAscii = 117 Then
Form1.BackColor = RGB(195, 2, 111)
ElseIf KeyAscii = 118 Then
Form1.BackColor = RGB(98, 155, 60)
ElseIf KeyAscii = 119 Then
Form1.BackColor = RGB(0, 25, 202)
ElseIf KeyAscii = 120 Then
Form1.BackColor = RGB(111, 2, 90)
ElseIf KeyAscii = 121 Then
Form1.BackColor = RGB(40, 205, 123)
ElseIf KeyAscii = 122 Then
Form1.BackColor = RGB(88, 145, 189)
ElseIf KeyAscii = 123 Then
Form1.BackColor = RGB(100, 255, 163)
ElseIf KeyAscii = 124 Then
Form1.BackColor = RGB(89, 55, 167)
ElseIf KeyAscii = 27 Then
End







End If

End Sub

