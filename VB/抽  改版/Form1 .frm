VERSION 5.00
Begin VB.Form Form1 
   BackColor       =   &H00FFFFFF&
   Caption         =   "抽取名字"
   ClientHeight    =   7935
   ClientLeft      =   120
   ClientTop       =   750
   ClientWidth     =   15240
   BeginProperty Font 
      Name            =   "宋体"
      Size            =   18
      Charset         =   134
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   Icon            =   "Form1 .frx":0000
   LinkTopic       =   "Form1"
   ScaleHeight     =   7935
   ScaleWidth      =   15240
   StartUpPosition =   2  '屏幕中心
   Begin VB.Frame Frame5 
      Caption         =   "设置标题"
      Height          =   2775
      Left            =   3653
      TabIndex        =   23
      Top             =   2580
      Visible         =   0   'False
      Width           =   7935
      Begin VB.CommandButton Command13 
         Caption         =   "取消"
         Height          =   495
         Left            =   4320
         TabIndex        =   26
         Top             =   2040
         Width           =   1455
      End
      Begin VB.CommandButton Command12 
         Caption         =   "确定"
         Height          =   495
         Left            =   2520
         TabIndex        =   25
         Top             =   2040
         Width           =   1455
      End
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
         TabIndex        =   24
         Top             =   720
         Width           =   6855
      End
   End
   Begin VB.TextBox Text4 
      Height          =   6735
      Left            =   13200
      Locked          =   -1  'True
      MultiLine       =   -1  'True
      ScrollBars      =   2  'Vertical
      TabIndex        =   22
      Top             =   600
      Width           =   1935
   End
   Begin VB.CommandButton Command11 
      Caption         =   "清除"
      Height          =   375
      Left            =   13440
      TabIndex        =   21
      Top             =   7440
      Width           =   975
   End
   Begin VB.Frame Frame3 
      Caption         =   "安装字体"
      Height          =   5415
      Left            =   -2760
      TabIndex        =   15
      Top             =   7800
      Visible         =   0   'False
      Width           =   8295
      Begin VB.CommandButton Command7 
         Caption         =   "返回"
         Height          =   855
         Left            =   1485
         TabIndex        =   17
         Top             =   3780
         Width           =   1575
      End
      Begin VB.CommandButton Command6 
         Caption         =   "安装"
         BeginProperty Font 
            Name            =   "楷体"
            Size            =   18
            Charset         =   134
            Weight          =   700
            Underline       =   -1  'True
            Italic          =   -1  'True
            Strikethrough   =   0   'False
         EndProperty
         Height          =   855
         Left            =   5205
         TabIndex        =   16
         Top             =   3780
         Width           =   1575
      End
      Begin VB.Label Label11 
         Caption         =   "为了您能得到最佳使用体验，请安装本程序使用的专属字体（点击安装，在弹出的窗口再点击安装），若已经安装则无需理会"
         BeginProperty Font 
            Name            =   "黑体"
            Size            =   18
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   2415
         Left            =   600
         TabIndex        =   18
         Top             =   600
         Width           =   6975
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "关于"
      Height          =   7935
      Left            =   -7
      TabIndex        =   10
      Top             =   0
      Visible         =   0   'False
      Width           =   15255
      Begin VB.CommandButton Command5 
         Caption         =   "确认"
         Height          =   855
         Left            =   12840
         TabIndex        =   13
         Top             =   6960
         Width           =   2295
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
         TabIndex        =   20
         Top             =   7200
         Width           =   3975
      End
      Begin VB.Label Label10 
         Caption         =   "built date:     2021\9\12"
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
         TabIndex        =   14
         Top             =   3240
         Width           =   5655
      End
      Begin VB.Label Label9 
         Caption         =   "版本：     V1.8.1(special)"
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
         Left            =   5400
         TabIndex        =   12
         Top             =   2880
         Width           =   3735
      End
      Begin VB.Label Label8 
         Caption         =   "制作者：     柯YC                                     QQ：     3524829413"
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
         Left            =   5040
         TabIndex        =   11
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
      TabIndex        =   5
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
      TabIndex        =   4
      Top             =   2160
      Width           =   735
   End
   Begin VB.CommandButton Command2 
      Caption         =   "停止"
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
      TabIndex        =   3
      Top             =   5880
      Visible         =   0   'False
      Width           =   5295
   End
   Begin VB.CommandButton Command1 
      Caption         =   "开始"
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
      TabIndex        =   2
      Top             =   5880
      Width           =   5295
   End
   Begin VB.Frame Frame1 
      BackColor       =   &H00FFFFFF&
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
      Begin VB.CommandButton Command14 
         Caption         =   "保存抽号记录"
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   360
         TabIndex        =   29
         Top             =   2280
         Width           =   2775
      End
      Begin VB.Label Label17 
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         ForeColor       =   &H80000008&
         Height          =   495
         Left            =   1080
         TabIndex        =   31
         Top             =   1080
         Width           =   2295
      End
      Begin VB.Label Label16 
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         Caption         =   "人数："
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   375
         Left            =   240
         TabIndex        =   30
         Top             =   1080
         Width           =   855
      End
      Begin VB.Label Label3 
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   15
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   495
         Left            =   1080
         TabIndex        =   28
         Top             =   360
         Width           =   2295
      End
      Begin VB.Label Label2 
         Appearance      =   0  'Flat
         BackColor       =   &H80000005&
         Caption         =   "状态："
         BeginProperty Font 
            Name            =   "宋体"
            Size            =   14.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H80000008&
         Height          =   375
         Left            =   240
         TabIndex        =   27
         Top             =   360
         Width           =   855
      End
   End
   Begin VB.Timer Timer1 
      Enabled         =   0   'False
      Interval        =   20
      Left            =   0
      Top             =   0
   End
   Begin VB.Label Label18 
      Alignment       =   2  'Center
      Appearance      =   0  'Flat
      BackColor       =   &H80000005&
      Caption         =   "开始"
      BeginProperty Font 
         Name            =   "微软雅黑"
         Size            =   42
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00C0C0C0&
      Height          =   1815
      Left            =   5160
      TabIndex        =   32
      Top             =   5880
      Visible         =   0   'False
      Width           =   5295
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
      TabIndex        =   19
      Top             =   0
      Width           =   2295
   End
   Begin VB.Label Label7 
      BackColor       =   &H00FFFFFF&
      Caption         =   "关于"
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
      TabIndex        =   9
      Top             =   7680
      Width           =   735
   End
   Begin VB.Label Label6 
      Alignment       =   2  'Center
      BackColor       =   &H00FFFFFF&
      Caption         =   "       请抽查到的同学回答问题"
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
      Left            =   45
      TabIndex        =   8
      Top             =   600
      Width           =   13095
   End
   Begin VB.Label Label5 
      BackColor       =   &H00FFFFFF&
      Caption         =   "抽号记录:"
      BeginProperty Font 
         Name            =   "宋体"
         Size            =   26.25
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00008000&
      Height          =   615
      Left            =   11520
      TabIndex        =   7
      Top             =   0
      Width           =   2415
   End
   Begin VB.Label Label4 
      BackColor       =   &H00FFFFFF&
      Caption         =   "速度调节:"
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
      Left            =   4440
      TabIndex        =   6
      Top             =   2400
      Width           =   1575
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      BackColor       =   &H00E0E0E0&
      BorderStyle     =   1  'Fixed Single
      BeginProperty Font 
         Name            =   "微软雅黑"
         Size            =   72
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00000000&
      Height          =   2775
      Left            =   3600
      TabIndex        =   0
      Top             =   3000
      Width           =   8415
   End
   Begin VB.Menu menu 
      Caption         =   "菜单"
      Begin VB.Menu about 
         Caption         =   "关于"
      End
      Begin VB.Menu exit 
         Caption         =   "退出"
      End
   End
   Begin VB.Menu option 
      Caption         =   "选项"
      Begin VB.Menu settitle 
         Caption         =   "设置标题"
      End
   End
   Begin VB.Menu help 
      Caption         =   "使用帮助"
   End
   Begin VB.Menu point 
      Caption         =   "←←←"
   End
