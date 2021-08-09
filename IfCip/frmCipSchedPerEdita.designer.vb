<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCipSchedPerEdita
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCipSchedPerEdita))
        Me.txtPerId = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbMesDisp = New System.Windows.Forms.ListBox()
        Me.lbMes = New System.Windows.Forms.ListBox()
        Me.lbSem = New System.Windows.Forms.ListBox()
        Me.lbSemDisp = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.butMesAdd = New System.Windows.Forms.Button()
        Me.butMesRem = New System.Windows.Forms.Button()
        Me.butSemRem = New System.Windows.Forms.Button()
        Me.butSemAdd = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.butFechar = New System.Windows.Forms.Button()
        Me.ilButtons = New System.Windows.Forms.ImageList(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtPerId
        '
        Me.txtPerId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPerId.Location = New System.Drawing.Point(56, 12)
        Me.txtPerId.Name = "txtPerId"
        Me.txtPerId.Size = New System.Drawing.Size(58, 26)
        Me.txtPerId.TabIndex = 42
        Me.txtPerId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "PerId"
        '
        'lbMesDisp
        '
        Me.lbMesDisp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMesDisp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMesDisp.FormattingEnabled = True
        Me.lbMesDisp.ItemHeight = 20
        Me.lbMesDisp.Location = New System.Drawing.Point(22, 108)
        Me.lbMesDisp.Name = "lbMesDisp"
        Me.lbMesDisp.Size = New System.Drawing.Size(92, 264)
        Me.lbMesDisp.TabIndex = 45
        '
        'lbMes
        '
        Me.lbMes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbMes.FormattingEnabled = True
        Me.lbMes.ItemHeight = 20
        Me.lbMes.Location = New System.Drawing.Point(201, 108)
        Me.lbMes.Name = "lbMes"
        Me.lbMes.Size = New System.Drawing.Size(92, 264)
        Me.lbMes.TabIndex = 46
        '
        'lbSem
        '
        Me.lbSem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbSem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSem.FormattingEnabled = True
        Me.lbSem.ItemHeight = 20
        Me.lbSem.Location = New System.Drawing.Point(528, 108)
        Me.lbSem.Name = "lbSem"
        Me.lbSem.Size = New System.Drawing.Size(92, 264)
        Me.lbSem.TabIndex = 48
        '
        'lbSemDisp
        '
        Me.lbSemDisp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbSemDisp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSemDisp.FormattingEnabled = True
        Me.lbSemDisp.ItemHeight = 20
        Me.lbSemDisp.Location = New System.Drawing.Point(349, 108)
        Me.lbSemDisp.Name = "lbSemDisp"
        Me.lbSemDisp.Size = New System.Drawing.Size(92, 264)
        Me.lbSemDisp.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(107, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 17)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Dias do Mês"
        '
        'butMesAdd
        '
        Me.butMesAdd.Location = New System.Drawing.Point(120, 181)
        Me.butMesAdd.Name = "butMesAdd"
        Me.butMesAdd.Size = New System.Drawing.Size(75, 23)
        Me.butMesAdd.TabIndex = 50
        Me.butMesAdd.Text = ">>"
        Me.butMesAdd.UseVisualStyleBackColor = True
        '
        'butMesRem
        '
        Me.butMesRem.Location = New System.Drawing.Point(120, 266)
        Me.butMesRem.Name = "butMesRem"
        Me.butMesRem.Size = New System.Drawing.Size(75, 23)
        Me.butMesRem.TabIndex = 51
        Me.butMesRem.Text = "<<"
        Me.butMesRem.UseVisualStyleBackColor = True
        '
        'butSemRem
        '
        Me.butSemRem.Location = New System.Drawing.Point(447, 266)
        Me.butSemRem.Name = "butSemRem"
        Me.butSemRem.Size = New System.Drawing.Size(75, 23)
        Me.butSemRem.TabIndex = 53
        Me.butSemRem.Text = "<<"
        Me.butSemRem.UseVisualStyleBackColor = True
        '
        'butSemAdd
        '
        Me.butSemAdd.Location = New System.Drawing.Point(447, 181)
        Me.butSemAdd.Name = "butSemAdd"
        Me.butSemAdd.Size = New System.Drawing.Size(75, 23)
        Me.butSemAdd.TabIndex = 52
        Me.butSemAdd.Text = ">>"
        Me.butSemAdd.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(429, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 17)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Dias da semana"
        '
        'butFechar
        '
        Me.butFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butFechar.ImageIndex = 0
        Me.butFechar.ImageList = Me.ilButtons
        Me.butFechar.Location = New System.Drawing.Point(634, 12)
        Me.butFechar.Name = "butFechar"
        Me.butFechar.Size = New System.Drawing.Size(49, 46)
        Me.butFechar.TabIndex = 55
        Me.butFechar.UseVisualStyleBackColor = True
        '
        'ilButtons
        '
        Me.ilButtons.ImageStream = CType(resources.GetObject("ilButtons.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilButtons.TransparentColor = System.Drawing.Color.Magenta
        Me.ilButtons.Images.SetKeyName(0, "Bot16x16Sair.bmp")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(32, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Disponíveis"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(209, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 57
        Me.Label8.Text = "Selecionados"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(538, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Selecionados"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(361, 92)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 58
        Me.Label10.Text = "Disponíveis"
        '
        'frmCipSchedPerEdita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butFechar
        Me.ClientSize = New System.Drawing.Size(695, 386)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.butFechar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.butSemRem)
        Me.Controls.Add(Me.butSemAdd)
        Me.Controls.Add(Me.butMesRem)
        Me.Controls.Add(Me.butMesAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbSem)
        Me.Controls.Add(Me.lbSemDisp)
        Me.Controls.Add(Me.lbMes)
        Me.Controls.Add(Me.lbMesDisp)
        Me.Controls.Add(Me.txtPerId)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCipSchedPerEdita"
        Me.Text = "Edita Cip Periódico"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPerId As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbMesDisp As System.Windows.Forms.ListBox
    Friend WithEvents lbMes As System.Windows.Forms.ListBox
    Friend WithEvents lbSem As System.Windows.Forms.ListBox
    Friend WithEvents lbSemDisp As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents butMesAdd As System.Windows.Forms.Button
    Friend WithEvents butMesRem As System.Windows.Forms.Button
    Friend WithEvents butSemRem As System.Windows.Forms.Button
    Friend WithEvents butSemAdd As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents butFechar As System.Windows.Forms.Button
    Friend WithEvents ilButtons As System.Windows.Forms.ImageList
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
