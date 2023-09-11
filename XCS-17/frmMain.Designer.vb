<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbl_ArticleNos = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lbl_tagnos = New System.Windows.Forms.Label()
        Me.lbl_WOnos = New System.Windows.Forms.Label()
        Me.lbl_wocounter = New System.Windows.Forms.Label()
        Me.lbl_currentref = New System.Windows.Forms.Label()
        Me.cmd_quit = New System.Windows.Forms.Button()
        Me.cmd_testspec = New System.Windows.Forms.Button()
        Me.cmd_reprint = New System.Windows.Forms.Button()
        Me.Cmd_Visual = New System.Windows.Forms.Button()
        Me.Cmd_CloseTag = New System.Windows.Forms.Button()
        Me.cmd_Refresh = New System.Windows.Forms.Button()
        Me.cmd_Modbus = New System.Windows.Forms.Button()
        Me.ReferenceSelector = New System.Windows.Forms.Button()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.Command3 = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.lbl_localip = New System.Windows.Forms.Label()
        Me.lbl_localhostname = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Ethernet = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_groupCount = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lbl_unitaryCount = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Image_preview_group = New System.Windows.Forms.PictureBox()
        Me.Image_preview_unitary = New System.Windows.Forms.PictureBox()
        Me.Image1 = New System.Windows.Forms.PictureBox()
        Me.lbl_msg = New System.Windows.Forms.Label()
        Me.Txt_Msg = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Image2 = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Text6 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BarcodeScan_Comm = New System.IO.Ports.SerialPort(Me.components)
        Me.Vacuumscan_Comm = New System.IO.Ports.SerialPort(Me.components)
        Me.RFID_Comm = New System.IO.Ports.SerialPort(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Text4 = New System.Windows.Forms.TextBox()
        Me.Text5 = New System.Windows.Forms.TextBox()
        Me.Text3 = New System.Windows.Forms.TextBox()
        Me.Command4 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.Ethernet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Image_preview_group, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image_preview_unitary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lbl_ArticleNos)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lbl_tagnos)
        Me.GroupBox1.Controls.Add(Me.lbl_WOnos)
        Me.GroupBox1.Controls.Add(Me.lbl_wocounter)
        Me.GroupBox1.Controls.Add(Me.lbl_currentref)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1232, 114)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(70, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 20)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Work Order Qty :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Green
        Me.Label7.Location = New System.Drawing.Point(1112, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 37)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "SC"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Green
        Me.Label1.Location = New System.Drawing.Point(66, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Work Order Nos :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Green
        Me.Label2.Location = New System.Drawing.Point(13, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(199, 20)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Work Order Reference :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Green
        Me.Label4.Location = New System.Drawing.Point(79, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(133, 20)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "RFID Tag Nos :"
        '
        'lbl_ArticleNos
        '
        Me.lbl_ArticleNos.AutoSize = True
        Me.lbl_ArticleNos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_ArticleNos.ForeColor = System.Drawing.Color.Green
        Me.lbl_ArticleNos.Location = New System.Drawing.Point(218, 89)
        Me.lbl_ArticleNos.Name = "lbl_ArticleNos"
        Me.lbl_ArticleNos.Size = New System.Drawing.Size(15, 20)
        Me.lbl_ArticleNos.TabIndex = 14
        Me.lbl_ArticleNos.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(106, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 20)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Article Nos :"
        '
        'lbl_tagnos
        '
        Me.lbl_tagnos.AutoSize = True
        Me.lbl_tagnos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_tagnos.ForeColor = System.Drawing.Color.Green
        Me.lbl_tagnos.Location = New System.Drawing.Point(218, 69)
        Me.lbl_tagnos.Name = "lbl_tagnos"
        Me.lbl_tagnos.Size = New System.Drawing.Size(15, 20)
        Me.lbl_tagnos.TabIndex = 14
        Me.lbl_tagnos.Text = "-"
        '
        'lbl_WOnos
        '
        Me.lbl_WOnos.AutoSize = True
        Me.lbl_WOnos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_WOnos.ForeColor = System.Drawing.Color.Green
        Me.lbl_WOnos.Location = New System.Drawing.Point(218, 9)
        Me.lbl_WOnos.Name = "lbl_WOnos"
        Me.lbl_WOnos.Size = New System.Drawing.Size(15, 20)
        Me.lbl_WOnos.TabIndex = 14
        Me.lbl_WOnos.Text = "-"
        '
        'lbl_wocounter
        '
        Me.lbl_wocounter.AutoSize = True
        Me.lbl_wocounter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_wocounter.ForeColor = System.Drawing.Color.Green
        Me.lbl_wocounter.Location = New System.Drawing.Point(218, 49)
        Me.lbl_wocounter.Name = "lbl_wocounter"
        Me.lbl_wocounter.Size = New System.Drawing.Size(15, 20)
        Me.lbl_wocounter.TabIndex = 14
        Me.lbl_wocounter.Text = "-"
        '
        'lbl_currentref
        '
        Me.lbl_currentref.AutoSize = True
        Me.lbl_currentref.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_currentref.ForeColor = System.Drawing.Color.Green
        Me.lbl_currentref.Location = New System.Drawing.Point(218, 29)
        Me.lbl_currentref.Name = "lbl_currentref"
        Me.lbl_currentref.Size = New System.Drawing.Size(15, 20)
        Me.lbl_currentref.TabIndex = 14
        Me.lbl_currentref.Text = "-"
        '
        'cmd_quit
        '
        Me.cmd_quit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_quit.Image = CType(resources.GetObject("cmd_quit.Image"), System.Drawing.Image)
        Me.cmd_quit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_quit.Location = New System.Drawing.Point(1250, 12)
        Me.cmd_quit.Name = "cmd_quit"
        Me.cmd_quit.Size = New System.Drawing.Size(88, 57)
        Me.cmd_quit.TabIndex = 18
        Me.cmd_quit.Text = "Quit"
        Me.cmd_quit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_quit.UseVisualStyleBackColor = True
        '
        'cmd_testspec
        '
        Me.cmd_testspec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_testspec.Image = CType(resources.GetObject("cmd_testspec.Image"), System.Drawing.Image)
        Me.cmd_testspec.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_testspec.Location = New System.Drawing.Point(1250, 75)
        Me.cmd_testspec.Name = "cmd_testspec"
        Me.cmd_testspec.Size = New System.Drawing.Size(88, 57)
        Me.cmd_testspec.TabIndex = 19
        Me.cmd_testspec.Text = "Parameter"
        Me.cmd_testspec.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_testspec.UseVisualStyleBackColor = True
        '
        'cmd_reprint
        '
        Me.cmd_reprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_reprint.Image = CType(resources.GetObject("cmd_reprint.Image"), System.Drawing.Image)
        Me.cmd_reprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_reprint.Location = New System.Drawing.Point(1250, 138)
        Me.cmd_reprint.Name = "cmd_reprint"
        Me.cmd_reprint.Size = New System.Drawing.Size(88, 57)
        Me.cmd_reprint.TabIndex = 20
        Me.cmd_reprint.Text = "Print Again"
        Me.cmd_reprint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_reprint.UseVisualStyleBackColor = True
        '
        'Cmd_Visual
        '
        Me.Cmd_Visual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_Visual.Image = CType(resources.GetObject("Cmd_Visual.Image"), System.Drawing.Image)
        Me.Cmd_Visual.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Cmd_Visual.Location = New System.Drawing.Point(1250, 201)
        Me.Cmd_Visual.Name = "Cmd_Visual"
        Me.Cmd_Visual.Size = New System.Drawing.Size(88, 70)
        Me.Cmd_Visual.TabIndex = 21
        Me.Cmd_Visual.Text = "Visual Reject"
        Me.Cmd_Visual.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cmd_Visual.UseVisualStyleBackColor = True
        '
        'Cmd_CloseTag
        '
        Me.Cmd_CloseTag.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd_CloseTag.Image = CType(resources.GetObject("Cmd_CloseTag.Image"), System.Drawing.Image)
        Me.Cmd_CloseTag.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Cmd_CloseTag.Location = New System.Drawing.Point(1250, 277)
        Me.Cmd_CloseTag.Name = "Cmd_CloseTag"
        Me.Cmd_CloseTag.Size = New System.Drawing.Size(88, 57)
        Me.Cmd_CloseTag.TabIndex = 22
        Me.Cmd_CloseTag.Text = "Close Tag"
        Me.Cmd_CloseTag.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Cmd_CloseTag.UseVisualStyleBackColor = True
        '
        'cmd_Refresh
        '
        Me.cmd_Refresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Refresh.Image = CType(resources.GetObject("cmd_Refresh.Image"), System.Drawing.Image)
        Me.cmd_Refresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_Refresh.Location = New System.Drawing.Point(1250, 340)
        Me.cmd_Refresh.Name = "cmd_Refresh"
        Me.cmd_Refresh.Size = New System.Drawing.Size(88, 57)
        Me.cmd_Refresh.TabIndex = 23
        Me.cmd_Refresh.Text = "Refresh"
        Me.cmd_Refresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_Refresh.UseVisualStyleBackColor = True
        '
        'cmd_Modbus
        '
        Me.cmd_Modbus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_Modbus.Image = CType(resources.GetObject("cmd_Modbus.Image"), System.Drawing.Image)
        Me.cmd_Modbus.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_Modbus.Location = New System.Drawing.Point(1250, 403)
        Me.cmd_Modbus.Name = "cmd_Modbus"
        Me.cmd_Modbus.Size = New System.Drawing.Size(88, 57)
        Me.cmd_Modbus.TabIndex = 24
        Me.cmd_Modbus.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_Modbus.UseVisualStyleBackColor = True
        '
        'ReferenceSelector
        '
        Me.ReferenceSelector.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReferenceSelector.Image = CType(resources.GetObject("ReferenceSelector.Image"), System.Drawing.Image)
        Me.ReferenceSelector.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ReferenceSelector.Location = New System.Drawing.Point(1250, 510)
        Me.ReferenceSelector.Name = "ReferenceSelector"
        Me.ReferenceSelector.Size = New System.Drawing.Size(88, 70)
        Me.ReferenceSelector.TabIndex = 25
        Me.ReferenceSelector.Text = "Plastic"
        Me.ReferenceSelector.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ReferenceSelector.UseVisualStyleBackColor = True
        '
        'Command2
        '
        Me.Command2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command2.Image = CType(resources.GetObject("Command2.Image"), System.Drawing.Image)
        Me.Command2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Command2.Location = New System.Drawing.Point(1250, 586)
        Me.Command2.Name = "Command2"
        Me.Command2.Size = New System.Drawing.Size(88, 57)
        Me.Command2.TabIndex = 26
        Me.Command2.Text = "PRINT"
        Me.Command2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Command2.UseVisualStyleBackColor = True
        '
        'Command3
        '
        Me.Command3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Command3.Location = New System.Drawing.Point(1250, 649)
        Me.Command3.Name = "Command3"
        Me.Command3.Size = New System.Drawing.Size(88, 57)
        Me.Command3.TabIndex = 27
        Me.Command3.Text = "MW101=10"
        Me.Command3.UseVisualStyleBackColor = True
        '
        'Command1
        '
        Me.Command1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command1.Image = CType(resources.GetObject("Command1.Image"), System.Drawing.Image)
        Me.Command1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Command1.Location = New System.Drawing.Point(1250, 712)
        Me.Command1.Name = "Command1"
        Me.Command1.Size = New System.Drawing.Size(88, 57)
        Me.Command1.TabIndex = 28
        Me.Command1.Text = "Eye Open"
        Me.Command1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Command1.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label75)
        Me.GroupBox7.Controls.Add(Me.lbl_localip)
        Me.GroupBox7.Controls.Add(Me.lbl_localhostname)
        Me.GroupBox7.Controls.Add(Me.Label72)
        Me.GroupBox7.Controls.Add(Me.Ethernet)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 669)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(287, 100)
        Me.GroupBox7.TabIndex = 29
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Ethernet"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.Color.Green
        Me.Label75.Location = New System.Drawing.Point(12, 75)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(179, 15)
        Me.Label75.TabIndex = 9
        Me.Label75.Text = "PLC IP Address : 126.254.108.2"
        '
        'lbl_localip
        '
        Me.lbl_localip.AutoSize = True
        Me.lbl_localip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_localip.ForeColor = System.Drawing.Color.Green
        Me.lbl_localip.Location = New System.Drawing.Point(12, 60)
        Me.lbl_localip.Name = "lbl_localip"
        Me.lbl_localip.Size = New System.Drawing.Size(45, 15)
        Me.lbl_localip.TabIndex = 9
        Me.lbl_localip.Text = "Label1"
        '
        'lbl_localhostname
        '
        Me.lbl_localhostname.AutoSize = True
        Me.lbl_localhostname.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_localhostname.ForeColor = System.Drawing.Color.Green
        Me.lbl_localhostname.Location = New System.Drawing.Point(12, 45)
        Me.lbl_localhostname.Name = "lbl_localhostname"
        Me.lbl_localhostname.Size = New System.Drawing.Size(45, 15)
        Me.lbl_localhostname.TabIndex = 9
        Me.lbl_localhostname.Text = "Label1"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.ForeColor = System.Drawing.Color.Green
        Me.Label72.Location = New System.Drawing.Point(57, 25)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(52, 15)
        Me.Label72.TabIndex = 9
        Me.Label72.Text = "Connect"
        '
        'Ethernet
        '
        Me.Ethernet.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Ethernet.Location = New System.Drawing.Point(16, 22)
        Me.Ethernet.Name = "Ethernet"
        Me.Ethernet.Size = New System.Drawing.Size(25, 20)
        Me.Ethernet.TabIndex = 0
        Me.Ethernet.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_groupCount)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.lbl_unitaryCount)
        Me.GroupBox2.Controls.Add(Me.Label50)
        Me.GroupBox2.Controls.Add(Me.Image_preview_group)
        Me.GroupBox2.Controls.Add(Me.Image_preview_unitary)
        Me.GroupBox2.Controls.Add(Me.Image1)
        Me.GroupBox2.Controls.Add(Me.lbl_msg)
        Me.GroupBox2.Controls.Add(Me.Txt_Msg)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 132)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(613, 531)
        Me.GroupBox2.TabIndex = 30
        Me.GroupBox2.TabStop = False
        '
        'lbl_groupCount
        '
        Me.lbl_groupCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_groupCount.ForeColor = System.Drawing.Color.Green
        Me.lbl_groupCount.Location = New System.Drawing.Point(281, 90)
        Me.lbl_groupCount.Name = "lbl_groupCount"
        Me.lbl_groupCount.Size = New System.Drawing.Size(113, 36)
        Me.lbl_groupCount.TabIndex = 28
        Me.lbl_groupCount.Text = "0"
        Me.lbl_groupCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Green
        Me.Label14.Location = New System.Drawing.Point(281, 66)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(106, 20)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Group Qty : "
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_unitaryCount
        '
        Me.lbl_unitaryCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_unitaryCount.ForeColor = System.Drawing.Color.Green
        Me.lbl_unitaryCount.Location = New System.Drawing.Point(78, 90)
        Me.lbl_unitaryCount.Name = "lbl_unitaryCount"
        Me.lbl_unitaryCount.Size = New System.Drawing.Size(113, 36)
        Me.lbl_unitaryCount.TabIndex = 26
        Me.lbl_unitaryCount.Text = "0"
        Me.lbl_unitaryCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.Color.Green
        Me.Label50.Location = New System.Drawing.Point(78, 66)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(113, 20)
        Me.Label50.TabIndex = 24
        Me.Label50.Text = "Unitary Qty : "
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Image_preview_group
        '
        Me.Image_preview_group.Location = New System.Drawing.Point(310, 364)
        Me.Image_preview_group.Name = "Image_preview_group"
        Me.Image_preview_group.Size = New System.Drawing.Size(297, 161)
        Me.Image_preview_group.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Image_preview_group.TabIndex = 23
        Me.Image_preview_group.TabStop = False
        Me.Image_preview_group.Visible = False
        '
        'Image_preview_unitary
        '
        Me.Image_preview_unitary.Location = New System.Drawing.Point(6, 364)
        Me.Image_preview_unitary.Name = "Image_preview_unitary"
        Me.Image_preview_unitary.Size = New System.Drawing.Size(297, 161)
        Me.Image_preview_unitary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Image_preview_unitary.TabIndex = 22
        Me.Image_preview_unitary.TabStop = False
        Me.Image_preview_unitary.Visible = False
        '
        'Image1
        '
        Me.Image1.Location = New System.Drawing.Point(486, 19)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(120, 120)
        Me.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Image1.TabIndex = 21
        Me.Image1.TabStop = False
        '
        'lbl_msg
        '
        Me.lbl_msg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_msg.ForeColor = System.Drawing.Color.Red
        Me.lbl_msg.Location = New System.Drawing.Point(6, 282)
        Me.lbl_msg.Name = "lbl_msg"
        Me.lbl_msg.Size = New System.Drawing.Size(600, 73)
        Me.lbl_msg.TabIndex = 20
        Me.lbl_msg.Text = "Please scan PSN Barcode..."
        '
        'Txt_Msg
        '
        Me.Txt_Msg.BackColor = System.Drawing.Color.LightGray
        Me.Txt_Msg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Msg.Location = New System.Drawing.Point(5, 170)
        Me.Txt_Msg.Multiline = True
        Me.Txt_Msg.Name = "Txt_Msg"
        Me.Txt_Msg.Size = New System.Drawing.Size(601, 89)
        Me.Txt_Msg.TabIndex = 19
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(5, 262)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(133, 16)
        Me.Label20.TabIndex = 18
        Me.Label20.Text = "Operator's Instruction"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(5, 151)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 16)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "System Information"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Green
        Me.Label6.Location = New System.Drawing.Point(6, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 25)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Packaging"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Image2)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Text6)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(631, 132)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(613, 531)
        Me.GroupBox3.TabIndex = 31
        Me.GroupBox3.TabStop = False
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Green
        Me.Label11.Location = New System.Drawing.Point(79, 90)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 36)
        Me.Label11.TabIndex = 33
        Me.Label11.Text = "0"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Green
        Me.Label13.Location = New System.Drawing.Point(79, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(95, 20)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Pass Qty : "
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Image2
        '
        Me.Image2.Location = New System.Drawing.Point(487, 19)
        Me.Image2.Name = "Image2"
        Me.Image2.Size = New System.Drawing.Size(120, 120)
        Me.Image2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Image2.TabIndex = 31
        Me.Image2.TabStop = False
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Red
        Me.Label10.Location = New System.Drawing.Point(7, 282)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(600, 73)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Please scan PSN Barcode..."
        '
        'Text6
        '
        Me.Text6.BackColor = System.Drawing.Color.LightGray
        Me.Text6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text6.Location = New System.Drawing.Point(6, 170)
        Me.Text6.Multiline = True
        Me.Text6.Name = "Text6"
        Me.Text6.Size = New System.Drawing.Size(601, 89)
        Me.Text6.TabIndex = 29
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 262)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(133, 16)
        Me.Label16.TabIndex = 28
        Me.Label16.Text = "Operator's Instruction"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(6, 151)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(121, 16)
        Me.Label17.TabIndex = 27
        Me.Label17.Text = "System Information"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Green
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(149, 25)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Vacuum Test"
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'BarcodeScan_Comm
        '
        '
        'Vacuumscan_Comm
        '
        Me.Vacuumscan_Comm.PortName = "COM8"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(319, 684)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 18)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "%MW101 - "
        '
        'Text4
        '
        Me.Text4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text4.Location = New System.Drawing.Point(411, 681)
        Me.Text4.Name = "Text4"
        Me.Text4.Size = New System.Drawing.Size(100, 24)
        Me.Text4.TabIndex = 33
        '
        'Text5
        '
        Me.Text5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text5.Location = New System.Drawing.Point(637, 714)
        Me.Text5.Name = "Text5"
        Me.Text5.Size = New System.Drawing.Size(150, 24)
        Me.Text5.TabIndex = 34
        Me.Text5.Visible = False
        '
        'Text3
        '
        Me.Text3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text3.Location = New System.Drawing.Point(637, 682)
        Me.Text3.Name = "Text3"
        Me.Text3.Size = New System.Drawing.Size(150, 24)
        Me.Text3.TabIndex = 35
        Me.Text3.Visible = False
        '
        'Command4
        '
        Me.Command4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Command4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Command4.Location = New System.Drawing.Point(525, 681)
        Me.Command4.Name = "Command4"
        Me.Command4.Size = New System.Drawing.Size(100, 57)
        Me.Command4.TabIndex = 36
        Me.Command4.Text = "Manual Print"
        Me.Command4.UseVisualStyleBackColor = True
        Me.Command4.Visible = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 781)
        Me.Controls.Add(Me.Command4)
        Me.Controls.Add(Me.Text3)
        Me.Controls.Add(Me.Text4)
        Me.Controls.Add(Me.Text5)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.Command3)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.ReferenceSelector)
        Me.Controls.Add(Me.cmd_Modbus)
        Me.Controls.Add(Me.cmd_Refresh)
        Me.Controls.Add(Me.Cmd_CloseTag)
        Me.Controls.Add(Me.Cmd_Visual)
        Me.Controls.Add(Me.cmd_reprint)
        Me.Controls.Add(Me.cmd_testspec)
        Me.Controls.Add(Me.cmd_quit)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PACKAGING STATION - Developed by SESEA"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.Ethernet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Image_preview_group, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image_preview_unitary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lbl_ArticleNos As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lbl_tagnos As Label
    Friend WithEvents lbl_WOnos As Label
    Friend WithEvents lbl_wocounter As Label
    Friend WithEvents lbl_currentref As Label
    Friend WithEvents cmd_quit As Button
    Friend WithEvents cmd_testspec As Button
    Friend WithEvents cmd_reprint As Button
    Friend WithEvents Cmd_Visual As Button
    Friend WithEvents Cmd_CloseTag As Button
    Friend WithEvents cmd_Refresh As Button
    Friend WithEvents cmd_Modbus As Button
    Friend WithEvents ReferenceSelector As Button
    Friend WithEvents Command2 As Button
    Friend WithEvents Command3 As Button
    Friend WithEvents Command1 As Button
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label75 As Label
    Friend WithEvents lbl_localip As Label
    Friend WithEvents lbl_localhostname As Label
    Friend WithEvents Label72 As Label
    Friend WithEvents Ethernet As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lbl_groupCount As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lbl_unitaryCount As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents Image_preview_group As PictureBox
    Friend WithEvents Image_preview_unitary As PictureBox
    Friend WithEvents Image1 As PictureBox
    Friend WithEvents lbl_msg As Label
    Friend WithEvents Txt_Msg As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Image2 As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Text6 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents BarcodeScan_Comm As IO.Ports.SerialPort
    Friend WithEvents Vacuumscan_Comm As IO.Ports.SerialPort
    Friend WithEvents RFID_Comm As IO.Ports.SerialPort
    Friend WithEvents Label12 As Label
    Friend WithEvents Text4 As TextBox
    Friend WithEvents Text5 As TextBox
    Friend WithEvents Text3 As TextBox
    Friend WithEvents Command4 As Button
End Class
