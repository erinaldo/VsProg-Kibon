<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelBloco
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelBloco))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.butCancela = New System.Windows.Forms.Button()
        Me.butOk = New System.Windows.Forms.Button()
        Me.dgBlocos = New System.Windows.Forms.DataGridView()
        Me.ilBlks = New System.Windows.Forms.ImageList(Me.components)
        Me.Blk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Icone = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Descr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgBlocos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butCancela
        '
        Me.butCancela.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.butCancela.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancela.Location = New System.Drawing.Point(272, 344)
        Me.butCancela.Name = "butCancela"
        Me.butCancela.Size = New System.Drawing.Size(144, 37)
        Me.butCancela.TabIndex = 26
        Me.butCancela.Text = "Fecha"
        Me.butCancela.UseVisualStyleBackColor = True
        '
        'butOk
        '
        Me.butOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.butOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.butOk.Location = New System.Drawing.Point(74, 344)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(144, 37)
        Me.butOk.TabIndex = 25
        Me.butOk.Text = "Inserir novo bloco"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'dgBlocos
        '
        Me.dgBlocos.AllowUserToAddRows = False
        Me.dgBlocos.AllowUserToDeleteRows = False
        Me.dgBlocos.AllowUserToResizeRows = False
        Me.dgBlocos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgBlocos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgBlocos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Blk, Me.Icone, Me.Descr})
        Me.dgBlocos.Location = New System.Drawing.Point(12, 12)
        Me.dgBlocos.MultiSelect = False
        Me.dgBlocos.Name = "dgBlocos"
        Me.dgBlocos.ReadOnly = True
        Me.dgBlocos.RowHeadersVisible = False
        Me.dgBlocos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgBlocos.Size = New System.Drawing.Size(470, 321)
        Me.dgBlocos.TabIndex = 27
        '
        'ilBlks
        '
        Me.ilBlks.ImageStream = CType(resources.GetObject("ilBlks.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilBlks.TransparentColor = System.Drawing.Color.Black
        Me.ilBlks.Images.SetKeyName(0, "BlkDefault.png")
        '
        'Blk
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Blk.DefaultCellStyle = DataGridViewCellStyle1
        Me.Blk.HeaderText = "Blk"
        Me.Blk.Name = "Blk"
        Me.Blk.ReadOnly = True
        Me.Blk.Width = 30
        '
        'Icone
        '
        Me.Icone.HeaderText = "Icone"
        Me.Icone.Name = "Icone"
        Me.Icone.ReadOnly = True
        Me.Icone.Width = 30
        '
        'Descr
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Descr.DefaultCellStyle = DataGridViewCellStyle2
        Me.Descr.HeaderText = "Descr"
        Me.Descr.Name = "Descr"
        Me.Descr.ReadOnly = True
        Me.Descr.Width = 370
        '
        'frmSelBloco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(494, 393)
        Me.Controls.Add(Me.butCancela)
        Me.Controls.Add(Me.butOk)
        Me.Controls.Add(Me.dgBlocos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelBloco"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selecione o Bloco"
        CType(Me.dgBlocos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents butCancela As System.Windows.Forms.Button
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents dgBlocos As System.Windows.Forms.DataGridView
    Friend WithEvents ilBlks As System.Windows.Forms.ImageList
    Friend WithEvents Blk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Icone As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Descr As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
