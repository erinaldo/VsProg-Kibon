<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadAlerg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadAlerg))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.butNovo = New System.Windows.Forms.ToolStripButton()
        Me.butEditar = New System.Windows.Forms.ToolStripButton()
        Me.butApagar = New System.Windows.Forms.ToolStripButton()
        Me.butSair = New System.Windows.Forms.ToolStripButton()
        Me.gvItens = New System.Windows.Forms.DataGridView()
        Me.CodAlerg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Letra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butNovo, Me.butEditar, Me.butApagar, Me.butSair})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(468, 43)
        Me.ToolStrip1.TabIndex = 11
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'butNovo
        '
        Me.butNovo.AutoSize = False
        Me.butNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butNovo.Image = CType(resources.GetObject("butNovo.Image"), System.Drawing.Image)
        Me.butNovo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butNovo.Name = "butNovo"
        Me.butNovo.Size = New System.Drawing.Size(40, 40)
        Me.butNovo.Text = "Novo"
        '
        'butEditar
        '
        Me.butEditar.AutoSize = False
        Me.butEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butEditar.Image = CType(resources.GetObject("butEditar.Image"), System.Drawing.Image)
        Me.butEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butEditar.Name = "butEditar"
        Me.butEditar.Size = New System.Drawing.Size(40, 40)
        Me.butEditar.Text = "Editar selecionado"
        '
        'butApagar
        '
        Me.butApagar.AutoSize = False
        Me.butApagar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butApagar.Image = CType(resources.GetObject("butApagar.Image"), System.Drawing.Image)
        Me.butApagar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butApagar.Name = "butApagar"
        Me.butApagar.Size = New System.Drawing.Size(40, 40)
        Me.butApagar.Text = "Apagar selecionado"
        '
        'butSair
        '
        Me.butSair.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.butSair.AutoSize = False
        Me.butSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butSair.Image = CType(resources.GetObject("butSair.Image"), System.Drawing.Image)
        Me.butSair.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butSair.Name = "butSair"
        Me.butSair.Size = New System.Drawing.Size(40, 40)
        Me.butSair.Text = "Sair"
        '
        'gvItens
        '
        Me.gvItens.AllowUserToAddRows = False
        Me.gvItens.AllowUserToDeleteRows = False
        Me.gvItens.AllowUserToResizeColumns = False
        Me.gvItens.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gvItens.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.gvItens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvItens.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodAlerg, Me.Nome, Me.Letra})
        Me.gvItens.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvItens.Location = New System.Drawing.Point(0, 43)
        Me.gvItens.MultiSelect = False
        Me.gvItens.Name = "gvItens"
        Me.gvItens.ReadOnly = True
        Me.gvItens.RowHeadersVisible = False
        Me.gvItens.RowHeadersWidth = 30
        Me.gvItens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvItens.Size = New System.Drawing.Size(468, 511)
        Me.gvItens.TabIndex = 12
        '
        'CodAlerg
        '
        Me.CodAlerg.HeaderText = "CodAlerg"
        Me.CodAlerg.Name = "CodAlerg"
        Me.CodAlerg.ReadOnly = True
        Me.CodAlerg.Visible = False
        '
        'Nome
        '
        Me.Nome.HeaderText = "Nome"
        Me.Nome.Name = "Nome"
        Me.Nome.ReadOnly = True
        Me.Nome.Width = 250
        '
        'Letra
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.RosyBrown
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Letra.DefaultCellStyle = DataGridViewCellStyle2
        Me.Letra.HeaderText = "Letra"
        Me.Letra.Name = "Letra"
        Me.Letra.ReadOnly = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 532)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(468, 22)
        Me.StatusStrip1.TabIndex = 13
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'frmCadAlerg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(468, 554)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gvItens)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCadAlerg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alergënicos"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gvItens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents butNovo As System.Windows.Forms.ToolStripButton
    Friend WithEvents butEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents butApagar As System.Windows.Forms.ToolStripButton
    Friend WithEvents butSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents gvItens As System.Windows.Forms.DataGridView
    Friend WithEvents CodAlerg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nome As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Letra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
End Class
