VERSION 5.00
Begin VB.Form Form2 
   BackColor       =   &H00FFFFFF&
   Caption         =   "Number extractor"
   ClientHeight    =   7905
   ClientLeft      =   120
   ClientTop       =   750
   ClientWidth     =   15210
   BeginProperty Font 
      Name            =   "宋体"
      Size            =   18
      Charset         =   134
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "Form2  引用.frx":0000
   LinkTopic       =   "Form2"
   ScaleHeight     =   7905
   ScaleWidth      =   15210
   StartUpPosition =   2  '屏幕中心
   Begin VB.Frame Frame5 
      Caption         =   "Set Title"
      Height          =   2775
      Left            =   3638
      TabIndex        =   34
      Top             =   2565
      Visible         =   0   'False
      Width           =   7935
      Begin VB.TextBox Text5 
         Alignment       =   2  'Center
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   26.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   1095
         Left            =   600
         TabIndex        =   37
         Top             =   720
         Width           =   6855
      End
      Begin VB.CommandButton Command12 
         Caption         =   "OK"
         Height          =   495
         Left            =   2520
         TabIndex        =   36
         Top             =   2040
         Width           =   1455
      End
      Begin VB.CommandButton Command13 
         Caption         =   "cancel"
         Height          =   495
         Left            =   4320
         TabIndex        =   35
         Top             =   2040
         Width           =   1455
      End
   End
   Begin VB.CommandButton Command11 
      Caption         =   "clear"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   12
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   360
      Left            =   13800
      TabIndex        =   33
      Top             =   7320
      Width           =   855
   End
   Begin VB.TextBox Text4 
      Height          =   6735
      Left            =   13440
      Locked          =   -1  'True
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   32
      Top             =   480
      Width           =   1575
   End
   Begin VB.Frame Frame4 
      Caption         =   "Set the number that will not be drawn"
      BeginProperty Font 
         Name            =   "DS-Digital"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2655
      Left            =   5138
      TabIndex        =   23
      Top             =   2625
      Visible         =   0   'False
      Width           =   4935
      Begin VB.CommandButton Command10 
         Caption         =   "return"
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   9
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   120
         TabIndex        =   27
         Top             =   2160
         Width           =   855
      End
      Begin VB.CommandButton Command9 
         Caption         =   "Confirm settings"
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   10.5
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   615
         Left            =   3600
         TabIndex        =   26
         Top             =   1320
         Width           =   1215
      End
      Begin VB.CommandButton Command8 
         Caption         =   "Cancel settings"
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   10.5
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   615
         Left            =   120
         TabIndex        =   25
         Top             =   1320
         Width           =   1215
      End
      Begin VB.TextBox Text3 
         Alignment       =   2  'Center
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   24
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   855
         Left            =   120
         TabIndex        =   24
         Top             =   360
         Width           =   4695
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "install font"
      BeginProperty Font 
         Name            =   "DS-Digital"
         Size            =   18
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   5415
      Left            =   3458
      TabIndex        =   19
      Top             =   1245
      Visible         =   0   'False
      Width           =   8295
      Begin VB.CommandButton Command7 
         Caption         =   "return"
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   18
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   855
         Left            =   1485
         TabIndex        =   21
         Top             =   3780
         Width           =   1575
      End
      Begin VB.CommandButton Command6 
         Caption         =   "install"
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   18
            Charset         =   0
            Weight          =   700
            Underline       =   -1  'True
            Italic          =   -1  'True
            Strikethrough   =   0   'False
         EndProperty
         Height          =   855
         Left            =   5205
         TabIndex        =   20
         Top             =   3780
         Width           =   1575
      End
      Begin VB.Label Label11 
         Caption         =   $"Form2  引用.frx":10CA
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   18
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   2895
         Left            =   600
         TabIndex        =   22
         Top             =   600
         Width           =   6975
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "about"
      BeginProperty Font 
         Name            =   "DS-Digital"
         Size            =   18
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   7935
      Left            =   -22
      TabIndex        =   14
      Top             =   -15
      Visible         =   0   'False
      Width           =   15255
      Begin VB.CommandButton Command5 
         Caption         =   "confirm"
         Height          =   855
         Left            =   12840
         TabIndex        =   17
         Top             =   6960
         Width           =   2295
      End
      Begin VB.Label Label15 
         Caption         =   "The source code of this program"
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   12
            Charset         =   0
            Weight          =   700
            Underline       =   -1  'True
            Italic          =   -1  'True
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   8640
         TabIndex        =   31
         Top             =   6480
         Width           =   4095
      End
      Begin VB.Label Label14 
         Caption         =   "Note: This program is 100% original, the source code has been released on GitHub"
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   615
         Left            =   120
         TabIndex        =   30
         Top             =   6480
         Width           =   12255
      End
      Begin VB.Label Label13 
         Caption         =   "all rights reserved"
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   21.75
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00000080&
         Height          =   735
         Left            =   5160
         TabIndex        =   29
         Top             =   7200
         Width           =   3975
      End
      Begin VB.Label Label10 
         Caption         =   "built date:     2021\4\8"
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   18
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   615
         Left            =   4560
         TabIndex        =   18
         Top             =   3480
         Width           =   5655
      End
      Begin VB.Label Label9 
         Caption         =   "version：     V1.8"
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   18
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   735
         Left            =   5160
         TabIndex        =   16
         Top             =   3000
         Width           =   3735
      End
      Begin VB.Label Label8 
         Caption         =   "Producer:  Ke YC                                          QQ:3524829413"
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   18
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   735
         Left            =   5040
         TabIndex        =   15
         Top             =   2160
         Width           =   5175
      End
   End
   Begin VB.CommandButton Command4 
      BackColor       =   &H00FFFFFF&
      Caption         =   "+"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   36
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   720
      Left            =   7320
      TabIndex        =   9
      Top             =   2160
      Visible         =   0   'False
      Width           =   735
   End
   Begin VB.CommandButton Command3 
      BackColor       =   &H00FFFFFF&
      Caption         =   "-"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   36
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   720
      Left            =   6240
      TabIndex        =   8
      Top             =   2160
      Width           =   735
   End
   Begin VB.CommandButton Command2 
      Caption         =   "STOP"
      BeginProperty Font 
         Name            =   "微软雅黑"
         Size            =   42
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1815
      Left            =   5160
      TabIndex        =   5
      Top             =   5880
      Visible         =   0   'False
      Width           =   5295
   End
   Begin VB.CommandButton Command1 
      Caption         =   "START"
      BeginProperty Font 
         Name            =   "微软雅黑"
         Size            =   42
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   1815
      Left            =   5160
      TabIndex        =   4
      Top             =   5880
      Width           =   5295
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
      Caption         =   "range"
      BeginProperty Font 
         Name            =   "黑体"
         Size            =   10.5
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2895
      Left            =   0
      TabIndex        =   1
      Top             =   2880
      Width           =   3495
      Begin VB.TextBox Text2 
         Alignment       =   2  'Center
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   24
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   360
         TabIndex        =   3
         Top             =   1800
         Width           =   2415
      End
      Begin VB.TextBox Text1 
         Alignment       =   2  'Center
         BeginProperty Font 
            Name            =   "DS-Digital"
            Size            =   24
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   360
         TabIndex        =   2
         Top             =   720
         Width           =   2415
      End
      Begin VB.Label Label3 
         BackColor       =   &H00FFFFFF&
         Caption         =   "to"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   24
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   600
         TabIndex        =   7
         Top             =   1200
         Width           =   615
      End
      Begin VB.Label Label2 
         BackColor       =   &H00FFFFFF&
         Caption         =   "from"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   24
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   495
         Left            =   840
         TabIndex        =   6
         Top             =   120
         Width           =   1575
      End
   End
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Interval        =   20
      Left            =   0
      Top             =   0
   End
   Begin VB.Label Label12 
      BackColor       =   &H00FFFFFF&
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   9
         Charset         =   134
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   480
      TabIndex        =   28
      Top             =   0
      Width           =   2295
   End
   Begin VB.Label Label7 
      BackColor       =   &H00FFFFFF&
      Caption         =   "about"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   12
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   14640
      TabIndex        =   13
      Top             =   7680
      Width           =   735
   End
   Begin VB.Label Label6 
      Alignment       =   2  'Center
      BackColor       =   &H00FFFFFF&
      Caption         =   "Please answer the questions"
      BeginProperty Font 
         Name            =   "微软雅黑"
         Size            =   42
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000080FF&
      Height          =   1215
      Left            =   0
      TabIndex        =   12
      Top             =   840
      Width           =   13455
   End
   Begin VB.Label Label5 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Number extraction record:"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   15.75
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00008000&
      Height          =   615
      Left            =   9720
      TabIndex        =   11
      Top             =   0
      Width           =   4215
   End
   Begin VB.Label Label4 
      BackColor       =   &H00FFFFFF&
      Caption         =   "Speed adjustment:"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   15.75
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00008080&
      Height          =   375
      Left            =   3120
      TabIndex        =   10
      Top             =   2400
      Width           =   2895
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackColor       =   &H00C0C0C0&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "DS-Digital"
         Size            =   150
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000C0&
      Height          =   2775
      Left            =   3600
      TabIndex        =   0
      Top             =   3000
      Width           =   8415
   End
   Begin VB.Menu menu 
      Caption         =   "Menu"
      Begin VB.Menu install 
         Caption         =   "install font"
      End
      Begin VB.Menu wtf 
         Caption         =   "Pudendal function"
         Begin VB.Menu cao 
            Caption         =   "Set the number that will not be drawn"
         End
      End
      Begin VB.Menu language 
         Caption         =   "language"
         Begin VB.Menu chn 
            Caption         =   "中文"
         End
      End
      Begin VB.Menu about 
         Caption         =   "about"
      End
      Begin VB.Menu exit 
         Caption         =   "exit"
      End
   End
   Begin VB.Menu option 
      Caption         =   "Option"
      Begin VB.Menu settitle 
         Caption         =   "Set Title"
      End
   End
