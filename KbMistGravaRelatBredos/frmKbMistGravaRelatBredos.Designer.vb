<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKbMistGravaRelatBredos
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
        Me.dpDataIni = New System.Windows.Forms.DateTimePicker()
        Me.cmdRelat = New System.Windows.Forms.Button()
        Me.Cancela = New System.Windows.Forms.Button()
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.dpDataFim = New System.Windows.Forms.DateTimePicker()
        Me.txtHoraFim = New System.Windows.Forms.TextBox()
        Me.txtHoraIni = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblAvisoOp = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Frame1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dpDataIni
        '
        Me.dpDataIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDataIni.Location = New System.Drawing.Point(128, 24)
        Me.dpDataIni.Name = "dpDataIni"
        Me.dpDataIni.Size = New System.Drawing.Size(90, 20)
        Me.dpDataIni.TabIndex = 12
        '
        'cmdRelat
        '
        Me.cmdRelat.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRelat.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdRelat.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRelat.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRelat.Location = New System.Drawing.Point(49, 185)
        Me.cmdRelat.Name = "cmdRelat"
        Me.cmdRelat.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRelat.Size = New System.Drawing.Size(105, 25)
        Me.cmdRelat.TabIndex = 18
        Me.cmdRelat.Text = "Criar relatório"
        Me.cmdRelat.UseVisualStyleBackColor = False
        '
        'Cancela
        '
        Me.Cancela.BackColor = System.Drawing.SystemColors.Control
        Me.Cancela.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancela.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancela.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancela.Location = New System.Drawing.Point(225, 185)
        Me.Cancela.Name = "Cancela"
        Me.Cancela.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancela.Size = New System.Drawing.Size(105, 25)
        Me.Cancela.TabIndex = 17
        Me.Cancela.Text = "Cancelar"
        Me.Cancela.UseVisualStyleBackColor = False
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.dpDataFim)
        Me.Frame1.Controls.Add(Me.dpDataIni)
        Me.Frame1.Controls.Add(Me.txtHoraFim)
        Me.Frame1.Controls.Add(Me.txtHoraIni)
        Me.Frame1.Controls.Add(Me.Label2)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(33, 65)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(337, 105)
        Me.Frame1.TabIndex = 16
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Datas"
        '
        'dpDataFim
        '
        Me.dpDataFim.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpDataFim.Location = New System.Drawing.Point(127, 64)
        Me.dpDataFim.Name = "dpDataFim"
        Me.dpDataFim.Size = New System.Drawing.Size(90, 20)
        Me.dpDataFim.TabIndex = 13
        '
        'txtHoraFim
        '
        Me.txtHoraFim.AcceptsReturn = True
        Me.txtHoraFim.BackColor = System.Drawing.SystemColors.Window
        Me.txtHoraFim.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHoraFim.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraFim.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHoraFim.Location = New System.Drawing.Point(224, 64)
        Me.txtHoraFim.MaxLength = 0
        Me.txtHoraFim.Name = "txtHoraFim"
        Me.txtHoraFim.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHoraFim.Size = New System.Drawing.Size(89, 20)
        Me.txtHoraFim.TabIndex = 11
        Me.txtHoraFim.Text = "00:00:00"
        Me.txtHoraFim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHoraIni
        '
        Me.txtHoraIni.AcceptsReturn = True
        Me.txtHoraIni.BackColor = System.Drawing.SystemColors.Window
        Me.txtHoraIni.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHoraIni.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraIni.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHoraIni.Location = New System.Drawing.Point(224, 24)
        Me.txtHoraIni.MaxLength = 0
        Me.txtHoraIni.Name = "txtHoraIni"
        Me.txtHoraIni.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHoraIni.Size = New System.Drawing.Size(89, 20)
        Me.txtHoraIni.TabIndex = 10
        Me.txtHoraIni.Text = "00:00:00"
        Me.txtHoraIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Data Final"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Data Inicial"
        '
        'lblAvisoOp
        '
        Me.lblAvisoOp.BackColor = System.Drawing.SystemColors.Control
        Me.lblAvisoOp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAvisoOp.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvisoOp.ForeColor = System.Drawing.Color.Red
        Me.lblAvisoOp.Location = New System.Drawing.Point(25, 33)
        Me.lblAvisoOp.Name = "lblAvisoOp"
        Me.lblAvisoOp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAvisoOp.Size = New System.Drawing.Size(305, 25)
        Me.lblAvisoOp.TabIndex = 19
        Me.lblAvisoOp.Text = "Aguarde: O relatório está sendo gerado."
        Me.lblAvisoOp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblAvisoOp.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(33, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(297, 25)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "RELATÓRIO DOS BREDOS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmMistGravaRelatBredos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 219)
        Me.Controls.Add(Me.cmdRelat)
        Me.Controls.Add(Me.Cancela)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.lblAvisoOp)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmMistGravaRelatBredos"
        Me.Text = "RELATÓRIO DOS BREDOS"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dpDataIni As System.Windows.Forms.DateTimePicker
    Public WithEvents cmdRelat As System.Windows.Forms.Button
    Public WithEvents Cancela As System.Windows.Forms.Button
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Friend WithEvents dpDataFim As System.Windows.Forms.DateTimePicker
    Public WithEvents txtHoraFim As System.Windows.Forms.TextBox
    Public WithEvents txtHoraIni As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents lblAvisoOp As System.Windows.Forms.Label
    Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents Label1 As System.Windows.Forms.Label

End Class
