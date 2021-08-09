<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRotaEdita
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRotaEdita))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtDescr = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTq3 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRotaId = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTq1 = New System.Windows.Forms.ComboBox()
        Me.cmbTq2 = New System.Windows.Forms.ComboBox()
        Me.cmbCirc = New System.Windows.Forms.ComboBox()
        Me.rdTanque = New System.Windows.Forms.RadioButton()
        Me.rdLinha = New System.Windows.Forms.RadioButton()
        Me.tcDados = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.butValvFlipIncluir = New System.Windows.Forms.ToolStripButton()
        Me.butValvFlipExcluir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtValvFlip = New System.Windows.Forms.ToolStripTextBox()
        Me.butValvFlipHelp = New System.Windows.Forms.ToolStripButton()
        Me.butValvFlipPesq = New System.Windows.Forms.ToolStripButton()
        Me.gvValvFlip = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmbValvFlipTipo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.gvValvNac = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.butValvNacIncluir = New System.Windows.Forms.ToolStripButton()
        Me.butValvNacExcluir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtValvNac = New System.Windows.Forms.ToolStripTextBox()
        Me.butValvNacPesq = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.butValvAcIncluir = New System.Windows.Forms.ToolStripButton()
        Me.butValvAcExcluir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtValvAc = New System.Windows.Forms.ToolStripTextBox()
        Me.butValvAcPesq = New System.Windows.Forms.ToolStripButton()
        Me.gvValvAc = New System.Windows.Forms.DataGridView()
        Me.colTagValvAc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.gvDependencias = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.butMotIncluir = New System.Windows.Forms.ToolStripButton()
        Me.butMotExcluir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.butMotPesq = New System.Windows.Forms.ToolStripButton()
        Me.gvMotores = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rwMotTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gvSensores = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.butSensorIncluir = New System.Windows.Forms.ToolStripButton()
        Me.butSensorExcluir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.butSensorPesq = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip6 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.butDepIncluir = New System.Windows.Forms.ToolStripButton()
        Me.butDepExcluir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.butDepPesq = New System.Windows.Forms.ToolStripButton()
        Me.butSalvar = New System.Windows.Forms.Button()
        Me.butCancelar = New System.Windows.Forms.Button()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mnuValvulas = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSuspAcionada = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSuspNaoAc = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuSuspFlip = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtVazao = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.tcDados.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        CType(Me.gvValvFlip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvValvNac, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.gvValvAc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.gvDependencias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip4.SuspendLayout()
        CType(Me.gvMotores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvSensores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip5.SuspendLayout()
        Me.ToolStrip6.SuspendLayout()
        Me.mnuValvulas.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtVazao)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtDescr)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbTq3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtRotaId)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbTq1)
        Me.GroupBox1.Controls.Add(Me.cmbTq2)
        Me.GroupBox1.Controls.Add(Me.cmbCirc)
        Me.GroupBox1.Controls.Add(Me.rdTanque)
        Me.GroupBox1.Controls.Add(Me.rdLinha)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(915, 129)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rota"
        '
        'txtDescr
        '
        Me.txtDescr.Location = New System.Drawing.Point(48, 84)
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(843, 20)
        Me.txtDescr.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Descrição"
        '
        'cmbTq3
        '
        Me.cmbTq3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTq3.FormattingEnabled = True
        Me.cmbTq3.Location = New System.Drawing.Point(659, 32)
        Me.cmbTq3.MaxDropDownItems = 6
        Me.cmbTq3.Name = "cmbTq3"
        Me.cmbTq3.Size = New System.Drawing.Size(127, 21)
        Me.cmbTq3.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(168, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Circuito"
        '
        'txtRotaId
        '
        Me.txtRotaId.Enabled = False
        Me.txtRotaId.Location = New System.Drawing.Point(48, 32)
        Me.txtRotaId.Name = "txtRotaId"
        Me.txtRotaId.Size = New System.Drawing.Size(90, 20)
        Me.txtRotaId.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(16, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Id"
        '
        'cmbTq1
        '
        Me.cmbTq1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTq1.FormattingEnabled = True
        Me.cmbTq1.Location = New System.Drawing.Point(393, 32)
        Me.cmbTq1.MaxDropDownItems = 6
        Me.cmbTq1.Name = "cmbTq1"
        Me.cmbTq1.Size = New System.Drawing.Size(127, 21)
        Me.cmbTq1.TabIndex = 5
        '
        'cmbTq2
        '
        Me.cmbTq2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTq2.FormattingEnabled = True
        Me.cmbTq2.Location = New System.Drawing.Point(526, 32)
        Me.cmbTq2.MaxDropDownItems = 6
        Me.cmbTq2.Name = "cmbTq2"
        Me.cmbTq2.Size = New System.Drawing.Size(127, 21)
        Me.cmbTq2.TabIndex = 6
        '
        'cmbCirc
        '
        Me.cmbCirc.FormattingEnabled = True
        Me.cmbCirc.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "CA", "CB", "CC", "CD", "CE"})
        Me.cmbCirc.Location = New System.Drawing.Point(171, 32)
        Me.cmbCirc.Name = "cmbCirc"
        Me.cmbCirc.Size = New System.Drawing.Size(65, 21)
        Me.cmbCirc.TabIndex = 2
        '
        'rdTanque
        '
        Me.rdTanque.AutoSize = True
        Me.rdTanque.Location = New System.Drawing.Point(325, 33)
        Me.rdTanque.Name = "rdTanque"
        Me.rdTanque.Size = New System.Drawing.Size(62, 17)
        Me.rdTanque.TabIndex = 4
        Me.rdTanque.Text = "Tanque"
        Me.rdTanque.UseVisualStyleBackColor = True
        '
        'rdLinha
        '
        Me.rdLinha.AutoSize = True
        Me.rdLinha.Checked = True
        Me.rdLinha.Location = New System.Drawing.Point(268, 33)
        Me.rdLinha.Name = "rdLinha"
        Me.rdLinha.Size = New System.Drawing.Size(51, 17)
        Me.rdLinha.TabIndex = 3
        Me.rdLinha.TabStop = True
        Me.rdLinha.Text = "Linha"
        Me.rdLinha.UseVisualStyleBackColor = True
        '
        'tcDados
        '
        Me.tcDados.Controls.Add(Me.TabPage1)
        Me.tcDados.Controls.Add(Me.TabPage2)
        Me.tcDados.Location = New System.Drawing.Point(12, 147)
        Me.tcDados.Name = "tcDados"
        Me.tcDados.SelectedIndex = 0
        Me.tcDados.Size = New System.Drawing.Size(914, 491)
        Me.tcDados.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ToolStrip3)
        Me.TabPage1.Controls.Add(Me.gvValvFlip)
        Me.TabPage1.Controls.Add(Me.gvValvNac)
        Me.TabPage1.Controls.Add(Me.ToolStrip2)
        Me.TabPage1.Controls.Add(Me.ToolStrip1)
        Me.TabPage1.Controls.Add(Me.gvValvAc)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(906, 465)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Válvulas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToolStrip3.AutoSize = False
        Me.ToolStrip3.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.ToolStripSeparator5, Me.butValvFlipIncluir, Me.butValvFlipExcluir, Me.ToolStripSeparator6, Me.txtValvFlip, Me.butValvFlipHelp, Me.butValvFlipPesq})
        Me.ToolStrip3.Location = New System.Drawing.Point(620, 21)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(260, 31)
        Me.ToolStrip3.TabIndex = 18
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.AutoSize = False
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(70, 28)
        Me.ToolStripLabel3.Text = "Flip"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'butValvFlipIncluir
        '
        Me.butValvFlipIncluir.AutoSize = False
        Me.butValvFlipIncluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butValvFlipIncluir.Image = Global.KbCipRotas.My.Resources.Resources.Bot16x16_Append
        Me.butValvFlipIncluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butValvFlipIncluir.Name = "butValvFlipIncluir"
        Me.butValvFlipIncluir.Size = New System.Drawing.Size(28, 28)
        '
        'butValvFlipExcluir
        '
        Me.butValvFlipExcluir.AutoSize = False
        Me.butValvFlipExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butValvFlipExcluir.Image = Global.KbCipRotas.My.Resources.Resources.Bot16x16_Exclui
        Me.butValvFlipExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butValvFlipExcluir.Name = "butValvFlipExcluir"
        Me.butValvFlipExcluir.Size = New System.Drawing.Size(28, 28)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'txtValvFlip
        '
        Me.txtValvFlip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.txtValvFlip.BackColor = System.Drawing.SystemColors.Window
        Me.txtValvFlip.Enabled = False
        Me.txtValvFlip.Name = "txtValvFlip"
        Me.txtValvFlip.ReadOnly = True
        Me.txtValvFlip.Size = New System.Drawing.Size(35, 31)
        Me.txtValvFlip.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'butValvFlipHelp
        '
        Me.butValvFlipHelp.AutoSize = False
        Me.butValvFlipHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butValvFlipHelp.Image = Global.KbCipRotas.My.Resources.Resources.tracking_v2_small
        Me.butValvFlipHelp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butValvFlipHelp.Name = "butValvFlipHelp"
        Me.butValvFlipHelp.Size = New System.Drawing.Size(28, 28)
        '
        'butValvFlipPesq
        '
        Me.butValvFlipPesq.AutoSize = False
        Me.butValvFlipPesq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butValvFlipPesq.Image = Global.KbCipRotas.My.Resources.Resources.Bot16x16_Ajuda
        Me.butValvFlipPesq.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butValvFlipPesq.Name = "butValvFlipPesq"
        Me.butValvFlipPesq.Size = New System.Drawing.Size(28, 28)
        '
        'gvValvFlip
        '
        Me.gvValvFlip.AllowDrop = True
        Me.gvValvFlip.AllowUserToAddRows = False
        Me.gvValvFlip.AllowUserToDeleteRows = False
        Me.gvValvFlip.ColumnHeadersHeight = 20
        Me.gvValvFlip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gvValvFlip.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.cmbValvFlipTipo})
        Me.gvValvFlip.Location = New System.Drawing.Point(620, 55)
        Me.gvValvFlip.Name = "gvValvFlip"
        Me.gvValvFlip.RowHeadersWidth = 10
        Me.gvValvFlip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvValvFlip.ShowCellErrors = False
        Me.gvValvFlip.ShowCellToolTips = False
        Me.gvValvFlip.ShowRowErrors = False
        Me.gvValvFlip.Size = New System.Drawing.Size(261, 372)
        Me.gvValvFlip.TabIndex = 17
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "colValvFlipTag"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Tag"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 140
        '
        'cmbValvFlipTipo
        '
        Me.cmbValvFlipTipo.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.cmbValvFlipTipo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbValvFlipTipo.HeaderText = "Tipo"
        Me.cmbValvFlipTipo.Name = "cmbValvFlipTipo"
        Me.cmbValvFlipTipo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.cmbValvFlipTipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.cmbValvFlipTipo.Width = 60
        '
        'gvValvNac
        '
        Me.gvValvNac.AllowDrop = True
        Me.gvValvNac.AllowUserToAddRows = False
        Me.gvValvNac.AllowUserToDeleteRows = False
        Me.gvValvNac.ColumnHeadersHeight = 20
        Me.gvValvNac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gvValvNac.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        Me.gvValvNac.Location = New System.Drawing.Point(323, 55)
        Me.gvValvNac.MultiSelect = False
        Me.gvValvNac.Name = "gvValvNac"
        Me.gvValvNac.ReadOnly = True
        Me.gvValvNac.RowHeadersWidth = 10
        Me.gvValvNac.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvValvNac.Size = New System.Drawing.Size(261, 372)
        Me.gvValvNac.TabIndex = 16
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Tag"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 180
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.ToolStripSeparator3, Me.butValvNacIncluir, Me.butValvNacExcluir, Me.ToolStripSeparator4, Me.txtValvNac, Me.butValvNacPesq})
        Me.ToolStrip2.Location = New System.Drawing.Point(323, 21)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(260, 31)
        Me.ToolStrip2.TabIndex = 15
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(78, 28)
        Me.ToolStripLabel2.Text = "Não Acionadas"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'butValvNacIncluir
        '
        Me.butValvNacIncluir.AutoSize = False
        Me.butValvNacIncluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butValvNacIncluir.Image = Global.KbCipRotas.My.Resources.Resources.Bot16x16_Append
        Me.butValvNacIncluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butValvNacIncluir.Name = "butValvNacIncluir"
        Me.butValvNacIncluir.Size = New System.Drawing.Size(28, 28)
        '
        'butValvNacExcluir
        '
        Me.butValvNacExcluir.AutoSize = False
        Me.butValvNacExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butValvNacExcluir.Image = Global.KbCipRotas.My.Resources.Resources.Bot16x16_Exclui
        Me.butValvNacExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butValvNacExcluir.Name = "butValvNacExcluir"
        Me.butValvNacExcluir.Size = New System.Drawing.Size(28, 28)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'txtValvNac
        '
        Me.txtValvNac.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.txtValvNac.BackColor = System.Drawing.SystemColors.Window
        Me.txtValvNac.Enabled = False
        Me.txtValvNac.Name = "txtValvNac"
        Me.txtValvNac.ReadOnly = True
        Me.txtValvNac.Size = New System.Drawing.Size(35, 31)
        Me.txtValvNac.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'butValvNacPesq
        '
        Me.butValvNacPesq.AutoSize = False
        Me.butValvNacPesq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butValvNacPesq.Image = Global.KbCipRotas.My.Resources.Resources.tracking_v2_small
        Me.butValvNacPesq.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butValvNacPesq.Name = "butValvNacPesq"
        Me.butValvNacPesq.Size = New System.Drawing.Size(28, 28)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator1, Me.butValvAcIncluir, Me.butValvAcExcluir, Me.ToolStripSeparator2, Me.txtValvAc, Me.butValvAcPesq})
        Me.ToolStrip1.Location = New System.Drawing.Point(29, 21)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(260, 31)
        Me.ToolStrip1.TabIndex = 14
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(70, 28)
        Me.ToolStripLabel1.Text = "Acionadas"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'butValvAcIncluir
        '
        Me.butValvAcIncluir.AutoSize = False
        Me.butValvAcIncluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butValvAcIncluir.Image = CType(resources.GetObject("butValvAcIncluir.Image"), System.Drawing.Image)
        Me.butValvAcIncluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butValvAcIncluir.Name = "butValvAcIncluir"
        Me.butValvAcIncluir.Size = New System.Drawing.Size(28, 28)
        '
        'butValvAcExcluir
        '
        Me.butValvAcExcluir.AutoSize = False
        Me.butValvAcExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butValvAcExcluir.Image = CType(resources.GetObject("butValvAcExcluir.Image"), System.Drawing.Image)
        Me.butValvAcExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butValvAcExcluir.Name = "butValvAcExcluir"
        Me.butValvAcExcluir.Size = New System.Drawing.Size(28, 28)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'txtValvAc
        '
        Me.txtValvAc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.txtValvAc.BackColor = System.Drawing.SystemColors.Window
        Me.txtValvAc.Enabled = False
        Me.txtValvAc.Name = "txtValvAc"
        Me.txtValvAc.ReadOnly = True
        Me.txtValvAc.Size = New System.Drawing.Size(35, 31)
        Me.txtValvAc.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'butValvAcPesq
        '
        Me.butValvAcPesq.AutoSize = False
        Me.butValvAcPesq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butValvAcPesq.Image = Global.KbCipRotas.My.Resources.Resources.tracking_v2_small
        Me.butValvAcPesq.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butValvAcPesq.Name = "butValvAcPesq"
        Me.butValvAcPesq.Size = New System.Drawing.Size(28, 28)
        '
        'gvValvAc
        '
        Me.gvValvAc.AllowDrop = True
        Me.gvValvAc.AllowUserToAddRows = False
        Me.gvValvAc.AllowUserToDeleteRows = False
        Me.gvValvAc.ColumnHeadersHeight = 20
        Me.gvValvAc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gvValvAc.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTagValvAc})
        Me.gvValvAc.Location = New System.Drawing.Point(28, 55)
        Me.gvValvAc.MultiSelect = False
        Me.gvValvAc.Name = "gvValvAc"
        Me.gvValvAc.ReadOnly = True
        Me.gvValvAc.RowHeadersWidth = 10
        Me.gvValvAc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvValvAc.Size = New System.Drawing.Size(261, 372)
        Me.gvValvAc.TabIndex = 13
        '
        'colTagValvAc
        '
        Me.colTagValvAc.HeaderText = "Tag"
        Me.colTagValvAc.Name = "colTagValvAc"
        Me.colTagValvAc.ReadOnly = True
        Me.colTagValvAc.Width = 180
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gvDependencias)
        Me.TabPage2.Controls.Add(Me.ToolStrip4)
        Me.TabPage2.Controls.Add(Me.gvMotores)
        Me.TabPage2.Controls.Add(Me.gvSensores)
        Me.TabPage2.Controls.Add(Me.ToolStrip5)
        Me.TabPage2.Controls.Add(Me.ToolStrip6)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(906, 465)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Outros"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gvDependencias
        '
        Me.gvDependencias.AllowUserToAddRows = False
        Me.gvDependencias.AllowUserToDeleteRows = False
        Me.gvDependencias.ColumnHeadersHeight = 20
        Me.gvDependencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gvDependencias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        Me.gvDependencias.Location = New System.Drawing.Point(29, 55)
        Me.gvDependencias.Name = "gvDependencias"
        Me.gvDependencias.ReadOnly = True
        Me.gvDependencias.RowHeadersWidth = 10
        Me.gvDependencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvDependencias.Size = New System.Drawing.Size(261, 372)
        Me.gvDependencias.TabIndex = 25
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "colValvFlipTag"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Tag"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 140
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Tipo"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 60
        '
        'ToolStrip4
        '
        Me.ToolStrip4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToolStrip4.AutoSize = False
        Me.ToolStrip4.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel4, Me.ToolStripSeparator7, Me.butMotIncluir, Me.butMotExcluir, Me.ToolStripSeparator12, Me.butMotPesq})
        Me.ToolStrip4.Location = New System.Drawing.Point(622, 21)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(260, 31)
        Me.ToolStrip4.TabIndex = 24
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.AutoSize = False
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(78, 28)
        Me.ToolStripLabel4.Text = "Motores"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'butMotIncluir
        '
        Me.butMotIncluir.AutoSize = False
        Me.butMotIncluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butMotIncluir.Image = Global.KbCipRotas.My.Resources.Resources.Bot16x16_Append
        Me.butMotIncluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butMotIncluir.Name = "butMotIncluir"
        Me.butMotIncluir.Size = New System.Drawing.Size(28, 28)
        '
        'butMotExcluir
        '
        Me.butMotExcluir.AutoSize = False
        Me.butMotExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butMotExcluir.Image = Global.KbCipRotas.My.Resources.Resources.Bot16x16_Exclui
        Me.butMotExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butMotExcluir.Name = "butMotExcluir"
        Me.butMotExcluir.Size = New System.Drawing.Size(28, 28)
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 31)
        '
        'butMotPesq
        '
        Me.butMotPesq.AutoSize = False
        Me.butMotPesq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butMotPesq.Image = Global.KbCipRotas.My.Resources.Resources.tracking_v2_small
        Me.butMotPesq.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butMotPesq.Name = "butMotPesq"
        Me.butMotPesq.Size = New System.Drawing.Size(28, 28)
        '
        'gvMotores
        '
        Me.gvMotores.AllowUserToAddRows = False
        Me.gvMotores.AllowUserToDeleteRows = False
        Me.gvMotores.ColumnHeadersHeight = 20
        Me.gvMotores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gvMotores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn3, Me.rwMotTipo})
        Me.gvMotores.Location = New System.Drawing.Point(622, 55)
        Me.gvMotores.Name = "gvMotores"
        Me.gvMotores.RowHeadersWidth = 10
        Me.gvMotores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvMotores.Size = New System.Drawing.Size(261, 372)
        Me.gvMotores.TabIndex = 23
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "colValvFlipTag"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Tag"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 140
        '
        'rwMotTipo
        '
        Me.rwMotTipo.HeaderText = "Tipo"
        Me.rwMotTipo.Name = "rwMotTipo"
        Me.rwMotTipo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.rwMotTipo.Width = 60
        '
        'gvSensores
        '
        Me.gvSensores.AllowUserToAddRows = False
        Me.gvSensores.AllowUserToDeleteRows = False
        Me.gvSensores.ColumnHeadersHeight = 20
        Me.gvSensores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gvSensores.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn7})
        Me.gvSensores.Location = New System.Drawing.Point(322, 55)
        Me.gvSensores.Name = "gvSensores"
        Me.gvSensores.ReadOnly = True
        Me.gvSensores.RowHeadersWidth = 10
        Me.gvSensores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gvSensores.Size = New System.Drawing.Size(261, 372)
        Me.gvSensores.TabIndex = 22
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Tag"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 180
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToolStrip5.AutoSize = False
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel5, Me.ToolStripSeparator9, Me.butSensorIncluir, Me.butSensorExcluir, Me.ToolStripSeparator10, Me.butSensorPesq})
        Me.ToolStrip5.Location = New System.Drawing.Point(322, 21)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(260, 31)
        Me.ToolStrip5.TabIndex = 21
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.AutoSize = False
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(78, 28)
        Me.ToolStripLabel5.Text = "Sensores"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'butSensorIncluir
        '
        Me.butSensorIncluir.AutoSize = False
        Me.butSensorIncluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butSensorIncluir.Image = Global.KbCipRotas.My.Resources.Resources.Bot16x16_Append
        Me.butSensorIncluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butSensorIncluir.Name = "butSensorIncluir"
        Me.butSensorIncluir.Size = New System.Drawing.Size(28, 28)
        '
        'butSensorExcluir
        '
        Me.butSensorExcluir.AutoSize = False
        Me.butSensorExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butSensorExcluir.Image = Global.KbCipRotas.My.Resources.Resources.Bot16x16_Exclui
        Me.butSensorExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butSensorExcluir.Name = "butSensorExcluir"
        Me.butSensorExcluir.Size = New System.Drawing.Size(28, 28)
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 31)
        '
        'butSensorPesq
        '
        Me.butSensorPesq.AutoSize = False
        Me.butSensorPesq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butSensorPesq.Image = Global.KbCipRotas.My.Resources.Resources.tracking_v2_small
        Me.butSensorPesq.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butSensorPesq.Name = "butSensorPesq"
        Me.butSensorPesq.Size = New System.Drawing.Size(28, 28)
        '
        'ToolStrip6
        '
        Me.ToolStrip6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ToolStrip6.AutoSize = False
        Me.ToolStrip6.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip6.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel6, Me.ToolStripSeparator11, Me.butDepIncluir, Me.butDepExcluir, Me.ToolStripSeparator8, Me.butDepPesq})
        Me.ToolStrip6.Location = New System.Drawing.Point(30, 21)
        Me.ToolStrip6.Name = "ToolStrip6"
        Me.ToolStrip6.Size = New System.Drawing.Size(260, 31)
        Me.ToolStrip6.TabIndex = 20
        Me.ToolStrip6.Text = "ToolStrip6"
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.AutoSize = False
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(78, 28)
        Me.ToolStripLabel6.Text = "Dependências"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 31)
        '
        'butDepIncluir
        '
        Me.butDepIncluir.AutoSize = False
        Me.butDepIncluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butDepIncluir.Image = Global.KbCipRotas.My.Resources.Resources.Bot16x16_Append
        Me.butDepIncluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butDepIncluir.Name = "butDepIncluir"
        Me.butDepIncluir.Size = New System.Drawing.Size(28, 28)
        '
        'butDepExcluir
        '
        Me.butDepExcluir.AutoSize = False
        Me.butDepExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butDepExcluir.Image = Global.KbCipRotas.My.Resources.Resources.Bot16x16_Exclui
        Me.butDepExcluir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butDepExcluir.Name = "butDepExcluir"
        Me.butDepExcluir.Size = New System.Drawing.Size(28, 28)
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'butDepPesq
        '
        Me.butDepPesq.AutoSize = False
        Me.butDepPesq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.butDepPesq.Image = Global.KbCipRotas.My.Resources.Resources.tracking_v2_small
        Me.butDepPesq.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.butDepPesq.Name = "butDepPesq"
        Me.butDepPesq.Size = New System.Drawing.Size(28, 28)
        '
        'butSalvar
        '
        Me.butSalvar.Location = New System.Drawing.Point(317, 651)
        Me.butSalvar.Name = "butSalvar"
        Me.butSalvar.Size = New System.Drawing.Size(137, 33)
        Me.butSalvar.TabIndex = 2
        Me.butSalvar.Text = "Salvar"
        Me.butSalvar.UseVisualStyleBackColor = True
        '
        'butCancelar
        '
        Me.butCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.butCancelar.Location = New System.Drawing.Point(489, 651)
        Me.butCancelar.Name = "butCancelar"
        Me.butCancelar.Size = New System.Drawing.Size(137, 33)
        Me.butCancelar.TabIndex = 3
        Me.butCancelar.Text = "Cancelar"
        Me.butCancelar.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Tipo"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 60
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "colValvFlipTag"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Tag"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 140
        '
        'mnuValvulas
        '
        Me.mnuValvulas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSuspAcionada, Me.MnuSuspNaoAc, Me.MnuSuspFlip})
        Me.mnuValvulas.Name = "mnuValvulas"
        Me.mnuValvulas.Size = New System.Drawing.Size(141, 70)
        '
        'mnuSuspAcionada
        '
        Me.mnuSuspAcionada.Name = "mnuSuspAcionada"
        Me.mnuSuspAcionada.Size = New System.Drawing.Size(140, 22)
        Me.mnuSuspAcionada.Text = "Acionada"
        '
        'MnuSuspNaoAc
        '
        Me.MnuSuspNaoAc.Name = "MnuSuspNaoAc"
        Me.MnuSuspNaoAc.Size = New System.Drawing.Size(140, 22)
        Me.MnuSuspNaoAc.Text = "Não Acionada"
        '
        'MnuSuspFlip
        '
        Me.MnuSuspFlip.Name = "MnuSuspFlip"
        Me.MnuSuspFlip.Size = New System.Drawing.Size(140, 22)
        Me.MnuSuspFlip.Text = "Flip"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(798, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Vazão { m3/h }"
        '
        'txtVazao
        '
        Me.txtVazao.Location = New System.Drawing.Point(801, 33)
        Me.txtVazao.Name = "txtVazao"
        Me.txtVazao.Size = New System.Drawing.Size(90, 20)
        Me.txtVazao.TabIndex = 11
        Me.txtVazao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmRotaEdita
        '
        Me.AcceptButton = Me.butSalvar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.butCancelar
        Me.ClientSize = New System.Drawing.Size(939, 696)
        Me.ControlBox = False
        Me.Controls.Add(Me.butCancelar)
        Me.Controls.Add(Me.butSalvar)
        Me.Controls.Add(Me.tcDados)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmRotaEdita"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edição de Rota"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tcDados.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        CType(Me.gvValvFlip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvValvNac, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.gvValvAc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.gvDependencias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        CType(Me.gvMotores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvSensores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ToolStrip6.ResumeLayout(False)
        Me.ToolStrip6.PerformLayout()
        Me.mnuValvulas.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDescr As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbTq3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRotaId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTq1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTq2 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCirc As System.Windows.Forms.ComboBox
    Friend WithEvents rdTanque As System.Windows.Forms.RadioButton
    Friend WithEvents rdLinha As System.Windows.Forms.RadioButton
    Friend WithEvents tcDados As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents butSalvar As System.Windows.Forms.Button
    Friend WithEvents butCancelar As System.Windows.Forms.Button
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butValvAcIncluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents butValvAcExcluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtValvAc As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents gvValvAc As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butValvFlipIncluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents butValvFlipExcluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtValvFlip As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents gvValvFlip As System.Windows.Forms.DataGridView
    Friend WithEvents gvValvNac As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butValvNacIncluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents butValvNacExcluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtValvNac As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents colTagValvAc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents gvDependencias As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip4 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butMotIncluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents butMotExcluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents gvMotores As System.Windows.Forms.DataGridView
    Friend WithEvents gvSensores As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStrip5 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butSensorIncluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents butSensorExcluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip6 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel6 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butDepIncluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents butDepExcluir As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuValvulas As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSuspAcionada As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSuspNaoAc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSuspFlip As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmbValvFlipTipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents butValvFlipHelp As System.Windows.Forms.ToolStripButton
    Friend WithEvents butValvAcPesq As System.Windows.Forms.ToolStripButton
    Friend WithEvents butValvNacPesq As System.Windows.Forms.ToolStripButton
    Friend WithEvents butValvFlipPesq As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butMotPesq As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butSensorPesq As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents butDepPesq As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rwMotTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtVazao As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
