VERSION 5.00
Begin VB.Form Form2 
   Caption         =   "Ê¹ÓÃ°ïÖú   (ÇëÎñ±Ø×ñÑ­²½Öè£¡)"
   ClientHeight    =   9675
   ClientLeft      =   120
   ClientTop       =   465
   ClientWidth     =   16365
   Icon            =   "Form2.frx":0000
   LinkTopic       =   "Form2"
   ScaleHeight     =   9675
   ScaleWidth      =   16365
   StartUpPosition =   2  'ÆÁÄ»ÖÐÐÄ
   Begin VB.Label Label5 
      BackStyle       =   0  'Transparent
      Caption         =   "5"
      BeginProperty Font 
         Name            =   "Î¢ÈíÑÅºÚ"
         Size            =   21.75
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   1080
      TabIndex        =   4
      Top             =   4920
      Width           =   375
   End
   Begin VB.Label Label4 
      BackStyle       =   0  'Transparent
      Caption         =   "4"
      BeginProperty Font 
         Name            =   "Î¢ÈíÑÅºÚ"
         Size            =   21.75
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   11640
      TabIndex        =   3
      Top             =   2280
      Width           =   375
   End
   Begin VB.Label Label3 
      BackStyle       =   0  'Transparent
      Caption         =   "3"
      BeginProperty Font 
         Name            =   "Î¢ÈíÑÅºÚ"
         Size            =   21.75
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   7800
      TabIndex        =   2
      Top             =   2160
      Width           =   375
   End
   Begin VB.Label Label2 
      BackStyle       =   0  'Transparent
      Caption         =   "2"
      BeginProperty Font 
         Name            =   "Î¢ÈíÑÅºÚ"
         Size            =   21.75
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   4320
      TabIndex        =   1
      Top             =   2160
      Width           =   375
   End
   Begin VB.Label Label1 
      BackStyle       =   0  'Transparent
      Caption         =   "1"
      BeginProperty Font 
         Name            =   "Î¢ÈíÑÅºÚ"
         Size            =   21.75
         Charset         =   134
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   615
      Left            =   960
      TabIndex        =   0
      Top             =   2160
      Width           =   375
   End
   Begin VB.Image Image5 
      Height          =   1575
      Left            =   1440
      Picture         =   "Form2.frx":0442
      Stretch         =   -1  'True
      Top             =   5280
      Width           =   2985
   End
   Begin VB.Image Image4 
      Height          =   1575
      Left            =   12120
      Picture         =   "Form2.frx":AA7F
      Stretch         =   -1  'True
      Top             =   2640
      Width           =   2985
   End
   Begin VB.Image Image3 
      Height          =   1575
      Left            =   8280
      Picture         =   "Form2.frx":15043
      Stretch         =   -1  'True
      Top             =   2640
      Width           =   2985
   End
   Begin VB.Image Image2 
      Height          =   1575
      Left            =   4800
      Picture         =   "Form2.frx":1A16A
      Stretch         =   -1  'True
      Top             =   2640
      Width           =   2985
   End
   Begin VB.Image Image1 
      Height          =   1575
      Left            =   1440
      Picture         =   "Form2.frx":22BCF
      Stretch         =   -1  'True
      Top             =   2640
      Width           =   2985
   End
End
Attribute VB_Name = "Form2"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
Private Sub Form_Unload(Cancel As Integer)
Form2.Hide
Form1.Show

End Sub

Private Sub Image1_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)


Label1.Visible = False
Label2.Visible = False
Label3.Visible = False
Label4.Visible = False
Label5.Visible = False
Image2.Visible = False
Image3.Visible = False
Image4.Visible = False
Image5.Visible = False

Image1.Left = 240
Image1.Top = 240

Image1.Height = 9015
Image1.Width = 15345
Sleep 1000
Image1.Height = 1575
Image1.Width = 2985

Image1.Left = 1440
Image1.Top = 2640

Image2.Visible = True
Image3.Visible = True
Image4.Visible = True
Image5.Visible = True
Label1.Visible = True
Label2.Visible = True
Label3.Visible = True
Label4.Visible = True
Label5.Visible = True


End Sub

Private Sub Image2_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
Label1.Visible = False
Label2.Visible = False
Label3.Visible = False
Label4.Visible = False
Label5.Visible = False
Image1.Visible = False
Image3.Visible = False
Image4.Visible = False
Image5.Visible = False

Image2.Left = 240
Image2.Top = 240

Image2.Height = 9015
Image2.Width = 15345
Sleep 1000
Image2.Height = 1575
Image2.Width = 2985

Image2.Left = 4800
Image2.Top = 2640

Image1.Visible = True
Image3.Visible = True
Image4.Visible = True
Image5.Visible = True
Label1.Visible = True
Label2.Visible = True
Label3.Visible = True
Label4.Visible = True
Label5.Visible = True
End Sub

Private Sub Image3_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
Label1.Visible = False
Label2.Visible = False
Label3.Visible = False
Label4.Visible = False
Label5.Visible = False
Image1.Visible = False
Image2.Visible = False
Image4.Visible = False
Image5.Visible = False

Image3.Left = 240
Image3.Top = 240

Image3.Height = 9015
Image3.Width = 15345
Sleep 1000
Image3.Height = 1575
Image3.Width = 2985

Image3.Left = 8280
Image3.Top = 2640

Image1.Visible = True
Image2.Visible = True
Image4.Visible = True
Image5.Visible = True
Label1.Visible = True
Label2.Visible = True
Label3.Visible = True
Label4.Visible = True
Label5.Visible = True
End Sub


Private Sub Image4_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
Label1.Visible = False
Label2.Visible = False
Label3.Visible = False
Label4.Visible = False
Label5.Visible = False
Image1.Visible = False
Image3.Visible = False
Image2.Visible = False
Image5.Visible = False

Image4.Left = 240
Image4.Top = 240

Image4.Height = 9015
Image4.Width = 15345
Sleep 1000
Image4.Height = 1575
Image4.Width = 2985

Image4.Left = 12120
Image4.Top = 2640

Image1.Visible = True
Image3.Visible = True
Image2.Visible = True
Image5.Visible = True
Label1.Visible = True
Label2.Visible = True
Label3.Visible = True
Label4.Visible = True
Label5.Visible = True
End Sub

Private Sub Image5_MouseMove(Button As Integer, Shift As Integer, X As Single, Y As Single)
Label1.Visible = False
Label2.Visible = False
Label3.Visible = False
Label4.Visible = False
Label5.Visible = False
Image1.Visible = False
Image3.Visible = False
Image2.Visible = False
Image4.Visible = False

Image5.Left = 240
Image5.Top = 240

Image5.Height = 9015
Image5.Width = 15345
Sleep 1000
Image5.Height = 1575
Image5.Width = 2985

Image5.Left = 1440
Image5.Top = 5280

Image1.Visible = True
Image3.Visible = True
Image2.Visible = True
Image4.Visible = True
Label1.Visible = True
Label2.Visible = True
Label3.Visible = True
Label4.Visible = True
Label5.Visible = True

End Sub
