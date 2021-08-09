<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKbImprimeRecPreench
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
        Me.botCancela = New System.Windows.Forms.Button()
        Me.lblAviso1 = New System.Windows.Forms.Label()
        Me.lblAviso2 = New System.Windows.Forms.Label()
        Me.tmrRel = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'botCancela
        '
        Me.botCancela.BackColor = System.Drawing.SystemColors.Control
        Me.botCancela.Cursor = System.Windows.Forms.Cursors.Default
        Me.botCancela.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.botCancela.ForeColor = System.Drawing.SystemColors.ControlText
        Me.botCancela.Location = New System.Drawing.Point(177, 53)
        Me.botCancela.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.botCancela.Name = "botCancela"
        Me.botCancela.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.botCancela.Size = New System.Drawing.Size(140, 41)
        Me.botCancela.TabIndex = 3
        Me.botCancela.Text = "Cancela"
        Me.botCancela.UseVisualStyleBackColor = False
        '
        'lblAviso1
        '
        Me.lblAviso1.BackColor = System.Drawing.SystemColors.Control
        Me.lblAviso1.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAviso1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAviso1.ForeColor = System.Drawing.Color.Red
        Me.lblAviso1.Location = New System.Drawing.Point(28, 14)
        Me.lblAviso1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAviso1.Name = "lblAviso1"
        Me.lblAviso1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAviso1.Size = New System.Drawing.Size(119, 31)
        Me.lblAviso1.TabIndex = 5
        Me.lblAviso1.Text = "Aguarde!"
        Me.lblAviso1.Visible = False
        '
        'lblAviso2
        '
        Me.lblAviso2.BackColor = System.Drawing.SystemColors.Control
        Me.lblAviso2.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAviso2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAviso2.ForeColor = System.Drawing.Color.Red
        Me.lblAviso2.Location = New System.Drawing.Point(156, 14)
        Me.lblAviso2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAviso2.Name = "lblAviso2"
        Me.lblAviso2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAviso2.Size = New System.Drawing.Size(332, 31)
        Me.lblAviso2.TabIndex = 4
        Me.lblAviso2.Text = "O relatorio esta sendo gerado!"
        Me.lblAviso2.Visible = False
        '
        'tmrRel
        '
        Me.tmrRel.Interval = 1000
        '
        'frmKbImprimeRecPreench
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(516, 107)
        Me.Controls.Add(Me.botCancela)
        Me.Controls.Add(Me.lblAviso1)
        Me.Controls.Add(Me.lblAviso2)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmKbImprimeRecPreench"
        Me.Text = "Cadastro de receita"
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents botCancela As System.Windows.Forms.Button
    Public WithEvents lblAviso1 As System.Windows.Forms.Label
    Public WithEvents lblAviso2 As System.Windows.Forms.Label
    Friend WithEvents tmrRel As System.Windows.Forms.Timer
End Class
