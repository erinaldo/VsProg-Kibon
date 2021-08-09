<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCadAreas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCadAreas))
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
        Me.chkIngred = New System.Windows.Forms.CheckBox()
        Me.chkPeso = New System.Windows.Forms.CheckBox()
        Me.chkBrix = New System.Windows.Forms.CheckBox()
        Me.txtLinx = New System.Windows.Forms.TextBox()
        Me.txtArea = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GridView = New System.Windows.Forms.DataGridView()
        Me.colArea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBrix = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colIngrd = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colPeso = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colLinx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butCancelar
        '
        Me.butCancelar.Enabled = False
        Me.butCancelar.Location = New System.Drawing.Point(325, 127)
        Me.butCancelar.Name = "butCancelar"
        Me.butCancelar.Size = New System.Drawing.Size(128, 27)
        Me.butCancelar.TabIndex = 9
        Me.butCancelar.Text = "Cancelar"
        Me.butCancelar.UseVisualStyleBackColor = True
        '
        'txtDescr
        '
        Me.txtDescr.Enabled = False
        Me.txtDescr.Location = New System.Drawing.Point(161, 43)
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(244, 20)
        Me.txtDescr.TabIndex = 7
        '
        'butSalvar
        '
        Me.butSalvar.Enabled = False
        Me.butSalvar.Location = New System.Drawing.Point(191, 127)
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
        Me.ToolStrip1.Size = New System.Drawing.Size(667, 43)
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
        Me.GroupBox1.Controls.Add(Me.chkIngred)
        Me.GroupBox1.Controls.Add(Me.chkPeso)
        Me.GroupBox1.Controls.Add(Me.chkBrix)
        Me.GroupBox1.Controls.Add(Me.butCancelar)
        Me.GroupBox1.Controls.Add(Me.butSalvar)
        Me.GroupBox1.Controls.Add(Me.txtDescr)
        Me.GroupBox1.Controls.Add(Me.txtLinx)
        Me.GroupBox1.Controls.Add(Me.txtArea)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 254)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(643, 172)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados da Area"
        '
        'chkIngred
        '
        Me.chkIngred.AutoSize = True
        Me.chkIngred.Enabled = False
        Me.chkIngred.Location = New System.Drawing.Point(423, 68)
        Me.chkIngred.Name = "chkIngred"
        Me.chkIngred.Size = New System.Drawing.Size(139, 17)
        Me.chkIngred.TabIndex = 12
        Me.chkIngred.Text = "Usa Ingrediente Manual"
        Me.chkIngred.UseVisualStyleBackColor = True
        '
        'chkPeso
        '
        Me.chkPeso.AutoSize = True
        Me.chkPeso.Enabled = False
        Me.chkPeso.Location = New System.Drawing.Point(423, 91)
        Me.chkPeso.Name = "chkPeso"
        Me.chkPeso.Size = New System.Drawing.Size(142, 17)
        Me.chkPeso.TabIndex = 11
        Me.chkPeso.Text = "Usa Peso de Referência"
        Me.chkPeso.UseVisualStyleBackColor = True
        '
        'chkBrix
        '
        Me.chkBrix.AutoSize = True
        Me.chkBrix.Enabled = False
        Me.chkBrix.Location = New System.Drawing.Point(423, 45)
        Me.chkBrix.Name = "chkBrix"
        Me.chkBrix.Size = New System.Drawing.Size(147, 17)
        Me.chkBrix.TabIndex = 10
        Me.chkBrix.Text = "Usa Planejamento de Brix"
        Me.chkBrix.UseVisualStyleBackColor = True
        '
        'txtLinx
        '
        Me.txtLinx.Enabled = False
        Me.txtLinx.Location = New System.Drawing.Point(22, 91)
        Me.txtLinx.Name = "txtLinx"
        Me.txtLinx.Size = New System.Drawing.Size(133, 20)
        Me.txtLinx.TabIndex = 6
        '
        'txtArea
        '
        Me.txtArea.Enabled = False
        Me.txtArea.Location = New System.Drawing.Point(22, 43)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(133, 20)
        Me.txtArea.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(158, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Descrição"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tópico RsLinx"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Area"
        '
        'GridView
        '
        Me.GridView.AllowUserToAddRows = False
        Me.GridView.AllowUserToDeleteRows = False
        Me.GridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colArea, Me.colDesc, Me.colBrix, Me.colIngrd, Me.colPeso, Me.colLinx})
        Me.GridView.Location = New System.Drawing.Point(0, 46)
        Me.GridView.Name = "GridView"
        Me.GridView.ReadOnly = True
        Me.GridView.RowHeadersVisible = False
        Me.GridView.RowHeadersWidth = 30
        Me.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridView.Size = New System.Drawing.Size(667, 202)
        Me.GridView.TabIndex = 4
        '
        'colArea
        '
        Me.colArea.HeaderText = "Area"
        Me.colArea.Name = "colArea"
        Me.colArea.ReadOnly = True
        Me.colArea.Width = 80
        '
        'colDesc
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colDesc.DefaultCellStyle = DataGridViewCellStyle1
        Me.colDesc.HeaderText = "Descrição"
        Me.colDesc.Name = "colDesc"
        Me.colDesc.ReadOnly = True
        Me.colDesc.Width = 140
        '
        'colBrix
        '
        Me.colBrix.HeaderText = "Usa Planej Brix"
        Me.colBrix.Name = "colBrix"
        Me.colBrix.ReadOnly = True
        Me.colBrix.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colBrix.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colBrix.Width = 110
        '
        'colIngrd
        '
        Me.colIngrd.HeaderText = "Usa Ingred Man"
        Me.colIngrd.Name = "colIngrd"
        Me.colIngrd.ReadOnly = True
        Me.colIngrd.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colIngrd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colIngrd.Width = 110
        '
        'colPeso
        '
        Me.colPeso.HeaderText = "Usa Peso Ref."
        Me.colPeso.Name = "colPeso"
        Me.colPeso.ReadOnly = True
        Me.colPeso.Width = 95
        '
        'colLinx
        '
        Me.colLinx.HeaderText = "Topico RsLinx"
        Me.colLinx.Name = "colLinx"
        Me.colLinx.ReadOnly = True
        Me.colLinx.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colLinx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colLinx.Width = 90
        '
        'frmCadAreas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 434)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GridView)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmCadAreas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cadastro de Areas"
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
    Friend WithEvents txtLinx As System.Windows.Forms.TextBox
    Friend WithEvents txtArea As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridView As System.Windows.Forms.DataGridView
    Friend WithEvents colArea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBrix As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colIngrd As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colPeso As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colLinx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkIngred As System.Windows.Forms.CheckBox
    Friend WithEvents chkPeso As System.Windows.Forms.CheckBox
    Friend WithEvents chkBrix As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
