VERSION 5.00
Begin VB.Form Form1 
   BackColor       =   &H00FFFFFF&
   Caption         =   "��Ż�"
   ClientHeight    =   7935
   ClientLeft      =   120
   ClientTop       =   750
   ClientWidth     =   15240
   BeginProperty Font 
      Name            =   "����"
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
   StartUpPosition =   2  '��Ļ����
   Begin VB.Frame Frame5 
      Caption         =   "���ñ���"
      Height          =   2775
      Left            =   3653
      TabIndex        =   34
      Top             =   2580
      Visible         =   0   'False
      Width           =   7935
      Begin VB.CommandButton Command13 
         Caption         =   "ȡ��"
         Height          =   495
         Left            =   4320
         TabIndex        =   37
         Top             =   2040
         Width           =   1455
      End
      Begin VB.CommandButton Command12 
         Caption         =   "ȷ��"
         Height          =   495
         Left            =   2520
         TabIndex        =   36
         Top             =   2040
         Width           =   1455
      End
      Begin VB.TextBox Text5 
         Alignment       =   2  'Center
         BeginProperty Font 
            Name            =   "����"
            Size            =   26.25
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   1095
         Left            =   600
         TabIndex        =   35
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
      TabIndex        =   33
      Top             =   600
      Width           =   1575
   End
   Begin VB.CommandButton Command11 
      Caption         =   "���"
      Height          =   375
      Left            =   13440
      TabIndex        =   32
      Top             =   7440
      Width           =   975
   End
   Begin VB.Frame Frame4 
      Caption         =   "���ò����鵽�ĺ�"
      BeginProperty Font 
         Name            =   "����"
         Size            =   12
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2655
      Left            =   6293
      TabIndex        =   23
      Top             =   2640
      Visible         =   0   'False
      Width           =   2655
      Begin VB.CommandButton Command10 
         Caption         =   "����"
         BeginProperty Font 
            Name            =   "����"
            Size            =   9
            Charset         =   134
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
         Caption         =   "ȷ������"
         BeginProperty Font 
            Name            =   "΢���ź�"
            Size            =   10.5
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   615
         Left            =   1320
         TabIndex        =   26
         Top             =   1320
         Width           =   1215
      End
      Begin VB.CommandButton Command8 
         Caption         =   "ȡ������"
         BeginProperty Font 
            Name            =   "΢���ź�"
            Size            =   10.5
            Charset         =   134
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
         Width           =   2415
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "��װ����"
      Height          =   5415
      Left            =   3473
      TabIndex        =   19
      Top             =   1260
      Visible         =   0   'False
      Width           =   8295
      Begin VB.CommandButton Command7 
         Caption         =   "����"
         Height          =   855
         Left            =   1485
         TabIndex        =   21
         Top             =   3780
         Width           =   1575
      End
      Begin VB.CommandButton Command6 
         Caption         =   "��װ"
         BeginProperty Font 
            Name            =   "����"
            Size            =   18
            Charset         =   134
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
         Caption         =   "Ϊ�����ܵõ����ʹ�����飬�밲װ������ʹ�õ�ר�����壨�����װ���ڵ����Ĵ����ٵ����װ�������Ѿ���װ���������"
         BeginProperty Font 
            Name            =   "����"
            Size            =   18
            Charset         =   134
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   2415
         Left            =   600
         TabIndex        =   22
         Top             =   600
         Width           =   6975
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "����"
      Height          =   7935
      Left            =   -7
      TabIndex        =   14
      Top             =   0
      Visible         =   0   'False
      Width           =   15255
      Begin VB.CommandButton Command5 
         Caption         =   "ȷ��"
         Height          =   855
         Left            =   12840
         TabIndex        =   17
         Top             =   6960
         Width           =   2295
      End
      Begin VB.Label Label15 
         Caption         =   "�������Դ����"
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
         Left            =   8880
         TabIndex        =   31
         Top             =   6600
         Width           =   1935
      End
      Begin VB.Label Label14 
         Caption         =   "ע��������100%Ϊԭ����������Դ������GitHub�Ϸ��� "
         BeginProperty Font 
            Name            =   "΢���ź�"
            Size            =   12
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   615
         Left            =   2760
         TabIndex        =   30
         Top             =   6600
         Width           =   9495
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
         Top             =   3240
         Width           =   5655
      End
      Begin VB.Label Label9 
         Caption         =   "�汾��     V1.8"
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
         TabIndex        =   16
         Top             =   2880
         Width           =   3735
      End
      Begin VB.Label Label8 
         Caption         =   "�����ߣ�     ��YC                                     QQ��     3524829413"
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
         TabIndex        =   15
         Top             =   2160
         Width           =   5175
      End
   End
   Begin VB.CommandButton Command4 
      BackColor       =   &H00FFFFFF&
      Caption         =   "+"
      BeginProperty Font 
         Name            =   "����"
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
         Name            =   "����"
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
      Caption         =   "ֹͣ"
      BeginProperty Font 
         Name            =   "΢���ź�"
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
      Caption         =   "��ʼ"
      BeginProperty Font 
         Name            =   "΢���ź�"
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
      Caption         =   "��Χ"
      BeginProperty Font 
         Name            =   "����"
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
         Caption         =   "��"
         BeginProperty Font 
            Name            =   "����"
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
         Caption         =   "��"
         BeginProperty Font 
            Name            =   "����"
            Size            =   24
            Charset         =   134
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   375
         Left            =   600
         TabIndex        =   6
         Top             =   240
         Width           =   495
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
         Name            =   "����"
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
      Caption         =   "����"
      BeginProperty Font 
         Name            =   "����"
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
      Caption         =   "       ���鵽��ͬѧ�ش�����"
      BeginProperty Font 
         Name            =   "΢���ź�"
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
      TabIndex        =   12
      Top             =   600
      Width           =   13095
   End
   Begin VB.Label Label5 
      BackColor       =   &H00FFFFFF&
      Caption         =   "��ż�¼:"
      BeginProperty Font 
         Name            =   "����"
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
      TabIndex        =   11
      Top             =   0
      Width           =   2415
   End
   Begin VB.Label Label4 
      BackColor       =   &H00FFFFFF&
      Caption         =   "�ٶȵ���:"
      BeginProperty Font 
         Name            =   "����"
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
      TabIndex        =   10
      Top             =   2400
      Width           =   1575
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
      Caption         =   "�˵�"
      Begin VB.Menu install 
         Caption         =   "��װ����"
      End
      Begin VB.Menu wtf 
         Caption         =   "���书��"
         Begin VB.Menu cao 
            Caption         =   "���ò��ᱻ�鵽�ĺ�"
         End
      End
      Begin VB.Menu language 
         Caption         =   "����"
         Begin VB.Menu eng 
            Caption         =   "English"
         End
      End
      Begin VB.Menu about 
         Caption         =   "����"
      End
      Begin VB.Menu exit 
         Caption         =   "�˳�"
      End
   End
   Begin VB.Menu option 
      Caption         =   "ѡ��"
      Begin VB.Menu settitle 
         Caption         =   "���ñ���"
      End
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

If Text1.Text = "" Then
MsgBox "��û�����뷶Χ��", vbOKOnly + vbExclamation, "û������"
ElseIf Text2.Text = "" Then

MsgBox "��û�����뷶Χ��", vbOKOnly + vbExclamation, "û������"
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
MsgBox "��û�����뷶Χ��", vbOKOnly + vbExclamation, "û������"
ElseIf Text2.Text = "" Then

MsgBox "��û�����뷶Χ��", vbOKOnly + vbExclamation, "û������"
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
MsgBox "���������ݣ�", vbOKOnly + vbExclamation, "������"
ElseIf Command1.Visible = False Then
MsgBox "����ֹͣ��ţ�", vbOKOnly + vbExclamation, "�����������"
Else
n = Int(Text3.Text)
End If



Frame4.Visible = False
Label12.Caption = "���书���ѿ�����"


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




Label1.Caption = Int((Y - X + 1) * Rnd + X)    '�����Ҫ����


If Text3.Text <> "" Then
   If Label1.Caption = n Then
   Label1.Caption = n + 1
   End If
End If









End Sub
