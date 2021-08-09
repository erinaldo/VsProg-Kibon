<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelPtoCr
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.butCancela = New System.Windows.Forms.Button()
        Me.butOk = New System.Windows.Forms.Button()
        Me.PtoCrId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pergunta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PtoCrId, Me.Pergunta})
        Me.gvItens.Location = New System.Drawing.Point(-1, 2)
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(616, 340)
        Me.gvItens.TabIndex = 90
        '
        'UserId
        '
        Me.UserId.DataPropertyName = "UserId"
        Me.UserId.HeaderText = "UserId"
        Me.UserId.Name = "UserId"
        '
        'butCancela
        '
        Me.butCancela.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancela.Location = New System.Drawing.Point(334, 348)
        Me.butCancela.Name = "butCancela"
        Me.butCancela.Size = New System.Drawing.Size(138, 30)
        Me.butCancela.TabIndex = 92
        Me.butCancela.Text = "Cancela"
        Me.butCancela.UseVisualStyleBackColor = True
        '
        'butOk
        '
        Me.butOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.butOk.Location = New System.Drawing.Point(129, 348)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(138, 30)
        Me.butOk.TabIndex = 91
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'PtoCrId
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PtoCrId.DefaultCellStyle = DataGridViewCellStyle1
        Me.PtoCrId.HeaderText = "PtoCrId"
        Me.PtoCrId.Name = "PtoCrId"
        Me.PtoCrId.ReadOnly = True
        Me.PtoCrId.Width = 50
        '
        'Pergunta
        '
        Me.Pergunta.HeaderText = "Pergunta"
        Me.Pergunta.Name = "Pergunta"
        Me.Pergunta.ReadOnly = True
        Me.Pergunta.Width = 500
        '
        'frmSelPtoCr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 381)
        Me.Controls.Add(Me.gvItens)
        Me.Controls.Add(Me.butCancela)
        Me.Controls.Add(Me.butOk)
        Me.Name = "frmSelPtoCr"
        Me.Text = "frmSelPtoCr"
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents butCancela As System.Windows.Forms.Button
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents PtoCrId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pergunta As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
