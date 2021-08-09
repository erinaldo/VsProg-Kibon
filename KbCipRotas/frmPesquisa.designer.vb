<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPesquisa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPesquisa))
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.butOk = New System.Windows.Forms.Button()
        Me.colTagValv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.AllowUserToResizeRows = False
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTagValv})
        Me.gvItens.Location = New System.Drawing.Point(16, 38)
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.RowHeadersWidth = 20
        Me.gvItens.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(256, 367)
        Me.gvItens.TabIndex = 0
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(48, 12)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(224, 20)
        Me.txtFiltro.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filtro"
        '
        'butOk
        '
        Me.butOk.Location = New System.Drawing.Point(59, 411)
        Me.butOk.Name = "butOk"
        Me.butOk.Size = New System.Drawing.Size(173, 36)
        Me.butOk.TabIndex = 3
        Me.butOk.Text = "Ok"
        Me.butOk.UseVisualStyleBackColor = True
        '
        'colTagValv
        '
        Me.colTagValv.HeaderText = "Tag"
        Me.colTagValv.Name = "colTagValv"
        Me.colTagValv.ReadOnly = True
        Me.colTagValv.Width = 180
        '
        'frmPesquisa
        '
        Me.AcceptButton = Me.butOk
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(285, 457)
        Me.Controls.Add(Me.gvItens)
        Me.Controls.Add(Me.butOk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtFiltro)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPesquisa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pesquisa Rápida"
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents txtFiltro As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents butOk As System.Windows.Forms.Button
    Friend WithEvents colTagValv As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
