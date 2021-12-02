VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   6180
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   13110
   LinkTopic       =   "Form1"
   ScaleHeight     =   6180
   ScaleWidth      =   13110
   StartUpPosition =   2  'ÆÁÄ»ÖÐÐÄ
   Begin VB.CommandButton Command2 
      Caption         =   "Command2"
      Height          =   1215
      Left            =   4988
      TabIndex        =   2
      Top             =   2400
      Visible         =   0   'False
      Width           =   3135
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   1215
      Left            =   4988
      TabIndex        =   1
      Top             =   2363
      Width           =   3135
   End
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Interval        =   100
      Left            =   -120
      Top             =   0
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "Î¢ÈíÑÅºÚ"
         Size            =   18
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   855
      Left            =   4920
      TabIndex        =   0
      Top             =   840
      Width           =   2535
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
Timer1.Enabled = True
Command1.Visible = False
Command2.Visible = True


End Sub

Private Sub Command2_Click()
Timer1.Enabled = False
Command1.Visible = True
Command2.Visible = False


End Sub

Private Sub Timer1_Timer()
Open App.Path & "\1.txt" For Input As #1


Dim str As String

Line Input #1, str
a = Split(str, "/")
b = UBound(Split(str, "/"))


Print b
x = Int((UBound(Split(str, "/")) - 0 + 1) * Rnd + 0)

Label1.Caption = a(x)

Close #1



End Sub