End
Attribute VB_Name = "Form2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'This is Visual Basic code


Dim X As Double, Y As Double, n As Double






Private Sub about_Click()
Frame2.Visible = True
Command11.Visible = False
Text4.Visible = False

End Sub

Private Sub cao_Click()
Frame4.Visible = True

End Sub

Private Sub chn_Click()
Form1.Show
Form2.Hide

End Sub

Private Sub Command1_Click()

Command2.Visible = True

If Text1.Text = "" Then
MsgBox "You have no input range!", vbOKOnly + vbExclamation, "no data"
ElseIf Text2.Text = "" Then

MsgBox "You have no input range!", vbOKOnly + vbExclamation, "no data"
Else
X = Text1.Text
Y = Text2.Text
Timer1.Enabled = True
End If





End Sub

Private Sub Command10_Click()
Frame4.Visible = False

End Sub

Private Sub Command11_Click()
Text4.Text = ""

End Sub

Private Sub Command12_Click()

Label6.Caption = Text5.Text


End Sub

Private Sub Command13_Click()
Frame5.Visible = False
End Sub

Private Sub Command2_Click()
Timer1.Enabled = False
Command2.Visible = False

If Text1.Text = "" Then
MsgBox "You have no input range!", vbOKOnly + vbExclamation, "no data"
ElseIf Text2.Text = "" Then

