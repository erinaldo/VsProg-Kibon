<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadFlip
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadFlip))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.butCancelar = New System.Windows.Forms.Button()
        Me.txtDescr = New System.Windows.Forms.TextBox()
        Me.butSalvar = New System.Windows.Forms.Button()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.butNovo = New System.Windows.Forms.ToolStripButton()
        Me.butEditar = New System.Windows.Forms.ToolStripButton()
        Me.butApagar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.butSair = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridView = New System.Windows.Forms.DataGridView()
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTag = New System.Windows.Forms.TextBox()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butCancelar
        '
        Me.butCancelar.Enabled = False
        Me.butCancelar.Location = New System.Drawing.Point(282, 218)
        Me.butCancelar.Name = "butCancelar"
        Me.butCancelar.Size = New System.Drawing.Size(128, 27)
        Me.butCancelar.TabIndex = 9
        Me.butCancelar.Text = "Cancelar"
        Me.butCancelar.UseVisualStyleBackColor = True
        '
        'txtDescr
        '
        Me.txtDescr.Enabled = False
        Me.txtDescr.Location = New System.Drawing.Point(22, 92)
        Me.txtDescr.Multiline = True
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(533, 104)
        Me.txtDescr.TabIndex = 7
        '
        'butSalvar
        '
        Me.butSalvar.Enabled = False
        Me.butSalvar.Location = New System.Drawing.Point(148, 218)
        Me.butSalvar.Name = "butSalvar"
        Me.butSalvar.Size = New System.Drawing.Size(128, 27)
        Me.butSalvar.TabIndex = 8
        Me.butSalvar.Text = "Salvar"
        Me.butSalvar.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.butNovo, Me.butEditar, Me.butApagar, Me.ToolStripSeparator1, Me.butSair})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(599, 43)
        Me.ToolStrip1.TabIndex = 3
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 43)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.butCancelar)
        Me.GroupBox1.Controls.Add(Me.butSalvar)
        Me.GroupBox1.Controls.Add(Me.txtDescr)
        Me.GroupBox1.Controls.Add(Me.txtCodigo)
        Me.GroupBox1.Controls.Add(Me.txtTipo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 347)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(575, 251)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados do Flip"
        '
        'txtCodigo
        '
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(95, 43)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(77, 20)
        Me.txtCodigo.TabIndex = 5
        '
        'txtTipo
        '
        Me.txtTipo.Enabled = False
        Me.txtTipo.Location = New System.Drawing.Point(22, 43)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(67, 20)
        Me.txtTipo.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Descrição"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(92, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Codigo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tipo"
        '
        'GridView
        '
        Me.GridView.AllowUserToAddRows = False
        Me.GridView.AllowUserToDeleteRows = False
        Me.GridView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridView.ColumnHeadersHeight = 25
        Me.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTipo, Me.colDescr, Me.colCodigo})
        Me.GridView.Location = New System.Drawing.Point(0, 46)
        Me.GridView.Name = "GridView"
        Me.GridView.ReadOnly = True
        Me.GridView.RowHeadersWidth = 30
        Me.GridView.RowTemplate.Height = 50
        Me.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridView.Size = New System.Drawing.Size(599, 290)
        Me.GridView.TabIndex = 4
        '
        'colTipo
        '
        Me.colTipo.HeaderText = "Tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.ReadOnly = True
        Me.colTipo.Width = 80
        '
        'colDescr
        '
        Me.colDescr.HeaderText = "Descrição"
        Me.colDescr.Name = "colDescr"
        Me.colDescr.ReadOnly = True
        Me.colDescr.Width = 350
        '
        'colCodigo
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colCodigo.DefaultCellStyle = DataGridViewCellStyle1
        Me.colCodigo.HeaderText = "Codigo"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.ReadOnly = True
        '
        'txtTag
        '
        Me.txtTag.Enabled = False
        Me.txtTag.Location = New System.Drawing.Point(22, 43)
        Me.txtTag.Name = "txtTag"
        Me.txtTag.Size = New System.Drawing.Size(67, 20)
        Me.txtTag.TabIndex = 4
        '
        'frmCadFlip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 605)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCadFlip"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Flip"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butCancelar As System.Windows.Forms.Button
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents butSalvar As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents butNovo As System.Windows.Forms.ToolStripButton
    Friend WithEvents butEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents butApagar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butSair As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridView As System.Windows.Forms.DataGridView
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtTag As System.Windows.Forms.TextBox
End Class
