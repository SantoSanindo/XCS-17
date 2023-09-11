<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Reprint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Reprint))
        Me.cmdback = New System.Windows.Forms.Button()
        Me.cmd_loadprintlist = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Image3 = New System.Windows.Forms.PictureBox()
        Me.List1 = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Text1 = New System.Windows.Forms.TextBox()
        Me.Option1 = New System.Windows.Forms.RadioButton()
        Me.Option2 = New System.Windows.Forms.RadioButton()
        Me.Option3 = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.Image3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdback
        '
        Me.cmdback.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdback.Image = CType(resources.GetObject("cmdback.Image"), System.Drawing.Image)
        Me.cmdback.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdback.Location = New System.Drawing.Point(916, 519)
        Me.cmdback.Name = "cmdback"
        Me.cmdback.Size = New System.Drawing.Size(88, 57)
        Me.cmdback.TabIndex = 5
        Me.cmdback.Text = "Back"
        Me.cmdback.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdback.UseVisualStyleBackColor = True
        '
        'cmd_loadprintlist
        '
        Me.cmd_loadprintlist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd_loadprintlist.Image = CType(resources.GetObject("cmd_loadprintlist.Image"), System.Drawing.Image)
        Me.cmd_loadprintlist.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmd_loadprintlist.Location = New System.Drawing.Point(822, 519)
        Me.cmd_loadprintlist.Name = "cmd_loadprintlist"
        Me.cmd_loadprintlist.Size = New System.Drawing.Size(88, 57)
        Me.cmd_loadprintlist.TabIndex = 6
        Me.cmd_loadprintlist.Text = "Load"
        Me.cmd_loadprintlist.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmd_loadprintlist.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(547, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(457, 201)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Message"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Option3)
        Me.GroupBox2.Controls.Add(Me.Option2)
        Me.GroupBox2.Controls.Add(Me.Option1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 502)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(529, 82)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Label Type"
        '
        'Image3
        '
        Me.Image3.Location = New System.Drawing.Point(547, 219)
        Me.Image3.Name = "Image3"
        Me.Image3.Size = New System.Drawing.Size(457, 277)
        Me.Image3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Image3.TabIndex = 9
        Me.Image3.TabStop = False
        '
        'List1
        '
        Me.List1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List1.FormattingEnabled = True
        Me.List1.ItemHeight = 16
        Me.List1.Location = New System.Drawing.Point(12, 12)
        Me.List1.Name = "List1"
        Me.List1.Size = New System.Drawing.Size(529, 484)
        Me.List1.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(425, 161)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Please load the print list of your desired work week by clicking the <Load> butto" &
    "n."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(562, 519)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 20)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Specified QTY"
        Me.Label2.Visible = False
        '
        'Text1
        '
        Me.Text1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text1.Location = New System.Drawing.Point(567, 550)
        Me.Text1.Name = "Text1"
        Me.Text1.Size = New System.Drawing.Size(100, 26)
        Me.Text1.TabIndex = 12
        Me.Text1.Visible = False
        '
        'Option1
        '
        Me.Option1.AutoSize = True
        Me.Option1.Location = New System.Drawing.Point(38, 33)
        Me.Option1.Name = "Option1"
        Me.Option1.Size = New System.Drawing.Size(77, 24)
        Me.Option1.TabIndex = 0
        Me.Option1.TabStop = True
        Me.Option1.Text = "Unitary"
        Me.Option1.UseVisualStyleBackColor = True
        '
        'Option2
        '
        Me.Option2.AutoSize = True
        Me.Option2.Location = New System.Drawing.Point(175, 33)
        Me.Option2.Name = "Option2"
        Me.Option2.Size = New System.Drawing.Size(126, 24)
        Me.Option2.TabIndex = 1
        Me.Option2.TabStop = True
        Me.Option2.Text = "S02 Standard"
        Me.Option2.UseVisualStyleBackColor = True
        '
        'Option3
        '
        Me.Option3.AutoSize = True
        Me.Option3.Location = New System.Drawing.Point(361, 33)
        Me.Option3.Name = "Option3"
        Me.Option3.Size = New System.Drawing.Size(126, 24)
        Me.Option3.TabIndex = 2
        Me.Option3.TabStop = True
        Me.Option3.Text = "S02 Specified"
        Me.Option3.UseVisualStyleBackColor = True
        '
        'frm_Reprint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 596)
        Me.ControlBox = False
        Me.Controls.Add(Me.Text1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.List1)
        Me.Controls.Add(Me.Image3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmd_loadprintlist)
        Me.Controls.Add(Me.cmdback)
        Me.Name = "frm_Reprint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Re Print Feature"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.Image3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdback As Button
    Friend WithEvents cmd_loadprintlist As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Image3 As PictureBox
    Friend WithEvents List1 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Text1 As TextBox
    Friend WithEvents Option3 As RadioButton
    Friend WithEvents Option2 As RadioButton
    Friend WithEvents Option1 As RadioButton
End Class
