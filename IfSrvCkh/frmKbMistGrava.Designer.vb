<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKbMistGrava
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
        Me.txtDataHora = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tmrPoll = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'txtDataHora
        '
        Me.txtDataHora.AcceptsReturn = True
        Me.txtDataHora.BackColor = System.Drawing.SystemColors.Window
        Me.txtDataHora.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDataHora.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDataHora.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDataHora.Location = New System.Drawing.Point(24, 55)
        Me.txtDataHora.MaxLength = 0
        Me.txtDataHora.Name = "txtDataHora"
        Me.txtDataHora.ReadOnly = True
        Me.txtDataHora.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDataHora.Size = New System.Drawing.Size(265, 20)
        Me.txtDataHora.TabIndex = 5
        Me.txtDataHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(105, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 24)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "MistGrava"
        '
        'tmrPoll
        '
        Me.tmrPoll.Interval = 1000
        '
        'frmMistGrava
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(315, 106)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDataHora)
        Me.Name = "frmMistGrava"
        Me.Text = "Grava dados de producao"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents txtDataHora As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tmrPoll As System.Windows.Forms.Timer

End Class
