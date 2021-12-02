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
   StartUpPosition =   3  '´°¿ÚÈ±Ê¡
   WindowState     =   2  'Maximized
   Begin VB.CommandButton Command1 
      Caption         =   "X"
      Height          =   255
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   375
   End
   Begin VB.Timer Timer13 
      Interval        =   1300
      Left            =   4080
      Top             =   2280
   End
   Begin VB.Timer Timer12 
      Interval        =   1200
      Left            =   3360
      Top             =   2280
   End
   Begin VB.Timer Timer11 
      Interval        =   1100
      Left            =   2520
      Top             =   2040
   End
   Begin VB.Timer Timer10 
      Interval        =   1000
      Left            =   1440
      Top             =   2160
   End
   Begin VB.Timer Timer9 
      Interval        =   900
      Left            =   480
      Top             =   1920
   End
   Begin VB.Timer Timer8 
      Interval        =   800
      Left            =   3240
      Top             =   1320
   End
   Begin VB.Timer Timer7 
      Interval        =   700
      Left            =   2400
      Top             =   1320
   End
   Begin VB.Timer Timer6 
      Interval        =   600
      Left            =   1560
      Top             =   1320
   End
   Begin VB.Timer Timer5 
      Interval        =   500
      Left            =   600
      Top             =   1080
   End
   Begin VB.Timer Timer4 
      Interval        =   400
      Left            =   3000
      Top             =   360
   End
   Begin VB.Timer Timer3 
      Interval        =   300
      Left            =   2160
      Top             =   240
   End
   Begin VB.Timer Timer2 
      Interval        =   200
      Left            =   1080
      Top             =   360
   End
   Begin VB.Timer Timer1 
      Interval        =   100
      Left            =   360
      Top             =   240
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
End

End Sub

Private Sub Timer1_Timer()
Form1.BackColor = RGB(0, 255, 0)
End Sub

Private Sub Timer10_Timer()
Form1.BackColor = RGB(100, 65, 11)
End Sub

Private Sub Timer11_Timer()
Form1.BackColor = RGB(123, 99, 244)
End Sub

Private Sub Timer12_Timer()
Form1.BackColor = RGB(88, 96, 255)
End Sub

Private Sub Timer13_Timer()
Form1.BackColor = RGB(2, 255, 39)
End Sub

Private Sub Timer2_Timer()
Form1.BackColor = RGB(0, 255, 0)
End Sub

Private Sub Timer3_Timer()
Form1.BackColor = RGB(255, 0, 0)
End Sub

Private Sub Timer4_Timer()
Form1.BackColor = RGB(255, 100, 200)
End Sub

Private Sub Timer5_Timer()
Form1.BackColor = RGB(100, 200, 255)
End Sub

Private Sub Timer6_Timer()
Form1.BackColor = RGB(20, 66, 199)
End Sub

Private Sub Timer7_Timer()
Form1.BackColor = RGB(246, 78, 200)
End Sub

Private Sub Timer8_Timer()
Form1.BackColor = RGB(211, 166, 23)
End Sub

Private Sub Timer9_Timer()
Form1.BackColor = RGB(55, 66, 77)
End Sub
