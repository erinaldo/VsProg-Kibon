<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelDataHora
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
        Me.mcCalend = New System.Windows.Forms.MonthCalendar
        Me.txtDataHora = New System.Windows.Forms.MaskedTextBox
        Me.butOk = New System.Windows.Forms.Button
        Me.butCancela = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'mcCalend
        '
        Me.mcCalend.Location = New System.Drawing.Point(6, 6)
        Me.mcCalend.Name = "mcCalend"
        Me.mcCalend.TabIndex = 0
        '
        'txtDataHora
        '
        Me.txtDataHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataHora.Location = New System.Drawing.Point(6, 173)
        Me.txtDataHora.Mask = "00/00/0000 00:00:00"
        Me.txtDataHora.Name = "txtDataHora"
        Me.txtDataHora.Size = New System.Drawing.Size(178, 24)
        Me.txtDataHora.TabIndex = 1
        Me.txtDataHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'butOk
        '
        Me.butOk.Location = New System.Drawing.Point(6, 231)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(80, 23)
        Me.butOk.TabIndex = 2
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'butCancela
        '
        Me.butCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancela.Location = New System.Drawing.Point(104, 231)
        Me.butCancela.Name = "butCancela"
        Me.butCancela.Size = New System.Drawing.Size(80, 23)
        Me.butCancela.TabIndex = 3
        Me.butCancela.Text = "Cancela"
        Me.butCancela.UseVisualStyleBackColor = True
        '
        'frmSelDataHora
        '
        Me.AcceptButton = Me.butOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancela
        Me.ClientSize = New System.Drawing.Size(192, 266)
        Me.Controls.Add(Me.butCancela)
        Me.Controls.Add(Me.butOk)
        Me.Controls.Add(Me.txtDataHora)
        Me.Controls.Add(Me.mcCalend)
        Me.Name = "frmSelDataHora"
        Me.Text = "frmSelData"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mcCalend As System.Windows.Forms.MonthCalendar
    Friend WithEvents txtDataHora As System.Windows.Forms.MaskedTextBox
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents butCancela As System.Windows.Forms.Button
End Class
