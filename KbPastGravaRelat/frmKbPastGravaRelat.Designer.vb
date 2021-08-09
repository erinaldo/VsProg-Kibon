<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKbPastGravaRelat
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
        Me.Frame1 = New System.Windows.Forms.GroupBox()
        Me.butSelProd = New System.Windows.Forms.Button()
        Me.txtHistId = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.butRelatProd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Cancela = New System.Windows.Forms.Button()
        Me.lblAvisoOp = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.butSelCip = New System.Windows.Forms.Button()
        Me.txtCipId = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.butRelatCip = New System.Windows.Forms.Button()
        Me.Frame1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Frame1
        '
        Me.Frame1.BackColor = System.Drawing.SystemColors.Control
        Me.Frame1.Controls.Add(Me.butSelProd)
        Me.Frame1.Controls.Add(Me.txtHistId)
        Me.Frame1.Controls.Add(Me.Label3)
        Me.Frame1.Controls.Add(Me.butRelatProd)
        Me.Frame1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Frame1.Location = New System.Drawing.Point(17, 64)
        Me.Frame1.Name = "Frame1"
        Me.Frame1.Padding = New System.Windows.Forms.Padding(0)
        Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Frame1.Size = New System.Drawing.Size(297, 138)
        Me.Frame1.TabIndex = 6
        Me.Frame1.TabStop = False
        Me.Frame1.Text = "Relatório de produção"
        '
        'butSelProd
        '
        Me.butSelProd.BackColor = System.Drawing.SystemColors.Control
        Me.butSelProd.Cursor = System.Windows.Forms.Cursors.Default
        Me.butSelProd.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSelProd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butSelProd.Image = Global.KbPastGravaRelat.My.Resources.Resources.document_view
        Me.butSelProd.Location = New System.Drawing.Point(247, 35)
        Me.butSelProd.Name = "butSelProd"
        Me.butSelProd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.butSelProd.Size = New System.Drawing.Size(37, 42)
        Me.butSelProd.TabIndex = 8
        Me.butSelProd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.butSelProd.UseVisualStyleBackColor = False
        '
        'txtHistId
        '
        Me.txtHistId.AcceptsReturn = True
        Me.txtHistId.BackColor = System.Drawing.SystemColors.Window
        Me.txtHistId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHistId.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHistId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtHistId.Location = New System.Drawing.Point(127, 41)
        Me.txtHistId.MaxLength = 0
        Me.txtHistId.Name = "txtHistId"
        Me.txtHistId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtHistId.Size = New System.Drawing.Size(113, 26)
        Me.txtHistId.TabIndex = 7
        Me.txtHistId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(24, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(97, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Identificação"
        '
        'butRelatProd
        '
        Me.butRelatProd.BackColor = System.Drawing.SystemColors.Control
        Me.butRelatProd.Cursor = System.Windows.Forms.Cursors.Default
        Me.butRelatProd.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butRelatProd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butRelatProd.Location = New System.Drawing.Point(16, 86)
        Me.butRelatProd.Name = "butRelatProd"
        Me.butRelatProd.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.butRelatProd.Size = New System.Drawing.Size(268, 35)
        Me.butRelatProd.TabIndex = 8
        Me.butRelatProd.Text = "Criar relatório de Produção"
        Me.butRelatProd.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(17, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(297, 25)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Relatório de Pasteurização"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Cancela
        '
        Me.Cancela.BackColor = System.Drawing.SystemColors.Control
        Me.Cancela.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancela.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cancela.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cancela.Location = New System.Drawing.Point(33, 379)
        Me.Cancela.Name = "Cancela"
        Me.Cancela.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cancela.Size = New System.Drawing.Size(268, 25)
        Me.Cancela.TabIndex = 7
        Me.Cancela.Text = "Fechar"
        Me.Cancela.UseVisualStyleBackColor = False
        '
        'lblAvisoOp
        '
        Me.lblAvisoOp.BackColor = System.Drawing.SystemColors.Control
        Me.lblAvisoOp.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblAvisoOp.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvisoOp.ForeColor = System.Drawing.Color.Red
        Me.lblAvisoOp.Location = New System.Drawing.Point(9, 32)
        Me.lblAvisoOp.Name = "lblAvisoOp"
        Me.lblAvisoOp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblAvisoOp.Size = New System.Drawing.Size(305, 25)
        Me.lblAvisoOp.TabIndex = 9
        Me.lblAvisoOp.Text = "Aguarde: O relatório está sendo gerado."
        Me.lblAvisoOp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblAvisoOp.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.butSelCip)
        Me.GroupBox1.Controls.Add(Me.txtCipId)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.butRelatCip)
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(17, 219)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(297, 138)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Relatório de CIP"
        '
        'butSelCip
        '
        Me.butSelCip.BackColor = System.Drawing.SystemColors.Control
        Me.butSelCip.Cursor = System.Windows.Forms.Cursors.Default
        Me.butSelCip.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSelCip.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butSelCip.Image = Global.KbPastGravaRelat.My.Resources.Resources.document_view
        Me.butSelCip.Location = New System.Drawing.Point(247, 35)
        Me.butSelCip.Name = "butSelCip"
        Me.butSelCip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.butSelCip.Size = New System.Drawing.Size(37, 42)
        Me.butSelCip.TabIndex = 8
        Me.butSelCip.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.butSelCip.UseVisualStyleBackColor = False
        '
        'txtCipId
        '
        Me.txtCipId.AcceptsReturn = True
        Me.txtCipId.BackColor = System.Drawing.SystemColors.Window
        Me.txtCipId.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCipId.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCipId.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtCipId.Location = New System.Drawing.Point(127, 41)
        Me.txtCipId.MaxLength = 0
        Me.txtCipId.Name = "txtCipId"
        Me.txtCipId.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtCipId.Size = New System.Drawing.Size(113, 26)
        Me.txtCipId.TabIndex = 7
        Me.txtCipId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(97, 17)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Identificação"
        '
        'butRelatCip
        '
        Me.butRelatCip.BackColor = System.Drawing.SystemColors.Control
        Me.butRelatCip.Cursor = System.Windows.Forms.Cursors.Default
        Me.butRelatCip.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butRelatCip.ForeColor = System.Drawing.SystemColors.ControlText
        Me.butRelatCip.Location = New System.Drawing.Point(16, 86)
        Me.butRelatCip.Name = "butRelatCip"
        Me.butRelatCip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.butRelatCip.Size = New System.Drawing.Size(268, 35)
        Me.butRelatCip.TabIndex = 8
        Me.butRelatCip.Text = "Criar relatório de CIP"
        Me.butRelatCip.UseVisualStyleBackColor = False
        '
        'frmKbPastGravaRelat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 418)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Frame1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Cancela)
        Me.Controls.Add(Me.lblAvisoOp)
        Me.Name = "frmKbPastGravaRelat"
        Me.Text = "Relatório de Pasteurização"
        Me.Frame1.ResumeLayout(False)
        Me.Frame1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents Frame1 As System.Windows.Forms.GroupBox
    Public WithEvents butSelProd As System.Windows.Forms.Button
    Public WithEvents txtHistId As System.Windows.Forms.TextBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Cancela As System.Windows.Forms.Button
    Public WithEvents butRelatProd As System.Windows.Forms.Button
    Public WithEvents lblAvisoOp As System.Windows.Forms.Label
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Public WithEvents butSelCip As System.Windows.Forms.Button
    Public WithEvents txtCipId As System.Windows.Forms.TextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents butRelatCip As System.Windows.Forms.Button

End Class