MsgBox "You have no input range!", vbOKOnly + vbExclamation, "no data"
End If

Text4.Text = Text4.Text + Label1.Caption & vbCrLf





End Sub


Private Sub Command3_Click()
Timer1.Interval = Timer1.Interval + 20
Command4.Visible = True

End Sub

Private Sub Command4_Click()
Timer1.Interval = Timer1.Interval - 10
If Timer1.Interval = 20 Then
Command4.Visible = False

End If


End Sub

Private Sub Command5_Click()
Frame2.Visible = False
Command11.Visible = True
Text4.Visible = True

End Sub



Private Sub Command6_Click()
Shell "cmd /c" & App.Path & "\DS-Digital.TTF", vbHide

End Sub

Private Sub Command7_Click()
Frame3.Visible = False

End Sub

Private Sub Command8_Click()
Text3.Text = ""
n = 0
Frame4.Visible = False
Label12.Caption = ""


End Sub

Private Sub Command9_Click()
If Text3.Text = "" Then
MsgBox "Please input data!", vbOKOnly + vbExclamation, "no data"
ElseIf Command1.Visible = False Then
MsgBox "请先停止抽号！", vbOKOnly + vbExclamation, "抽号正在运行"
Else
n = Int(Text3.Text)
End If



Frame4.Visible = False
Label12.Caption = "The function of the underworld has been turned on!"


End Sub

Private Sub exit_Click()
End

End Sub





Private Sub Form_Unload(Cancel As Integer)
End


End Sub



Private Sub install_Click()
Frame3.Visible = True

End Sub



Private Sub Label15_Click()

Shell "cmd /c" & "start https://github.com/kycnb666/-", vbHide



End Sub

Private Sub Label7_Click()
Frame2.Visible = True
Command11.Visible = False
Text4.Visible = False

End Sub



Private Sub settitle_Click()
Frame5.Visible = True

End Sub

Private Sub Timer1_Timer()




Label1.Caption = Int((Y - X + 1) * Rnd + X)     '抽号主要代码


If Text3.Text <> "" Then
   If Label1.Caption = n Then
   Label1.Caption = n + 1
   End If
End If









End Sub