End
Attribute VB_Name = "Form1"
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

Private Sub Command1_Click()

Command2.Visible = True


Timer1.Enabled = True






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

Private Sub Command14_Click()
Open App.Path & "\记录.txt" For Output As #2
Print #2, Text4.Text
Close #2
MsgBox "记录已保存在程序所在文件夹中！", vbInformation + vbOKOnly, "已保存"

End Sub

Private Sub Command2_Click()
Timer1.Enabled = False
Command2.Visible = False



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
MsgBox "请输入数据！", vbOKOnly + vbExclamation, "无数据"
ElseIf Command1.Visible = False Then
MsgBox "请先停止抽号！", vbOKOnly + vbExclamation, "抽号正在运行"
Else
n = Int(Text3.Text)
End If



Frame4.Visible = False
Label12.Caption = "阴间功能已开启！"


End Sub

Private Sub eng_Click()
Form2.Show
Form1.Hide

End Sub

Private Sub exit_Click()
End

End Sub







Private Sub install_Click()
Frame3.Visible = True

End Sub



Private Sub Form_Load()

On Error GoTo el



If Dir(App.Path & "\1.txt") = "" Then
Label3.Caption = "未读取到名单！"
Label17.Caption = "未知"
Label18.Visible = True
Command1.Visible = False
Command2.Visible = False

Else
Label3.Caption = "已读取到名单"
Open App.Path & "\1.txt" For Input As #1


Dim str As String

Line Input #1, str
b = UBound(Split(str, "/"))
Label17.Caption = b + 1
Close #1
End If
el:
If Err.Number = 62 Then
MsgBox "你的名单没有任何内容！程序即将退出", vbExclamation + vbOKOnly, "出错了"
End

End If

End Sub

Private Sub help_Click()
Form1.Hide
Form2.Show

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



Open App.Path & "\1.txt" For Input As #1


Dim str As String

Line Input #1, str
a = Split(str, "/")




X = Int((UBound(Split(str, "/")) - 0 + 1) * Rnd + 0)

Label1.Caption = a(X)

Close #1













End Sub
