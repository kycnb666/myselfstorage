VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3015
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   4560
   LinkTopic       =   "Form1"
   ScaleHeight     =   3015
   ScaleWidth      =   4560
   StartUpPosition =   3  '´°¿ÚÈ±Ê¡
   Begin VB.CommandButton Command1 
      Caption         =   "µã"
      Height          =   1215
      Left            =   480
      TabIndex        =   0
      Top             =   840
      Width           =   3615
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False



Private Sub Command1_Click()
Dim myKey As Object
    Set myKey = CreateObject("WScript.Shell")
    myKey.SendKeys "%{f4}"
    myKey.SendKeys "^+{esc}"
End Sub

Private Sub Form_Unload(Cancel As Integer)
End

End Sub
